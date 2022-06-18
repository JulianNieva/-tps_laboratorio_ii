using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Serializador
{
    public interface IArchivo<T>
    {
        bool ExportarArchivo(string nombreArchivo, T datosAExportar);
    }
}
