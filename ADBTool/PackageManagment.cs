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
using AC.AndroidUtils.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class PackageManagment : Form
    {
        private ADBInstance adbi;
        private AndroidDevice device;
        private Dictionary<int, string> pkgMap;    // <index, package name>
        private Dictionary<int, string> initialMap;   // A cache to save the original "package map".
        private int type;

        private const int THIRDPARTY_APPS = 1;
        private const int SYSTEM_APPS = 2;
        private const int DISABLED_APPS = 3;
        private const int ALL_APPS = 4;

        // 621x540

        private delegate void Callback(string pkgName);
        private delegate bool Predicate(string pkgName);

        public PackageManagment(AndroidDevice device1, ADBInstance instance)
        {
            InitializeComponent();
            adbi = instance;
            device = device1;
            pkgMap = new Dictionary<int, string>();
            initialMap = new Dictionary<int, string>();
            type = ALL_APPS;

            Size s = new Size();
            s.Width = 621;
            s.Height = 540;

            Size = s;

            kw.KeyPress += HandleEnter;
        }

        private void PackagesManagment_Load(object sender, EventArgs e)
        {
            LoadPackagesBySpecifiedType(ALL_APPS);
        }

        private void LoadPackages() => LoadPackagesBySpecifiedType(type);

        private void LoadPackagesBySpecifiedType(int type)
        {
            Text = "Loading...";
            packagesListbox.Items.Clear();
            pkgMap.Clear();
            initialMap.Clear();
            kw.Text = "";

            string response;
            switch (type)
            {
                case THIRDPARTY_APPS:
                    response = adbi.ListThirdPartyPackages(device);
                    break;
                case DISABLED_APPS:
                    response = adbi.ListDisabledPackages(device);
                    break;
                case SYSTEM_APPS:
                    response = adbi.ListSystemPackages(device);
                    break;
                case ALL_APPS:
                    response = adbi.ListPackages(device);
                    break;
                default:
                    throw new FormatException();
            }

            using (StringReader sr = new StringReader(response))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    packagesListbox.Items.Add(line);
                    pkgMap.Add(i, line);
                    initialMap.Add(i, line);
                    i++;
                }
            }

            Text = "Package Managment";
        }

        private void ThirdParty_CheckedChanged(object sender, EventArgs e)
        {
            type = THIRDPARTY_APPS;
            LoadPackages();
        }

        private void System_CheckedChanged(object sender, EventArgs e)
        {
            type = SYSTEM_APPS;
            LoadPackages();
        }

        private void Disabled_CheckedChanged(object sender, EventArgs e)
        {
            type = DISABLED_APPS;
            LoadPackages();
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            type = ALL_APPS;
            LoadPackages();
        }

        private void Uninstall_Click(object sender, EventArgs e) => RunActsWithConfirm((pkgN) => adbi.UninstallApp(device, pkgN));

        private bool RunActs(Callback callback, bool needsConfirm)
        {
            if (packagesListbox.SelectedIndices.Count == 0)
            {
                AlertDialog("Please select at least one package.");
                return false;
            }

            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append("Are you sure? \nPackage Name: \n");
            List<string> pkgL = new List<string>();

            foreach (int i in packagesListbox.SelectedIndices)
            {
                pkgL.Add(pkgMap[i]);
                messageBuilder.AppendLine(pkgMap[i]);
            }

            if (!needsConfirm || ConfirmDialog(messageBuilder.ToString()))
            {
                foreach (string pkgN in pkgL)
                {
                    callback.Invoke(pkgN);
                }

                LoadPackages();

                return true;
            }

            return false;
        }

        private bool RunActsWithConfirm(Callback callback) => RunActs(callback, true);
        private bool ConfirmDialog(string mess) => MessageBox.Show(mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        private void AlertDialog(string mess) => MessageBox.Show(mess, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void Export_Click(object sender, EventArgs e)
        {
            if (RunActs((pkgN) => DoExport(pkgN), false)) MessageBox.Show("Export successfully.", "Hint");
        }

        private void DoExport(string pkgN)
        {
            Text = "Exporting package " + pkgN + "....";
            StringBuilder cmdBuilder = new StringBuilder();
            string path = adbi.GetApkPathByPackageName(device, pkgN);
            string randomAPKName = IOUtil.GenerateRandomFileName("apk");
            string randomTempD = IOUtil.GetRandomDirectoryInTemp();

            Directory.CreateDirectory(randomTempD);

            // Copy out the selected apk file to the sdcard. //
            cmdBuilder.Append("cp ").Append(path).Append(" /sdcard/").Append(randomAPKName);
            ShellResponse shr = adbi.RunCommand(device, cmdBuilder.ToString(), false);

            string tempAPKPath = randomTempD + "\\" + randomAPKName;

            adbi.PullFileFromDevice(device, "/sdcard/" + randomAPKName, tempAPKPath);

            //MessageBox.Show(tempAPKPath);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Android Package|*.apk";
            sfd.Title = "Save the exported package (" + pkgN + ") to: ";

            DialogResult dr = sfd.ShowDialog();

            //MessageBox.Show(dr == DialogResult.OK ? sfd.FileName : "User abort");
            if (dr != DialogResult.OK) return;

            if (File.Exists(sfd.FileName)) File.Delete(sfd.FileName);     // Delete the file if user wants to override.

            File.Copy(tempAPKPath, sfd.FileName);

            File.Delete(tempAPKPath);

            Directory.Delete(randomTempD, true);

            adbi.RunCommand(device, "rm /sdcard/" + randomAPKName, false);
        }

        private void InstallApk_Click(object sender, EventArgs e) => new InstallApplication(device, adbi).ShowDialog();

        private void ClearData_Click(object sender, EventArgs e) => RunActs((pkgN) => adbi.RunCommand(device, "pm clear " + pkgN, false), true);

        private void Refresh_Click(object sender, EventArgs e) => LoadPackages();

        private void RemoveIf(Predicate p)
        {
            IEnumerator<KeyValuePair<int, string>> enumeratorM = pkgMap.GetEnumerator();
            Dictionary<int, string> removeMap = new Dictionary<int, string>();

            while (enumeratorM.MoveNext())
            {
                KeyValuePair<int, string> kvp = enumeratorM.Current;
                if (p.Invoke(kvp.Value))
                {
                    removeMap.Add(kvp.Key, kvp.Value);
                }
            }


            foreach (KeyValuePair<int, string> kvp2 in removeMap)
            {
                pkgMap.Remove(kvp2.Key);
                packagesListbox.Items.Remove(kvp2.Value);
            }

            RefillPkgMap();
        }

        private void RefillPkgMap()
        {
            pkgMap.Clear();

            int i = 0;
            foreach (string s in packagesListbox.Items)
            {
                pkgMap.Add(i, s);
                i++;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            ReloadInitialMap();
            RemoveIf((pkgN) => (!(pkgN.Contains(kw.Text))));
        }

        private void ReloadInitialMap()
        {
            pkgMap.Clear();
            packagesListbox.Items.Clear();

            foreach (KeyValuePair<int, string> kvp in initialMap)
            {
                packagesListbox.Items.Add(kvp.Value);
                pkgMap.Add(kvp.Key, kvp.Value);
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            kw.Text = "";
            ReloadInitialMap();
        }

        private void CpPkgName_Click(object sender, EventArgs e)
        {
            if (packagesListbox.SelectedIndices.Count == 0)
            {
                AlertDialog("Please select at least one package.");
            }
            else if(packagesListbox.SelectedIndices.Count > 1)
            {
                AlertDialog("Only one package can be selected.");
            }
            else
            {
                Clipboard.SetText(pkgMap[packagesListbox.SelectedIndex]);
            }
        }

        private void HandleEnter(object sender, KeyPressEventArgs kpea)
        {
            if (kpea.KeyChar == 13)     // [Enter] key.
            {
                search.PerformClick();
                kpea.Handled = true;       // Terminate the spreading of the event.
            }
        }

        private void Disable_Click(object sender, EventArgs e)
        {
            if(ConfirmDialog("This action requires ROOT PERMISSION, please make sure that your device is rooted.\n\nIs your device rooted?"))
                RunActs((pkgN) => adbi.RunCommand(device, "pm disable " + pkgN, true), true);
        }

        private void Enable_Click(object sender, EventArgs e)
        {
            if(ConfirmDialog("This action requires ROOT PERMISSION, please make sure that your device is rooted.\n\nIs your device rooted?"))
                RunActs((pkgN) => adbi.RunCommand(device, "pm enable " + pkgN, true), false);
        }

        private void Dsall_Click(object sender, EventArgs e)
        {
            packagesListbox.ClearSelected();
        }
    }
}
