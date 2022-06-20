using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Excepciones;
using System.IO;
using Entidades;

namespace Entidades
{
    public static class ExtensionTxt
    {
     
        /// <summary>
        /// Exporto el listado de clientes en formato txt
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="path"></param>
        /// <param name="nombre"></param>
        public static void ExportarClientesTxt(this List<Cliente> listadoClientes,string path,string nombre)
        {
            string pathAuxiliar = path + @"\InformesTxt\";

            try
            {
                if (!Directory.Exists(pathAuxiliar))
                {
                    Directory.CreateDirectory(pathAuxiliar);
                }

                pathAuxiliar += @"Informe " + nombre + ".txt";

                if (pathAuxiliar != null)
                {
                    using (StreamWriter sr = new StreamWriter(pathAuxiliar))
                    {
                        for (int i = 0; i < listadoClientes.Count; i++)
                        {
                            sr.WriteLine(Cliente.MostrarCliente(listadoClientes[i]));
                        }
                    }

                }

            }
            catch (Exception exc)
            {
                exc = new ArchivosException("Se produjo un error al querer exportar el archivo en formato .txt");
                throw exc;
            }
        }

        /// <summary>
        /// Exporto el lista de reclamos en formato txt
        /// </summary>
        /// <param name="listadoDeReclamos"></param>
        /// <param name="path"></param>
        /// <param name="nombre"></param>
        public static void ExportarReclamosTxt(this List<Reclamo> listadoDeReclamos,string path, string nombre)
        {
            string pathAuxiliar = path + @"\InformesTxt\";

            try
            {
                if (!Directory.Exists(pathAuxiliar))
                {
                    Directory.CreateDirectory(pathAuxiliar);
                }

                pathAuxiliar += @"Informe " + nombre + ".txt";

                if (pathAuxiliar != null)
                {
                    using (StreamWriter sr = new StreamWriter(pathAuxiliar))
                    {
                        for (int i = 0; i < listadoDeReclamos.Count; i++)
                        {
                            sr.WriteLine(Reclamo.MostrarReclamo(listadoDeReclamos[i]));
                        }
                    }
                }

            }
            catch (Exception exc)
            {
                exc = new ArchivosException("Se produjo un error al querer exportar el archivo en formato .txt");
                throw exc;
            }
        }
    }
}
