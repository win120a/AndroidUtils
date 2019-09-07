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
            this.installApk = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.enable = new System.Windows.Forms.Button();
            this.kw = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.x = new System.Windows.Forms.Button();
            this.cpPkgName = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // packagesListbox
            // 
            this.packagesListbox.FormattingEnabled = true;
            this.packagesListbox.ItemHeight = 18;
            this.packagesListbox.Location = new System.Drawing.Point(12, 12);
            this.packagesListbox.Name = "packagesListbox";
            this.packagesListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.packagesListbox.Size = new System.Drawing.Size(884, 562);
            this.packagesListbox.TabIndex = 0;
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(766, 700);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(108, 39);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // clearData
            // 
            this.clearData.Location = new System.Drawing.Point(502, 580);
            this.clearData.Name = "clearData";
            this.clearData.Size = new System.Drawing.Size(166, 39);
            this.clearData.TabIndex = 5;
            this.clearData.Text = "&Clear data";
            this.clearData.UseVisualStyleBackColor = true;
            this.clearData.Click += new System.EventHandler(this.ClearData_Click);
            // 
            // disable
            // 
            this.disable.Location = new System.Drawing.Point(150, 580);
            this.disable.Name = "disable";
            this.disable.Size = new System.Drawing.Size(108, 39);
            this.disable.TabIndex = 2;
            this.disable.Text = "&Disable";
            this.disable.UseVisualStyleBackColor = true;
            this.disable.Click += new System.EventHandler(this.Disable_Click);
            // 
            // uninstall
            // 
            this.uninstall.Location = new System.Drawing.Point(378, 580);
            this.uninstall.Name = "uninstall";
            this.uninstall.Size = new System.Drawing.Size(118, 39);
            this.uninstall.TabIndex = 4;
            this.uninstall.Text = "&Uninstall";
            this.uninstall.UseVisualStyleBackColor = true;
            this.uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(675, 580);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(200, 39);
            this.export.TabIndex = 6;
            this.export.Text = "E&xport Package";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.all);
            this.groupBox1.Controls.Add(this.system);
            this.groupBox1.Controls.Add(this.disabled);
            this.groupBox1.Controls.Add(this.thirdParty);
            this.groupBox1.Location = new System.Drawing.Point(12, 681);
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
            // installApk
            // 
            this.installApk.Location = new System.Drawing.Point(18, 580);
            this.installApk.Name = "installApk";
            this.installApk.Size = new System.Drawing.Size(126, 39);
            this.installApk.TabIndex = 1;
            this.installApk.Text = "&Install...";
            this.installApk.UseVisualStyleBackColor = true;
            this.installApk.Click += new System.EventHandler(this.InstallApk_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(652, 700);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(108, 39);
            this.refresh.TabIndex = 9;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // enable
            // 
            this.enable.Location = new System.Drawing.Point(264, 580);
            this.enable.Name = "enable";
            this.enable.Size = new System.Drawing.Size(108, 39);
            this.enable.TabIndex = 3;
            this.enable.Text = "&Enable";
            this.enable.UseVisualStyleBackColor = true;
            this.enable.Click += new System.EventHandler(this.Enable_Click);
            // 
            // kw
            // 
            this.kw.Location = new System.Drawing.Point(378, 632);
            this.kw.Name = "kw";
            this.kw.Size = new System.Drawing.Size(382, 28);
            this.kw.TabIndex = 12;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(766, 625);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(81, 39);
            this.search.TabIndex = 13;
            this.search.Text = "&Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.Search_Click);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(853, 625);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(43, 39);
            this.x.TabIndex = 14;
            this.x.Text = "X";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.X_Click);
            // 
            // cpPkgName
            // 
            this.cpPkgName.Location = new System.Drawing.Point(18, 621);
            this.cpPkgName.Name = "cpPkgName";
            this.cpPkgName.Size = new System.Drawing.Size(177, 39);
            this.cpPkgName.TabIndex = 7;
            this.cpPkgName.Text = "C&opy Package Name";
            this.cpPkgName.UseVisualStyleBackColor = true;
            this.cpPkgName.Click += new System.EventHandler(this.CpPkgName_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(201, 621);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(171, 39);
            this.start.TabIndex = 15;
            this.start.Text = "Start App";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // PackageManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(908, 752);
            this.Controls.Add(this.start);
            this.Controls.Add(this.cpPkgName);
            this.Controls.Add(this.x);
            this.Controls.Add(this.search);
            this.Controls.Add(this.kw);
            this.Controls.Add(this.enable);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.installApk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.export);
            this.Controls.Add(this.uninstall);
            this.Controls.Add(this.disable);
            this.Controls.Add(this.clearData);
            this.Controls.Add(this.close);
            this.Controls.Add(this.packagesListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageManagment";
            this.Text = "Package Managment";
            this.Load += new System.EventHandler(this.PackagesManagment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox packagesListbox;
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
        private System.Windows.Forms.Button installApk;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button enable;
        private System.Windows.Forms.TextBox kw;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Button cpPkgName;
        private System.Windows.Forms.Button start;
    }
}