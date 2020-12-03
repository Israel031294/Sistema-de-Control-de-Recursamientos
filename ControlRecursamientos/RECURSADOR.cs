using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ControlRecursamientos
{
    class RECURSADOR: USUARIO
    {
        public string nombre;
        public string ape_pat;
        public string ape_mat;
        public int id_mat;
        public int id_grupo;
        public int id_prof;
        

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Ape_pat 
        {
            get { return this.ape_pat; }
            set { this.ape_pat = value; }

        }

        public string Ape_mat
        {
            get { return this.ape_mat; }
            set { this.ape_mat = value; }

        }




        public bool IngresarDatos(string sql)
        {
            this.Base.cn.Open();
            //BASE.cn.Open();
            comando = new SqlCommand(sql, this.Base.cn);
            int i = comando.ExecuteNonQuery();
            this.Base.cn.Close();
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
