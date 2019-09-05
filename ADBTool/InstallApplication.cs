using AC.AndroidUtils.ApkUtil;
using AC.AndroidUtils.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AC.AndroidUtils.ADB;

namespace AC.AndroidUtils.GUI
{
    public partial class InstallApplication : Form
    {
        private AndroidDevice device;
        private ADBInstance adbInstance;
        public InstallApplication(AndroidDevice device1, ADBInstance adbi)
        {
            InitializeComponent();
            device = device1;
            apkDetails.Enabled = false;
            install.Enabled = false;
            adbInstance = adbi;
            apps.DragDrop += HandleDragAndDrop;
        }

        private void HandleDragAndDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.ToString());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Android Package|*.apk";
            ofd.Multiselect = true;
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                foreach (string s in ofd.FileNames)
                {
                    if (!apps.Items.Contains(s)) apps.Items.Add(s);
                }
            }

            install.Enabled = apps.Items.Count > 0;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            HashSet<string> selected = new HashSet<string>();

            foreach (int i in apps.SelectedIndices)
            {
                selected.Add((string)apps.Items[i]);
            }

            foreach (string i in selected)
            {
                apps.Items.Remove(i);
            }

            install.Enabled = apps.Items.Count > 0;
        }

        private void ApkDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This action will take a while, please wait patiently.", "Hint");

            string apkP = (string) apps.Items[apps.SelectedIndex];

            AndroidApplication app = AndroidAppParser.ReadApk(apkP);

            new ApkWindow(app, false).Show();
        }

        private void Apps_SelectedIndexChanged(object sender, EventArgs e)
        {
            apkDetails.Enabled = apps.SelectedIndices.Count == 1;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void Install_Click(object sender, EventArgs e)
        {
            foreach(string app in apps.Items)
            {
                adbInstance.InstallApp(device, app);
            }
        }
    }
}
