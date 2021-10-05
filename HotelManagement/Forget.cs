﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Web;

namespace LoginPanel
{
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string otp = File.ReadAllText(@".\otp.txt");
            
            if (guna2TextBox3.Text == otp)
            {
                reset reset = new reset();
                reset.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("OTP incorrect");
            }
            
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string to, from, pass, messageBody;          
            string numbers = "0123456789";
            File.WriteAllText(@".\email.txt",guna2TextBox1.Text);
            Random random = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int tempval = random.Next(0, numbers.Length);
                otp += tempval;
                File.WriteAllText(@".\otp.txt", otp);

            }
            //Connection String   
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Userlogins where EmailId=@EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", guna2TextBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Connection open here   
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                MailMessage message = new MailMessage();
                to = guna2TextBox1.Text;
                from = "ashishtech890@gmail.com";
                pass = "Ashish@890";
                messageBody = "You can use this OTP for reset your account password <br> OTP : " + otp;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = "From : Ashishtech" + "<br>Message : " + messageBody;
                message.Subject = "Forget Password";
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("OTP Successfully Send");                    
                }
                catch (Exception)
                {
                    MessageBox.Show("OTP not send");
                }
            }
            else
            {
                MessageBox.Show("Wrong Email Address it does not match with our records");
            }
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "NmEzODcwNzUzNjUzNTIzMDRhNWE2MTY0NmU0ZjM1NzE"},
                {"numbers" , "917408655629"},
                {"message" ,HttpUtility.UrlEncode("You can use thos OTP for reset your account password<br>OTP " + otp)},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
            }
        }
        Point lastPoint;
        private void Forget_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Forget_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }
    }
}
