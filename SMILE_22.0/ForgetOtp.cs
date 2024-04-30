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

namespace SMILE_22._0
{
    public partial class ForgetOtp : Form
    {
        private String email;
        private String generatedOTP;
        createNewPass n=new createNewPass();
        public ForgetOtp()
        {
            InitializeComponent();
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
                n.searchByEmail(email);
                n.Show();

            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "OTP Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
