using AC.AndroidUtils.ApkUtil;
using AC.AndroidUtils.Shared;
using System;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class ApkWindow : Form
    {
        public string ApkPath { get; private set; }
        public AndroidApplication ApplicationObject
        {
            get; private set;
        }

        public ApkWindow(string apkPath)
        {
            InitializeComponent();
            FormClosed += HandleExit;
            ApkPath = apkPath;
        }

        private void HandleExit(object sender, FormClosedEventArgs e) => ExitApp();

        private void ExitApp() => Application.Exit();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationObject = AndroidAppParser.ReadApk(ApkPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Decompile error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            apkPath.Text = ApplicationObject.ApkPath;
            pkgName.Text = ApplicationObject.PackageName;
            appName.Text = ApplicationObject.AppName;

            if (ApplicationObject.Logo != null)
            {
                appLogo.Image = ApplicationObject.Logo;
            }

            APKMain.sw.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            ExitApp();
        }
    }
}
