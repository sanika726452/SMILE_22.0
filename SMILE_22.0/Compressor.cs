using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILE_22._0
{
    public partial class Compressor : Form
    {
        public Compressor()
        {
            InitializeComponent();
            button3.Hide();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Load the image and add it to your form or any other control
                try
                {
                    Image selectedImage = Image.FromFile(selectedImagePath);

                    // Assuming you have a PictureBox named pictureBox1 on your form
                    pictureBox1.Image = selectedImage;

                    // If you want to resize the PictureBox to fit the image
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    // You can perform other actions with the image as needed
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            button4.Hide();
            
            ShowOriginalSize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if there is an image in the PictureBox
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please compress an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Allow the user to choose the location to save the image
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg";
            saveFileDialog.Title = "Save Compressed Image";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the compressed image to the chosen location
                pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image originalImage = pictureBox1.Image;

            if (originalImage == null)
            {
                MessageBox.Show("Please load an image into the PictureBox first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the size of the original image
            long originalSize = GetImageSize(originalImage);
            // sizeLabel.Text = $"Original Size: {FormatSize(originalSize)}";

            // Set up compression parameters
            System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter qualityParam = new EncoderParameter(qualityEncoder, 85L); // Adjust quality value as needed
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            // Get the JPEG codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            // Save the compressed image
            originalImage.Save("compressed_image.jpg", jpegCodec, encoderParams);

            // Display the compressed image in the PictureBox
            pictureBox1.Image = Image.FromFile("compressed_image.jpg");

            // Get the size of the compressed image
            long compressedSize = GetImageSize(pictureBox1.Image);
            originalSizeLabel.Text += $"\nCompressed Size: {FormatSize(compressedSize)}";
            button3.Show();
        }
        private long GetImageSize(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg); // Save in JPEG format for size calculation
                return ms.Length;
            }
        }

        // Helper method to get the JPEG codec
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }

            return null;
        }

        // Helper method to format file size
        private string FormatSize(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;

            while (bytes >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                bytes /= 1024;
                suffixIndex++;
            }

            return $"{bytes} {suffixes[suffixIndex]}";
        }

        private void ShowOriginalSize()
        {
            if (pictureBox1.Image != null)
            {
                long originalSize = GetImageSize(pictureBox1.Image);
                originalSizeLabel.Text = $"Original Image Size: {FormatSize(originalSize)}";
            }
            else
            {
                originalSizeLabel.Text = "Original Image Size: N/A";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Advance_Feauture_Page advance_Feauture_Page=new Advance_Feauture_Page();
            advance_Feauture_Page.Show();
        }
    }

    }
