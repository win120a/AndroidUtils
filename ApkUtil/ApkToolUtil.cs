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
