using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class SplashWindow : Form
    {
        private string ApkPath { get; set; }
        public SplashWindow(string apkPath)
        {
            InitializeComponent();
            ApkPath = apkPath;
        }

        private void SplashWindow_Load(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            new ApkWindow(ApkPath).Show();
        }
    }
}
