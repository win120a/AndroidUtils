using AC.AndroidUtils.ADB;
using AC.AndroidUtils.Shared;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class ADBShell : Form
    {
        // private const string shText = "#! /system/bin/sh";
        private AndroidDevice device;
        private ADBInstance adbi;

        public ADBShell(AndroidDevice device, ADBInstance adbI)
        {
            InitializeComponent();
            this.device = device;
            this.adbi = adbI;
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            new ResponseWindow(adbi.RunMultiLineCommand(device, shellText.Text, runasroot.Checked)).Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }
    }
}
