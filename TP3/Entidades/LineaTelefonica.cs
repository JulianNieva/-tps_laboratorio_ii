using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LineaTelefonica : Servicio
    {
        public LineaTelefonica()
        {

        }

        public LineaTelefonica(double precio)
            :base(precio)
        {

        }

        public override double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value * 0.10;
            }
        }

        public override bool ValidarServicio(Servicio s)
        {
            return s.GetType() == typeof(LineaTelefonica);
        }

        public override string Mostrar()
        {
            return $"Linea Telefonica - Precio: {this.Precio}";
        }

    }
}
