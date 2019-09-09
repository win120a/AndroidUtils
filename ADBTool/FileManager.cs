using AC.AndroidUtils.ADB;
using AC.AndroidUtils.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class FileManager : Form
    {
        private AndroidDevice device;
        private ADBInstance adbi;

        public FileManager(AndroidDevice dev, ADBInstance i)
        {
            InitializeComponent();
            device = dev;
            adbi = i;
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            fileView.Nodes.Add("/");
            

            ShellResponse sr = adbi.RunCommand(device, "cd /; ls", false);

            using (StringReader strR = new StringReader(sr.stdOut))
            {
                string line;
                while ((line = strR.ReadLine()) != null)
                {
                    fileView.Nodes[0].Nodes.Add(line);
                }
            }

            fileView.SelectedNode = fileView.Nodes[0];
            fileView.SelectedNode.Expand();

            OnSizeChanged(this, null);
        }

        private string GetFullPath(TreeNode n)
        {
            List<string> pathL = new List<string>();

            TreeNode node = n;
            pathL.Add(n.Text);
            while((node = node.Parent) != null)
            {
                pathL.Add(node.Text);
            }

            StringBuilder pathBuilder = new StringBuilder();
            pathBuilder.Append("/");

            for (int i = pathL.Count - 1; i >= 0; i--)
            {
                pathBuilder.Append(pathL[i]);
                pathBuilder.Append("/");
            }

            pathBuilder.Remove(pathBuilder.Length - 1, 1);

            return pathBuilder.ToString();
        }

        private void FileView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = fileView.SelectedNode;

            ShellResponse sr = adbi.RunCommand(device, "cd " + GetFullPath(node) + "; ls", false);

            if (sr.stdOut.Contains("Not a directory") && sr.stdOut.Contains("cd: ")) return;
            if (node.Nodes.Count != 0) node.Nodes.Clear();

            using (StringReader strR = new StringReader(sr.stdOut))
            {
                Encoding enA = Encoding.ASCII;
                Encoding enU = Encoding.UTF8;
                Encoding enGB = Encoding.Default;

                string line;
                while ((line = strR.ReadLine()) != null)
                {
                    node.Nodes.Add(enU.GetString(enGB.GetBytes(line)));
                    //if (line.Contains("2013")) MessageBox.Show(enU.GetString(enA.GetBytes(line)));
                    //node.Nodes.Add(enU.GetString(enGB.GetBytes(line)));   // GBK -> Unicode
                }
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            TreeNode node = fileView.SelectedNode;
            string fullPath = GetFullPath(node);

            SaveFileDialog sfd = new SaveFileDialog();
            string[] fullPA = fullPath.Split('.');
            sfd.Filter = fullPA[fullPA.Length - 1].ToUpper() + " File|*." + fullPA[fullPA.Length - 1].ToLower();
            if (sfd.ShowDialog() == DialogResult.OK) adbi.PullFileFromDevice(device, fullPath, sfd.FileName);
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            int fv_w = Size.Width - 30;
            int fv_h = Size.Height - 100;

            fileView.Size = new Size()
            {
                Height = fv_h,
                Width = fv_w
            };

            int buttons_y = fv_h + 10;

            import.Location = new Point(import.Location.X, buttons_y);
            export.Location = new Point(export.Location.X, buttons_y);
        }
    }
}
