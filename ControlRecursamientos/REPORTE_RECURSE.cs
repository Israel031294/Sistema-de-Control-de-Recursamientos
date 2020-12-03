using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlRecursamientos
{
    public partial class REPORTE_RECURSE : Form
    {
        private string _boleta;
        // setter y getter boleta desde LOGUEO_RECURSADOR
        public string BOLETA
        {
            get { return _boleta; }
            set { _boleta = value; }
        }
        public REPORTE_RECURSE()
        {
            InitializeComponent();
        }

        private void REPORTE_RECURSE_Load(object sender, EventArgs e)
        {
            label1.Text = BOLETA;
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.sp_alumno' 
            this.sp_alumnoTableAdapter.Fill(this.DataSet1.sp_alumno, int.Parse(label1.Text));
            this.reportViewer1.RefreshReport();
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
