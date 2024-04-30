using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace SMILE_22._0
{
    public partial class Forget_Pass_Page2 : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";


        private string name, mobile, password;
        private String email;
        private String generatedOTP;
        public Forget_Pass_Page2()
        {
            InitializeComponent();


        }

        public void setData(String name, string mobile, string email, string password)
        {
            this.name = name;
            this.mobile = mobile;
            this.email = email;
            this.password = password;

        }
        public void setEmail(string email, string generatedOTP)
        {
            this.email = email;
            this.generatedOTP = generatedOTP;
            SendOTPByEmail(this.email, generatedOTP);

            MessageBox.Show("OTP sent to your email. Check your inbox.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtotp.Text.Trim();

            if (enteredOTP.Equals(generatedOTP))
            {
                MessageBox.Show("OTP verified successfully!", "OTP Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                insertData();
                // You can proceed with further actions (e.g., user registration) here
                Home_Page home_Page = new Home_Page();
                home_Page.Show();
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "OTP Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtotp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SendOTPByEmail(string toEmail, string otp)
        {
            try
            {
                // Configure SMTP client settings
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("sasthorat@gmail.com", "vipwkzumrlpxtdjr"),
                    EnableSsl = true,
                };

                // Create the mail message
                MailMessage mailMessage = new MailMessage("sasthorat@gmaill.com", toEmail)
                {
                    Subject = "OTP Verification",
                    Body = $"Your OTP for verification is: {otp}",
                };

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertData()
        {

            string query = "INSERT INTO [dbo].[User] (User_name, User_mobile, User_email, User_password) " +
            "VALUES (@Username, @MobileNumber, @Email, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", name);
                    command.Parameters.AddWithValue("@MobileNumber", mobile);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("User information saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Unable to save user information. Please try again later.");
                        // Log the exception for debugging purposes
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
