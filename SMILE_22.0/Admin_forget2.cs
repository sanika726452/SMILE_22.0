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
    public partial class Admin_forget2 : Form
    {
        private string email;
        private string generatedOTP;
        public Admin_forget2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtotp.Text.Trim();

            if (enteredOTP.Equals(generatedOTP))
            {
                MessageBox.Show("OTP verified successfully!", "OTP Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);



                Admin_newpass pass = new Admin_newpass();
                pass.setEmail(email);
                pass.Show();



               
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "OTP Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void setEmail(string email, string generatedOTP)
        {
            this.email = email;
            this.generatedOTP = generatedOTP;
            SendOTPByEmail(this.email, generatedOTP);

            MessageBox.Show("OTP sent to your email. Check your inbox.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

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


    }
}
