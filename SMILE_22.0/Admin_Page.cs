using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace SMILE_22._0
{
    public partial class Admin_Page : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";

        public Admin_Page()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Admin_Forget1 forget = new Admin_Forget1();
            forget.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtuemail.Text;
            string password = txtupass.Text;
            string name = txtuname.Text;
            string mobile = txtumob.Text;

            string query = "SELECT COUNT(*) FROM [dbo].[Admin] WHERE Admin_email = @Email AND Admin_password = @Password AND Admin_name = @Name AND Admin_mobile = @Mobile";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Mobile", mobile);

                    try
                    {
                        connection.Open();
                        int adminCount = (int)command.ExecuteScalar();

                        if (adminCount > 0)
                        {
                            MessageBox.Show("Login successful!");
                            // You can add code here to navigate to the main application form
                            Admin_Reporting admin_Reporting = new Admin_Reporting();
                            admin_Reporting.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email, password, name, or mobile number. Please try again.");
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

        private void txtupass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
