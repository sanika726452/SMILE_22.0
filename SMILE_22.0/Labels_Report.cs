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
    public partial class Labels_Report : Form
    {
        public Labels_Report()
        {
            InitializeComponent();
        }

        private void Labels_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMILEDataSet8.Labels' table. You can move, or remove it, as needed.
            this.labelsTableAdapter.Fill(this.sMILEDataSet8.Labels);

            this.reportViewer1.RefreshReport();
        }
    }
}
