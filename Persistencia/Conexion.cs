using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
   
        public class Conexion
        {

            private static string str = "Data Source=.;Initial Catalog=EntidadesPublicas;Integrated security=True";

            public static string STR
            {
                get { return str; }
            }

        }
    
}
