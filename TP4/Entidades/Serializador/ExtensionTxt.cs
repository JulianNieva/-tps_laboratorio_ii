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
