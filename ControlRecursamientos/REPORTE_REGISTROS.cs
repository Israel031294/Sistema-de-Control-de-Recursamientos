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
    public partial class REPORTE_REGISTROS : Form
    {
        public REPORTE_REGISTROS()
        {
            InitializeComponent();
        }

        private void REPORTE_REGISTROS_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'RECURSAMIENTODataSet.ALUMNO' Puede moverla o quitarla según sea necesario.
            this.ALUMNOTableAdapter.Fill(this.RECURSAMIENTODataSet.ALUMNO);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
