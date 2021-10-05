using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            //display mainform
            guna2ProgressBar1.Increment(10);
            guna2ProgressBar1.Visible = true;
            if (guna2ProgressBar1.Value == guna2ProgressBar1.Maximum)
            {
                Login mf = new Login();

                mf.Show();
                //hide this form
                this.Hide();
                timer1.Stop();
            }
        }

        private void splash_Shown(object sender, EventArgs e)
        {
        }
    }
}
