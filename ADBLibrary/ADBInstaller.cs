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

using AC.AndroidUtils.ADB.Properties;
using AC.AndroidUtils.Shared;
using System.Diagnostics;
using System.IO;

namespace AC.AndroidUtils.ADB
{
    public class ADBInstaller
    {
        public static void InstallADBTo(string path)
        {
            KillADBProcess();
            IOUtil.WriteBytesToFile(Resources.adbE, path + "\\adbE.exe");

            ProcessStartInfo psi = new ProcessStartInfo(path + "\\adbE.exe");
            psi.WorkingDirectory = path;

            Process p = new Process();
            p.StartInfo = psi;

            p.Start();
            p.WaitForExit();
        }

        public static bool CheckADB(string path)
        {
            bool v1 = Directory.Exists(path);
            bool v2 = File.Exists(path + "\\adb.exe");
            bool v3 = File.Exists(path + "\\AdbWinApi.dll");
            bool v4 = File.Exists(path + "\\AdbWinUsbApi.dll");

            return v1 & v2 & v3 & v4;
        }

        public static void KillADBProcess()
        {
            Process[] pg = Process.GetProcessesByName("adb");

            foreach (Process p in pg)
            {
                p.Kill();
                p.WaitForExit();
                p.Close();
                p.Dispose();
            }
        }

        public static void UninstallADB(string path)
        {
            KillADBProcess();

            File.Delete(path + "\\adb.exe");
            File.Delete(path + "\\AdbWinApi.dll");
            File.Delete(path + "\\AdbWinUsbApi.dll");
        }
    }
}