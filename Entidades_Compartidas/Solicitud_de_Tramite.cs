using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Solicitud_de_Tramite
    {
        private int _Nro;
        private DateTime _FechaHora;
        private string _NomCliente;
        private string _estado;

        Usuario _unEmp;
        Tipo_de_Tramite _unT;

        public int Numero
        {
            set { _Nro = value; }
            get { return _Nro; }
        }

        public Usuario Usuario
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el usuario");
                else
                    _unEmp = value;
            }

            get { return _unEmp; }

        }

        public Tipo_de_Tramite TipoTramite
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el tipo de tramite");
                else
                    _unT = value;
            }

            get { return _unT; }

        }

        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set { _FechaHora = value; }
        }

        public string NombreCliente
        {
            set
            {
                if (value.Length != 0)
                    _NomCliente = value;
                else
                    throw new Exception("Error - Ingrese un nombre válido");
            }

            get { return _NomCliente; }
        }
       
        public string EstadoSolicitud
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Solicitud_de_Tramite(int pNumero, Usuario pUsuario,Tipo_de_Tramite pTipoTramite,DateTime pFechaHora,string pNombreCliente,string pEstadoSolicitud)
        {
            Numero = pNumero;
            _unEmp = pUsuario;
            _unT = pTipoTramite;
            FechaHora = pFechaHora;
            NombreCliente = pNombreCliente;
            EstadoSolicitud = pEstadoSolicitud;
        }

        public override string ToString()
        {
            return ("Numero: " + _Nro + " Nombre Empleado: " + Usuario.CI.ToString()  + " Tipo de tramite: " + TipoTramite.Codigo.ToString() +"Fecha y Hora: " + " Nombre del Solicitante: " + NombreCliente+" Estado de la solicitud: " + EstadoSolicitud);
        }

    }
}
