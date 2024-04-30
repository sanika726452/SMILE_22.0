using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMILE_22._0
{
    public partial class Pinned_Page : Form
    {
        public Pinned_Page()
        {
            InitializeComponent();
            LoadPinnedImages();
        }
        public void ReceivePinListView(ListView pinListView)
        {
            // Add the pinList ListView to the Controls collection of the destination form
            Controls.Add(pinListView);
           
            pinListView.Show();
        }
        private void LoadPinnedImages()
        {
           
        }

        private void Pinned_Page_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
        }
    }
}
