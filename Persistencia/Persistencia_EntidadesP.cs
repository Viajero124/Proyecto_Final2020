using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades_Compartidas;

namespace Persistencia
{
    public class Persistencia_EntidadesP
    {
        public static List<Entidades_Publicas> ListarEntidades()
        {


            string oNombre, oDireccion,oTelefono;
            List<string> listaTelefonos = new List<string>();

            List<Entidades_Publicas> oListaEntidadesP = new List<Entidades_Publicas>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Listar_Entidades " , oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    
                    oNombre = (string)oReader["NombreE"];
                    oDireccion = (string)oReader["Direccion"];
                    oTelefono = (string)oReader["NroTel"];
                    listaTelefonos.Add(oTelefono);



                    
                    Entidades_Publicas a = new Entidades_Publicas(oNombre,listaTelefonos,oDireccion);

                    oListaEntidadesP.Add(a);
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
            return oListaEntidadesP;
        }
        public static Entidades_Publicas Buscar(string pNombre)
        {

            string oNombre, oDireccion;
            List<string> listaTelefonos = new List<string>();
            Entidades_Publicas EP = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarEntidad " + pNombre, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        oNombre = (string)oReader["NombreE"];
                        oDireccion = (string)oReader["Direccion"];
                        

                        listaTelefonos=Persistencia_EntidadesP.ListarTelefonos(oNombre);
                       



                        EP = new Entidades_Publicas(oNombre, listaTelefonos, oDireccion);
                    }
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
            return EP;
        }
        internal static List<string> ListarTelefonos(string pNombre)
        {
            string oTelefono = "";
            List<string> _lista = new List<string>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Listar_Telefonos " + pNombre, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oTelefono = (string)oReader["NroTel"];
                    _lista.Add(oTelefono);
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
            return _lista;
        }
        public static void AgregarTelefonos(Entidades_Publicas pEnti)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.STR);
            SqlCommand _comando = new SqlCommand("Agregar_Telefonos " , _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@NombreE", pEnti.Nombre);
            

            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);
            SqlParameter _Telefonos = new SqlParameter("@Telefonos", SqlDbType.VarChar, 9);
            _comando.Parameters.Add(_Telefonos);

            

            try
            {
                _cnn.Open();
                foreach (string Telef in pEnti.MisTelefonos)
                {
                    _Telefonos.Value = Telef;
                    _comando.ExecuteNonQuery();

                    if ((int)_retorno.Value == -1)
                        throw new Exception("El telefono ya existe");
                    else if ((int)_retorno.Value == -2)
                        throw new Exception("Error en el alta");
                   
                }
                 
                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
        public static void Agregar(Entidades_Publicas pEntidadP)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarEntidadP", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            
            oComando.Parameters.AddWithValue("@Nombre", pEntidadP.Nombre);            
            oComando.Parameters.AddWithValue("@Direccion", pEntidadP.Direccion);
           
           


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("Ya Existe la Entidad");
                else if (oAfectados == -2)
                    throw new Exception("Error");
                //si se llegó acá, se dio de alta ok a la entidad.
                //Entonces puedo agregarle telefonos en la DB.
                Persistencia_EntidadesP.AgregarTelefonos(pEntidadP);

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

        public static void Modificar(Entidades_Publicas pEntidadP)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarEntidadP", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

           
            oComando.Parameters.AddWithValue("@Nombre", pEntidadP.Nombre);
            oComando.Parameters.AddWithValue("@Direccion", pEntidadP.Direccion);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery(); //Manda a ejecutar procedimientos que no tengan consultas.
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No existe-No es posiblemodificar");
                else if (oAfectados == -2)
                    throw new Exception("Error-No es posible modificar");
                //primero mando a eliminar los autores que hay
                Persistencia_EntidadesP.EliminarTelefonos(pEntidadP.Nombre);
                //segundo actualizo con los autores que hay en el objeto
                Persistencia_EntidadesP.AgregarTelefonos(pEntidadP);
                

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
        public static void Eliminar(Entidades_Publicas pEntidadP)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarEntidadP", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNombre = new SqlParameter("@Nombre", pEntidadP.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe - No se Elimina");
                else if (oAfectados == -2)
                    throw new Exception("No se puede eliminar, tiene solicitudes asociadas ");
                else if (oAfectados == -3)
                    throw new Exception("No se pudo eliminar-Error");
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
        internal static void EliminarTelefonos(string pNombre)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.STR);
            SqlCommand _comando = new SqlCommand("EliminarTelefonos ", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@NombreE", pNombre);

            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
    }
}
