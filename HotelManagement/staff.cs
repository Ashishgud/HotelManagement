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
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
            data();
            label7.Text = DateTime.Now.ToShortDateString();
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
            SqlCommand cmd = new SqlCommand("select *from staff", con);
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
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && comboBox1.Text != "" && guna2TextBox3.Text != "")
            {
                
                    SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("insert into [staff] ([StaffName],[StaffPh],[StaffPass],[StaffG])values(@StaffName,@StaffPhone,@StaffPass,@StaffGender)", con);
                    cmd.Parameters.AddWithValue("@StaffName", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@StaffPhone", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@StaffPass", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@StaffGender", comboBox1.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //Connection open here   
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    data();
                    MessageBox.Show("Staff Added");
                
                
                }
                            
            else
            {
                MessageBox.Show("Please enter required fields");
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {   //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update staff set StaffName=@StaffName,StaffPh=@StaffPhone,Staffg=@StaffGender,StaffPass=@StaffPass where StaffId=@StaffId", con);
                cmd.Parameters.AddWithValue("@StaffName", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@StaffPhone", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@StaffPass", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@StaffId",Convert.ToInt32(guna2TextBox4.Text));
                cmd.Parameters.AddWithValue("@StaffGender", comboBox1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Staff Details Updated");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Staff Id");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {   //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from staff where StaffId=@StaffId", con);
                cmd.Parameters.AddWithValue("@StaffId", Convert.ToInt32(guna2TextBox4.Text));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Staff Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Staff Id");
            }
        }
        Point lastPoint;
        private void staff_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void staff_MouseMove(object sender, MouseEventArgs e)
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
            SqlCommand cmd = new SqlCommand("select *from staff where StaffName= '" + guna2TextBox6.Text + "'", con);
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

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select *from staff where StaffId= '" + Convert.ToInt32(guna2TextBox4.Text) + "'", con);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();

                while (sda.Read())
                {
                    guna2TextBox2.Text = sda.GetValue(1).ToString();
                    guna2TextBox1.Text = sda.GetValue(2).ToString();
                    guna2TextBox3.Text = sda.GetValue(4).ToString();
                    comboBox1.Text = sda.GetValue(3).ToString();
                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
    }
