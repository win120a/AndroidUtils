using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AC.AndroidUtils.ADB;
using AC.AndroidUtils.Shared;

namespace AC.AndroidUtils.GUI
{
    static class ADBMain
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ADBInstance adbi = new ADBInstance("D:\\adb");
            adbi.ConnectToRemoteDevice("192.168.1.110", 5555);

            List<AndroidDevice> devices = adbi.GetAndroidDeviceList();
            AndroidDevice device = null;

            foreach (AndroidDevice d in devices)
            {
                MessageBox.Show(d.ToString());
                if (d.Serial.StartsWith("192.168"))
                {
                    device = d;
                }
            }

            adbi.RebootToRecovery(device);

            //Application.Run(new Form1());
        }
    }
}
