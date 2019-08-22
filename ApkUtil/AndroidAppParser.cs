﻿using System;
using System.IO;
using System.Xml;
using AC.AndroidUtils.Shared;

namespace AC.AndroidUtils.ApkUtil
{
    public class AndroidAppParser
    {
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

            string[] dpiSuffix = { "-xhdpi", "-xhdpi-v4", "-xxhdpi-v4", "-hdpi-v21", "-hdpi", "-mdpi-v4", "-mdpi" };
            string[] imgSuffix = { ".png", ".jpg", ".webp", "" };   // Keep the last element empty.

            string finalPath = null;
            foreach(string s in dpiSuffix)
            {
                if(Directory.Exists(resPath + dir + s))
                {
                    foreach(string imgS in imgSuffix)
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
                        if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "string" && xmlr.GetAttribute("name") == appNV)
                        {
                            xmlr.Read();
                            appN = xmlr.Value;
                        }
                    }
                }
            }

            return appN;
        }

        private static ReturnStruct GetPathsAndPackageName(string manifestXml)
        {
            ReturnStruct rs = new ReturnStruct();

            using (StreamReader sr = new StreamReader(manifestXml))
            {
                using (XmlReader xmlr = XmlReader.Create(sr))
                {
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "application")
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
                                    rs.appNameV = label;    // In order to handle with the apk which writes its name directly.
                                    rs.nameWritesDirectly = true;
                                }
                            }

                            rs.logoV = xmlr.GetAttribute("android:icon");
                            // android:icon="@mipmap/ic_launcher"   -- Sample
                        }
                        else if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "manifest")
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
            string outPath = Environment.GetEnvironmentVariable("Temp") + "\\apk";

            ApkToolUtil.DecompileApk(apkPath, outPath, false, true);

            return GetApplicationObject(outPath, outPath + "\\res\\values\\strings.xml", apkPath);
        }
    }
}
