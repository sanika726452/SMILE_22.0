using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMILE_22._0
{
    public partial class Advance_Feauture_Page : Form
    {
        private List<string> imagePaths = new List<string>();

        public Advance_Feauture_Page()
        {
            InitializeComponent();
            AdvancelistView1.SmallImageList = new ImageList();
            AdvancelistView1.SmallImageList.ImageSize = new Size(150, 150);

         
            AdvancelistView1.View = View.LargeIcon;
            AdvancelistView1.GridLines = true;
            AdvancelistView1.HeaderStyle = ColumnHeaderStyle.None; // Hide column headers
            AdvancelistView1.MultiSelect = false;
            LoadDefaultImages();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder containing images";
                folderBrowserDialog.ShowNewFolderButton = false;

                try
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFolderPath = folderBrowserDialog.SelectedPath;

                        // Hide all controls except ListView and PictureBox
                        /*  foreach (Control control in Controls)
                          {
                              if (control != listView1 && control != pictureBox1)
                              {
                                  control.Visible = false;
                              }
                          }

                          // Make ListView and PictureBox occupy the entire screen
                          listView1.Dock = DockStyle.Fill;
                          pictureBox1.Dock = DockStyle.Fill;
  */
                        // Clear existing items in ListView and imagePaths
                        AdvancelistView1.Items.Clear();
                        imagePaths.Clear();

                        // Load images and display in PictureBox and ListView
                        LoadImagesFromFolder(selectedFolderPath);

                        // Show ListView and PictureBox
                        AdvancelistView1.Visible = true;
                        pictureBox1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDefaultImages()
        {
            ImageList largeImageList = new ImageList();
            largeImageList.ImageSize = new Size(150, 150);

            for (int i = 0; i < 100; i++)
            {
                // Create a ListViewItem for each row
                ListViewItem item = new ListViewItem();

                // Set the image key for the item (assuming you have image keys)
                item.ImageKey = i.ToString();

                // Set text for each column (adjust this based on your data)
                for (int j = 2; j <= 7; j++)
                {
                    item.SubItems.Add($"Column {j} - {i}");
                }

                // Add the item to the ListView
                AdvancelistView1.Items.Add(item);

                // Add a placeholder image to the LargeImageList
                largeImageList.Images.Add(i.ToString(), new Bitmap(150, 150));
            }

            // Set the LargeImageList property of the ListView
            AdvancelistView1.LargeImageList = largeImageList;

        }

        private void LoadImagesFromFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(file => file.ToLower().EndsWith(".jpg") ||
                                   file.ToLower().EndsWith(".jpeg") ||
                                   file.ToLower().EndsWith(".png") ||
                                   file.ToLower().EndsWith(".gif") ||
                                   file.ToLower().EndsWith(".bmp"))
                    .ToArray();

                if (imageFiles.Length > 0)
                {
                    AdvancelistView1.Items.Clear(); // Clear existing items
                    imagePaths.Clear();

                    foreach (string imageFile in imageFiles)
                    {
                        // Add the full path of the image to imagePaths
                        imagePaths.Add(imageFile);

                        // Create a ListViewItem with a unique identifier (e.g., index)
                        ListViewItem item = new ListViewItem();
                        int index = imagePaths.IndexOf(imageFile);
                        item.ImageKey = index.ToString();  // Use the index as the key

                        // Load the original image
                        using (Image originalImage = Image.FromFile(imageFile))
                        {
                            // Create a thumbnail for the SmallImageList
                            Image thumbnail = originalImage.GetThumbnailImage(256, 256, null, IntPtr.Zero);

                            // Add the thumbnail and file name to the ListViewItem
                            AdvancelistView1.SmallImageList.Images.Add(index.ToString(), thumbnail);  // Use the index as the key
                            item.SubItems.Add(Path.GetFileName(imageFile));
                        }

                        // Add the item to the ListView
                        AdvancelistView1.Items.Add(item);
                    }

                    // Display the first image (optional)
                    if (AdvancelistView1.Items.Count > 0)
                    {
                        AdvancelistView1.Items[0].Selected = true;
                    }
                }
                else
                {
                    MessageBox.Show("No image files found in the selected folder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selected folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AdvancelistView1.LargeImageList = AdvancelistView1.SmallImageList;

        }

        private void AdvancelistView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Label_Page tag_Page = new Label_Page();
            tag_Page.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Compressor c = new Compressor();
            c.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Faces_Page faces_Page = new Faces_Page();
            faces_Page.Show();
        }
    }

       
      
    
}
