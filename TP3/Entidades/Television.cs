using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Television :Servicio
    {
        public Television(double precio)
            :base(precio)
        {
            
        }

        public override double Precio
        {
            get
            {
                return this.precio + this.precio * 0.20;
            }
        }

        public override bool ValidarServicio(Servicio s)
        {
            return s.GetType() == typeof(Television);
        }

        public override string Mostrar()
        {
            return $"Television\nPrecio: {this.Precio}";
        }

    }
}
