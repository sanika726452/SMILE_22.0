using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
//using static System.Net.WebRequestMethods;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;




namespace SMILE_22._0
{
    public partial class Home_Page : Form
    {
        private List<string> imagePaths = new List<string>();
        private Size originalPictureBoxSize;
        private Point originalPictureBoxLocation;
        private List<string> recentlySelectedItems = new List<string>();
        private bool isPictureBoxMaximized = false;
        private int currentIndex = 0;
        private List<int> displayedImageIndices = new List<int>();
        private string pinnedImagesFilePath = "pinnedImages.txt";
        Pinned_Page destinationForm = new Pinned_Page();

        public Home_Page()
        {
            InitializeComponent();
            KeyPreview = true;
            listView1.SmallImageList = new ImageList();
            listView1.SmallImageList.ImageSize = new Size(150, 150); // Adjust the size as needed

            //  listView1.View = View.Details; // Set ListView to Details view
            listView1.View = View.LargeIcon;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.None; // Hide column headers
            listView1.MultiSelect = false;
            panel5.Hide();
            panel5.Dock = DockStyle.Fill;
            this.KeyDown += Home_Page_KeyDown;
            //  listView1.Columns.Add("File Name", 150); // Add a column for file names

            pinList.SmallImageList = new ImageList();
            pinList.SmallImageList.ImageSize = new Size(256, 256);
            pinList.GridLines = true;
         pinList.HeaderStyle = ColumnHeaderStyle.None; // Hide column headers
            pinList.MultiSelect = false;
            recentItemsListView.SmallImageList = new ImageList();
            recentItemsListView.SmallImageList.ImageSize = new Size(150, 150);
            recentItemsListView.View = View.LargeIcon;
            recentItemsListView.GridLines = true;
            recentItemsListView.HeaderStyle = ColumnHeaderStyle.None;
            recentItemsListView.MultiSelect = false;

            roundButton.FlatStyle = FlatStyle.Flat;
            roundButton.FlatAppearance.BorderSize = 0; // Set the border size to 0
            roundButton.BackColor = System.Drawing.Color.LightBlue;
            roundButton.Size = new System.Drawing.Size(100, 100);
            roundButton.Paint += RoundButton_Paint;


            panel6.Hide();
            panel7.Hide();
            button2.Hide();
            button6.Hide();
            pinList.Hide();
            InitializeMouseEvents();
            LoadDefaultImages();

        }
        private void InitializeMouseEvents()
        {

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
                listView1.Items.Add(item);

                // Add a placeholder image to the LargeImageList
                largeImageList.Images.Add(i.ToString(), new Bitmap(150, 150));
            }

            // Set the LargeImageList property of the ListView
            listView1.LargeImageList = largeImageList;

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
                    listView1.Items.Clear(); // Clear existing items
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
                            listView1.SmallImageList.Images.Add(index.ToString(), thumbnail);  // Use the index as the key
                            item.SubItems.Add(Path.GetFileName(imageFile));
                        }

