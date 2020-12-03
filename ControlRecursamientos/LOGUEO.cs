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
    public partial class LOGUEO : Form
    {
        
        USUARIO usuario = new USUARIO();
        
        public LOGUEO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // ID y Contraseña se usan de la clase heredada USUARIO 
            usuario. Id = this.textBox1.Text;
            usuario.Contraseña = this.textBox2.Text;

            if (usuario.logueoRecursador() == true)
            {
                MessageBox.Show("BIENVENIDO");
                
                REGISTRO_RECURSAMIENTO registro = new REGISTRO_RECURSAMIENTO();
                registro.BOLETA = textBox1.Text;
                registro.Show();

                this.Hide();
            }


            else if (usuario.loguepAdmin() == true)
            {
                MessageBox.Show("BIENVENIDO");
                TRANSACCIONES transaccion = new TRANSACCIONES();
            
                transaccion.Show();

                this.Hide();

            }

            else
            {
                MessageBox.Show("UPS, INGRESASTE MAL LA CONTRASEÑA");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
            usuario.Id = this.textBox1.Text;
            if (usuario.verificarRecursador() == true)
            {
                MessageBox.Show("ALUMNO EXISTENTE");
                button1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                button2.Visible = false;
                


            }
            else if (usuario.verificarAdmin() == true)
            {
                MessageBox.Show("ADMINISTRADOR");
                button1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                button2.Visible = false;


            }
                
            else
            {
                 MessageBox.Show("ALUMNO NO REGISTRADO");

            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
