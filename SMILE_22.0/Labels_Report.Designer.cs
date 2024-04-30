namespace SMILE_22._0
{
    partial class Labels_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sMILEDataSet8 = new SMILE_22._0.SMILEDataSet8();
            this.labelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelsTableAdapter = new SMILE_22._0.SMILEDataSet8TableAdapters.LabelsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sMILEDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.labelsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMILE_22._0.Labels_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sMILEDataSet8
            // 
            this.sMILEDataSet8.DataSetName = "SMILEDataSet8";
            this.sMILEDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelsBindingSource
            // 
            this.labelsBindingSource.DataMember = "Labels";
            this.labelsBindingSource.DataSource = this.sMILEDataSet8;
            // 
            // labelsTableAdapter
            // 
            this.labelsTableAdapter.ClearBeforeFill = true;
            // 
            // Labels_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Labels_Report";
            this.Text = "Labels_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Labels_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sMILEDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SMILEDataSet8 sMILEDataSet8;
        private System.Windows.Forms.BindingSource labelsBindingSource;
        private SMILEDataSet8TableAdapters.LabelsTableAdapter labelsTableAdapter;
    }
}