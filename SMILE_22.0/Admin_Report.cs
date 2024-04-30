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
    public partial class Admin_Report : Form
    {
        public Admin_Report()
        {
            InitializeComponent();
        }

        private void Admin_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMILEDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.sMILEDataSet5.Admin);

            this.reportViewer1.RefreshReport();
        }
    }
}
