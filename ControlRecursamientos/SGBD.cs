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
   public class SGBD
    {
       
       
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        public SqlCommandBuilder cmb;
        protected string sql;
        public BASE_DE_DATOS Base = new BASE_DE_DATOS();

        public SGBD()
        {
            conectar();
        }


        public void conectar()
        {
            Base.cn = new SqlConnection(Base.cadena);

        }

        public int ObtenerIdAlumno()
        {


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            int a = 0;
            try
            {
                Base.cn.Open();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM ALUMNO ", Base.cn);
                adapter.Fill(ds);
               Base.cn.Close();
                for (i = 0; i < ds.Tables[0].Rows.Count ; i++)
                {
                    //MessageBox.Show(ds.Tables[0].Rows[2].ItemArray[1].ToString());
                    a = a + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return a;
        }
      


        public int consulta(string a, string b)
        {
            int x;
            string cad = "SELECT ID_Grupo from GRUPO where ID_Materia='" + a + "'";


           
            SqlCommand comand = new SqlCommand(cad,Base.cn);
            Base.cn.Open();
           


            SqlDataReader leer = comand.ExecuteReader();

            if (leer.Read() == true)
            {
                b= leer["ID_Grupo"].ToString();
                x = int.Parse(b);

            }
            else
            {
                MessageBox.Show("no eiste"); 
            }
            Base.cn.Close();

            return int.Parse(b); 

        }

        public string datos(string a, string b)
        {
            int x;
         
            string cad = "SELECT NOMBRE from ALUMNO where Boleta='" + a + "'";



            SqlCommand comand = new SqlCommand(cad, Base.cn);
            Base.cn.Open();



            SqlDataReader leer = comand.ExecuteReader();

            if (leer.Read() == true)
            {
                b = leer["Boleta"].ToString();
                return b;
               // x = int.Parse(b);

            }
            else
            {
                MessageBox.Show("NO ALUMNO");
            }
            Base.cn.Close();

            return b; //int.Parse(b);

        }



        public void visualizar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, Base.cn);
            cmb = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);

        }




        public DataTable consultar2(string tabla)
        {

            string sql = "select * from  " + tabla;
            da = new SqlDataAdapter(sql, Base.cn);

            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

     

        // eliminar
        public bool eliminar(string tabla, string condicion)
        {
            Base.cn.Open();

            string sql = "delete  from " + tabla + " where " + condicion;
            comando = new SqlCommand(sql, Base.cn);
            int i = comando.ExecuteNonQuery();
            Base.cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }





        }



       



       
    }
}
