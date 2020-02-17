using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
   public class Logica_Usuario
    {
        public static Usuario Logueo(string pUsu, string pPass)
        {
            Usuario unUsu = null;

            //Verifico Empleado
            unUsu = Persistencia_Usuario.Logueo(pUsu, pPass);

           
            //retorno lo que encontre
            return unUsu;
        }
        public static Usuario Buscar(int pCI)
        {
            Usuario U = null;

            U = (Usuario)Persistencia_Usuario.BuscarUsuario(pCI);

            if (U == null)
                U = (Usuario)Persistencia_Usuario.BuscarUsuario(pCI);

            return U;
        }

        public static void Eliminar(Usuario unEmp)
        {
            Persistencia_Usuario.EliminarUsuario(unEmp);
        }

        public static void Modificar(Usuario unEmp)
        {
            Persistencia_Usuario.ModificarUsuario(unEmp);
        }

        public static void Alta(Usuario unEmp)
        {
            Persistencia_Usuario.AltaUsuario(unEmp);
        }

    }
}
