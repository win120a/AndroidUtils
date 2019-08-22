using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AC.AndroidUtils.ADB.Properties;
using System.Diagnostics;
using AC.AndroidUtils.Shared;

namespace AC.AndroidUtils.ADB
{
    public class ADBInstaller
    {
        public static void InstallADBTo(string path)
        {
            IOUtil.WriteBytesToFile(Resources.adbE, path + "\\adbE.exe");
            Process.Start(path + "\\adbE.exe").WaitForExit();
        }

        public static void KillADBServer()
        {

        }
    }
}