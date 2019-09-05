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

using AC.AndroidUtils.Shared;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AC.AndroidUtils.ADB
{
    /// <summary>
    /// Represents an ADB instance.
    /// </summary>
    public class ADBInstance
    {
        public ADBInstance(string adbPathL)
        {
            ADBPath = adbPathL;
        }

        private string adbPath;

        /// <summary>
        /// A property that represents the ADB path.
        /// </summary>
        public string ADBPath
        {
            get => adbPath;

            private set
            {
                if (!ADBInstaller.CheckADB(value))
                {
                    throw new FileNotFoundException();
                }

                adbPath = value;
            }
        }

        /// <summary>
        /// Start the ADB Server (Daemon).
        /// </summary>
        public void StartADBServer()
        {
            InvokeADBCommand("start-server", true);
        }

        /// <summary>
        /// Install an Android app.
        /// </summary>
        /// <param name="device">The Android device.</param>
        /// <param name="apkPath">Path to the apk.</param>
        public void InstallApp(AndroidDevice device, string apkPath)
        {
            InvokeADBCommand(device, "install \"" + apkPath + "\"", true);
        }

        public void InstallApp(AndroidDevice device, AndroidApplication aa)
        {
            InstallApp(device, aa.ApkPath);
        }

        /// <summary>
        /// Reboot the device.
        /// </summary>
        /// <param name="device">The device.</param>
        public void Reboot(AndroidDevice device)
        {
            InvokeADBCommand(device, "reboot", false);
        }

        /// <summary>
        /// Reboot the device and enter into the recovery.
        /// </summary>
        /// <param name="device">The device.</param>
        public void RebootToRecovery(AndroidDevice device)
        {
            InvokeADBCommand(device, "reboot recovery", false);
        }

        /// <summary>
        /// Connect to a remote device.
        /// </summary>
        /// <param name="address">The devices' address</param>
        /// <param name="port">The port to the adbd.</param>
        public void ConnectToRemoteDevice(string address, uint port)
        {
            InvokeADBCommand("connect " + address + ":" + port, true);
        }

        /// <summary>
        /// Disconnect the remote device.
        /// </summary>
        /// <param name="address">The devices' address</param>
        /// <param name="port">The port to the adbd.</param>
        public void DisconnectRemoteDevice(string address, uint port)
        {
            InvokeADBCommand("disconnect " + address + ":" + port, true);
        }

        /// <summary>
        /// Core method to invoke ADB with specified args, and return the Process object.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="waitToFinish">The thread will wait for the process to finish if it is true.</param>
        /// <returns>The Process object associated with the ADB.</returns>
        private Process InvokeADBCommand(string arg, bool waitToFinish)
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = ADBPath + "\\adb.exe";
            psi.Arguments = arg;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();

            if (waitToFinish)
            {
                p.WaitForExit();
            }

            return p;
        }

        /// <summary>
        /// Core method to invoke ADB Command with a specified Android Device.
        /// </summary>
        /// <param name="device">The AndroidDevice object, to determine the device.</param>
        /// <param name="args">The argument.</param>
        /// <param name="waitToFinish">The thread will wait for the process to finish if it is true.</param>
        /// <returns>The Process object associated with the ADB.</returns>
        private Process InvokeADBCommand(AndroidDevice device, string args, bool waitToFinish)
        {
            return InvokeADBCommand("-s \"" + device.Serial + "\" " + args, waitToFinish);
        }

        /// <summary>
        /// List devices that are attacted on ADB. This method intends to return the response only.
        /// </summary>
        /// <returns>The response of "adb devices"</returns>
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

        /// <summary>
        /// List devices that are attached on ADB. This method returns a list of AndroidDevice Objects.
        /// </summary>
        /// <returns>A list of AndroidDevice objects.</returns>
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

        /// <summary>
        /// Kill the daemon of the adb.
        /// </summary>
        public void KillServer()
        {
            InvokeADBCommand("kill-server", true);
        }

        /// <summary>
        /// Make the thread to wait for an device.
        /// </summary>
        public void WaitForDevice()
        {
            InvokeADBCommand("wait-for-device", true);
        }

        /// <summary>
        /// Push a file to the Android device.
        /// </summary>
        /// <param name="device">The android device.</param>
        /// <param name="localPath">The path to the file that will send. (Computer)</param>
        /// <param name="remotePath">The path to the file that will receive. (Android device)</param>
        public void PushFile(AndroidDevice device, string localPath, string remotePath)
        {
            StringBuilder sBuilder = new StringBuilder();

            sBuilder.Append("push \"");
            sBuilder.Append(localPath);
            sBuilder.Append("\" ");
            sBuilder.Append("\"");
            sBuilder.Append(remotePath);
            sBuilder.Append("\"");

            InvokeADBCommand(device, sBuilder.ToString(), true);
        }

        /// <summary>
        /// Pull a file from the Android Device.
        /// </summary>
        /// <param name="device">The Android device.</param>
        /// <param name="localPath">The path to the file that will receive. (Computer)</param>
        /// <param name="remotePath">The path to the file that will send. (Android device)</param>
        public void PullFileFromDevice(AndroidDevice device, string remotePath, string localPath)
        {
            StringBuilder sBuilder = new StringBuilder();

            sBuilder.Append("pull \"");
            sBuilder.Append(remotePath);
            sBuilder.Append("\" ");
            sBuilder.Append("\"");
            sBuilder.Append(localPath);
            sBuilder.Append("\"");

            InvokeADBCommand(device, sBuilder.ToString(), true);
        }

        /// <summary>
        /// Run a shell command on an Android device.
        /// </summary>
        /// <param name="device">The android device.</param>
        /// <param name="command">The command.</param>
        /// <param name="runAsRoot">The command will run as root if it is true.</param>
        /// <returns>The shell response.</returns>
        public ShellResponse RunCommand(AndroidDevice device, string command, bool runAsRoot)
        {
            StringBuilder retS = new StringBuilder();
            StringBuilder errS = new StringBuilder();
            string argH = runAsRoot ? "shell su -c " : "shell ";
            string arg = argH + command;
            Process adbP = InvokeADBCommand(device, arg, true);

            using(StreamReader sr = adbP.StandardOutput)
            {
                while (!sr.EndOfStream)
                {
                    retS.AppendLine(sr.ReadLine());
                }
            }

            using (StreamReader sr = adbP.StandardError)
            {
                while (!sr.EndOfStream)
                {
                    errS.AppendLine(sr.ReadLine());
                }
            }

            ShellResponse shr = new ShellResponse();
            shr.stdOut = retS.ToString();
            shr.stdError = errS.ToString();

            return shr;
        }

        public string ListPackages(AndroidDevice device) => ListPackagesBySpecifiedType(device, "");
        public string ListThirdPartyPackages(AndroidDevice device) => ListPackagesBySpecifiedType(device, "-3");
        public string ListDisabledPackages(AndroidDevice device) => ListPackagesBySpecifiedType(device, "-d");
        public string ListSystemPackages(AndroidDevice device) => ListPackagesBySpecifiedType(device, "-s");

        private string ListPackagesBySpecifiedType(AndroidDevice device, string additionalArgs)
        {
            /*
             * Due to the compability issues, it has to read standard output.
             */

            Process p = InvokeADBCommand(device, "shell pm list packages " + additionalArgs, true);
            StringBuilder sBuilder = new StringBuilder();

            using (StreamReader sr = p.StandardOutput)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sBuilder.AppendLine(line);
                }
            }

            sBuilder.Replace("\r\n\r\n", "\r\n");
            sBuilder.Replace("package:", "");
            string s = sBuilder.ToString();
            return s;
        }

        public void UninstallApp(AndroidDevice device, string pkgName)
        {
            RunCommand(device, "pm uninstall " + pkgName, false);
        }

        public string GetApkPathByPackageName(AndroidDevice device, string pkgName)
        {
            string res = RunCommand(device, "pm path " + pkgName, false).stdOut;
            return res.Replace("package:", "").Replace("\r\n\r\n", "");
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
                ADBInstance other = (ADBInstance) obj;

                return other.ADBPath.Equals(ADBPath);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ADBPath.GetHashCode();
        }

        /*
         * Definition of C# Operator.
         */
        public static bool operator ==(ADBInstance i1, ADBInstance i2)
        {
            return i1.Equals(i2);
        }

        public static bool operator !=(ADBInstance i1, ADBInstance i2)
        {
            return !(i1.Equals(i2));
        }
    }
}
