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

        public static bool operator == (RedSignal r, Reclamo rec)
        {
            bool retorno = false;

            if(r is not null && rec is not null)
            {
                foreach (Reclamo reclamo in r.listaDeReclamos)
                {
                    if(reclamo == rec)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public static bool operator !=(RedSignal r, Reclamo rec)
        {
            return !(r == rec);
        }

        public static bool operator ==(RedSignal r, Cliente c)
        {
            bool retorno = false;

            if (r is not null && c is not null)
            {
                foreach (Cliente cliente in r.listaDeClientes)
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

        public static bool operator !=(RedSignal r, Cliente c)
        {
            return !(r == c);
        }

    }
}
