using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Internet : Servicio
    {
        public Internet()
        {

        }

        public Internet(double precio)
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
                this.precio = value * 0.45;
            }
        }

        public override bool ValidarServicio(Servicio s)
        {
            return s.GetType() == typeof(Internet);
        }

        public override string Mostrar()
        {
            return $"Internet - Precio: {this.Precio}";
        }

    }
}
