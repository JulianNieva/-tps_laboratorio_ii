using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Excepciones;

namespace Entidades
{
    public class RedSignal
    {
        private List<Cliente> listaDeClientes;
        private List<Reclamo> listaDeReclamos;

        public RedSignal()
        {
            this.listaDeClientes = new List<Cliente>();
            this.listaDeReclamos = new List<Reclamo>();
        }

        public List<Reclamo> ListaDeReclamos
        {
            get
            {
                return this.listaDeReclamos;
            }
        }

        public List<Cliente> ListaDeClientes
        {
            get
            {
                return this.listaDeClientes;
            }
        }

        public static bool operator == (RedSignal t, Reclamo r)
        {
            bool retorno = false;

            if(t is not null && r is not null)
            {
                foreach (Reclamo reclamo in t.listaDeReclamos)
                {
                    if(reclamo == r)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public static bool operator !=(RedSignal t, Reclamo r)
        {
            return !(t == r);
        }

        public static bool operator ==(RedSignal t, Cliente c)
        {
            bool retorno = false;

            if (t is not null && c is not null)
            {
                foreach (Cliente cliente in t.listaDeClientes)
                {
                    if (cliente == c)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public static bool operator !=(RedSignal t, Cliente c)
        {
            return !(t == c);
        }

    }
}
