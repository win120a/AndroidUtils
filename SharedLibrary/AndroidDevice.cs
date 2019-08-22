using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