                        // Add the item to the ListView
                        listView1.Items.Add(item);
                    }

                    // Display the first image (optional)
                    if (listView1.Items.Count > 0)
                    {
                        listView1.Items[0].Selected = true;
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
            listView1.LargeImageList = listView1.SmallImageList;

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
                        listView1.Items.Clear();
                        imagePaths.Clear();

                        // Load images and display in PictureBox and ListView
                        LoadImagesFromFolder(selectedFolderPath);

                        // Show ListView and PictureBox
                        listView1.Visible = true;
                        pictureBox1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //  Photos_Page photos_Page = new Photos_Page();
            //  photos_Page.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Advance_Feauture_Page advance_Feauture_Page = new Advance_Feauture_Page();
            advance_Feauture_Page.Show();

        }













        private void DisplayImageByIndex(int index)
        {
            if (index >= 0 && index < imagePaths.Count)
            {
                // Load the original image into the PictureBox
                pictureBox1.Image = Image.FromFile(imagePaths[index]);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;  // Set PictureBoxSizeMode to Zoom
                pictureBox1.Show();

                // Display the name of the selected picture on the label
                // label1.Text = Path.GetFileName(imagePaths[index]);
            }


        }














        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void next_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Use Index instead of ImageKey
                int selectedIndex = selectedItem.Index;

                // Check if the selected index is within the bounds of imagePaths
                if (selectedIndex >= 0 && selectedIndex < imagePaths.Count)
                {
                    // Load the original image into the PictureBox using the selected index
                    pictureBox1.Image = Image.FromFile(imagePaths[selectedIndex]);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;  // Set PictureBoxSizeMode to Zoom
                    pictureBox1.Show();

                    // Update the currentIndex based on the selected image
                    currentIndex = selectedIndex;
                    string selectedPath = imagePaths[selectedIndex];

                    // Add the selected item to the recentlySelectedItems list
                    if (!recentlySelectedItems.Contains(selectedPath))
                    {
                        recentlySelectedItems.Insert(0, selectedPath);

                        // Ensure the list only contains the most recent 15 items
                        if (recentlySelectedItems.Count > 15)
                        {
                            recentlySelectedItems.RemoveAt(15);
                        }

                        // Add the displayed index to the list
                        displayedImageIndices.Insert(0, selectedIndex);

                        // Ensure the list only contains the most recent 15 indices
                        if (displayedImageIndices.Count > 15)
                        {
                            displayedImageIndices.RemoveAt(15);
                        }

                        // Update the recentItemsListView
                        UpdateRecentlySelectedListView();
                    }



                }
            }




            panel5.Show();


        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            listView1.Hide();
            panel5.Hide();
            panel6.Show();
            recentItemsListView.Show();
            pinList.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel5.Hide();


        }
        private void Home_Page_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the PictureBox is visible
            if (pictureBox1.Visible)
            {
                // Handle arrow key presses
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (currentIndex > 0)
                        {
                            currentIndex--;
                            DisplayImageByIndex(currentIndex);
                        }
                        break;
                    case Keys.Right:
                        if (currentIndex < imagePaths.Count - 1)
                        {
                            currentIndex++;
                            DisplayImageByIndex(currentIndex);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            button2.Hide();
            button6.Hide();
            panel7.Hide();
            if (isPictureBoxMaximized)
            {
                // If already maximized, restore to original size and location
                pictureBox1.Dock = DockStyle.None;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = originalPictureBoxSize; // Restore the original size
                pictureBox1.Location = originalPictureBoxLocation; // Restore the original location


            }
            else
            {
                // If not maximized, fill the panel
                originalPictureBoxSize = pictureBox1.Size; // Store the original size
                originalPictureBoxLocation = pictureBox1.Location; // Store the original location

                pictureBox1.Dock = DockStyle.Fill;
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
               
            }

            isPictureBoxMaximized = !isPictureBoxMaximized;
        }

        private void pictureBox1_Click_4(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            //panel5.Hide();
            listView1.Show();
            recentItemsListView.Hide();
           
           

        }

        private void UpdateRecentlySelectedListView()
        {
            recentItemsListView.Items.Clear();
            recentItemsListView.SmallImageList.Images.Clear(); // Clear existing images

            foreach (int index in displayedImageIndices)
            {
                string imagePath = imagePaths[index];

                ListViewItem item = new ListViewItem();
                item.ImageKey = index.ToString();

                using (Image originalImage = Image.FromFile(imagePath))
                {
                    Image thumbnail = originalImage.GetThumbnailImage(256, 256, null, IntPtr.Zero);
                    recentItemsListView.SmallImageList.Images.Add(index.ToString(), thumbnail);
                    item.SubItems.Add(Path.GetFileName(imagePath));
                }

                recentItemsListView.Items.Add(item);
            }

            recentItemsListView.LargeImageList = recentItemsListView.SmallImageList;
        }

        private void recentItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recentItemsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = recentItemsListView.SelectedItems[0];

                // Use Index instead of ImageKey
                int selectedIndex = selectedItem.Index;

                // Check if the selected index is within the bounds of imagePaths
                if (selectedIndex >= 0 && selectedIndex < imagePaths.Count)
                {
                    // Load the original image into the PictureBox using the selected index
                    pictureBox1.Image = Image.FromFile(imagePaths[selectedIndex]);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;  // Set PictureBoxSizeMode to Zoom
                    pictureBox1.Show();

                    // Update the currentIndex based on the selected image
                    currentIndex = selectedIndex;
                    string selectedPath = imagePaths[selectedIndex];

                    // Add the selected item to the recentlySelectedItems list
                    if (!recentlySelectedItems.Contains(selectedPath))
                    {
                        recentlySelectedItems.Insert(0, selectedPath);

                        // Ensure the list only contains the most recent 15 items
                        if (recentlySelectedItems.Count > 15)
                        {
                            recentlySelectedItems.RemoveAt(15);
                        }

                        // Add the displayed index to the list
                        displayedImageIndices.Insert(0, selectedIndex);

                        // Ensure the list only contains the most recent 15 indices
                        if (displayedImageIndices.Count > 15)
                        {
                            displayedImageIndices.RemoveAt(15);
                        }

                        // Update the recentItemsListView
                        UpdateRecentlySelectedListView();
                    }

                }
            }
            panel5.Show();
        }




        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void RoundButton_Paint(object sender, PaintEventArgs e)
        {
            // Draw a round button by using the Graphics object
            Button button = (Button)sender;
            GraphicsPath buttonPath = new GraphicsPath();
            buttonPath.AddEllipse(0, 0, button.Width, button.Height);
            button.Region = new Region(buttonPath);
        }

        private void roundButton_Click(object sender, EventArgs e)
        {
            if (panel7.Visible != true)
            {
                panel7.Show();
            }
            else
            {
                panel7.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                if (currentIndex >= 0 && currentIndex < imagePaths.Count)
                {
                    string currentImagePath = imagePaths[currentIndex];

                    if (!string.IsNullOrEmpty(currentImagePath))
                    {
                        ListViewItem newItem = new ListViewItem();
                        newItem.ImageKey = currentIndex.ToString();

                        using (Image originalImage = Image.FromFile(currentImagePath))
                        {
                            Image thumbnail = originalImage.GetThumbnailImage(256, 256, null, IntPtr.Zero);
                            pinList.SmallImageList.Images.Add(currentIndex.ToString(), thumbnail);
                            newItem.ImageKey = currentIndex.ToString();
                            newItem.SubItems.Add(Path.GetFileName(currentImagePath));
                        }

                        pinList.Items.Add(newItem);
                        pinList.LargeImageList = pinList.SmallImageList;

                        // Save the pinned image path to the file
                        SavePinnedImage(currentImagePath);

                        MessageBox.Show("Image Pinned");
                    }
                    else
                    {
                        MessageBox.Show("The image path is empty or null.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid currentIndex.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image_Page p = new Image_Page();
            // Pass the image from PictureBox in Form1 to PictureBox in Form2
            p.ImageFromForm1 = pictureBox1.Image;
            p.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (currentIndex >= 0 && currentIndex < imagePaths.Count)
            {
                string currentImagePath = imagePaths[currentIndex];

                if (!string.IsNullOrEmpty(currentImagePath))
                {
                    // Get image details
                    Image image = Image.FromFile(currentImagePath);
                    string fileName = Path.GetFileName(currentImagePath);
                    string fullPath = Path.GetFullPath(currentImagePath); // Full path
                    long fileSizeInBytes = new FileInfo(currentImagePath).Length;

                    // Convert fileSize to KB or MB based on its magnitude
                    string fileSize;
                    if (fileSizeInBytes < 1024)  // Less than 1KB
                    {
                        fileSize = $"{fileSizeInBytes} bytes";
                    }
                    else if (fileSizeInBytes < 1024 * 1024)  // Less than 1MB
                    {
                        fileSize = $"{fileSizeInBytes / 1024} KB";
                    }
                    else  // 1MB or greater
                    {
                        fileSize = $"{fileSizeInBytes / (1024 * 1024)} MB";
                    }

                    DateTime imageDate = File.GetCreationTime(currentImagePath); // Use CreationTime

                    string resolution = $"{image.Width} x {image.Height}";
                    string format = ImageFormatToString(image.RawFormat); // Convert ImageFormat to string

                    // Construct the details message
                    string detailsMessage = $"File Name: {fileName}{Environment.NewLine}Full Path: {fullPath}{Environment.NewLine}File Size: {fileSize}{Environment.NewLine}Image Date: {imageDate}{Environment.NewLine}Resolution: {resolution}{Environment.NewLine}Format: {format}";

                    // Display details in a message box
                    MessageBox.Show(detailsMessage, "Image Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Copy details to clipboard
                    Clipboard.SetText(detailsMessage);
                }
            }
        }

        private string ImageFormatToString(ImageFormat format)
        {
            if (format.Equals(ImageFormat.Jpeg))
                return "JPEG";
            else if (format.Equals(ImageFormat.Png))
                return "PNG";
            else if (format.Equals(ImageFormat.Gif))
                return "GIF";
            else if (format.Equals(ImageFormat.Bmp))
                return "BMP";
            else
                return "Unknown";
        }
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void next_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Zoom zoomForm = new Zoom(this);
            zoomForm.ImageFromForm1 = pictureBox1.Image;
            zoomForm.Show();
            this.Hide();
        }
        public void showPageHome()
        {
            listView1.Show();
            this.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the index of the selected item
                int selectedIndex = listView1.SelectedItems[0].Index;

                // Remove the image path from the imagePaths list
                if (selectedIndex >= 0 && selectedIndex < imagePaths.Count)
                {
                    imagePaths.RemoveAt(selectedIndex);
                    pictureBox1.Image = null;
                }

                // Remove the item from the ListView
                listView1.Items.RemoveAt(selectedIndex);
            }

        }

        private void SavePinnedImage(string imagePath)
        {
            try
            {
                // Append the image path to the file
                File.AppendAllLines(pinnedImagesFilePath, new[] { imagePath });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save pinned image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPinnedImages()
        {
            try
            {
                // Clear existing items from the ListView
                pinList.Items.Clear();

                // Read the pinned image paths from the file
                if (File.Exists(pinnedImagesFilePath))
                {
                    imagePaths.AddRange(File.ReadAllLines(pinnedImagesFilePath));

                    // Load pinned images into the ListView
                    foreach (string imagePath in imagePaths)
                    {
                        // Add your code to create ListViewItems and display images here
                        // Example: pinListView.Items.Add(CreateListViewItem(imagePath));
                        if (File.Exists(imagePath))
                        {
                            ListViewItem newItem = new ListViewItem();
                            newItem.ImageKey = imagePath;

                            using (Image originalImage = Image.FromFile(imagePath))
                            {
                                Image thumbnail = originalImage.GetThumbnailImage(256, 256, null, IntPtr.Zero);
                                pinList.SmallImageList.Images.Add(imagePath, thumbnail);
                                newItem.ImageKey = imagePath;
                                newItem.SubItems.Add(Path.GetFileName(imagePath));
                            }

                            pinList.Items.Add(newItem);
                        }
                        else
                        {
                            // Handle the case where the file does not exist
                            MessageBox.Show($"File not found: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load pinned images: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
            SendPinListData();
            

            
        }

        private void pinListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SendPinListData()
        {
          //  DestinationForm destinationForm = new DestinationForm();

            // Call the method in DestinationForm to receive pinList
            destinationForm.ReceivePinListView(pinList);

            // Show the DestinationForm
            destinationForm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (currentIndex < imagePaths.Count - 1)
            {
                currentIndex++;
                DisplayImageByIndex(currentIndex);
            }
            else
            {
                MessageBox.Show("No more images.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayImageByIndex(currentIndex);
            }
        }
    }
}
