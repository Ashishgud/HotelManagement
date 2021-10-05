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
using System.IO;
namespace LoginPanel
{
    public partial class reset : Form
    {
        public reset()
        {
            InitializeComponent();
        }
        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtb1.Text == txtb2.Text)
            {
                string emailid = File.ReadAllText(@".\email.txt");
                //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update UserLogins set Password=@Password where EmailId=@EmailId", con);
                cmd.Parameters.AddWithValue("@EmailId", emailid);
                cmd.Parameters.AddWithValue("@Password", txtb1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password Successfully Changed");
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                txtb1.BorderColor = Color.Red;
                txtb2.BorderColor = Color.Red;
                MessageBox.Show("Password not Matched");
                
            }
        }
    }
}
