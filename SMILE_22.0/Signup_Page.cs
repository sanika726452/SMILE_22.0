using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SMILE_22._0
{
    public partial class Signup_Page : Form
    {
       Forget_Pass_Page2 f = new Forget_Pass_Page2();
        public Signup_Page()
        {
            InitializeComponent();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuname.Text))
            {
                errorProvider1.SetError(txtuname, "Name is required!");
            }
            if (string.IsNullOrEmpty(txtupass.Text))
            {
                errorProvider4.SetError(txtupass, "Password required!");
            }
            string mobileNumber = txtumob.Text.Trim();

            if (string.IsNullOrEmpty(mobileNumber))
            {
                errorProvider2.SetError(txtumob, "Mobile number is required!");
            }
            string emailAddress = txtuemail.Text.Trim();

            if (string.IsNullOrEmpty(emailAddress))
            {
                errorProvider3.SetError(txtuemail, "Email address is required!");
            }
            else

            {
                string name = txtuname.Text;
                string email = txtuemail.Text;
                string mobile=txtumob.Text;
                string password=txtupass.Text;

                Forget_Pass_Page2 f1 = new Forget_Pass_Page2();
                String generatedOTP = GenerateOTP();
               
                f1.setEmail(email,generatedOTP);
                f1.setData(name,mobile,email,password);
                f1.Show();
            }
        }

            private void label1_Click(object sender, EventArgs e)
        {
              Login_Page login_Page = new Login_Page();
            login_Page.Show();
        }

        private void txtupass_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtupass.Text))
            {
                errorProvider4.SetError(txtupass, "Password required!");
            }
            else if (!Regex.IsMatch(txtupass.Text, @"^\d{8}$"))
            {
                errorProvider4.SetError(txtupass, "use numbers & min 8 digit");
            }
            else
            {
                errorProvider4.SetError(txtupass, null);
            }
        }

        private void txtuname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtuname.Text))
            {
                errorProvider1.SetError(txtuname, "Name is required!");
            }
            else if (txtuname.Text.Length < 4)
            {
                errorProvider1.SetError(txtuname, "Name must be at least 4 characters long!");
            }
            else
            {
                errorProvider1.SetError(txtuname, null);
            }

        }

        private void txtumob_Validating(object sender, CancelEventArgs e)
        {
            // Assuming txtMobile is the TextBox for entering the mobile number
            string mobileNumber = txtumob.Text.Trim();

            if (string.IsNullOrEmpty(mobileNumber))
            {
                errorProvider2.SetError(txtumob, "Mobile number is required!");
            }
            else if (!Regex.IsMatch(mobileNumber, @"^\d{10}$"))
            {
                errorProvider2.SetError(txtumob, "Invalid mobile number. It should be 10 digits long.");
            }
            else
            {
                errorProvider2.SetError(txtumob, null);
            }


        }

        private void txtuemail_Validating(object sender, CancelEventArgs e)
        {
            // Assuming txtEmail is the TextBox for entering the email address
            string emailAddress = txtuemail.Text.Trim();

            if (string.IsNullOrEmpty(emailAddress))
            {
                errorProvider3.SetError(txtuemail, "Email address is required!");
            }
            else if (!Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") || !emailAddress.Contains("@") || !emailAddress.Contains(".") || emailAddress.IndexOf("@") > emailAddress.LastIndexOf("."))
            {
                errorProvider3.SetError(txtuemail, "Invalid email address!");
            }
            else
            {
                errorProvider3.SetError(txtuemail, null);
            }

        }
        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void Signup_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
