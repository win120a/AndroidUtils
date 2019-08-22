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
