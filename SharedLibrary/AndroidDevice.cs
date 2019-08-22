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

namespace AC.AndroidUtils.Shared
{
    public class AndroidDevice
    {
        public string Serial
        {
            get; private set;
        }

        public DeviceStatus Status
        {
            get; set;
        }

        private AndroidDevice(string serial, DeviceStatus status)
        {
            Serial = serial;
            Status = status;
        }

        public static AndroidDevice GetAndroidDeviceObjectThroughADBResopnse(string adbResponse)
        {
            string[] r = adbResponse.Split(',');
            DeviceStatus s;

            switch (r[1])
            {
                case "device":
                    s = DeviceStatus.Device;
                    break;
                case "bootloader":
                    s = DeviceStatus.Bootloader;
                    break;
                case "sideload":
                    s = DeviceStatus.Sideload;
                    break;
                case "unauthorized":
                    s = DeviceStatus.Unauthorized;
                    break;
                case "offline":
                    s = DeviceStatus.Offline;
                    break;
                case "recovery":
                    s = DeviceStatus.Recovery;
                    break;
                default:
                    throw new FormatException();
            }
            return new AndroidDevice(r[0], s);
        }

        public override string ToString()
        {
            return "Serial: " + Serial + "\nStatus: " + Status.ToString();
        }
    }
}
