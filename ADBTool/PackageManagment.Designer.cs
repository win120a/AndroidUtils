namespace AC.AndroidUtils.GUI
{
    partial class PackageManagment
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
            this.packagesListbox = new System.Windows.Forms.ListBox();
            this.hide = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.clearData = new System.Windows.Forms.Button();
            this.disable = new System.Windows.Forms.Button();
            this.uninstall = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.all = new System.Windows.Forms.RadioButton();
            this.system = new System.Windows.Forms.RadioButton();
            this.disabled = new System.Windows.Forms.RadioButton();
            this.thirdParty = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // packagesListbox
            // 
            this.packagesListbox.FormattingEnabled = true;
            this.packagesListbox.ItemHeight = 18;
            this.packagesListbox.Location = new System.Drawing.Point(12, 12);
            this.packagesListbox.Name = "packagesListbox";
            this.packagesListbox.Size = new System.Drawing.Size(884, 562);
            this.packagesListbox.TabIndex = 0;
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(93, 580);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(108, 39);
            this.hide.TabIndex = 1;
            this.hide.Text = "Hide";
            this.hide.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(766, 657);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(108, 39);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // clearData
            // 
            this.clearData.Location = new System.Drawing.Point(445, 580);
            this.clearData.Name = "clearData";
            this.clearData.Size = new System.Drawing.Size(167, 39);
            this.clearData.TabIndex = 3;
            this.clearData.Text = "Clear data";
            this.clearData.UseVisualStyleBackColor = true;
            // 
            // disable
            // 
            this.disable.Location = new System.Drawing.Point(207, 580);
            this.disable.Name = "disable";
            this.disable.Size = new System.Drawing.Size(108, 39);
            this.disable.TabIndex = 4;
            this.disable.Text = "Disable";
            this.disable.UseVisualStyleBackColor = true;
            // 
            // uninstall
            // 
            this.uninstall.Location = new System.Drawing.Point(321, 580);
            this.uninstall.Name = "uninstall";
            this.uninstall.Size = new System.Drawing.Size(118, 39);
            this.uninstall.TabIndex = 5;
            this.uninstall.Text = "Uninstall";
            this.uninstall.UseVisualStyleBackColor = true;
            this.uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(618, 580);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(179, 39);
            this.export.TabIndex = 6;
            this.export.Text = "Export Package";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.all);
            this.groupBox1.Controls.Add(this.system);
            this.groupBox1.Controls.Add(this.disabled);
            this.groupBox1.Controls.Add(this.thirdParty);
            this.groupBox1.Location = new System.Drawing.Point(12, 638);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 58);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show only...";
            // 
            // all
            // 
            this.all.AutoSize = true;
            this.all.Checked = true;
            this.all.Location = new System.Drawing.Point(483, 27);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(105, 22);
            this.all.TabIndex = 3;
            this.all.TabStop = true;
            this.all.Text = "All apps";
            this.all.UseVisualStyleBackColor = true;
            this.all.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // system
            // 
            this.system.AutoSize = true;
            this.system.Location = new System.Drawing.Point(189, 27);
            this.system.Name = "system";
            this.system.Size = new System.Drawing.Size(132, 22);
            this.system.TabIndex = 2;
            this.system.Text = "System Apps";
            this.system.UseVisualStyleBackColor = true;
            this.system.CheckedChanged += new System.EventHandler(this.System_CheckedChanged);
            // 
            // disabled
            // 
            this.disabled.AutoSize = true;
            this.disabled.Location = new System.Drawing.Point(327, 27);
            this.disabled.Name = "disabled";
            this.disabled.Size = new System.Drawing.Size(150, 22);
            this.disabled.TabIndex = 1;
            this.disabled.Text = "Disabled apps";
            this.disabled.UseVisualStyleBackColor = true;
            this.disabled.CheckedChanged += new System.EventHandler(this.Disabled_CheckedChanged);
            // 
            // thirdParty
            // 
            this.thirdParty.AutoSize = true;
            this.thirdParty.Location = new System.Drawing.Point(6, 27);
            this.thirdParty.Name = "thirdParty";
            this.thirdParty.Size = new System.Drawing.Size(177, 22);
            this.thirdParty.TabIndex = 0;
            this.thirdParty.Text = "Third-party apps";
            this.thirdParty.UseVisualStyleBackColor = true;
            this.thirdParty.CheckedChanged += new System.EventHandler(this.ThirdParty_CheckedChanged);
            // 
            // PackageManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(908, 708);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.export);
            this.Controls.Add(this.uninstall);
            this.Controls.Add(this.disable);
            this.Controls.Add(this.clearData);
            this.Controls.Add(this.close);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.packagesListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageManagment";
            this.Text = "PackagesManagment";
            this.Load += new System.EventHandler(this.PackagesManagment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox packagesListbox;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button clearData;
        private System.Windows.Forms.Button disable;
        private System.Windows.Forms.Button uninstall;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton all;
        private System.Windows.Forms.RadioButton system;
        private System.Windows.Forms.RadioButton disabled;
        private System.Windows.Forms.RadioButton thirdParty;
    }
}