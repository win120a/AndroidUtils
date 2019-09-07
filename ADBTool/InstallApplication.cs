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

using AC.AndroidUtils.ApkUtil;
using AC.AndroidUtils.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AC.AndroidUtils.ADB;
using System.IO;

namespace AC.AndroidUtils.GUI
{
    public partial class InstallApplication : Form
    {
        private AndroidDevice device;
        private ADBInstance adbInstance;
        public InstallApplication(AndroidDevice device1, ADBInstance adbi)
        {
            InitializeComponent();
            device = device1;
            apkDetails.Enabled = false;
            install.Enabled = false;
            adbInstance = adbi;
            apps.DragDrop += HandleDragAndDrop;
        }

        private void HandleDragAndDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.ToString());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Android Package|*.apk";
            ofd.Multiselect = true;
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                foreach (string s in ofd.FileNames)
                {
                    if (!apps.Items.Contains(s)) apps.Items.Add(s);
                }
            }

            install.Enabled = apps.Items.Count > 0;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            HashSet<string> selected = new HashSet<string>();

            foreach (int i in apps.SelectedIndices)
            {
                selected.Add((string)apps.Items[i]);
            }

            foreach (string i in selected)
            {
                apps.Items.Remove(i);
            }

            install.Enabled = apps.Items.Count > 0;
        }

        private void ApkDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This action will take a while, please wait patiently.", "Hint");

            string apkP = (string) apps.Items[apps.SelectedIndex];

            AndroidApplication app = AndroidAppParser.ReadApk(apkP);

            new ApkWindow(app, false).Show();
        }

        private void Apps_SelectedIndexChanged(object sender, EventArgs e)
        {
            apkDetails.Enabled = apps.SelectedIndices.Count == 1;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void Install_Click(object sender, EventArgs e)
        {
            int i = 1;
            int total = apps.Items.Count;

            foreach(string app in apps.Items)
            {
                string fileName = Path.GetFileNameWithoutExtension(app);
                Text = "[" + i + "/" + total + "] Installing " + fileName + "...";
                adbInstance.InstallApp(device, app);
                i++;
            }

            MessageBox.Show("Process finished.", "Hint");
            Text = "Install Android Application";
        }
    }
}
