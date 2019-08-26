namespace AC.AndroidUtils.GUI
{
    partial class ADBWindow
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
            this.connectNet = new System.Windows.Forms.Button();
            this.disconnectNet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.netADB_port = new System.Windows.Forms.TextBox();
            this.netADB_ip = new System.Windows.Forms.TextBox();
            this.devices = new System.Windows.Forms.GroupBox();
            this.refresh = new System.Windows.Forms.Button();
            this.devList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.shell = new System.Windows.Forms.Button();
            this.reboot_recovery = new System.Windows.Forms.Button();
            this.reboot = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uninstall = new System.Windows.Forms.Button();
            this.install = new System.Windows.Forms.Button();
            this.browseADBPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.adbPath = new System.Windows.Forms.TextBox();
            this.load = new System.Windows.Forms.Button();
            this.devStatus = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.devices.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectNet);
            this.groupBox1.Controls.Add(this.disconnectNet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.netADB_port);
            this.groupBox1.Controls.Add(this.netADB_ip);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Debugging";
            // 
            // connectNet
            // 
            this.connectNet.Location = new System.Drawing.Point(235, 80);
            this.connectNet.Name = "connectNet";
            this.connectNet.Size = new System.Drawing.Size(98, 35);
            this.connectNet.TabIndex = 4;
            this.connectNet.Text = "Connect";
            this.connectNet.UseVisualStyleBackColor = true;
            this.connectNet.Click += new System.EventHandler(this.ConnectNet_Click);
            // 
            // disconnectNet
            // 
            this.disconnectNet.Location = new System.Drawing.Point(339, 80);
            this.disconnectNet.Name = "disconnectNet";
            this.disconnectNet.Size = new System.Drawing.Size(130, 35);
            this.disconnectNet.TabIndex = 3;
            this.disconnectNet.Text = "Disconnect";
            this.disconnectNet.UseVisualStyleBackColor = true;
            this.disconnectNet.Click += new System.EventHandler(this.DisconnectNet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // netADB_port
            // 
            this.netADB_port.Location = new System.Drawing.Point(402, 46);
            this.netADB_port.Name = "netADB_port";
            this.netADB_port.Size = new System.Drawing.Size(67, 28);
            this.netADB_port.TabIndex = 1;
            // 
            // netADB_ip
            // 
            this.netADB_ip.Location = new System.Drawing.Point(21, 46);
            this.netADB_ip.Name = "netADB_ip";
            this.netADB_ip.Size = new System.Drawing.Size(352, 28);
            this.netADB_ip.TabIndex = 0;
            // 
            // devices
            // 
            this.devices.Controls.Add(this.devStatus);
            this.devices.Controls.Add(this.refresh);
            this.devices.Controls.Add(this.devList);
            this.devices.Location = new System.Drawing.Point(12, 177);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(491, 307);
            this.devices.TabIndex = 1;
            this.devices.TabStop = false;
            this.devices.Text = "Connected Devices";
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(370, 253);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(99, 38);
            this.refresh.TabIndex = 3;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // devList
            // 
            this.devList.FormattingEnabled = true;
            this.devList.ItemHeight = 18;
            this.devList.Location = new System.Drawing.Point(21, 27);
            this.devList.Name = "devList";
            this.devList.Size = new System.Drawing.Size(448, 220);
            this.devList.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.shell);
            this.groupBox3.Controls.Add(this.reboot_recovery);
            this.groupBox3.Controls.Add(this.reboot);
            this.groupBox3.Location = new System.Drawing.Point(531, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 186);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device Operations";
            // 
            // shell
            // 
            this.shell.Location = new System.Drawing.Point(12, 124);
            this.shell.Name = "shell";
            this.shell.Size = new System.Drawing.Size(197, 38);
            this.shell.TabIndex = 2;
            this.shell.Text = "Run shell command";
            this.shell.UseVisualStyleBackColor = true;
            this.shell.Click += new System.EventHandler(this.Shell_Click);
            // 
            // reboot_recovery
            // 
            this.reboot_recovery.Location = new System.Drawing.Point(12, 80);
            this.reboot_recovery.Name = "reboot_recovery";
            this.reboot_recovery.Size = new System.Drawing.Size(197, 38);
            this.reboot_recovery.TabIndex = 1;
            this.reboot_recovery.Text = "Reboot to Recovery";
            this.reboot_recovery.UseVisualStyleBackColor = true;
            this.reboot_recovery.Click += new System.EventHandler(this.Reboot_recovery_Click);
            // 
            // reboot
            // 
            this.reboot.Location = new System.Drawing.Point(12, 35);
            this.reboot.Name = "reboot";
            this.reboot.Size = new System.Drawing.Size(197, 38);
            this.reboot.TabIndex = 0;
            this.reboot.Text = "Reboot";
            this.reboot.UseVisualStyleBackColor = true;
            this.reboot.Click += new System.EventHandler(this.Reboot_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uninstall);
            this.groupBox2.Controls.Add(this.install);
            this.groupBox2.Controls.Add(this.browseADBPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.adbPath);
            this.groupBox2.Controls.Add(this.load);
            this.groupBox2.Location = new System.Drawing.Point(531, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 150);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADB Operations";
            // 
            // uninstall
            // 
            this.uninstall.Location = new System.Drawing.Point(317, 76);
            this.uninstall.Name = "uninstall";
            this.uninstall.Size = new System.Drawing.Size(121, 43);
            this.uninstall.TabIndex = 5;
            this.uninstall.Text = "Uninstall";
            this.uninstall.UseVisualStyleBackColor = true;
            this.uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // install
            // 
            this.install.Location = new System.Drawing.Point(166, 76);
            this.install.Name = "install";
            this.install.Size = new System.Drawing.Size(121, 43);
            this.install.TabIndex = 4;
            this.install.Text = "Install";
            this.install.UseVisualStyleBackColor = true;
            this.install.Click += new System.EventHandler(this.Install_Click);
            // 
            // browseADBPath
            // 
            this.browseADBPath.Location = new System.Drawing.Point(391, 26);
            this.browseADBPath.Name = "browseADBPath";
            this.browseADBPath.Size = new System.Drawing.Size(47, 30);
            this.browseADBPath.TabIndex = 3;
            this.browseADBPath.Text = "...";
            this.browseADBPath.UseVisualStyleBackColor = true;
            this.browseADBPath.Click += new System.EventHandler(this.BrowseADBPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ADB Path";
            // 
            // adbPath
            // 
            this.adbPath.Enabled = false;
            this.adbPath.Location = new System.Drawing.Point(88, 27);
            this.adbPath.Name = "adbPath";
            this.adbPath.Size = new System.Drawing.Size(297, 28);
            this.adbPath.TabIndex = 1;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(12, 76);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(121, 43);
            this.load.TabIndex = 0;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.Load_Click_1);
            // 
            // devStatus
            // 
            this.devStatus.Location = new System.Drawing.Point(215, 253);
            this.devStatus.Name = "devStatus";
            this.devStatus.Size = new System.Drawing.Size(149, 38);
            this.devStatus.TabIndex = 4;
            this.devStatus.Text = "Device Status";
            this.devStatus.UseVisualStyleBackColor = true;
            this.devStatus.Click += new System.EventHandler(this.DevStatus_Click);
            // 
            // ADBWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 520);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.devices);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADBWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADB Utility";
            this.Load += new System.EventHandler(this.ADBWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.devices.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox devices;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.ListBox devList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button connectNet;
        private System.Windows.Forms.Button disconnectNet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox netADB_port;
        private System.Windows.Forms.TextBox netADB_ip;
        private System.Windows.Forms.Button shell;
        private System.Windows.Forms.Button reboot_recovery;
        private System.Windows.Forms.Button reboot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseADBPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adbPath;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button uninstall;
        private System.Windows.Forms.Button install;
        private System.Windows.Forms.Button devStatus;
    }
}

