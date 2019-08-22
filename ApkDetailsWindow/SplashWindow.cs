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

using System;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class SplashWindow : Form
    {
        private string ApkPath { get; set; }
        public SplashWindow(string apkPath)
        {
            InitializeComponent();
            ApkPath = apkPath;
        }

        private void SplashWindow_Load(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            new ApkWindow(ApkPath).Show();
        }
    }
}
