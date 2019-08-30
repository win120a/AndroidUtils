using AC.AndroidUtils.ADB;
using System;
using System.Windows.Forms;

namespace AC.AndroidUtils.GUI
{
    public partial class ResponseWindow : Form
    {
        private string res;
        private string err;
        public ResponseWindow(string responseS, string respondE)
        {
            InitializeComponent();
            res = responseS;
            err = respondE;
        }

        public ResponseWindow(ShellResponse shr) : this(shr.stdOut, shr.stdError)
        {
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void ResponseWindow_Load(object sender, EventArgs e)
        {
            response.Text = res;
        }

        private void StdOut_CheckedChanged(object sender, EventArgs e)
        {
            response.Text = res;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            response.Text = err;
        }
    }
}
