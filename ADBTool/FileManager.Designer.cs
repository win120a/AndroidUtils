namespace AC.AndroidUtils.GUI
{
    partial class FileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileView = new System.Windows.Forms.TreeView();
            this.import = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.cut = new System.Windows.Forms.Button();
            this.useRoot = new System.Windows.Forms.CheckBox();
            this.copy = new System.Windows.Forms.Button();
            this.paste = new System.Windows.Forms.Button();
            this.viewCB = new System.Windows.Forms.Button();
            this.chkFS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileView
            // 
            this.fileView.HideSelection = false;
            this.fileView.Location = new System.Drawing.Point(12, 12);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(935, 523);
            this.fileView.TabIndex = 0;
            this.fileView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FileView_AfterSelect);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(12, 541);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(135, 41);
            this.import.TabIndex = 1;
            this.import.Text = "Import...";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.Import_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(153, 541);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(135, 41);
            this.export.TabIndex = 2;
            this.export.Text = "Export...";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(294, 541);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(135, 41);
            this.delete.TabIndex = 3;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(12, 588);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(135, 40);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // cut
            // 
            this.cut.Location = new System.Drawing.Point(435, 541);
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(118, 41);
            this.cut.TabIndex = 5;
            this.cut.Text = "Cut";
            this.cut.UseVisualStyleBackColor = true;
            this.cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // useRoot
            // 
            this.useRoot.AutoSize = true;
            this.useRoot.Location = new System.Drawing.Point(153, 598);
            this.useRoot.Name = "useRoot";
            this.useRoot.Size = new System.Drawing.Size(169, 22);
            this.useRoot.TabIndex = 6;
            this.useRoot.Text = "Super User Mode";
            this.useRoot.UseVisualStyleBackColor = true;
            this.useRoot.CheckedChanged += new System.EventHandler(this.UseRoot_CheckedChanged);
            // 
            // copy
            // 
            this.copy.Location = new System.Drawing.Point(559, 541);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(118, 41);
            this.copy.TabIndex = 7;
            this.copy.Text = "Copy";
            this.copy.UseVisualStyleBackColor = true;
            this.copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // paste
            // 
            this.paste.Enabled = false;
            this.paste.Location = new System.Drawing.Point(683, 541);
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(118, 41);
            this.paste.TabIndex = 8;
            this.paste.Text = "Paste";
            this.paste.UseVisualStyleBackColor = true;
            this.paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // viewCB
            // 
            this.viewCB.Location = new System.Drawing.Point(807, 541);
            this.viewCB.Name = "viewCB";
            this.viewCB.Size = new System.Drawing.Size(118, 41);
            this.viewCB.TabIndex = 9;
            this.viewCB.Text = "Clipboard";
            this.viewCB.UseVisualStyleBackColor = true;
            this.viewCB.Click += new System.EventHandler(this.ViewCB_Click);
            // 
            // chkFS
            // 
            this.chkFS.Location = new System.Drawing.Point(435, 588);
            this.chkFS.Name = "chkFS";
            this.chkFS.Size = new System.Drawing.Size(242, 40);
            this.chkFS.TabIndex = 10;
            this.chkFS.Text = "Check Free Space";
            this.chkFS.UseVisualStyleBackColor = true;
            this.chkFS.Click += new System.EventHandler(this.ChkFS_Click);
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 636);
            this.Controls.Add(this.chkFS);
            this.Controls.Add(this.viewCB);
            this.Controls.Add(this.paste);
            this.Controls.Add(this.copy);
            this.Controls.Add(this.useRoot);
            this.Controls.Add(this.cut);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.fileView);
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView fileView;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button cut;
        private System.Windows.Forms.CheckBox useRoot;
        private System.Windows.Forms.Button copy;
        private System.Windows.Forms.Button paste;
        private System.Windows.Forms.Button viewCB;
        private System.Windows.Forms.Button chkFS;
    }
}