using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Tipo_de_Tramite 
    {

        private string _Codigo;
        private string _NombreT;
        private string _Descripcion;

        Entidades_Publicas _unaEntidad;


        public Entidades_Publicas Entidad_Gestionadora
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse la entidad");
                else
                    _unaEntidad = value;
            }

            get { return _unaEntidad; }
        
        }
        public string NombreEnt
        {
            get { return _unaEntidad.Nombre; }
          
      
        }


        public string Codigo
        {
            set
            {
                if (value.Length <= 6)
                    _Codigo = value;
                else
                    throw new Exception("La clave debe contener como maximo 6 caracteres ");
            }

            get
            { return _Codigo; }
        }

        public string Nombre_Tramite
        {
            set
            {
                if (value.Length != 0)
                    _NombreT = value;
                else
                    throw new Exception("Error - Ingrese un nombre válido");
            }

            get { return _NombreT; }

        }

        public string Descripcion
        {
            set
            {
                if (value.Length != 0)
                    _Descripcion = value;
                else
                    throw new Exception("Error - Ingrese una descripción");
            }

            get { return _Descripcion; }
        }


        public Tipo_de_Tramite(Entidades_Publicas pEntidadGestionadora, string pCodigo, string pNombreTramite, string pDescripcion)
            
        {
            _unaEntidad = pEntidadGestionadora;
            Codigo = pCodigo;
            Nombre_Tramite = pNombreTramite;
            Descripcion = pDescripcion;
            
        }

        public override string ToString()
        {
            return (" Entidad Gestionadora: " + NombreEnt + " Codigo: " + Codigo + " Nombre del Tramite: " + Nombre_Tramite + " Descripcion: " + Descripcion);
        }
      
    }
}
