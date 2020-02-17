using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades_Compartidas;

namespace Persistencia
{
    public class Persistencia_TipoTramite
    {
        public static Tipo_de_Tramite Buscar(string pNombre)
        {
            
            string oNombreT, oCodigo,oDescripcion;


            Entidades_Publicas oNombreE;
            Tipo_de_Tramite TT = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarTipoTramite " + pNombre, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    
                    oNombreE = Persistencia_EntidadesP.Buscar(pNombre);
                   

                    oCodigo = (string)oReader["Codigo"];
                    oNombreT = (string)oReader["NombreT"];
                    oDescripcion = (string)oReader["Descripcion"];

                    TT = new Tipo_de_Tramite(oNombreE,oCodigo,oNombreT,oDescripcion);
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
            return TT;
        }
        public static List<Tipo_de_Tramite> ListarTipoTramite()
        {


            string oNombreE,oCodigo, oNombreT, oDescripcion;
            Entidades_Publicas oEntidad;
            

            List<Tipo_de_Tramite> oListaTT = new List<Tipo_de_Tramite>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Listar_TipoTramite ", oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oNombreE = (string)oReader["NombreE"];
                    oEntidad = Persistencia_EntidadesP.Buscar(oNombreE);
                    oCodigo = (string)oReader["Codigo"];
                    oNombreT = (string)oReader["NombreT"];
                    oDescripcion = (string)oReader["Descripcion"];



                    Tipo_de_Tramite TT = new Tipo_de_Tramite(oEntidad,oCodigo,oNombreT,oDescripcion);

                    oListaTT.Add(TT);
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
            return oListaTT;
        }
        public static int Agregar(Tipo_de_Tramite pTipoTramite)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaTipoTramite", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombreE", pTipoTramite.Entidad_Gestionadora.Nombre);
            oComando.Parameters.AddWithValue("@Codigo", pTipoTramite.Codigo);
            oComando.Parameters.AddWithValue("@NombreT", pTipoTramite.Nombre_Tramite);
            oComando.Parameters.AddWithValue("@Descripcion", pTipoTramite.Descripcion);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("El tipo de tramite no existe");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oAfectados;
        }

        public static void Modificar(Tipo_de_Tramite pTipoTramite)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarTipoTramite", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombreE", pTipoTramite.Entidad_Gestionadora.Nombre);
            oComando.Parameters.AddWithValue("@Codigo", pTipoTramite.Codigo);
            oComando.Parameters.AddWithValue("@NombreT", pTipoTramite.Nombre_Tramite);
            oComando.Parameters.AddWithValue("@Descripcion", pTipoTramite.Descripcion);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe - No se modifica");

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

        public static void Eliminar(Tipo_de_Tramite pTipoTramite)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarTipoTramite", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodigo = new SqlParameter("@Codigo", pTipoTramite.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == 0)
                    throw new Exception("No existe - No se Elimina");

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
        public static Tipo_de_Tramite BuscarxCodigo(string pCodigo)
        {

            string oNombreE, oCodigo, oNombreT, oDescripcion;

            Entidades_Publicas oEntidadPublica;

            Tipo_de_Tramite TT = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarTipoTramite " + pCodigo, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    oNombreE = (string)oReader["NombreE"];
                    oCodigo = (string)oReader["Codigo"];
                    oNombreT = (string)oReader["NombreT"];
                    oDescripcion = (string)oReader["Descripcion"];

                    oEntidadPublica = Persistencia_EntidadesP.Buscar(oNombreE);

                    TT = new Tipo_de_Tramite(oEntidadPublica, oCodigo, oNombreT, oDescripcion);
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
            return TT;
        }



    }
}
