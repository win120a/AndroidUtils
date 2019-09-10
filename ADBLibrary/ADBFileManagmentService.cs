using AC.AndroidUtils.Shared;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AC.AndroidUtils.ADB
{
    /// <summary>
    /// Provides a series of file managment feature through ADB shell only.
    /// </summary>
    public class ADBFileManagmentService
    {
        private const int MAXIUM_TOLERATE_RESPONSE_LENGTH = 2;
        private AndroidDevice device;
        private ADBInstance adbi;
        private const string PERM_HINT_WORDS = "  [Can't access due to the insufficient permission]";

        public ADBFileManagmentService(AndroidDevice dev, ADBInstance instance)
        {
            adbi = instance;
            device = dev;
        }

        public FSObjectStatus GetFSObjectStatus(string pathToObject, bool inRoot)
        {
            StringBuilder cmdB = new StringBuilder();
            cmdB.AppendLine("cd " + pathToObject);
            cmdB.AppendLine("ls");
            ShellResponse sr = adbi.RunMultiLineCommand(device, cmdB.ToString(), inRoot);

            if (pathToObject.Contains(PERM_HINT_WORDS))
                return FSObjectStatus.PermissionDenied;

            if (sr.stdOut.Contains("Not a directory") && sr.stdOut.Contains("cd: "))
                return FSObjectStatus.File;

            if (sr.stdOut.Contains("Permission denied") && (sr.stdOut.Contains("opendir") || sr.stdOut.Contains("cd: ")))  // Permission Denied.
                return FSObjectStatus.PermissionDenied;

            return FSObjectStatus.Directory;
        }

        public List<string> ListFiles(string path, bool inRoot)
        {
            StringBuilder cmdB = new StringBuilder();
            cmdB.AppendLine("cd " + path);
            cmdB.AppendLine("ls");
            ShellResponse sr = adbi.RunMultiLineCommand(device, cmdB.ToString(), inRoot);

            List<string> fileNames = new List<string>();

            using (StringReader strR = new StringReader(sr.stdOut))
            {
                Encoding enU = Encoding.UTF8;
                Encoding enGB = Encoding.Default;

                string line;
                while ((line = strR.ReadLine()) != null)
                {
                    fileNames.Add(enU.GetString(enGB.GetBytes(line)));   // GBK -> Unicode, may not work in other countries.
                }
            }

            fileNames.Sort();

            return fileNames;
        }

        public void DeleteFile(string path, bool inRoot)
        {
            if (GetFSObjectStatus(path, inRoot) == FSObjectStatus.PermissionDenied)
                throw new IOException("It is a pre-determined Permission Denied Directory.");

            ShellResponse sr;

            if (GetFSObjectStatus(path, inRoot) == FSObjectStatus.File)
            {
                sr = adbi.RunCommand(device, "rm " + path, inRoot);
            }
            else
            {
                sr = adbi.RunCommand(device, "rm -rf " + path, inRoot);
            }

            //if (sr.stdOut.Contains("Permission Denied") || sr.stdOut.Contains("Read-only"))
            if (sr.stdOut.Length > MAXIUM_TOLERATE_RESPONSE_LENGTH)
            {
                throw new IOException(sr.stdOut);
            }
        }

        public void MoveFile(string orig, string dest)
        {

        }

        public void CopyFileTo(string orig, string dest, bool inRoot)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("cp ");
            stringBuilder.Append("\"" + orig + "\"");
            stringBuilder.Append("\"" + dest + "\"");

            adbi.RunCommand(device, stringBuilder.ToString(), inRoot);
        }
    }

    public enum FSObjectStatus
    {
        Directory, File, PermissionDenied
    }
}
