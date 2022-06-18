using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Entidades.Excepciones;

namespace Entidades.Serializador
{
    public class Xml<T> :IArchivo<T>
    {
        readonly string path;
        public Xml()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\InformesRedSignal\";
        }

        public bool ExportarArchivo(string nombreArchivo, T datosAExportar)
        {
            bool seLogroExportar = false;
            string pathAuxiliar = path + @"\InformesXml\";

            try
            {
                if(!Directory.Exists(pathAuxiliar))
                {
                    Directory.CreateDirectory(pathAuxiliar);
                }

                pathAuxiliar += @"Informe " + nombreArchivo + ".xml";

                if(pathAuxiliar != null)
                {
                    using (XmlTextWriter auxWriter = new XmlTextWriter(pathAuxiliar,Encoding.UTF8))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(T));

                        serializador.Serialize(auxWriter, datosAExportar);

                        seLogroExportar = true;
                    }
                }

            }
            catch (Exception exc)
            {
                exc = new ArchivosException("Se produjo un error al querer exportar el archivo en formato .xml");
                throw exc;
            }

            return seLogroExportar;
        }

    }
}
