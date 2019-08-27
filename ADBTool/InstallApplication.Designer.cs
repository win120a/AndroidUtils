namespace AC.AndroidUtils.GUI
{
    partial class InstallApplication
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
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.install = new System.Windows.Forms.Button();
            this.apps = new System.Windows.Forms.ListBox();
            this.close = new System.Windows.Forms.Button();
            this.apkDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(12, 390);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(143, 48);
            this.add.TabIndex = 0;
            this.add.Text = "&Add...";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(161, 390);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(145, 48);
            this.remove.TabIndex = 1;
            this.remove.Text = "&Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // install
            // 
            this.install.Location = new System.Drawing.Point(312, 390);
            this.install.Name = "install";
            this.install.Size = new System.Drawing.Size(152, 48);
            this.install.TabIndex = 2;
            this.install.Text = "&Install";
            this.install.UseVisualStyleBackColor = true;
            // 
            // apps
            // 
            this.apps.FormattingEnabled = true;
            this.apps.ItemHeight = 18;
            this.apps.Location = new System.Drawing.Point(12, 31);
            this.apps.Name = "apps";
            this.apps.ScrollAlwaysVisible = true;
            this.apps.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.apps.Size = new System.Drawing.Size(775, 346);
            this.apps.TabIndex = 3;
            this.apps.SelectedIndexChanged += new System.EventHandler(this.Apps_SelectedIndexChanged);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(635, 390);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(152, 48);
            this.close.TabIndex = 4;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // apkDetails
            // 
            this.apkDetails.Location = new System.Drawing.Point(470, 390);
            this.apkDetails.Name = "apkDetails";
            this.apkDetails.Size = new System.Drawing.Size(159, 48);
            this.apkDetails.TabIndex = 5;
            this.apkDetails.Text = "APK &Details";
            this.apkDetails.UseVisualStyleBackColor = true;
            this.apkDetails.Click += new System.EventHandler(this.ApkDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add the package you want to install below:";
            // 
            // InstallApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apkDetails);
            this.Controls.Add(this.close);
            this.Controls.Add(this.apps);
            this.Controls.Add(this.install);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallApplication";
            this.Text = "Install Android Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button install;
        private System.Windows.Forms.ListBox apps;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button apkDetails;
        private System.Windows.Forms.Label label1;
    }
}