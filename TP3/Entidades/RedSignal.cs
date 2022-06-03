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

        public string MostrarListaDeClientes
        {
            get
            {
                return this.ListarClientes();
            }
        }

        public string MostrarListaDeReclamos
        {
            get
            {
                return this.ListarReclamos();
            }
        }

        private string ListarClientes()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Clientes cargados actualmente: {this.listaDeClientes.Count}");
            sb.AppendLine();
            foreach (Cliente cliente in this.listaDeClientes)
            {
                sb.AppendLine(cliente.ToString());
            }

            return sb.ToString();
        }

        private string ListarReclamos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Reclamos realizados: {this.listaDeReclamos.Count}");
            sb.AppendLine();

            foreach (Reclamo reclamo in this.listaDeReclamos)
            {
                sb.AppendLine(reclamo.ToString());
            }


            return sb.ToString();
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

        public static RedSignal operator +(RedSignal t, Reclamo r)
        {
            if(t != r)
            {
                t.listaDeReclamos.Add(r);
            }
            else
            {
                throw new ReclamoYaExistenteException("El reclamo sigue pendiente");
            }

            return t;
        }

        public static RedSignal operator +(RedSignal t, Cliente c)
        {
            if (t != c)
            {
                t.listaDeClientes.Add(c);
            }
            else
            {
                throw new ClienteYaExistenteException("El cliente ya se encuentra cargado");
            }

            return t;
        }

        public static RedSignal operator -(RedSignal t, Reclamo r)
        {
            if(t == r)
            {
                t.listaDeReclamos.Remove(r);
            }

            return t;
        }

        public static RedSignal operator-(RedSignal t, Cliente c)
        {
            if (t == c)
            {
                t.listaDeClientes.Remove(c);
            }

            return t;
        }

    }
}
