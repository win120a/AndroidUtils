/*
    This is a part of AndroidUtils.

    Copyright (C) 2011-2019 Andy Cheung

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using AC.AndroidUtils.ADB;
using AC.AndroidUtils.GUI.Properties;
using AC.AndroidUtils.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class ADBWindow : Form
    {
        private delegate void ConfirmCallBack();

        private string path;
        private ADBInstance adbi;
        private Dictionary<int, AndroidDevice> devicesMap;

        public ADBWindow()
        {
            InitializeComponent();
            devicesMap = new Dictionary<int, AndroidDevice>();
#if DEBUG
            // Do nothing.
#else
            test.Visible = false;
#endif
        }

        private bool IsDeviceStatusNormal(AndroidDevice dev) => !((dev.Status == DeviceStatus.Offline) || (dev.Status == DeviceStatus.Unauthorized));

        #region UI Methods (except event handlers).
        private bool ConfirmDialog(string mess, string title) => (MessageBox.Show(mess, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes;
        private bool ConfirmDialog(string mess) => ConfirmDialog(mess, "Confirm");
        private void WarningDialog(string mess, string title) => MessageBox.Show(mess, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void WarningDialog(string mess) => WarningDialog(mess, "Warning");

        private void ConfirmDeviceSelection(ConfirmCallBack callback, bool askSure)
        {
            if (!IsBoxSelected(devList))
            {
                WarningDialog("Please select a device.");
            }
            else if (!IsDeviceStatusNormal(devicesMap[devList.SelectedIndex]))
            {
                WarningDialog("Device status isn't normal. Please refresh to check the newest status.");
            }
            else
            {
                if (askSure)
                {
                    if (!ConfirmDialog("Are you sure?"))
                    {
                        return;
                    }
                }
                callback.Invoke();
                LoadDevices();
            }
        }

        private void ConfirmDeviceSelection(ConfirmCallBack callback) => ConfirmDeviceSelection(callback, true);

        private void SetButtonsAvailableOrNot(bool avail)
        {
            connectNet.Enabled = avail;
            disconnectNet.Enabled = avail;
            reboot.Enabled = avail;
            reboot_recovery.Enabled = avail;
            refresh.Enabled = avail;
            devStatus.Enabled = avail;
            pkgMgmt.Enabled = avail;
            shell.Enabled = avail;
        }

        private bool IsEmpty(string str) => str.Length == 0;
        private bool IsBoxSelected(ListBox lb) => lb.SelectedIndex != -1;

        #endregion

        #region Methods to load compoments.
        private void LoadDevices()
        {
            devList.Items.Clear();
            devicesMap.Clear();

            List<AndroidDevice> list = adbi.GetAndroidDeviceList();

            int i = 0;
            foreach (AndroidDevice d in list)
            {
                devList.Items.Add(d.Serial);
                devicesMap.Add(i++, d);
            }
        }

        private void LoadADB()
        {
            path = Settings.Default.adbPath;
            adbi = new ADBInstance(path);
            LoadDevices();
        }
        #endregion

        #region Event Handlers
        private void ADBWindow_Load(object sender, System.EventArgs e)
        {
            if (Settings.Default.adbPath != "" & ADBInstaller.CheckADB(Settings.Default.adbPath))
            {
                LoadADB();
                adbPath.Text = Settings.Default.adbPath;
            }
            else
            {
                MessageBox.Show("Please load ADB in this window.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetButtonsAvailableOrNot(false);
            }
        }

        private void Refresh_Click(object sender, System.EventArgs e) => LoadDevices();

        private void ConnectNet_Click(object sender, System.EventArgs e)
        {
            if (IsEmpty(netADB_ip.Text) || IsEmpty(netADB_port.Text))
            {
                MessageBox.Show("Please fill in all blanks.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            adbi.ConnectToRemoteDevice(netADB_ip.Text, uint.Parse(netADB_port.Text));
            LoadDevices();
        }

        private void DisconnectNet_Click(object sender, System.EventArgs e)
        {
            if (IsEmpty(netADB_ip.Text) || IsEmpty(netADB_port.Text))
            {
                WarningDialog("Please fill in all blanks.", "Hint");
                return;
            }

            adbi.DisconnectRemoteDevice(netADB_ip.Text, uint.Parse(netADB_port.Text));
            LoadDevices();
        }

        private void Reboot_Click(object sender, System.EventArgs e) => ConfirmDeviceSelection(() => adbi.Reboot(devicesMap[devList.SelectedIndex]));
        private void Reboot_recovery_Click(object sender, System.EventArgs e) => ConfirmDeviceSelection(() => adbi.RebootToRecovery(devicesMap[devList.SelectedIndex]));

        private void BrowseADBPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                adbPath.Text = fbd.SelectedPath;
            }
        }

        private void Install_Click(object sender, System.EventArgs e)
        {
            if (!IsEmpty(adbPath.Text))
            {
                WarningDialog("Please select a directory.", "Hint");
                return;
            }

            ADBInstaller.InstallADBTo(adbPath.Text);
            MessageBox.Show("Install successfully.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Load_Click_1(object sender, System.EventArgs e)
        {
            if (!ADBInstaller.CheckADB(adbPath.Text))
            {
                MessageBox.Show("This folder doesn't contain ADB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Settings.Default.adbPath = adbPath.Text;
            path = adbPath.Text;
            Settings.Default.Save();

            LoadADB();
            LoadDevices();

            SetButtonsAvailableOrNot(true);

            MessageBox.Show("Load successfully.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Uninstall_Click(object sender, System.EventArgs e)
        {
            if (!ADBInstaller.CheckADB(adbPath.Text))
            {
                MessageBox.Show("This folder doesn't contain ADB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("ADB will be uninstalled, and this app can NOT be used!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ADBInstaller.UninstallADB(adbPath.Text);
                SetButtonsAvailableOrNot(false);
                MessageBox.Show("Uninstall successfully.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DevStatus_Click(object sender, System.EventArgs e)
        {
            if (!IsBoxSelected(devList))
            {
                WarningDialog("Please select a device.", "Warning");
                return;
            }

            MessageBox.Show(devicesMap[devList.SelectedIndex].ToString());
        }

        private void Shell_Click(object sender, System.EventArgs e)
        {
            if (!IsBoxSelected(devList))
            {
                WarningDialog("Please select a device.", "Warning");
                return;
            }

            new ADBShell(devicesMap[devList.SelectedIndex], adbi).Show();
        }

        private void KillADB_Click(object sender, System.EventArgs e)
        {
            adbi.KillServer();
            SetButtonsAvailableOrNot(false);
        }

        private void StartADB_Click(object sender, System.EventArgs e)
        {
            adbi.StartADBServer();
            SetButtonsAvailableOrNot(true);
        }

        private void Test_Click(object sender, System.EventArgs e) => ConfirmDeviceSelection(() => new FileManager(devicesMap[devList.SelectedIndex], adbi).ShowDialog(), false);

        private void PkgMgmt_Click(object sender, System.EventArgs e) => ConfirmDeviceSelection(() => new PackageManagment(devicesMap[devList.SelectedIndex], adbi).ShowDialog(), false);

        private void DevList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (devList.SelectedIndex == -1) return;

            if (devicesMap[devList.SelectedIndex].Serial.Contains(":"))
            {
                string[] addrA = devicesMap[devList.SelectedIndex].Serial.Split(':');

                netADB_ip.Text = addrA[0];
                netADB_port.Text = addrA[1];
            }
        }

        private void DisconnectAll_Click(object sender, System.EventArgs e)
        {
            Text = "Disconnecting...";
            adbi.KillServer();
            adbi.StartADBServer();
            LoadDevices();
            Text = "ADB Utility";
        }

        private void HandlePortFieldKeyPress(object sender, KeyPressEventArgs kpea)
        {
            /*
             * 48 = '0'   57 = '9'   8 = '<bksp>'
             */

            if ((kpea.KeyChar < 48 || kpea.KeyChar > 57) & kpea.KeyChar != 8)
            {
                kpea.Handled = true;     // Get rid of the invaild character.
            }
        }

        private void FileManager_Click(object sender, System.EventArgs e) => new FileManager(devicesMap[devList.SelectedIndex], adbi).ShowDialog();
        #endregion
    }
}