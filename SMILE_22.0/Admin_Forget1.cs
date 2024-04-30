using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILE_22._0
{
    public partial class Admin_Forget1 : Form
    {
        Admin_forget2 admin_Forget2 = new Admin_forget2();
        public Admin_Forget1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String generatedOTP = GenerateOTP();
            string textBoxEmail = textBox1.Text;
           admin_Forget2.setEmail(textBoxEmail, generatedOTP);
            admin_Forget2.Show();
        }

        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
