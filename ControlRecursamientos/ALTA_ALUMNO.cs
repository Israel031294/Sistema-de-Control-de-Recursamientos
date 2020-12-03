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
    public partial class ALTA_ALUMNO : Form
    {
        public ALTA_ALUMNO()
        {
            InitializeComponent();
        }

        private void ALTA_ALUMNO_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR transaccion= new ADMINISTRADOR();
          
            string sql = "insert into REGISTRO (UserBoleta, Contraseña) values ( '" + this.textBox1.Text + "','" + this.textBox2.Text + "')";
            if (transaccion.insertar(sql))
            {
                MessageBox.Show("datos completos");
            }
            else
            {
                MessageBox.Show("error");

                
            }
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TRANSACCIONES menu = new TRANSACCIONES();
            menu.Show();
            this.Hide();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
