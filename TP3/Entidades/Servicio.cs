using System;
using System.Text;

namespace Entidades
{
    public abstract class Servicio
    {
        protected double precio;

        public Servicio(double precio)
        {
            this.precio = precio;
        }

        public abstract double Precio
        {
            get;
        }

        public abstract bool ValidarServicio(Servicio s);

        public abstract string Mostrar();

    }
}
