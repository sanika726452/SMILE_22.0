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
using System.Text.RegularExpressions;

namespace SMILE_22._0
{
    public partial class Forget_Pass_Page1 : Form
    {
        ForgetOtp f = new ForgetOtp();
        private string generatedOTP;
        public Forget_Pass_Page1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null) { 
            String generatedOTP = GenerateOTP();
            string textBoxEmail = textBox1.Text;
            f.setEmail(textBoxEmail, generatedOTP);
            f.Show();
            }
            else
            {
                errorProvider1.SetError(textBox1, "Email required!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string emailAddress = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(emailAddress))
            {
                errorProvider1.SetError(textBox1, "Email address is required!");
            }
            else if (!Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") || !emailAddress.Contains("@") || !emailAddress.Contains(".") || emailAddress.IndexOf("@") > emailAddress.LastIndexOf("."))
            {
                errorProvider1.SetError(textBox1, "Invalid email address!");

            }
            else
            {

            }
        }
    }
}
