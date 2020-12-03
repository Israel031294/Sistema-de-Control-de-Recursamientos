using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControlRecursamientos
{
    class ADMINISTRADOR:USUARIO
    {



        public bool insertar(string sql)
        {
            Base.cn.Open();
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
