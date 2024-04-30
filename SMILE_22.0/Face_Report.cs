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
    public partial class Face_Report : Form
    {
        public Face_Report()
        {
            InitializeComponent();
        }

        private void Face_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMILEDataSet7.Face' table. You can move, or remove it, as needed.
            this.faceTableAdapter.Fill(this.sMILEDataSet7.Face);

            this.reportViewer1.RefreshReport();
        }
    }
}
