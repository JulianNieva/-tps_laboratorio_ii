using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class ClientesTest
    {
        [TestMethod]
        public void Comparacion_CuandoRecibeDosClientesIguales_DebeRetornarTrue()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Cliente c2 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);

            bool resultado = c1 == c2;

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Comparacion_CuandoRecibeDosClientesDistinto_DebeRetornarFalse()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Cliente c2 = new Cliente("Hernan", "Herejes", "44768545", ELocalidad.BuenosAires);

            bool resultado = c1 == c2;

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Comparacion_CuandoRecibeUnServicioQueYaEstaCargado_DebeRetornarTrue()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Television t = new Television(450);
            Internet i = new Internet(650);

            c1.ServiciosContratados.Add(t);
            c1.ServiciosContratados.Add(i);

            bool resultado = c1 ==i;

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Comparacion_CuandoRecibeUnServicioQueNoEstaCargado_DebeRetornarFalse()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Television t = new Television(450);
            Internet i = new Internet(650);

            c1.ServiciosContratados.Add(i);

            bool resultado = c1 == t;

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Agregar_CuandoSeDeseaAgregarUnNuevoServicio_DebeTener2ServiciosEnTotal()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Television t = new Television(450);
            Internet i = new Internet(650);

            c1.ServiciosContratados.Add(i);

            c1+=t;

            Assert.AreEqual(2,c1.ServiciosContratados.Count);
        }

        [TestMethod]
        public void Agregar_CuandoSeDeseaAgregarUnServicioYaCargado_DebeTener3ServiciosEnTotal()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Television t = new Television(450);
            Internet i = new Internet(650);
            LineaTelefonica l = new LineaTelefonica(250);

            c1.ServiciosContratados.Add(i);
            c1.ServiciosContratados.Add(t);

            c1 += t;
            c1 += l;

            Assert.AreEqual(3, c1.ServiciosContratados.Count);
        }

        [TestMethod]
        public void Eliminar_CuandoSeDeseaEliminarUnServicioYaCargado_DebeTener1ServicioEnTotal()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Television t = new Television(450);
            Internet i = new Internet(650);

            c1.ServiciosContratados.Add(i);
            c1.ServiciosContratados.Add(t);

            c1 -= i;

            Assert.AreEqual(1, c1.ServiciosContratados.Count);
        }

        [TestMethod]
        public void Eliminar_CuandoSeDeseaEliminarUnServicioNoExistente_DebeTener2ServiciosEnTotal()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Television t = new Television(450);
            Internet i = new Internet(650);
            LineaTelefonica l = new LineaTelefonica(250);

            c1.ServiciosContratados.Add(i);
            c1.ServiciosContratados.Add(t);

            c1 -= l;

            Assert.AreEqual(2, c1.ServiciosContratados.Count);
        }
    }
}
