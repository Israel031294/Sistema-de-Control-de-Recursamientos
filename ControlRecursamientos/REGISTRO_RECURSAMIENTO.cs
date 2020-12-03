using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ControlRecursamientos
{
    public partial class REGISTRO_RECURSAMIENTO : Form
    {
        


 
        public REGISTRO_RECURSAMIENTO()
        {
            InitializeComponent();
        }

        // 
        RECURSADOR recursador = new RECURSADOR();
       
       

        //variables´para pasar ID's
        int id_mat, id_prof, id_grupo,boleta;
        int id;// id alumno
        int d;
        string b;
        private string _boleta;
        // setter y getter boleta desde LOGUEO_RECURSADOR
        public string BOLETA
         {
             get { return _boleta; }
             set { _boleta = value; }
         }
       
       
       

        SGBD transaccion = new SGBD();

        private void REGISTRO_RECURSAMIENTO_Load(object sender, EventArgs e)
        {
            //carga los datos al combobox para ver las materias de la base de datos
            this.comboBox1.DataSource = transaccion.consultar2("MATERIA");
            this.comboBox1.DisplayMember = "Descripcion";
            this.comboBox1.ValueMember = "ID_Materia";
            this.comboBox1.Refresh();
            //asigna la boleta obtenida en la clase LOGUEO_RECURSADOR al iniciar el formulario
            label6.Text = BOLETA;



            id = transaccion.ObtenerIdAlumno()+1;
            label12.Text = id.ToString();




            string sqlcad = "SELECT * from ALUMNO where Boleta='" + BOLETA + "'";
            SqlCommand caro = new SqlCommand(sqlcad, recursador.Base.cn);
            recursador.Base.cn.Open();
            SqlDataReader asignar = caro.ExecuteReader();

            if (asignar.Read() == true)
            {
                textBox1.Text = asignar["NOMBRE"].ToString();
                textBox2.Text = asignar["Ape_Pat"].ToString();
                textBox3.Text = asignar["Ape_Mat"].ToString();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                


            }
            recursador.Base.cn.Close();
           


           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {


            b = BOLETA;
            // escribe la boleta en label6
            label6.Text = BOLETA;
            //escribe el ID_Materia del LOAD 
            label5.Text =this.comboBox1.SelectedValue.ToString();

            // datos de atributos de la clase RECURSADOR por medio del objeto recursador
            recursador.nombre = this.textBox1.Text;
            recursador.ape_pat = this.textBox2.Text;
            recursador.ape_mat = this.textBox3.Text;

            //obntencion del id_profe y id_grupo
            string cadSql = "SELECT ID_Prof from PROFESOR WHERE ID_Materia='" +label5.Text+"'" ;
            //asignacion de id_mat a partir del label5
            id_mat = int.Parse(label5.Text);
            //uso de atributo cn de la clase RECURSADOR por medio del objeto recursador y lectura de SELECT ID_prof  de cadSql
            SqlCommand comand = new SqlCommand(cadSql, recursador.Base.cn);
            recursador.Base.cn.Open();
            //BASE.cn.Open();

            SqlDataReader leer = comand.ExecuteReader();
            
            if (leer.Read() == true)
            { 
                label10.Text=leer["ID_Prof"].ToString();
                id_prof = int.Parse(label10.Text);

            }
            else
            { MessageBox.Show("no existe"); }
           
            //BASE.cn.Close();
            recursador.Base.cn.Close();
            //acceso al metodo consulta de la clase RECURSADOR que requiere el id_mat e id_prof para retornar id_grupo
            id_grupo = recursador.consulta(id_mat.ToString(),id_prof.ToString());
            label11.Text = id_grupo.ToString();

            boleta = int.Parse(BOLETA);

           

            string sql = "insert into ALUMNO (ID_alum,Boleta,Nombre,Ape_Pat,Ape_Mat,ID_Materia,ID_Grupo,ID_Prof) values ( '" + id + "' ,'" + boleta + "' , '" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + id_mat + "' ,'" + id_grupo + "','" + id_prof + "'   )";
            if (recursador.IngresarDatos(sql))
            {
                MessageBox.Show("datos completos");
                button2.Visible = true;
                button3.Visible = true;

            }
            else
            {
                MessageBox.Show("error");


            }
            //Application.Restart();








        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            REPORTE_RECURSE comprobandte = new REPORTE_RECURSE();
            this.Hide();
            comprobandte.BOLETA = boleta.ToString();
            comprobandte.Show();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
            {
               id= id + 1;
               MessageBox.Show("Selecciona nueva materia y oprime INSCRIBIR MATERIA");

               
                
            }
        }
    }
}
