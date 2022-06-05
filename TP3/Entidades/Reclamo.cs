using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reclamo
    {
        private string codigo;
        private Cliente cliente;
        private Servicio servicioReclamado;
        private static Random alfanumericoRnd;

        static Reclamo()
        {
            alfanumericoRnd = new Random();
        }

        public Reclamo()
        {
        }

        public Reclamo(Cliente cliente, Servicio servicioReclamado,string codigo)
        {
            this.Codigo = codigo;
            this.Cliente = cliente;
            this.ServicioReclamado = servicioReclamado;
        }

        public string Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }

        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }

        public Servicio ServicioReclamado
        {
            get
            {
                return this.servicioReclamado;
            }
            set
            {
                this.servicioReclamado = value;
            }
        }

        public static string GenerarCodigoAlfanumerico()
        {
            StringBuilder sb = new StringBuilder();
            int longitud = 7;

            for (int i = 0; i < longitud; i++)
            {
                sb.Append((char)(alfanumericoRnd.Next(1,26) + 64)).ToString().ToUpper();
            }

            return sb.ToString();
        }

        public static bool operator ==(Reclamo r1, Reclamo r2)
        {
            bool retorno = false;

            if(r1 is not null && r2 is not null)
            {
                if(r1.cliente == r2.cliente && r1.servicioReclamado.ValidarServicio(r2.servicioReclamado))
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Reclamo r1, Reclamo r2)
        {
            return !(r1 == r2);
        }

        public override string ToString()
        {
            return $"Cliente: {this.cliente.Nombre} {this.cliente.Apellido} - Codigo: {this.codigo} - Reclamo: {this.servicioReclamado.Mostrar()}";
        }

        public static string MostrarReclamo(Reclamo r)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {r.codigo}");
            sb.AppendLine($"Cliente: {r.cliente.Nombre} {r.Cliente.Apellido}");
            sb.AppendLine($"Servicio reclamado: {r.servicioReclamado.Mostrar()}");

            return sb.ToString();
        }
    }
}
