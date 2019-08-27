using AC.AndroidUtils.ApkUtil;
using AC.AndroidUtils.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace AC.AndroidUtils.GUI
{
    public partial class InstallApplication : Form
    {
        private AndroidDevice device;

        public InstallApplication(AndroidDevice device1)
        {
            InitializeComponent();
            device = device1;
            apkDetails.Enabled = false;
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
        }

        private void ApkDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This action will take a while, please wait patiently.", "Hint");

            string apkP = (string) apps.Items[apps.SelectedIndex];

            AndroidApplication app = AndroidAppParser.ReadApk(apkP);

            new ApkWindow(app).Show();
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
    }
}
