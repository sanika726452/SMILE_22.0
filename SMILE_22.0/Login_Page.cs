using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILE_22._0
{
    public partial class Login_Page : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";

        public Login_Page()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Signup_Page signup_Page = new Signup_Page();
            signup_Page.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtname.Text;
            string password = txtpass.Text;
            // Replace "YourTableName" with your actual database table name
            string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE User_name = @Username AND User_password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login successful!");
                            // You can add code here to navigate to the main application form
                            Home_Page home_Page = new Home_Page();
                            home_Page.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Unable to perform login verification. Please try again later.");
                        // Log the exception for debugging purposes
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Forget_Pass_Page1 forget_Pass_Page1 = new Forget_Pass_Page1();
            forget_Pass_Page1.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Admin_Page admin_Page = new Admin_Page();
            admin_Page.Show();
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
