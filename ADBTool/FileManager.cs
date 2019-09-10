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

using AC.AndroidUtils.ADB;
using AC.AndroidUtils.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class FileManager : Form
    {
        private const string PERM_HINT_WORDS = "  [Can't access due to the insufficient permission]";
        private AndroidDevice device;
        private ADBInstance adbi;
        private bool inRoot = false;
        private ClipboardObject clipboard;
        private ADBFileManagmentService adbFM;

        public FileManager(AndroidDevice dev, ADBInstance i)
        {
            InitializeComponent();
            device = dev;
            adbi = i;
            Text = "File Manager [Device Serial: " + dev.Serial + "]";
            adbFM = new ADBFileManagmentService(dev, adbi);
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            LoadRootPath();
            OnSizeChanged(this, null);
        }

        private void LoadRootPath()
        {
            fileView.Nodes.Clear();

            fileView.Nodes.Add("/");

            ShellResponse sr = adbi.RunCommand(device, "ls /", inRoot);

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
        }

        private string GetFullPath(TreeNode n)
        {
            List<string> pathL = new List<string>();

            TreeNode node = n;
            if (n.Text != "/") pathL.Add(n.Text);
            while ((node = node.Parent) != null)
            {
                if (node.Text == "/") continue;
                pathL.Add(node.Text);
            }

            StringBuilder pathBuilder = new StringBuilder();
            pathBuilder.Append("/");

            for (int i = pathL.Count - 1; i >= 0; i--)
            {
                pathBuilder.Append(pathL[i]);
                pathBuilder.Append("/");
            }

            if(pathBuilder.ToString() != "/") pathBuilder.Remove(pathBuilder.Length - 1, 1);

            return pathBuilder.ToString();
        }

        private void FileView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = fileView.SelectedNode;
            string pathToFile = GetFullPath(node);
            FSObjectStatus fos = adbFM.GetFSObjectStatus(pathToFile, inRoot);

            if (fos == FSObjectStatus.PermissionDenied)    // Permission Denied.
            {
                node.Text += pathToFile.Contains(PERM_HINT_WORDS) ? "" : PERM_HINT_WORDS;
                return;
            }

            if (fos == FSObjectStatus.File)
                return;

            if (node.Nodes.Count != 0) node.Nodes.Clear();

            foreach (string s in adbFM.ListFiles(pathToFile, inRoot))
            {
                node.Nodes.Add(s);
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
            int fv_h = Size.Height - 120;

            fileView.Size = new Size()
            {
                Height = fv_h,
                Width = fv_w
            };

            // First Line //
            int buttons_y_first = fv_h + 10;
            import.Location = new Point(import.Location.X, buttons_y_first);
            export.Location = new Point(export.Location.X, buttons_y_first);
            delete.Location = new Point(delete.Location.X, buttons_y_first);
            cut.Location = new Point(cut.Location.X, buttons_y_first);
            copy.Location = new Point(copy.Location.X, buttons_y_first);
            paste.Location = new Point(paste.Location.X, buttons_y_first);
            viewCB.Location = new Point(viewCB.Location.X, buttons_y_first);

            // Second Line //
            int buttons_y_second = buttons_y_first + 30;
            refresh.Location = new Point(refresh.Location.X, buttons_y_second);
            useRoot.Location = new Point(useRoot.Location.X, buttons_y_second);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (fileView.SelectedNode == null) return;

            string path = GetFullPath(fileView.SelectedNode).Replace(PERM_HINT_WORDS, "");

            if (ConfirmDialog("Are you sure? \n\nThe file (folder) you're going to delete is: " + path))
            {
                try
                {
                    adbFM.DeleteFile(path, inRoot);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("Error when processing your request.\n\nMessage: \n" + ioe.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ConfirmDialog(string mess) => MessageBox.Show(mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private bool IsFile(TreeNode node)
        {
            return adbFM.GetFSObjectStatus(GetFullPath(node), inRoot) == FSObjectStatus.File;
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if (fileView.SelectedNode == null || IsFile(fileView.SelectedNode))
            {
                MessageBox.Show("Invaild selection.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                adbi.PushFile(device, ofd.FileName, GetFullPath(fileView.SelectedNode) + "/" + Path.GetFileName(ofd.FileName));
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadRootPath();
        }

        private void UseRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (useRoot.Checked) MessageBox.Show("Please make sure that your device is rooted.");
            inRoot = useRoot.Checked;
            LoadRootPath();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            SetClipboard(true);
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            SetClipboard(false);
        }

        private void SetClipboard(bool delFlag)
        {
            if (fileView.SelectedNode == null || !IsFile(fileView.SelectedNode))
            {
                MessageBox.Show("Invaild selection.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clipboard = new ClipboardObject()
            {
                node = fileView.SelectedNode,
                deleteFlag = delFlag
            };

            paste.Enabled = true;
        }


        private void Paste_Click(object sender, EventArgs e)
        {
            if (fileView.SelectedNode == null || IsFile(fileView.SelectedNode))
            {
                MessageBox.Show("Invaild selection.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(clipboard.deleteFlag ? "mv " : "cp ");
            stringBuilder.Append("\"" + GetFullPath(clipboard.node) + "\"");
            stringBuilder.Append("\"" + GetFullPath(fileView.SelectedNode) + "\"");

            // MessageBox.Show(stringBuilder.ToString());
            adbi.RunCommand(device, stringBuilder.ToString(), inRoot);

            paste.Enabled = false;
        }

        private void ViewCB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File: " + (clipboard.node == null ? "<none>" : GetFullPath(clipboard.node)));
        }

        private struct ClipboardObject
        {
            internal TreeNode node;
            internal bool deleteFlag;
        }
    }
}
