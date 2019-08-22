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
using System.Diagnostics;
using System.IO;
using System.Text;
using AC.AndroidUtils.Shared;

namespace AC.AndroidUtils.ApkUtil
{
    internal class ApkToolUtil
    {
        private ApkToolUtil() { }

        private static void WriteApkTool()
        {
            IOUtil.WriteBytesToFile(Properties.Resources.apktool, Environment.GetEnvironmentVariable("Temp") + "\\apkt.jar");
        }

        public static void DecompileApk(string apkPath, string output, bool withSmali, bool forceOverride)
        {
            WriteApkTool();

            string systemTemp = Environment.GetEnvironmentVariable("Temp");

            ProcessStartInfo psi = new ProcessStartInfo();
#if DEBUG
            psi.FileName = "java";
#else
            psi.FileName = "javaw";
#endif
            psi.Arguments = "-jar \"" + systemTemp + "\\apkt.jar\"";
            psi.Arguments += withSmali ? (" " + "d -o " + "\"" + output + "\" ") : 
                                (" " + "d -s -o " + "\"" + output + "\" ");

            psi.Arguments += forceOverride ? "-f" : "";

            psi.Arguments += " \"" + apkPath + "\"";

            psi.UseShellExecute = false;

            Process p = new Process();
            p.StartInfo = psi;
            string m = psi.FileName + " " + psi.Arguments;
            p.Start();

            p.WaitForExit();
        }
    }
}
