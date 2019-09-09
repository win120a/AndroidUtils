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
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 636);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.fileView);
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileView;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button export;
    }
}