using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Excepciones;

namespace Entidades
{
    public static class ClienteDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static ClienteDAO()
        {
            cadenaConexion = @"Data Source=.; Database = RedSignal; Trusted_Connection = True";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }

        /// <summary>
        /// Se modifica un cliente en la base de datos
        /// </summary>
        /// <param name="c">Cliente a modificar</param>
        public static void ModificarCliente(Cliente c)
        {
            bool tieneInternet = c.ServiciosContratados.Contains(new Internet());
            bool tieneTv = c.ServiciosContratados.Contains(new Television());
            bool tieneTelefono = c.ServiciosContratados.Contains(new LineaTelefonica());

            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"UPDATE Clientes SET Nombre = @nombre ,Apellido = @apellido ,Localidad = @localidad ," +
                    $"Tiene_Telefono = @telefono ,Tiene_Int = @internet ,Tiene_Tv = @television WHERE Dni = {c.Dni}";

                comando.Parameters.AddWithValue("@dni", c.Dni);
                comando.Parameters.AddWithValue("@nombre", c.Nombre);
                comando.Parameters.AddWithValue("@apellido", c.Apellido);
                comando.Parameters.AddWithValue("@localidad", c.Localidad.ToString());
                comando.Parameters.AddWithValue("@telefono", tieneTelefono);
                comando.Parameters.AddWithValue("@internet", tieneInternet);
                comando.Parameters.AddWithValue("@television", tieneTv);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error al modificar el cliente en la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// Trae todo los clientes de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> LeerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM Clientes";
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Cliente clienteAux = new Cliente(lector["Nombre"].ToString(), lector["Apellido"].ToString(), lector["Dni"].ToString(), ((ELocalidad)Enum.Parse(typeof(ELocalidad), lector["Localidad"].ToString())));

                    if (lector["Tiene_Telefono"].ToString() == "True")
                    {
                        clienteAux.ServiciosContratados.Add(new LineaTelefonica(150));
                    }
                    if(lector["Tiene_Int"].ToString() == "True")
                    {
                        clienteAux.ServiciosContratados.Add(new Internet(350));
                    }
                    if(lector["Tiene_Tv"].ToString() == "True")
                    {
                        clienteAux.ServiciosContratados.Add(new Television(200));
                    }

                    clientes.Add(clienteAux);
                }
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error en la lectura de los clientes");
            }
            finally
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return clientes;
        }

        /// <summary>
        /// Traigo un cliente segun el dni recibido
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static Cliente LeerClientePorDni(string dni)
        {
            Cliente clienteAux = null;

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT * FROM Clientes WHERE Dni = '{dni}'";

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    clienteAux = new Cliente(lector["Nombre"].ToString(), lector["Apellido"].ToString(), lector["Dni"].ToString(), ((ELocalidad)Enum.Parse(typeof(ELocalidad), lector["Localidad"].ToString())));

                    if (lector["Tiene_Telefono"].ToString() == "True")
                    {
                        clienteAux.ServiciosContratados.Add(new LineaTelefonica(150));
                    }
                    if (lector["Tiene_Int"].ToString() == "True")
                    {
                        clienteAux.ServiciosContratados.Add(new Internet(350));
                    }
                    if (lector["Tiene_Tv"].ToString() == "True")
                    {
                        clienteAux.ServiciosContratados.Add(new Television(200));
                    }
                }
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error al buscar el cliente");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return clienteAux;
        }

        /// <summary>
        /// Guardo un cliente en la base de datos
        /// </summary>
        /// <param name="c"></param>
        public static void GuardarCliente(Cliente c)
        {
            bool tieneInternet = c.ServiciosContratados.Contains(new Internet());
            bool tieneTv = c.ServiciosContratados.Contains(new Television());
            bool tieneTelefono = c.ServiciosContratados.Contains(new LineaTelefonica());

            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Clientes (Dni,Nombre,Apellido,Localidad,Tiene_Telefono,Tiene_Int,Tiene_Tv) " +
                    "VALUES (@dni,@nombre,@apellido,@localidad,@telefono,@internet,@television)";

                comando.Parameters.AddWithValue("@dni",c.Dni);
                comando.Parameters.AddWithValue("@nombre", c.Nombre);
                comando.Parameters.AddWithValue("@apellido", c.Apellido);
                comando.Parameters.AddWithValue("@localidad", c.Localidad.ToString());
                comando.Parameters.AddWithValue("@telefono", tieneTelefono);
                comando.Parameters.AddWithValue("@internet", tieneInternet);
                comando.Parameters.AddWithValue("@television", tieneTv);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error al guardar el cliente en la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// Elimino un cliente de la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static bool BorrarCliente(string dni)
        {
            bool retorno = false;

            try
            {
                conexion.Open();
                comando.CommandText = $"DELETE FROM Clientes WHERE Dni = '{dni}'";

                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error en borrar al cliente de la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return retorno;
        }

    }
}
