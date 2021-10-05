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
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void WelcomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login op = new Login();
            op.Show();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login op = new Login();
            op.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            client ct = new client();
            ct.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            staff sf = new staff();
            sf.Show();
            this.Hide();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            rooms rm = new rooms();
            rm.Show();
            this.Hide();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            reserve res = new reserve();
            res.Show();
            this.Hide();
        }
        Point lastPoint;
        private void WelcomePage_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void WelcomePage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void guna2PictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void guna2PictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
