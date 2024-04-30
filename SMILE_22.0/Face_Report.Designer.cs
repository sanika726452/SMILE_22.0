namespace SMILE_22._0
{
    partial class Face_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.faceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMILEDataSet7 = new SMILE_22._0.SMILEDataSet7();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.faceTableAdapter = new SMILE_22._0.SMILEDataSet7TableAdapters.FaceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.faceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMILEDataSet7)).BeginInit();
            this.SuspendLayout();
            // 
            // faceBindingSource
            // 
            this.faceBindingSource.DataMember = "Face";
            this.faceBindingSource.DataSource = this.sMILEDataSet7;
            // 
            // sMILEDataSet7
            // 
            this.sMILEDataSet7.DataSetName = "SMILEDataSet7";
            this.sMILEDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.faceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMILE_22._0.Face_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // faceTableAdapter
            // 
            this.faceTableAdapter.ClearBeforeFill = true;
            // 
            // Face_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Face_Report";
            this.Text = "Face_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Face_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.faceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMILEDataSet7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SMILEDataSet7 sMILEDataSet7;
        private System.Windows.Forms.BindingSource faceBindingSource;
        private SMILEDataSet7TableAdapters.FaceTableAdapter faceTableAdapter;
    }
}