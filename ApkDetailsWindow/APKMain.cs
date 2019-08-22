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
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    static class APKMain
    {
        internal static SplashWindow sw;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //using (XmlReader reader = XmlReader.Create(sr))
            //{
            //    while (reader.Read())
            //    {
            //        if(reader.NodeType == XmlNodeType.Element && reader.Name == "application")
            //        {
            //            sb.AppendLine("\n !!!" + reader.GetAttribute("android:label"));
            //        }

            //        switch (reader.NodeType)
            //        {
            //            case XmlNodeType.Element:
            //                sb.AppendLine("Start Element {0}".Replace("{0}", reader.Name));
            //                break;
            //            case XmlNodeType.Text:
            //                sb.AppendLine("Text Node: {0}".Replace("{0}", reader.Value));
            //                break;
            //            case XmlNodeType.EndElement:
            //                sb.AppendLine("End Element {0}".Replace("{0}", reader.Name));
            //                break;
            //            default:
            //                sb.AppendLine("Other node {0} with value {1}".Replace("{0}", reader.NodeType.ToString()).Replace("{1}", reader.Value));
            //                break;
            //        }
            //    }

            //    string s = sb.ToString();

            //    MessageBox.Show(s);

            //MessageBox.Show(AndroidAppParser.ReadApk("D:\\al.apk").AppName);
            //MessageBox.Show(AndroidAppParser.ReadApk("D:\\tm.apk").PackageName);
            //MessageBox.Show(AndroidAppParser.ReadApk("D:\\tm.apk").ApkPath);

            if (args.Length == 0)
            {
                MessageBox.Show("Please drag an Android Package File to the application.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }

            if (!File.Exists(args[0]))
            {
                MessageBox.Show("The file you entered is not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(-1);
            }

            sw = new SplashWindow(args[0]);

            Application.Run(sw);
        }
    }
}
