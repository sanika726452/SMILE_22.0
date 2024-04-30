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
  
    public partial class Zoom : Form
    {
        private Home_Page originalForm;
        private bool Dragging;
        private int xPos;
        private int yPos;
        private int zoom = 0;
        public Zoom(Home_Page originalForm)
        {
            InitializeComponent();

            this.pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            this.originalForm = originalForm;
        }
        public Image ImageFromForm1
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        private void PictureBox1_MouseWheel(Object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (zoom >= 1 && zoom <= 10)
                {
                    int previousWidth = pictureBox1.Width;
                    int previousHeight = pictureBox1.Height;

                    pictureBox1.Width += 100;
                    pictureBox1.Height += 100;

                    // Adjust the position to keep the center fixed
                    pictureBox1.Left -= (pictureBox1.Width - previousWidth) / 2;
                    pictureBox1.Top -= (pictureBox1.Height - previousHeight) / 2;

                    zoom++;
                }
            }
            else
            {
                if (zoom > 1 && zoom <= 10)
                {
                    int previousWidth = pictureBox1.Width;
                    int previousHeight = pictureBox1.Height;

                    pictureBox1.Width -= 100;
                    pictureBox1.Height -= 100;

                    // Adjust the position to keep the center fixed
                    pictureBox1.Left -= (pictureBox1.Width - previousWidth) / 2;
                    pictureBox1.Top -= (pictureBox1.Height - previousHeight) / 2;

                    zoom--;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (zoom == 0)
            {
                zoom++;
            }

            if (zoom >= 1 && zoom <= 10)
            {
                int previousWidth = pictureBox1.Width;
                int previousHeight = pictureBox1.Height;

                pictureBox1.Width += 100;
                pictureBox1.Height += 100;

                // Adjust the position to keep the center fixed
                pictureBox1.Left -= (pictureBox1.Width - previousWidth) / 2;
                pictureBox1.Top -= (pictureBox1.Height - previousHeight) / 2;
                ++zoom;

            }
        }

        private void Zoom_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageFromForm1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            originalForm.Show();
            this.Close();
           
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (zoom >= 2 && zoom <= 12)
            {
                int previousWidth = pictureBox1.Width;
                int previousHeight = pictureBox1.Height;

                pictureBox1.Width -= 100;
                pictureBox1.Height -= 100;

                // Adjust the position to keep the center fixed
                pictureBox1.Left -= (pictureBox1.Width - previousWidth) / 2;
                pictureBox1.Top -= (pictureBox1.Height - previousHeight) / 2;

                zoom--;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;

            if (Dragging && c != null)
            {
                if (zoom > 1)
                {
                    c.Top = e.Y + c.Top - yPos;
                    c.Left = e.X + c.Left - xPos;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();

        }
    }
}
