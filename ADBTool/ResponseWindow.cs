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
    public partial class ResponseWindow : Form
    {
        private string res;
        public ResponseWindow(string response)
        {
            InitializeComponent();
            res = response;
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
    }
}
