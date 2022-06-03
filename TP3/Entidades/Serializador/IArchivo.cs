using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Serializador
{
    public interface IArchivo<T>
    {
        bool ImportarArchivo(string path, T datos);

        bool LeerArchivo(string path, T datos);
    }
}
