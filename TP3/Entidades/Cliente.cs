using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private string dni;
        private ELocalidad localidad;
        private List<Servicio> listaServicios;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Cliente()
        {
            this.listaServicios = new List<Servicio>();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// <param name="dni">Dni a asignar</param>
        /// <param name="localidad">Localidad a asignar</param>
        public Cliente(string nombre, string apellido, string dni, ELocalidad localidad)
            :this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Localidad = localidad;
            this.Dni = dni;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        
        public ELocalidad Localidad
        {
            get
            {
                return this.localidad;
            }
            set
            {
                this.localidad = value;
            }
        }

        public List<Servicio> ServiciosContratados
        {
            get
            {
                return this.listaServicios;
            }
            set
            {
                this.listaServicios = value;
            }
        }

        /// <summary>
        /// Compara 2 clientes mediante su dni
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>Retorna true si ambos clientes tienen el mismo dni, false caso contrario</returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            bool retorno = false;

            if(c1 is not null && c2 is not null)
            {
                if(c1.dni == c2.dni)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara 2 clientes mediante su dni
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>Retorna false si ambos clientes tienen el mismo dni, true caso contrario</returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Verifico si un cliente tiene el servicio recibido asignado
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool operator ==(Cliente c, Servicio s)
        {
            bool retorno = false;

            foreach (Servicio ser in c.listaServicios)
            {
                if (ser.ValidarServicio(s))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Cliente c, Servicio s)
        {
            return !(c == s);
        }

        /// <summary>
        /// Agrega un servicio a un cliente, siempre y cuando no este cargado
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Cliente operator +(Cliente c, Servicio s)
        {
            if(c != s)
            {
                c.listaServicios.Add(s);
            }

            return c;
        }

        /// <summary>
        /// Retorna unos datos del Cliente para tener mejor visibilidad en el formulario
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.nombre} {this.apellido} - DNI: {this.dni}";
        }

        /// <summary>
        /// Muestro los datos del cliente
        /// </summary>
        /// <param name="c">Cliente a mostrar</param>
        /// <returns></returns>
        public static string MostrarCliente(Cliente c)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DNI: {c.dni}");
            sb.AppendLine($"{c.nombre} {c.apellido}");
            sb.AppendLine($"Localidad: {c.localidad}");
            sb.AppendLine($"Servicios contratados: ");
            foreach (Servicio servicio in c.listaServicios)
            {
                sb.AppendLine(servicio.Mostrar());
            }

            return sb.ToString();
        }

    }
}
