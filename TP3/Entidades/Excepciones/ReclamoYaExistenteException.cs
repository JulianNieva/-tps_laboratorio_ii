using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ReclamoYaExistenteException :Exception
    {
        public ReclamoYaExistenteException(string mensaje)
            :base(mensaje)
        {

        }

    }
}
