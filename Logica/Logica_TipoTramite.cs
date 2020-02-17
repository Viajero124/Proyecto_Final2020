using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
   public class Logica_TipoTramite
    {
        public static Tipo_de_Tramite Buscar(string pNombre)
        {
            return Persistencia_TipoTramite.Buscar(pNombre);
        }

        public static List<Tipo_de_Tramite> ListarTipoTramite()
        {
            return Persistencia_TipoTramite.ListarTipoTramite();

        }
        public static void Agregar(Tipo_de_Tramite pTipoTramite)
        {
            Persistencia_TipoTramite.Agregar(pTipoTramite);
        }

       

        public static Tipo_de_Tramite BuscarxCodigo(string pCodigo)
        {
            return Persistencia_TipoTramite.BuscarxCodigo(pCodigo);
        }

        public static void Modificar(Tipo_de_Tramite pTipoTramite)
        {
            Persistencia_TipoTramite.Modificar(pTipoTramite);
        }

        public static void Eliminar(Tipo_de_Tramite pTipoTramite)
        {
            Persistencia_TipoTramite.Eliminar(pTipoTramite);
        }

    }
}
