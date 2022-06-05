using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Television))]
    [XmlInclude(typeof(Internet))]
    [XmlInclude(typeof(LineaTelefonica))]
    public abstract class Servicio
    {
        protected double precio;

        public Servicio()
        {
        }

        public Servicio(double precio)
        {
            this.Precio = precio;
        }

        public abstract double Precio
        {
            get; set;
        }

        public abstract bool ValidarServicio(Servicio s);

        public abstract string Mostrar();

    }
}
