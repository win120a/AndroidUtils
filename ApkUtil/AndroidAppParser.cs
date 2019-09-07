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
using System.IO;
using System.Xml;
using AC.AndroidUtils.Shared;

namespace AC.AndroidUtils.ApkUtil
{
    public class AndroidAppParser
    {
        /*
         * The struct that the GetPathsAndPackageName method will use.
         */
        private struct ReturnStruct
        {
            internal string appNameV;
            internal string packageName;
            internal string logoV;
            internal bool nameWritesDirectly;
        }

        private static AndroidApplication GetApplicationObject(string outPath, string valueXml, string apkPath)
        {
            string manifestXml = outPath + "\\AndroidManifest.xml";

            ReturnStruct rs = GetPathsAndPackageName(manifestXml);

            string appNV = rs.appNameV;
            string package = rs.packageName;
            string appN = rs.nameWritesDirectly ? rs.appNameV : GetAppNameByVariableName(valueXml, appNV);
            string logoPath;

            try
            {
                logoPath = GetLogoPath(rs.logoV, outPath);
            }
            catch (Exception)
            {
                logoPath = null;
            }
            

            AndroidApplication appO = new AndroidApplication(appN, package, apkPath, logoPath);
            return appO;
        }

        private static string GetLogoPath(string logoV, string outPath)
        {
            // android:icon="@mipmap/ic_launcher" -- Sample
            string resPath = outPath + "\\res\\";
            string[] parts = logoV.Split('/');
            string dir = parts[0].Replace("@", "");
            string imgName = parts[1];

            // Possible suffixes.
            string[] dpiSuffix = { "-xhdpi", "-xhdpi-v4", "-xxhdpi-v4", "-hdpi-v21", "-hdpi", "-mdpi-v4", "-mdpi" };
            string[] imgSuffix = { ".png", ".jpg", ".webp", "" };     // Keep the last element empty.

            /*
             * Iterate over the suffixes, to find the logo file that exists.
             */ 
            string finalPath = null;
            foreach(string s in dpiSuffix)
            {
                if(Directory.Exists(resPath + dir + s))
                {
                    foreach (string imgS in imgSuffix)
                    {
                        if (File.Exists(resPath + dir + s + "\\" + imgName + imgS))
                        {
                            finalPath = resPath + dir + s + "\\" + imgName + imgS;
                            break;
                        }
                    }
                }
            }

            return finalPath;
        }

        private static string GetAppNameByVariableName(string valueXml, string appNV)
        {
            string appN = null;

            using (StreamReader sr1 = new StreamReader(valueXml))
            {
                using (XmlReader xmlr = XmlReader.Create(sr1))
                {
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "string" && xmlr.GetAttribute("name") == appNV)     // <string name="..." />, where "name" equals the appname's variable name.
                        {
                            xmlr.Read();      // <string> .... </string>.  Go deeper to gather the value.
                            appN = xmlr.Value;
                            break;
                        }
                    }
                }
            }

            return appN;
        }

        private static ReturnStruct GetPathsAndPackageName(string manifestXml)
        {
            /*
             * In order to find the package name and app name in the same time, 
             * the method needs to return two values. Hence I wrapped the result
             * in a struct.
             */ 

            ReturnStruct rs = new ReturnStruct();

            using (StreamReader sr = new StreamReader(manifestXml))
            {
                using (XmlReader xmlr = XmlReader.Create(sr))    // Create an XML Reader with a specified document.
                {
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "application")   // <application> element
                        {
                            string label = xmlr.GetAttribute("android:label");   // "android:label"
                            if (label != null)
                            {
                                if (label.Contains("@"))
                                {
                                    rs.appNameV = label.Split('/')[1];
                                    rs.nameWritesDirectly = false;
                                }
                                else
                                {
                                    rs.appNameV = label;    // To handle with the apk which writes its name directly.
                                    rs.nameWritesDirectly = true;
                                }
                            }

                            rs.logoV = xmlr.GetAttribute("android:icon");
                            // android:icon="@mipmap/ic_launcher"   -- Sample
                        }
                        else if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "manifest")   // <manifest>, to seek the package name.
                        {
                            rs.packageName = xmlr.GetAttribute("package");
                        }
                    }
                }
            }

            return rs;
        }

        public static AndroidApplication ReadApk(string apkPath)
        {
            string outPath = IOUtil.GetRandomDirectoryInTemp();

            ApkToolUtil.DecompileApk(apkPath, outPath, false, true);

            return GetApplicationObject(outPath, outPath + "\\res\\values\\strings.xml", apkPath);
        }
    }
}
