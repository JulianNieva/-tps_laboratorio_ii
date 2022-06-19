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

        /// <summary>
        /// Constructor estatico de Reclamos
        /// </summary>
        static Reclamo()
        {
            alfanumericoRnd = new Random();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Reclamo()
        {
        }

        /// <summary>
        /// Constructor por parametros
        /// </summary>
        /// <param name="cliente">Cliente a asignar</param>
        /// <param name="servicioReclamado">Servicio reclamado a asignar</param>
        /// <param name="codigo">Codigo a asignar</param>
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

        /// <summary>
        /// Genera un codigo alfanumerico para asignar a un reclamo
        /// </summary>
        /// <returns>Retorna el codigo generado</returns>
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

        /// <summary>
        /// Compara dos reclamos mediante sus clientes, y el servicio reclamado
        /// </summary>
        /// <param name="r1">Primer reclamo a comparar</param>
        /// <param name="r2">Segundo reclamo a comparar</param>
        /// <returns>Retorna true si ambos reclamos son iguales, false caso contrario</returns>
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

        /// <summary>
        /// Compara dos reclamos mediante sus clientes, y el servicio reclamado
        /// </summary>
        /// <param name="r1">Primer reclamo a comparar</param>
        /// <param name="r2">Segundo reclamo a comparar</param>
        /// <returns>Retorna false si ambos reclamos son iguales, true caso contrario</returns>
        public static bool operator !=(Reclamo r1, Reclamo r2)
        {
            return !(r1 == r2);
        }

        /// <summary>
        /// Retorna los datos del reclamos para mostrar en el formulario
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Cliente: {this.cliente.Nombre} - {this.cliente.Apellido} - Codigo: {this.codigo} - Reclamo: {this.servicioReclamado.Mostrar()}";
        }

        /// <summary>
        /// Muestro el reclamos recibido
        /// </summary>
        /// <param name="r">Reclamo recibido</param>
        /// <returns></returns>
        public static string MostrarReclamo(Reclamo r)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {r.codigo}");
            sb.Append($"Cliente: {Cliente.MostrarCliente(r.cliente)}");
            sb.AppendLine($"Servicio reclamado: {r.servicioReclamado.Mostrar()}");

            return sb.ToString();
        }
    }
}
