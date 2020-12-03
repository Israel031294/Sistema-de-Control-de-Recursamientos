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
    public class USUARIO: SGBD
    {
       
        public string id;
        public string contraseña;
        public SGBD BASE;

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
                public string Contraseña
        {
            get { return this.contraseña; }
            set { this.contraseña = value; }


        }
        public bool verificarRecursador()
        {

            bool resultado = false;
            this.sql = string.Format(@"SELECT * FROM REGISTRO WHERE UserBoleta = '{0}'", this.id);
            this.comando = new SqlCommand(this.sql, this.Base.cn);
            this.Base.cn.Open();
            SqlDataReader reg = null;
            reg = this.comando.ExecuteReader();
            if (reg.Read())
            {
                resultado = true;

            }


            else
            {

            }

            this.Base.cn.Close();
            return resultado;
        }

        public bool verificarAdmin()
        {

            bool resultado = false;
            this.sql = string.Format(@"SELECT * FROM REGISTRO_ADMIN WHERE Usuario = '{0}'", this.id);
            this.comando = new SqlCommand(this.sql, this.Base.cn);
            this.Base.cn.Open();
            SqlDataReader reg = null;
            reg = this.comando.ExecuteReader();
            if (reg.Read())
            {
                resultado = true;

            }


            else
            {

            }

            this.Base.cn.Close();
            return resultado;
        }







        public bool loguepAdmin()
        {
            bool resultado = false;
            this.sql = string.Format(@"SELECT * FROM REGISTRO_ADMIN WHERE Usuario = '{0}' AND Contraseña = '{1}'", this.id, this.contraseña);
            this.comando = new SqlCommand(this.sql, this.Base.cn);
            this.Base.cn.Open();
            SqlDataReader reg = null;
            reg = this.comando.ExecuteReader();
            if (reg.Read())
            {
                resultado = true;
                
            }


            else
            {

            }

            this.Base.cn.Close();
            return resultado;
 
        }

        public bool logueoRecursador()
        {
            bool resultado = false;
            this.sql = string.Format(@"SELECT * FROM REGISTRO WHERE UserBoleta = '{0}' AND Contraseña = '{1}'", this.id, this.contraseña);
            this.comando = new SqlCommand(this.sql, this.Base.cn);
            this.Base.cn.Open();
            SqlDataReader reg = null;
            reg = this.comando.ExecuteReader();
            if (reg.Read())
            {
                resultado = true;

            }


            else
            {

            }

            this.Base.cn.Close();
            return resultado;
 
        }


        ~USUARIO()
        {
        }


    }
}