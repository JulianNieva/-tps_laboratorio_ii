using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Excepciones;

namespace Entidades
{
    public static class ReclamoDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        static ReclamoDAO()
        {
            cadenaConexion = @"Data Source=.; Database = RedSignal; Trusted_Connection = True";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }

        public static void GuardarReclamo(Reclamo r)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"INSERT INTO Reclamos (Codigo,Dni_Cliente,Servicio_Reclamado) VALUES (@codigo,@dni,@servicio)";
                comando.Parameters.AddWithValue("@codigo", r.Codigo);
                comando.Parameters.AddWithValue("@dni", r.Cliente.Dni);
                comando.Parameters.AddWithValue("@servicio", r.ServicioReclamado.ToString());

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error en borrar el reclamo en la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Reclamo> LeerReclamos()
        {
            List<Reclamo> reclamos = new List<Reclamo>();

            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM Reclamos";

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Servicio servicio = null;

                    switch (lector["Servicio_Reclamado"])
                    {
                        case "Internet":
                            servicio = new Internet(350);
                            break;
                        case "Television":
                            servicio = new Television(200);
                            break;
                        case "Linea Telefonica":
                            servicio = new LineaTelefonica(150);
                            break;
                    }

                    Reclamo r = new Reclamo(ClienteDAO.LeerClientePorDni(lector["Dni_Cliente"].ToString()),servicio,lector["Codigo"].ToString());

                    reclamos.Add(r);
                }

            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Se produjo un error en borrar el reclamo en la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return reclamos;
        }

        public static bool EliminarReclamo(string codigo)
        {
            bool retorno = false;

            try
            {
                conexion.Open();
                comando.CommandText = $"DELETE FROM Reclamos WHERE Codigo = '{codigo}'";
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception exc)
            {
                throw new BaseDeDatosException(exc.Message);
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
