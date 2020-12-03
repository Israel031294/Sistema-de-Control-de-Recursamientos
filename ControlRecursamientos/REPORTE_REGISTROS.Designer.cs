namespace ControlRecursamientos
{
    partial class REPORTE_REGISTROS
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
            this.ALUMNOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RECURSAMIENTODataSet = new ControlRecursamientos.RECURSAMIENTODataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ALUMNOTableAdapter = new ControlRecursamientos.RECURSAMIENTODataSetTableAdapters.ALUMNOTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ALUMNOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RECURSAMIENTODataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ALUMNOBindingSource
            // 
            this.ALUMNOBindingSource.DataMember = "ALUMNO";
            this.ALUMNOBindingSource.DataSource = this.RECURSAMIENTODataSet;
            // 
            // RECURSAMIENTODataSet
            // 
            this.RECURSAMIENTODataSet.DataSetName = "RECURSAMIENTODataSet";
            this.RECURSAMIENTODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ALUMNOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControlRecursamientos.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(508, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // ALUMNOTableAdapter
            // 
            this.ALUMNOTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "SALIR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // REPORTE_REGISTROS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "REPORTE_REGISTROS";
            this.Text = "REPORTE_REGISTROS";
            this.Load += new System.EventHandler(this.REPORTE_REGISTROS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ALUMNOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RECURSAMIENTODataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ALUMNOBindingSource;
        private RECURSAMIENTODataSet RECURSAMIENTODataSet;
        private RECURSAMIENTODataSetTableAdapters.ALUMNOTableAdapter ALUMNOTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}