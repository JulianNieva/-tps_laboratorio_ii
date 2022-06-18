using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades.Excepciones;

namespace Entidades.Serializador
{
    public class Txt<T> : IArchivo<T>
    {
        readonly string path;
        public Txt()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\InformesRedSignal\";
        }

        public bool ExportarArchivo(string nombreArchivo, T datosAExportar)
        {
            bool retorno = false;
            string pathAuxiliar = path + @"\InformesTxt\";

            try
            {
                if (!Directory.Exists(pathAuxiliar))
                {
                    Directory.CreateDirectory(pathAuxiliar);
                }

                pathAuxiliar += @"Informe " + nombreArchivo + ".txt";

                if (pathAuxiliar != null)
                {
                    using (StreamWriter sr = new StreamWriter(pathAuxiliar))
                    {
                        sr.Write(datosAExportar.ToString());
                        retorno = true;
                    }

                }

            }
            catch (Exception exc)
            {
                exc = new ArchivosException("Se produjo un error al querer exportar el archivo en formato .txt");
                throw exc;
            }

            return retorno;
        }
    }
}
