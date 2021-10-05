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
using Guna.UI2.WinForms;

namespace LoginPanel
{
    public partial class reserve : Form
    {

        public reserve()
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
            //Connection String   
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select *from reserve", con);
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
            if (guna2TextBox1.Text != "" && guna2TextBox4.Text != "" && guna2DateTimePicker2.Text !="" && guna2DateTimePicker3.Text != "")
            {
                try
                {
                    //Connection String   
                    SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("insert into [reserve] ([ClientName],[RoomNo],[DateIn],[DateOut])values(@ClientName,@RoomNo,@DateIn,@DateOut)", con);
                    cmd.Parameters.AddWithValue("@ClientName", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@DateIn", guna2DateTimePicker3.Text);
                    cmd.Parameters.AddWithValue("@DateOut", guna2DateTimePicker2.Text);
                    //Connection open here   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                    con.Close();
                    data();
                    MessageBox.Show("Added");
                }
                catch (Exception)
                {
                    MessageBox.Show("Please fill the required fields");
                }
            }
            else
            {
                MessageBox.Show("Please enter required fields");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            try
            {
                //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE reserve SET ClientName = @ClientName , RoomNo = @RoomNo , DateIn = @DateIn , DateOut = @DateOut WHERE ResId=@ResId", con);
                cmd.Parameters.AddWithValue("@ClientName", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@RoomNo", Convert.ToInt32(guna2TextBox4.Text));
                cmd.Parameters.AddWithValue("@DateIn",guna2DateTimePicker3.Text);
                cmd.Parameters.AddWithValue("@DateOut", guna2DateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@ResId", Convert.ToInt32(guna2TextBox2.Text));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Reservation Details Updated");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Reservation Number");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            try
            {
                //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from reserve where ResId=@ResId", con);
                cmd.Parameters.AddWithValue("@ResId", Convert.ToInt32(guna2TextBox2.Text));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Reservation Details Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Reservation Number");
            }
        }
        Point lastPoint;
       
        private void reserve_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void reserve_MouseMove(object sender, MouseEventArgs e)
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

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select *from reserve where ResId= '" + Convert.ToInt32(guna2TextBox2.Text) + "'", con);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();

                while (sda.Read())
                {
                    guna2TextBox1.Text = sda.GetValue(1).ToString();
                    guna2TextBox4.Text = sda.GetValue(2).ToString();                   
                    guna2DateTimePicker3.Value = Convert.ToDateTime(sda.GetValue(3));
                    guna2DateTimePicker2.Value = Convert.ToDateTime(sda.GetValue(4));
                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }
        private void search()
        {
            //Connection String   
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from reserve where ClientName= '" + guna2TextBox6.Text + "'", con);
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
    }
}
