using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
     public class  Entidades_Publicas 
    {
        private string _NombreE;
        private List<string> _MisTelefonos;
        private string _Direccion;

        public string Direccion
        {
            set
            {
                if (value.Length != 0)
                    _Direccion = value;
                else
                    throw new Exception("Error - Ingrese una dirección");
            }

            get { return _Direccion; }
            
        }
         public List<string> MisTelefonos
        {
            get { return _MisTelefonos; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar al menos un telefono");
                
                _MisTelefonos = value;
            }
        }

        public string Nombre
        {
            set
            {
                if (value.Length != 0)
                    _NombreE = value;
                else
                    throw new Exception("Error - Ingrese un nombre válido");
            }

            get { return _NombreE; }
        }




        public Entidades_Publicas(string pNombre, List<string> pTelefonos, string pDireccion)
        {
            Nombre = pNombre;
            MisTelefonos = pTelefonos;           
            Direccion = pDireccion;
        }

        public override string ToString()
        {
            return ("Nombre: " + Nombre + " Telefono: " + MisTelefonos  +  " Direccion: " + Direccion);
        }

    }
}
   