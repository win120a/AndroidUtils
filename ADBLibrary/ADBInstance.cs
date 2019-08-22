﻿/*
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

using AC.AndroidUtils.Shared;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AC.AndroidUtils.ADB
{
    public class ADBInstance
    {
        public ADBInstance(string adbPathL)
        {
            ADBPath = adbPathL;
        }

        private string adbPath;

        public string ADBPath
        {
            get => adbPath;

            private set
            {
                if (!Directory.Exists(value) || !File.Exists(value + "\\adb.exe"))
                {
                    throw new FileNotFoundException();
                }

                adbPath = value;
            }
        }

        public void StartADBServer()
        {
            InvokeADBCommand("start-server", true);
        }

        public void InstallApp(AndroidDevice device, string apkPath)
        {
            InvokeADBCommand("install \"" + apkPath + "\"", true);
        }

        public void InstallApp(AndroidDevice device, AndroidApplication aa)
        {
            InstallApp(device, aa.ApkPath);
        }

        public void Reboot(AndroidDevice device)
        {
            InvokeADBCommand(device, "reboot", false);
        }

        public void RebootToRecovery(AndroidDevice device)
        {
            InvokeADBCommand(device, "reboot recovery", false);
        }

        public void ConnectToRemoteDevice(string address, uint port)
        {
            InvokeADBCommand("connect " + address + ":" + port, false);
        }

        private Process InvokeADBCommand(string arg, bool waitToFinish)
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = ADBPath + "\\adb.exe";
            psi.Arguments = arg;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();

            if (waitToFinish)
            {
                p.WaitForExit();
                p.Close();
                return null;
            }

            return p;
        }

        private Process InvokeADBCommand(AndroidDevice device, string args, bool waitToFinish)
        {
            return InvokeADBCommand("-s \"" + device.Serial + "\" " + args, waitToFinish);
        }

        private string ListDevices()
        {
            StartADBServer();

            Process p = InvokeADBCommand("devices", false);
            StringBuilder b = new StringBuilder();

            using (StreamReader sr = p.StandardOutput)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!(line.StartsWith("List of devices attached")) && line != "")
                    {
                        b.AppendLine(line);
                    }
                }
            }

            b.Replace("\t", ",");

            return b.ToString();
        }

        public List<AndroidDevice> GetAndroidDeviceList()
        {
            string adbResponse = ListDevices();
            List<AndroidDevice> ad = new List<AndroidDevice>();
            
            using (StringReader sr = new StringReader(adbResponse))
            {
                string line;
                while((line = sr.ReadLine()) != null){
                    ad.Add(AndroidDevice.GetAndroidDeviceObjectThroughADBResopnse(line));
                }
            }

            return ad;
        }

        public void KillServer()
        {
            InvokeADBCommand("kill-server", true);
        }

        public void WaitForDevice()
        {
            InvokeADBCommand("wait-for-device", true);
        }

        /*
         * Use ADB Path to identify the object.
         */
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (ReferenceEquals(obj, this)) return true;

            if (ReferenceEquals(obj.GetType(), GetType()))
            {
                ADBInstance other = (ADBInstance)obj;

                return other.ADBPath.Equals(ADBPath);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ADBPath.GetHashCode();
        }
    }
}