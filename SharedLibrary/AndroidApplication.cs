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

using System.Drawing;

namespace AC.AndroidUtils.Shared
{
    public class AndroidApplication
    {
        public AndroidApplication(string appName, string pkgName, string apkPath, string logoPath)
        {
            PackageName = pkgName;
            AppName = appName;
            ApkPath = apkPath;
            Logo = new Bitmap(logoPath);
        }

        internal AndroidApplication(string apkPath)
        {
            ApkPath = apkPath;
            PackageName = AppName = null;
        }

        public string PackageName
        {
            get; private set;
        }

        public string AppName
        {
            get; private set;
        }

        public string ApkPath
        {
            get; private set;
        }

        public Bitmap Logo { get; private set; }

        public string Version { get; private set; }

        public long InternalVersion { get; private set; }
    }
}
