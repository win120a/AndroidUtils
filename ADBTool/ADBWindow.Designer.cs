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
            this.devices = new System.Windows.Forms.GroupBox();
            this.refresh = new System.Windows.Forms.Button();
            this.devList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.netADB_ip = new System.Windows.Forms.TextBox();
            this.netADB_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.disconnectNet = new System.Windows.Forms.Button();
            this.connectNet = new System.Windows.Forms.Button();
            this.reboot = new System.Windows.Forms.Button();
            this.reboot_recovery = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.devices.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // devices
            // 
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
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.reboot_recovery);
            this.groupBox3.Controls.Add(this.reboot);
            this.groupBox3.Location = new System.Drawing.Point(531, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 412);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operations";
            // 
            // netADB_ip
            // 
            this.netADB_ip.Location = new System.Drawing.Point(21, 46);
            this.netADB_ip.Name = "netADB_ip";
            this.netADB_ip.Size = new System.Drawing.Size(352, 28);
            this.netADB_ip.TabIndex = 0;
            // 
            // netADB_port
            // 
            this.netADB_port.Location = new System.Drawing.Point(402, 46);
            this.netADB_port.Name = "netADB_port";
            this.netADB_port.Size = new System.Drawing.Size(67, 28);
            this.netADB_port.TabIndex = 1;
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ADBWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 520);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.devices);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ADBWindow";
            this.Text = "ADB Utility";
            this.Load += new System.EventHandler(this.ADBWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.devices.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button reboot_recovery;
        private System.Windows.Forms.Button reboot;
    }
}

