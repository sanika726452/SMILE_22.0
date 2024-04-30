﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace SMILE_22._0
{
    public partial class Faces_Page : Form
    {
        private ImageList collectionImageList = new ImageList();
        private ImageList collectionIconList = new ImageList();
        private List<ImageCollection1> collections = new List<ImageCollection1>();
        private const string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";

        public Faces_Page()
        {
            InitializeComponent();
           


            listView1.View = View.LargeIcon; // Set the view to LargeIcon
            listView1.LargeImageList = imageList1;
            listView1.LargeImageList.ImageSize = new Size(256, 256);
            listView2.LargeImageList = collectionIconList;
            listView1.Hide();
            pictureBox4.Hide();
            
            pictureBox3.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Faces_Page_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Advance_Feauture_Page advance_Feauture_Page=new Advance_Feauture_Page();
            advance_Feauture_Page.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            listView1.Clear();// Check if an item is selected in the ListView
            if (listView2.SelectedItems.Count > 0)
            {
                int selectedIndex = listView2.SelectedIndices[0];
                ImageCollection1 selectedCollection = collections[selectedIndex];

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Connect to the database
                    string connectionString = @"Data Source=DESKTOP-2I8GI87\SQLEXPRESS;Initial Catalog=SMILE;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        foreach (string fileName in openFileDialog.FileNames)
                        {
                            try
                            {
                                // Add images to the selected collection
                                Image image = Image.FromFile(fileName);
                                selectedCollection.Images.Add(image);

                                // Insert image into database with collection name
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO Face (Image_name, Face_name, ImageData) VALUES (@Filename, @CollectionName, @ImageData)", connection))
                                {
                                    // Assuming you have a table named Images with columns Filename, CollectionName, and ImageData (varbinary)
                                    cmd.Parameters.AddWithValue("@Filename", Path.GetFileName(fileName));
                                    cmd.Parameters.AddWithValue("@CollectionName", selectedCollection.Name);
                                    byte[] imageData;
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        image.Save(ms, ImageFormat.Jpeg); // Change ImageFormat as needed
                                        imageData = ms.ToArray();
                                    }
                                    cmd.Parameters.AddWithValue("@ImageData", imageData);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                // Handle exceptions (e.g., invalid image file)
                                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    // Update the ImageList to include the new images
                    imageList1.Images.Clear();
                    foreach (Image image in selectedCollection.Images)
                    {
                        imageList1.Images.Add(image);
                    }

                    // Set the LargeImageList property of listView1
                    listView1.LargeImageList = imageList1;

                    // Add items to the ListView with the corresponding image index
                    for (int i = 0; i < selectedCollection.Images.Count; i++)
                    {
                        listView1.Items.Add(new ListViewItem { ImageIndex = i });
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Face first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string collectionName = PromptForCollectionName("Enter Face Name");

            if (collectionName != null)
            {
                ImageCollection1 newCollection = new ImageCollection1(collectionName);

                collections.Add(newCollection);

               
                listView2.Items.Add(newCollection.Name);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            listView1.Clear();// Check if an item is selected in the ListView
            if (listView2.SelectedItems.Count > 0)
            {
                int selectedIndex = listView2.SelectedIndices[0];
                ImageCollection1 selectedCollection = collections[selectedIndex];

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            // Add images to the selected collection
                            Image image = Image.FromFile(fileName);
                            selectedCollection.Images.Add(image);
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions (e.g., invalid image file)
                            MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Update the ImageList to include the new images
                    imageList1.Images.Clear();
                    foreach (Image image in selectedCollection.Images)
                    {
                        imageList1.Images.Add(image);
                    }

                    // Set the LargeImageList property of listView1
                    listView1.LargeImageList = imageList1;

                    // Add items to the ListView with the corresponding image index
                    for (int i = 0; i < selectedCollection.Images.Count; i++)
                    {
                        listView1.Items.Add(new ListViewItem { ImageIndex = i });
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select Face first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Advance_Feauture_Page advance_Feauture_Page = new Advance_Feauture_Page();
            advance_Feauture_Page.Show();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            pictureBox4.Show();
            listView1.Show();
           
            // Check if any collection is selected
            if (listView2.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView2.SelectedIndices[0];
                ImageCollection1 selectedCollection = collections[selectedIndex];

                // Display all images in the selected collection in listView1
                for (int i = 0; i < selectedCollection.Images.Count; i++)
                {
                    // Add the image to the ImageList
                    listView1.LargeImageList.Images.Add(selectedCollection.Images[i]);

                    // Create a new ListViewItem with the corresponding image index
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = i;

                    // Add the ListViewItem to listView1
                    listView1.Items.Add(item);
                }
            }
            else
            {
              
                foreach (ImageCollection1 collection in collections)
                {
                    for (int i = 0; i < collection.Images.Count; i++)
                    {
                        // Add the image to the ImageList
                        listView1.LargeImageList.Images.Add(collection.Images[i]);

                        // Create a new ListViewItem with the corresponding image index
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = i;

                        // Add the ListViewItem to listView1
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox3.Show();
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].ImageIndex;

               
                if (selectedIndex >= 0 && selectedIndex < listView1.LargeImageList.Images.Count)
                {
                    pictureBox3.Image = listView1.LargeImageList.Images[selectedIndex];
                }
            }
        }
        private string PromptForCollectionName(string prompt)
        {
            // Show an input dialog to get the collection name from the user
            using (var form = new Form())
            using (var label = new Label())
            using (var textBox = new TextBox())
            using (var okButton = new Button())
            {
                form.Text = prompt;
                label.Text = "Provide Face detail:";
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;

                form.ClientSize = new Size(300, 100);
                label.Size = new Size(200, 20);
                textBox.Size = new Size(200, 20);
                okButton.Size = new Size(80, 30);

                label.Location = new Point(20, 20);
                textBox.Location = new Point(20, 50);
                okButton.Location = new Point(230, 45);

                form.Controls.AddRange(new Control[] { label, textBox, okButton });

                var result = form.ShowDialog();
                return result == DialogResult.OK ? textBox.Text : null;
            }
        }

    }
    public class ImageCollection1
    {
        public string Name { get; set; }
        public List<Image> Images { get; set; }

        public ImageCollection1(string name)
        {
            Name = name;
            Images = new List<Image>();
        }

        public override string ToString()
        {
            return Name;
        }



    }
}