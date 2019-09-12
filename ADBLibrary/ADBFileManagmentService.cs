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
using AC.AndroidUtils.ADB.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AC.AndroidUtils.ADB
{
    /// <summary>
    /// Provides a series of file managment feature through ADB shell only.
    /// </summary>
    public class ADBFileManagmentService : IFileManagmentService
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

            if (pathToObject.Contains(PERM_HINT_WORDS))
                return FSObjectStatus.PermissionDenied;

            ShellResponse sr = adbi.RunMultiLineCommand(device, cmdB.ToString(), inRoot);

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
            cmdB.AppendLine("ls -a");
            ShellResponse sr = adbi.RunMultiLineCommand(device, cmdB.ToString(), inRoot);

            List<string> fileNames = new List<string>();
            List<string> folders = new List<string>();
            List<string> result = new List<string>();

            using (StringReader strR = new StringReader(sr.stdOut))
            {
                Encoding enU = Encoding.UTF8;
                Encoding enGB = Encoding.Default;

                string line;
                while ((line = strR.ReadLine()) != null)
                {
                    if (line.Contains(".") && line.ToCharArray()[0] != '.')
                    {
                        fileNames.Add(enU.GetString(enGB.GetBytes(line)));
                    }
                    else
                    {
                        folders.Add(enU.GetString(enGB.GetBytes(line)));   // GBK -> UTF-8, may not work in other countries.
                    }
                }
            }

            fileNames.Sort();
            folders.Sort();

            foreach(string s in folders)
            {
                result.Add(s);
            }

            foreach(string s in fileNames)
            {
                result.Add(s);
            }

            return result;
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

        public void MoveFile(string orig, string dest, bool inRoot)
        {
            CopyFile(orig, dest, inRoot);
            DeleteFile(orig, inRoot);
        }

        public void CopyFile(string orig, string dest, bool inRoot)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("cp ");
            stringBuilder.Append("\"" + orig + "\"");
            stringBuilder.Append("\"" + dest + "\"");

            adbi.RunCommand(device, stringBuilder.ToString(), inRoot);
        }
    }
}
