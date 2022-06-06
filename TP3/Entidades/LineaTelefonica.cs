using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LineaTelefonica : Servicio
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public LineaTelefonica()
        {

        }

        /// <summary>
        /// Constructor recibiendo un parametro
        /// </summary>
        /// <param name="precio">precio a asignar</param>
        public LineaTelefonica(double precio)
            :base(precio)
        {

        }

        /// <summary>
        /// Propiedad que retorna el precio del servicio con una recarga del 10%
        /// </summary>
        public override double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value + value * 0.10;
            }
        }

        /// <summary>
        /// Validara que el servicio recibido coincida con el que llama al metodo
        /// </summary>
        /// <param name="s">Servicio a comparar</param>
        /// <returns>Retorna true si coinciden, false caso contrario</returns>
        public override bool ValidarServicio(Servicio s)
        {
            return s.GetType() == typeof(LineaTelefonica);
        }

        /// <summary>
        /// Muestra el servicio con su precio
        /// </summary>
        /// <returns>Retorna los datos del servicio</returns>
        public override string Mostrar()
        {
            return $"Linea Telefonica - Precio: {this.Precio}";
        }

    }
}
