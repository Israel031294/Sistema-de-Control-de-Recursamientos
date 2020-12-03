using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace ControlRecursamientos
{
   public class BASE_DE_DATOS
    {

        public SqlConnection cn;
       
        public string cadena = @"Data Source=(local);Initial Catalog=RECURSAMIENTO;Integrated Security=True";
    }
}
