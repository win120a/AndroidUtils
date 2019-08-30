using AC.AndroidUtils.ADB;
using AC.AndroidUtils.Shared;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class ADBShell : Form
    {
        private const string shText = "#! /system/bin/sh";
        private AndroidDevice device;
        private ADBInstance adbi;

        public ADBShell(AndroidDevice device, ADBInstance adbI)
        {
            InitializeComponent();
            this.device = device;
            this.adbi = adbI;
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            string randomName = IOUtil.GenerateRandomFileName("sh");
            string fileName = Environment.GetEnvironmentVariable("Temp") + randomName;

            StringBuilder swB = new StringBuilder();
            StringWriter strW = new StringWriter(swB);
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                strW.WriteLine(shText);
                strW.WriteLine(shellText.Text.Replace("\r\n", "\n"));

                strW.Flush();
                strW.Close();

                swB.Replace("\r\n", "\n");      // CRLF -> LF

                sw.Write(swB.ToString());
            }

            adbi.PushFile(device, fileName, "/sdcard/" + randomName);

            new ResponseWindow(adbi.RunCommand(device, "sh /sdcard/" + randomName, runasroot.Checked)).Show();

            adbi.RunCommand(device, "rm /sdcard/" + randomName, false);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }
    }
}
