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

        /// <summary>
        /// Constructor por defecto
        /// </summary>
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
            set
            {
                this.listaDeReclamos = value;
            }
        }

        public List<Cliente> ListaDeClientes
        {
            get
            {
                return this.listaDeClientes;
            }
            set
            {
                this.listaDeClientes = value;
            }
        }

        /// <summary>
        /// Verifico si un reclamo esta cargado en la lista
        /// </summary>
        /// <param name="r"></param>
        /// <param name="rec"></param>
        /// <returns>Retorno true si esta en la lista, false caso contrario</returns>
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

        /// <summary>
        /// Verifico si un cliente esta cargado en la lista
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns>Retorno true si esta en la lista, false caso contrario</returns>
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
