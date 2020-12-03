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
    public partial class CONSULTA_REGISTROS : Form
    {
        public CONSULTA_REGISTROS()
        {
            InitializeComponent();
        }
        SGBD registro = new SGBD();
        private void CONSULTA_REGISTROS_Load(object sender, EventArgs e)
        {
            registro.visualizar("SELECT Boleta, Nombre, Ape_Pat, Ape_Mat, ID_Materia from ALUMNO", "ALUMNO");
            this.dataGridView1.DataSource = registro.ds.Tables["ALUMNO"];
            this.dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TRANSACCIONES regresar = new TRANSACCIONES();
            regresar.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            REPORTE_REGISTROS registro = new REPORTE_REGISTROS();
            registro.Show();
            this.Hide();
        }
    }
}
