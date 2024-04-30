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

namespace SMILE_22._0
{
    public partial class Admin_newpass : Form
    {
        private string email;
        private const string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";

        public Admin_newpass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpass != null)
            {
                string newPassword = txtpass.Text;

                string query = "UPDATE [dbo].[Admin] SET Admin_password = @NewPassword WHERE Admin_email = @Email";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@Email", email);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("No user found with the provided email.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Unable to update password. Please try again later.");
                            // Log the exception for debugging purposes
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
        }
        public void setEmail(String  email) {
            this.email = email;
        }
    }
}
