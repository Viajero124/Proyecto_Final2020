using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Usuario
    {
        private int _CI;
        private string _Contraseña;
        private string _NomEmpleado;

        public int CI
        {
            set
            {
                if (value.ToString().Length == 8)
                     _CI=value;
                else
                    throw new Exception ("La cedula de identidad debe contener 8 digitos ");
            }

            get
            { return _CI; }
        
        }

        public string Contraseña
        {
            set
            {
                if (value.Length <=10)
                
                     _Contraseña=value;
                else
                    throw new Exception ("La clave debe contener como maximo 10 caracteres ");
            }

            get
            { return _Contraseña; }
        
        }

        public string NomEmpleado
        {
            set
            {
                if (value.Length != 0)
                    _NomEmpleado = value;
                else
                    throw new Exception("Error - Ingrese un nombre válido");
            }

            get { return _NomEmpleado; }

        }

        public Usuario(int pCI, string pContraseña, string pNomEmpleado)
        {
            CI = pCI;
            Contraseña = pContraseña;
            NomEmpleado = pNomEmpleado;
        }

        public override string ToString()
        {
            return ("Cedula: " + CI + "Contraseña: " + Contraseña + "Nombre Completo: " + NomEmpleado);
        }
    }
}
