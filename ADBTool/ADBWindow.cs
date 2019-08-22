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

using System.Collections.Generic;
using System.Windows.Forms;
using AC.AndroidUtils.ADB;
using AC.AndroidUtils.Shared;

namespace AC.AndroidUtils.GUI
{
    public partial class ADBWindow : Form
    {
        string path = "D:\\adb";
        ADBInstance adbi;
        Dictionary<int, AndroidDevice> devicesMap;

        public ADBWindow()
        {
            InitializeComponent();
            devicesMap = new Dictionary<int, AndroidDevice>();
        }

        private void ADBWindow_Load(object sender, System.EventArgs e)
        {
            adbi = new ADBInstance(path);
            LoadDevices();
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
            adbi.ConnectToRemoteDevice(netADB_ip.Text, uint.Parse(netADB_port.Text));
            LoadDevices();
        }

        private void DisconnectNet_Click(object sender, System.EventArgs e)
        {
            adbi.DisconnectRemoteDevice(netADB_ip.Text, uint.Parse(netADB_port.Text));
            LoadDevices();
        }

        private void Reboot_Click(object sender, System.EventArgs e)
        {
            adbi.Reboot(devicesMap[devList.SelectedIndex]);
        }

        private void Reboot_recovery_Click(object sender, System.EventArgs e)
        {
            adbi.Reboot(devicesMap[devList.SelectedIndex]);
        }
    }
}
