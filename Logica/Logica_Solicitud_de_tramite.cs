using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
   public class Logica_Solicitud_de_tramite
    {
       public static Solicitud_de_Tramite Buscar(int pNumero)
       {
           return PersistenciaSolicitudTramite.Buscar(pNumero);
       }

       public static void Agregar(Solicitud_de_Tramite pSol)
       {
            PersistenciaSolicitudTramite.Agregar( pSol);
       }
    }
}
