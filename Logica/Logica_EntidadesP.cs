using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class Logica_EntidadesP
    {
        public static List<Entidades_Publicas> ListarEntidades()
        {
            return Persistencia_EntidadesP.ListarEntidades();
        }

        public static Entidades_Publicas Buscar(string pNombre)
        {
            return Persistencia_EntidadesP.Buscar(pNombre);
        }
        public static void Agregar(Entidades_Publicas pEntidadP)
        {
            Persistencia_EntidadesP.Agregar(pEntidadP);
        }
        public static void Modificar(Entidades_Publicas pEntidadP)
        {
            Persistencia_EntidadesP.Modificar(pEntidadP);
        }

        public static void Eliminar(Entidades_Publicas pEntidadP)
        {
            Persistencia_EntidadesP.Eliminar(pEntidadP);
        }
    }
}
