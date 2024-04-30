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
    public partial class Admin_Reporting : Form
    {
        public Admin_Reporting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Report user_Report = new User_Report();
            user_Report.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Face_Report face_Report = new Face_Report();
            face_Report.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Labels_Report labels_Report = new Labels_Report();
            labels_Report.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Report admin_Report = new Admin_Report(); 
            admin_Report.Show();
        }
    }
}
