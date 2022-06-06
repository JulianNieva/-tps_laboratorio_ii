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

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Servicio()
        {
        }

        /// <summary>
        /// Constructor recibiendo un parametro
        /// </summary>
        /// <param name="precio">precio a asignar</param>
        public Servicio(double precio)
        {
            this.Precio = precio;
        }

        /// <summary>
        /// Propiedad que retorna el precio del servicio 
        /// </summary>
        public abstract double Precio
        {
            get; set;
        }

        /// <summary>
        /// Validara que el servicio recibido coincida con el que llama al metodo
        /// </summary>
        /// <param name="s">Servicio a comparar</param>
        /// <returns>Retorna true si coinciden, false caso contrario</returns>
        public abstract bool ValidarServicio(Servicio s);

        /// <summary>
        /// Muestra el servicio con su precio
        /// </summary>
        /// <returns>Retorna los datos del servicio</returns>
        public abstract string Mostrar();

    }
}
