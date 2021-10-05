using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginPanel
{
    public partial class rooms : Form
    {
        public rooms()
        {
            InitializeComponent();
            data();
            label5.Text = DateTime.Now.ToShortDateString();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage wp = new WelcomePage();
            wp.Show();
        }

        private void data()
        {

            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select *from room", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Connection open here   
            con.Open();
            int i = cmd.ExecuteNonQuery();
            guna2DataGridView1.DataSource = dt;
            con.Close();
            //Connection Close here
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into [room] ([RoomNo],[RoomPh],[Roomav])values(@RoomNo,@RoomPh,@RoomAv)", con);
                cmd.Parameters.AddWithValue("@RoomNo", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@RoomPh", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@RoomAv", guna2RadioButton1.Checked ? guna2RadioButton1.Text : guna2RadioButton3.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Added");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill the required fields");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            try
            {   //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE room SET RoomPh = @RoomPhone , RoomAv = @RoomAv WHERE RoomNo=@RoomNo", con);
                cmd.Parameters.AddWithValue("@RoomNo", Convert.ToInt32(guna2TextBox3.Text));
                cmd.Parameters.AddWithValue("@RoomPhone", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@RoomAv", guna2RadioButton1.Checked ? guna2RadioButton1.Text : guna2RadioButton3.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Room Details Updated");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Room Number");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {   //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from room where RoomNo=@RoomNo", con);
                cmd.Parameters.AddWithValue("@RoomNo", Convert.ToInt32(guna2TextBox3.Text));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Room Details Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Room Number");
            }
        }
        Point lastPoint;
        private void rooms_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void rooms_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void search()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from room where RoomNo= '" + Convert.ToInt32(guna2TextBox6.Text) + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            var dt = new DataSet();
            sda.Fill(dt);
            //Connection open here               
            int i = cmd.ExecuteNonQuery();
            guna2DataGridView1.DataSource = dt.Tables[0];
            con.Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            data();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select *from room where RoomNo= '" + Convert.ToInt32(guna2TextBox3.Text) + "'", con);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();

                while (sda.Read())
                {
                    guna2TextBox2.Text = sda.GetValue(1).ToString();
                    string value = sda.GetValue(2).ToString();
                    if(value == "Free")
                    {
                        guna2RadioButton1.Checked = true;
                    }
                    else
                    {
                        guna2RadioButton3.Checked = true;
                    }

                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
