using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArduLEDNameSpace
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2);
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
