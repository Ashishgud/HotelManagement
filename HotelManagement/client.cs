using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class client : Form
    {

        public client()
        {
            InitializeComponent();
            data();
            label5.Text = DateTime.Now.ToShortDateString();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void search()
        {
            //Connection String
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from client where ClientName= '" + guna2TextBox6.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            var dt = new DataSet();
            sda.Fill(dt);
            //Connection open here               
            int i = cmd.ExecuteNonQuery();
            guna2DataGridView1.DataSource = dt.Tables[0];
            con.Close();
        }
        private void data()
        {
            //Connection String
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from client", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = cmd.ExecuteNonQuery();
            guna2DataGridView1.DataSource = dt;
            con.Close();
            //Connection Close here
        }
        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage wp = new WelcomePage();
            wp.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    //Connection String
                    SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into [client] ([ClientName],[ClientPhone],[ClientCountry])values(@ClientName,@ClientPhone,@ClientCountry)", con);
                    cmd.Parameters.AddWithValue("@ClientName", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@ClientPhone", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@ClientCountry", comboBox1.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

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
            else
            {
                MessageBox.Show("Please enter required fields");
            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Connection String
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                //Connection open here 
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from client where ClientId=@ClientId", con);
                cmd.Parameters.AddWithValue("@ClientId", Convert.ToInt32(guna2TextBox4.Text));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Client Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Client Id");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Connection String
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE client SET ClientName=@ClientName, ClientPhone = @ClientPhone , ClientCountry = @ClientCountry WHERE ClientId=@ClientId", con);
                cmd.Parameters.AddWithValue("@ClientId", Convert.ToInt32(guna2TextBox4.Text));
                cmd.Parameters.AddWithValue("@ClientName", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@ClientPhone", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@ClientCountry", comboBox1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                data();
                MessageBox.Show("Client Updated");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Client Id");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            search();
        }
        Point lastPoint;
        private void client_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void client_MouseMove(object sender, MouseEventArgs e)
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

        private void guna2TextBox3_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            data();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //Connection String
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select *from client where ClientId= '" + Convert.ToInt32(guna2TextBox4.Text) + "'", con);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();

                while (sda.Read())
                {
                    guna2TextBox2.Text = sda.GetValue(1).ToString();
                    guna2TextBox1.Text = sda.GetValue(2).ToString();
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
