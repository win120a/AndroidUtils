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
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class ApkWindow : Form
    {
        public string ApkPath { get; private set; }
        public AndroidApplication ApplicationObject
        {
            get; private set;
        }

        public ApkWindow(string apkPath)
        {
            InitializeComponent();
            FormClosed += HandleExit;
            ApkPath = apkPath;
        }

        public ApkWindow(AndroidApplication andApp)
        {
            ApkPath = andApp.ApkPath;
            ApplicationObject = andApp;
            InitializeComponent();
        }

        private void HandleExit(object sender, FormClosedEventArgs e) => ExitApp();

        private void ExitApp() => Application.Exit();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ApplicationObject == null)
            {
                try
                {
                    ApplicationObject = AndroidAppParser.ReadApk(ApkPath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Decompile error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

            apkPath.Text = ApplicationObject.ApkPath;
            pkgName.Text = ApplicationObject.PackageName;
            appName.Text = ApplicationObject.AppName;

            if (ApplicationObject.Logo != null)
            {
                appLogo.Image = ApplicationObject.Logo;
            }

            if(APKMain.sw != null) APKMain.sw.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            ExitApp();
        }
    }
}
