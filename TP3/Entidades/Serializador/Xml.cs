using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Serializador
{
    public class Xml<T> :IArchivo<T>
    {
        public bool ImportarArchivo(string path, T datosAImportar)
        {
            return true;
        }

        public bool ExportarArchivo(string path, T datosALeer)
        {
            return true;
        }

    }
}
