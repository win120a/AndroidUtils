namespace AC.AndroidUtils.GUI
{
    partial class ApkWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apkPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pkgName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appName = new System.Windows.Forms.Label();
            this.appLogo = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.apkPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pkgName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.appName);
            this.groupBox1.Controls.Add(this.appLogo);
            this.groupBox1.Location = new System.Drawing.Point(14, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(819, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "APK Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Path to APK:";
            // 
            // apkPath
            // 
            this.apkPath.AutoSize = true;
            this.apkPath.Location = new System.Drawing.Point(306, 128);
            this.apkPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.apkPath.Name = "apkPath";
            this.apkPath.Size = new System.Drawing.Size(62, 18);
            this.apkPath.TabIndex = 5;
            this.apkPath.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Package Name:";
            // 
            // pkgName
            // 
            this.pkgName.AutoSize = true;
            this.pkgName.Location = new System.Drawing.Point(306, 88);
            this.pkgName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pkgName.Name = "pkgName";
            this.pkgName.Size = new System.Drawing.Size(62, 18);
            this.pkgName.TabIndex = 3;
            this.pkgName.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "App Name:";
            // 
            // appName
            // 
            this.appName.AutoSize = true;
            this.appName.Location = new System.Drawing.Point(270, 45);
            this.appName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(62, 18);
            this.appName.TabIndex = 1;
            this.appName.Text = "label1";
            // 
            // appLogo
            // 
            this.appLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.appLogo.Location = new System.Drawing.Point(8, 29);
            this.appLogo.Margin = new System.Windows.Forms.Padding(4);
            this.appLogo.Name = "appLogo";
            this.appLogo.Size = new System.Drawing.Size(151, 152);
            this.appLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.appLogo.TabIndex = 0;
            this.appLogo.TabStop = false;
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(682, 250);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(151, 50);
            this.close.TabIndex = 1;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ApkWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(846, 321);
            this.Controls.Add(this.close);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApkWindow";
            this.Text = "APK Details";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.PictureBox appLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pkgName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label apkPath;
        private System.Windows.Forms.Button close;
    }
}

