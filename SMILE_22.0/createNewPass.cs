using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILE_22._0
{
    public partial class createNewPass : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";
        string email;
        public createNewPass()
        {
            InitializeComponent();
            user.DropDownStyle = ComboBoxStyle.DropDownList;


        }
        public void searchByEmail(string email)
        {
            this.email = email;
            findUser();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected username from the ComboBox
            string selectedUsername = user.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedUsername))
            {
                MessageBox.Show("Please select a username from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the new password from the TextBox
            string newPassword = txtpass.Text;

            // Update the password in the database
            if (UpdatePassword(selectedUsername, newPassword))
            {
                MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login_Page l=new Login_Page();
                this.Close();
                l.Show();
            }
            else
            {
                MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool UpdatePassword(string username, string newPassword)
        {
            // Replace "YourTableName" with your actual database table name
            string updateQuery = "UPDATE [dbo].[Table] SET User_password = @Password WHERE User_name = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", newPassword);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception for debugging purposes
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        private void findUser()
        {
            string emailToSearch = email;

            // Replace "YourTableName" with your actual database table name
            string query = "SELECT User_name FROM [dbo].[Table] WHERE User_email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to prevent SQL injection
                    command.Parameters.AddWithValue("@Email", emailToSearch);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        StringBuilder usernames = new StringBuilder();
                        int index = 1;
                        while (reader.Read())
                        {
                            string username = reader["User_name"].ToString();
                            user.Items.Add(username);
                            usernames.AppendLine($"{index}. {username}");
                            index++;
                        }

                            if (usernames.Length > 0)
                        {
                            lblUsernames.Text = $"Usernames associated with {emailToSearch}:\n{usernames.ToString()}";
                        }
                        else
                        {
                            lblUsernames.Text = $"No usernames found for {emailToSearch}.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblUsernames.Text = $"Error: Unable to retrieve usernames. Please try again later.";
                        // Log the exception for debugging purposes
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void user_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblUsernames_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
