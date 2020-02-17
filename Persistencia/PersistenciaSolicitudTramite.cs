using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades_Compartidas;

namespace Persistencia
{
    public class PersistenciaSolicitudTramite
    {
        public static Solicitud_de_Tramite Buscar(int pNumero)
        {

            int oNumero,oCI;
            string oNomCliente, oEstado,oNombreE,oCodigo;
            DateTime oFechaHora;
            Usuario oUsuario;
            Tipo_de_Tramite oTipoTramite;
            Solicitud_de_Tramite ST = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarEstadoTramite " + pNumero, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    oNumero = (int)oReader["Nro"];
                    oNomCliente = (string)oReader["NomCliente"];
                    oEstado = (string)oReader["estado"];
                    oFechaHora = (DateTime)oReader["FechaHora"];
                    oCI = (int)oReader["CI"];
                    oNombreE = (string)oReader["NombreE"];
                    oCodigo = (string)oReader["codigo"];

                    oUsuario = Persistencia_Usuario.Buscar(oCI);
                    oTipoTramite = Persistencia_TipoTramite.Buscar(oNombreE);
                    ST = new Solicitud_de_Tramite(oNumero,oUsuario,oTipoTramite,oFechaHora,oNomCliente,oEstado);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return ST;
        }
        public static void Agregar(Solicitud_de_Tramite pSol)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarSolicitud", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            oComando.Parameters.AddWithValue("@FechaHora", pSol.FechaHora);
            oComando.Parameters.AddWithValue("@NomCliente", pSol.NombreCliente);
            oComando.Parameters.AddWithValue("@estado", pSol.EstadoSolicitud);
            oComando.Parameters.AddWithValue("@CI", pSol.Usuario.CI);
            oComando.Parameters.AddWithValue("@NombreE", pSol.TipoTramite.NombreEnt);
            oComando.Parameters.AddWithValue("Codigo", pSol.TipoTramite.Codigo);
            
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("Ya una solicitud para esa Fecha y hora");
                else if (oAfectados == -2)
                    throw new Exception("Error");
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
