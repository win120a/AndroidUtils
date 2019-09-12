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
using AC.AndroidUtils.ADB.Interfaces;
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
        private IFileManagmentService adbFM;
        private Dictionary<string, FSObjectStatus> objStatusCache;
        private Dictionary<string, List<string>> responseCache;    // <path, FileList>

        public FileManager(AndroidDevice dev, ADBInstance i)
        {
            InitializeComponent();
            device = dev;
            adbi = i;
            Text = "File Manager [Device Serial: " + dev.Serial + "]";
            adbFM = new ADBFileManagmentService(dev, adbi);
            objStatusCache = new Dictionary<string, FSObjectStatus>();
            responseCache = new Dictionary<string, List<string>>();
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            LoadRootPath();
            OnSizeChanged(this, null);
        }

        private void LoadRootPath()
        {
            fileView.Nodes.Clear();
            responseCache.Clear();
            objStatusCache.Clear();

            fileView.Nodes.Add("/");

            fileView.SelectedNode = fileView.Nodes[0];   // The event handler of the AfterSelect will be invoked.
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

            if (pathBuilder.ToString() != "/") pathBuilder.Remove(pathBuilder.Length - 1, 1);

            return pathBuilder.ToString();
        }

        private FSObjectStatus GetFSObjectStatusWithCache(string path)
        {
            if (objStatusCache.ContainsKey(path)) return objStatusCache[path];
            else
            {
                FSObjectStatus s = adbFM.GetFSObjectStatus(path, inRoot);
                objStatusCache.Add(path, s);
                return s;
            }
        }

        private List<string> ListFilesWithCache(string path)
        {
            if (responseCache.ContainsKey(path))
            {
                return responseCache[path];
            }
            else
            {
                List<string> list = adbFM.ListFiles(path, inRoot);
                responseCache.Add(path, list);
                return list;
            }
        }

        private void FileView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = fileView.SelectedNode;
            string pathToFile = GetFullPath(node);
            //FSObjectStatus fos = adbFM.GetFSObjectStatus(pathToFile, inRoot);
            FSObjectStatus fos = GetFSObjectStatusWithCache(pathToFile);

            if (fos == FSObjectStatus.PermissionDenied)    // Permission Denied.
            {
                node.Text += pathToFile.Contains(PERM_HINT_WORDS) ? "" : PERM_HINT_WORDS;
                return;
            }

            if (fos == FSObjectStatus.File)
                return;

            if (node.Nodes.Count != 0) node.Nodes.Clear();

            foreach (string s in ListFilesWithCache(pathToFile))
            {
                node.Nodes.Add(s);
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if (fileView.SelectedNode == null || !IsFile(fileView.SelectedNode))
            {
                MessageBox.Show("Invaild selection.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            chkFS.Location = new Point(chkFS.Location.X, buttons_y_second);
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

                ReloadUpper();
            }
        }

        private void ReloadUpper()
        {
            responseCache.Remove(GetFullPath(fileView.SelectedNode.Parent));
            TreeNode n = fileView.SelectedNode;
            fileView.SelectedNode = n.Parent != null ? n.Parent : fileView.Nodes[0];
            fileView.SelectedNode = n;
        }

        private bool ConfirmDialog(string mess) => MessageBox.Show(mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private bool IsFile(TreeNode node)
        {
            return GetFSObjectStatusWithCache(GetFullPath(node)) == FSObjectStatus.File;
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if (fileView.SelectedNode == null || IsFile(fileView.SelectedNode))
            {
                MessageBox.Show("Invaild selection.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in ofd.FileNames)
                {
                    adbi.PushFile(device, fileName, GetFullPath(fileView.SelectedNode) + "/" + Path.GetFileName(ofd.FileName));
                }
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

            if (clipboard.deleteFlag)
            {
                adbFM.MoveFile(GetFullPath(clipboard.node), GetFullPath(fileView.SelectedNode), inRoot);
            }
            else
            {
                adbFM.CopyFile(GetFullPath(clipboard.node), GetFullPath(fileView.SelectedNode), inRoot);
            }

            ReloadUpper();

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

        private void ChkFS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(adbi.RunCommand(device, "df", inRoot).stdOut, "Remaining disk space of device " + device.Serial, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
