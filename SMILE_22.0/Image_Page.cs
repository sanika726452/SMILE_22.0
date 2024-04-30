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
    public partial class Image_Page : Form
    {
       
        //declare some variable for crop coordinates
        int crpX, crpY, rectW, rectH;
        // Declare crop pen for cropping image
        public Pen crpPen = new Pen(Color.White);
        private bool cropModeEnabled = false;


        public Image_Page()
        {
            InitializeComponent();
            InitializeMouseEvents();
            button6.Hide();
            

        }
        public Image ImageFromForm1
        {
            get { return pictureBox2.Image; }
            set { pictureBox2.Image = value; }
        }
        private void InitializeMouseEvents()
        {
            //pictureBox2.MouseDown += new MouseEventHandler(pictureBox2_MouseDown);
            //pictureBox2.MouseMove += new MouseEventHandler(pictureBox2_MouseMove);
           // pictureBox2.MouseEnter += new MouseEventHandler(pictureBox2_MouseEnter);
          //  pictureBox2.MouseUp += new MouseEventHandler(pictureBox2_MouseUp);

            // Set initial state
            cropModeEnabled = false;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Refresh the PictureBox to reflect the changes
            pictureBox2.Refresh();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button6.Show();
            
            pictureBox5.Hide();
            cropModeEnabled = !cropModeEnabled;

            if (cropModeEnabled)
            {
                Cursor = Cursors.Cross;
                crpPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
            else
            {
                Cursor = Cursors.Default;
            }

        }
       
    
        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            if (cropModeEnabled && MouseButtons == MouseButtons.Left && IsMouseOverImage())
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void pictureBox2_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (cropModeEnabled && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                crpPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                crpX = e.X;
                crpY = e.Y;
            }
        }

       

      

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (cropModeEnabled && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox2.Refresh();
                rectW = e.X - crpX;
                rectH = e.Y - crpY;
                Graphics g = pictureBox2.CreateGraphics();
                g.DrawRectangle(crpPen, crpX, crpY, rectW, rectH);
                g.Dispose();
            }
        }

        private void pictureBox2_MouseUp_1(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
           
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (cropModeEnabled && IsMouseOverImage())
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Hide();
            Cursor = Cursors.Default;
            //Now we will draw the cropped image into pictureBox2
            Bitmap bmp2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.DrawToBitmap(bmp2, pictureBox2.ClientRectangle);

            Bitmap crpImg = new Bitmap(rectW, rectH);

            for (int i = 0; i < rectW; i++)
            {
                for (int y = 0; y < rectH; y++)
                {
                    Color pxlclr = bmp2.GetPixel(crpX + i, crpY + y);
                    crpImg.SetPixel(i, y, pxlclr);
                }
            }

            pictureBox2.Image = (Image)crpImg;
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

           
            pictureBox5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Check if there is an image in the PictureBox
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Please load an image into the PictureBox first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Allow the user to choose the location and format to save the image
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif";
            saveFileDialog.Title = "Save Image";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the image to the chosen location and format
                string filePath = saveFileDialog.FileName;
                SaveImageToFile(filePath, pictureBox2.Image, GetImageFormat(filePath));
                MessageBox.Show($"Image saved successfully to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox
            if (pictureBox2.Image != null)
            {
                // Mirror the image horizontally
                pictureBox2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Refresh the PictureBox to display the mirrored image
                pictureBox2.Refresh();
            }
        }

        private bool IsMouseOverImage()
        {
            Point relativeMousePos = pictureBox2.PointToClient(MousePosition);
            return new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height).Contains(relativeMousePos);
        }
        private void SaveImageToFile(string filePath, Image image, ImageFormat format)
        {
            // Save the image to the specified file path with the chosen format
            image.Save(filePath, format);
        }

        private ImageFormat GetImageFormat(string filePath)
        {
            // Determine the ImageFormat based on the file extension
            string extension = Path.GetExtension(filePath).ToLower();

            switch (extension)
            {
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".gif":
                    return ImageFormat.Gif;
                default:
                    throw new ArgumentException("Unsupported file format");
            }
        }

    }
}
