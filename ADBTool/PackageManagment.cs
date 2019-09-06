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
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class PackageManagment : Form
    {
        private ADBInstance adbi;
        private AndroidDevice device;
        private Dictionary<int, string> pkgMap;
        private int type;

        private const int THIRDPARTY_APPS = 1;
        private const int SYSTEM_APPS = 2;
        private const int DISABLED_APPS = 3;
        private const int ALL_APPS = 4;

        private delegate void Callback(string pkgName);

        public PackageManagment(AndroidDevice device1, ADBInstance instance)
        {
            InitializeComponent();
            adbi = instance;
            device = device1;
            pkgMap = new Dictionary<int, string>();
            type = ALL_APPS;
        }

        private void PackagesManagment_Load(object sender, EventArgs e)
        {
            LoadPackagesBySpecifiedType(ALL_APPS);
        }

        private void LoadPackages() => LoadPackagesBySpecifiedType(type);

        private void LoadPackagesBySpecifiedType(int type)
        {
            packagesListbox.Items.Clear();
            pkgMap.Clear();

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
                    i++;
                }
            }
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

        private void RunActs(Callback callback, bool needsConfirm)
        {
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
            }

            LoadPackages();
        }

        private void RunActsWithConfirm(Callback callback) => RunActs(callback, true);

        private bool ConfirmDialog(string mess) => MessageBox.Show(mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private void Export_Click(object sender, EventArgs e)
        {
            MessageBox.Show(adbi.GetApkPathByPackageName(device, pkgMap[packagesListbox.SelectedIndex]));
        }

        private void InstallApk_Click(object sender, EventArgs e)
        {
            new InstallApplication(device, adbi).ShowDialog();
        }

        private void Hide_Click(object sender, EventArgs e) => RunActsWithConfirm((pkgN) => adbi.RunCommand(device, "pm hide " + pkgN, false));
    }
}
