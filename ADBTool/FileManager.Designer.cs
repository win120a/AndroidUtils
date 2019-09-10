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
            this.button2 = new System.Windows.Forms.Button();
            this.useRoot = new System.Windows.Forms.CheckBox();
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(559, 541);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 41);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // useRoot
            // 
            this.useRoot.AutoSize = true;
            this.useRoot.Location = new System.Drawing.Point(153, 598);
            this.useRoot.Name = "useRoot";
            this.useRoot.Size = new System.Drawing.Size(160, 22);
            this.useRoot.TabIndex = 6;
            this.useRoot.Text = "Root User Mode";
            this.useRoot.UseVisualStyleBackColor = true;
            this.useRoot.CheckedChanged += new System.EventHandler(this.UseRoot_CheckedChanged);
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 636);
            this.Controls.Add(this.useRoot);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox useRoot;
    }
}