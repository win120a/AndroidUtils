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
            KillADBProcess();
            IOUtil.WriteBytesToFile(Resources.adbE, path + "\\adbE.exe");
            Process.Start(path + "\\adbE.exe").WaitForExit();
        }

        public static void KillADBProcess()
        {
            Process[] pg = Process.GetProcessesByName("adb.exe");

            foreach(Process p in pg)
            {
                p.Kill();
                p.Close();
                p.Dispose();
            }
        }
    }
}