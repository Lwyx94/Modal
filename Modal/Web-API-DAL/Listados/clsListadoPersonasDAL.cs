using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_API_DAL.Conexion;

namespace Web_API_DAL.Listados
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Obtiene un listado de todas las personas de la BD
        /// </summary>
        /// <returns>List<clsPersona> listadoPersonas</returns>
        public List<clsPersona> getListadoPersonas()
        {

            List<clsPersona> personas = new List<clsPersona>();
            clsMyConnection conexion = new clsMyConnection();

            SqlConnection miConexion = conexion.getConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona;
            //miConexion.ConnectionString = ("server=mispersonas.database.windows.net;database=PersonasDB;uid=lgutierrez;pwd=Personas_DB;");

            try
            {
                // miConexion.Open();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.idPersona = (int)miLector["id"];
                        oPersona.nombre = (string)miLector["nombre"];
                        oPersona.apellidos = (string)miLector["apellidos"];
                        oPersona.fechaNac = (DateTime)miLector["nacimiento"];
                        oPersona.direccion = (string)miLector["direccion"];
                        oPersona.telefono = (string)miLector["telefono"];
                        personas.Add(oPersona);
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return personas;
        }
        /// <summary>
        /// Obtiene una persona segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersona persona</returns>
        public clsPersona getPersonaPorID(int id)
        {
            clsMyConnection conexion = new clsMyConnection();

            SqlConnection miConexion = conexion.getConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona = new clsPersona();

            try
            {
                // miConexion.Open();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                //PARAMETRO PARA EVITAR SQLINJECTION
                SqlParameter param;
                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;
                miComando.CommandText = "SELECT * FROM personas WHERE id = " + id;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    oPersona.idPersona = (int)miLector["id"];
                    oPersona.nombre = (string)miLector["nombre"];
                    oPersona.apellidos = (string)miLector["apellidos"];
                    oPersona.fechaNac = (DateTime)miLector["nacimiento"];
                    oPersona.direccion = (string)miLector["direccion"];
                    oPersona.telefono = (string)miLector["telefono"];
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return oPersona;
        }

        /// <summary>
        /// Actualiza en la BD la persona que recibe por parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>int resultado</returns>
        public int updatePersonasDAL(clsPersona persona)
        {
            clsMyConnection miconexion = new clsMyConnection();
            int resultado = 0;

            try
            {
                SqlConnection conexion = miconexion.getConnection();

                SqlCommand comando = new SqlCommand();

                comando.CommandText = "UPDATE personas SET nombre=@nombre, apellidos=@apellidos, nacimiento=@fechaNac, direccion=@direccion, telefono=@telefono WHERE id=@id";
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
                comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
                comando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.fechaNac;
                comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
                comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();
                miconexion.closeConnection(ref conexion);
            }
            catch (SqlException e)
            {
                throw e;
            }

            return resultado;
        }

        /// <summary>
        /// Elimina una persona de la BD según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int resultado</returns>
        public int deletePersonasDAL(int id)
        {
            clsMyConnection miconexion = new clsMyConnection();
            int resultado = 0;

            try
            {
                SqlConnection conexion = miconexion.getConnection();

                SqlCommand comando = new SqlCommand();

                comando.CommandText = "DELETE FROM personas WHERE id=@id";
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;


                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();
                miconexion.closeConnection(ref conexion);
            }
            catch (SqlException e)
            {
                throw e;
            }

            return resultado;
        }

        /// <summary>
        /// Inserta una persona en la BD
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>int resultado</returns>
        public int insertPersonasDAL(clsPersona persona)
        {
            clsMyConnection miconexion = new clsMyConnection();
            int resultado = 0;

            try
            {
                SqlConnection conexion = miconexion.getConnection();
                SqlCommand comando = new SqlCommand();

                comando.CommandText = "INSERT INTO personas (nombre,apellidos,nacimiento,direccion,telefono) VALUES (@nombre,@apellidos,@fechaNac,@direccion,@telefono)";
                //comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
                comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
                comando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.fechaNac;
                comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
                comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();
                miconexion.closeConnection(ref conexion);
            }
            catch (SqlException e)
            {
                throw e;
            }

            return resultado;
        }
    }
}
