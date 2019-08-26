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
        string path;
        ADBInstance adbi;
        Dictionary<int, AndroidDevice> devicesMap;

        public ADBWindow()
        {
            InitializeComponent();
            devicesMap = new Dictionary<int, AndroidDevice>();
        }

        private void LoadADB()
        {
            path = Settings.Default.adbPath;
            adbi = new ADBInstance(path);
            LoadDevices();
        }

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
                SetButtonsAvaliableOrNot(false);
            }
        }

        private void SetButtonsAvaliableOrNot(bool avail)
        {
            connectNet.Enabled = avail;
            disconnectNet.Enabled = avail;
            reboot.Enabled = avail;
            reboot_recovery.Enabled = avail;
            refresh.Enabled = avail;
        }

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

        private bool IsBoxSelected(ListBox lb) => lb.SelectedIndex != -1;

        private void Reboot_Click(object sender, System.EventArgs e)
        {
            if (!IsBoxSelected(devList))
            {
                WarningDialog("Please select a device.", "Warning");
                return;
            }
            adbi.Reboot(devicesMap[devList.SelectedIndex]);
        }

        private void WarningDialog(string mess, string title) => MessageBox.Show(mess, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void Reboot_recovery_Click(object sender, System.EventArgs e)
        {
            if (!IsBoxSelected(devList))
            {
                WarningDialog("Please select a device.", "Warning");
                return;
            }

            adbi.Reboot(devicesMap[devList.SelectedIndex]);
        }

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

            SetButtonsAvaliableOrNot(true);

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
                SetButtonsAvaliableOrNot(false);
                MessageBox.Show("Uninstall successfully.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsEmpty(string str) => str.Length == 0;
    }
}
