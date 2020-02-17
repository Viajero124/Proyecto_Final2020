using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades_Compartidas;

namespace Persistencia
{
   public class Persistencia_Usuario
    {
        public static Usuario Buscar(int pCI)
        {

            int oCI;
            string oContraseña,oNomEmpleado;

            Usuario Us = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarUsuario " + pCI, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    oCI = (int)oReader["CI"];
                    oContraseña = (string)oReader["Contraseña"];
                    oNomEmpleado = (string)oReader["NomEmpleado"];
                    Us = new Usuario(oCI,oContraseña,oNomEmpleado);
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
            return Us;
        }
        public static Usuario Logueo(string pUsu, string pPass)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            Usuario Us = null;
            int oCI;
            string oContraseña,oNomEmpleado;

            oComando.Parameters.AddWithValue("@Usu", pUsu);
            oComando.Parameters.AddWithValue("@Pass", pPass);
            


            

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();
                

                if (oReader.Read())
                {
                    oCI = (int)oReader["CI"];
                    oContraseña = (string)oReader["Contraseña"];
                    oNomEmpleado = (string)oReader["NomEmpleado"];
                    Us = new Usuario(oCI, oContraseña, oNomEmpleado);
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
            return Us;
        }
        public static void AltaUsuario(Usuario unEmp)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("AltaEmpleado", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CI", unEmp.CI);
            _Comando.Parameters.AddWithValue("@Contraseña", unEmp.Contraseña);
            _Comando.Parameters.AddWithValue("@NomEmpleado", unEmp.NomEmpleado);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe la Cedula");
                else if (oAfectados == -2)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static void ModificarUsuario (Usuario unEmp)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("ModificarEmpleado", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Ci", unEmp.CI);
            _Comando.Parameters.AddWithValue("@NomEmpleado", unEmp.NomEmpleado);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No Existe la cedula - No se Modifico");
                else if (oAfectados == -2)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static void EliminarUsuario(Usuario unEmp) 
        {
            //comando a ejecutar
            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("EliminarEmpleado", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCI = new SqlParameter("@CI", unEmp.CI);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            _Comando.Parameters.Add(oCI);
            _Comando.Parameters.Add(oRetorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("Hay Solicitudes Asociadas - No se Elimina");
                else if (oAfectados == 0)
                    throw new Exception("No Existe - No se Elimina");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static Usuario BuscarUsuario(int pCI)
        {
            Usuario U = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.STR);
            SqlCommand _Comando = new SqlCommand("Exec BuscarEmpleado " + pCI, _Conexion);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    U = new Usuario(Convert.ToInt32(_Reader["CI"]), _Reader["Contraseña"].ToString(), _Reader["NomEmpleado"].ToString());

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return U;
        }
    }
}
   
