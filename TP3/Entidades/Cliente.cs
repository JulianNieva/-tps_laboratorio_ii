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

        public Cliente()
        {
            this.listaServicios = new List<Servicio>();
        }

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

        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Cliente)
            {
                retorno = this == (Cliente)obj;
            }

            return retorno;
        }

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

        public static Cliente operator +(Cliente c, Servicio s)
        {
            if(c != s)
            {
                c.listaServicios.Add(s);
            }

            return c;
        }

        public static Cliente operator -(Cliente c, Servicio s)
        {
            if(c == s)
            {
                c.listaServicios.Remove(s);
            }
            return c;
        }

        public override string ToString()
        {
            return $"{this.nombre} {this.apellido} - DNI: {this.dni}";
        }

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
