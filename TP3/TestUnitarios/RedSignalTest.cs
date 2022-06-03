using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Entidades.Excepciones;

namespace TestUnitarios
{

    [TestClass]
    public class RedSignalTest
    {
        RedSignal red = new RedSignal();

        Reclamo r1 = new Reclamo(new Cliente("Roberto", "Hernandez", "44555666", ELocalidad.BuenosAires), new LineaTelefonica(180));
        Reclamo r2 = new Reclamo(new Cliente("Presti", "Francis", "44555666", ELocalidad.EntreRios), new Internet(426));


        [TestMethod]
        public void Comparacion_CuandoRecibeUnReclamosYaCargadoEnLaListaDeReclamos_DebeRetornarTrue()
        {
            red.ListaDeReclamos.Add(r1);
            red.ListaDeReclamos.Add(r2);

            bool retorno = red == r1;

            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Comparacion_CuandoRecibeUnReclamosQueNoEstaCargadoEnLaListaDeReclamos_DebeRetornarFalse()
        {
            red.ListaDeReclamos.Add(r2);

            bool retorno = red == r1;

            Assert.IsFalse(retorno);
        }

        [TestMethod]
        [ExpectedException(typeof(ClienteYaExistenteException))]
        public void Agregar_CuandoRecibeUnClienteQueEstaCargado_DebeLanzarLaExcepcionClienteYaExistenteException()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Cliente c2 = new Cliente("Prest", "Francis", "44554525", ELocalidad.BuenosAires);

            red += c1;
            red += c2;
        }

        [TestMethod]
        public void Agregar_CuandoRecibeUnClienteQueNoEstaCargado_LaCantidadDeClientesCargadosDebeSer2()
        {
            Cliente c1 = new Cliente("Fernando", "Herejes", "44554525", ELocalidad.BuenosAires);
            Cliente c2 = new Cliente("Prest", "Francis", "55666345", ELocalidad.BuenosAires);

            red += c1;
            red += c2;

            Assert.AreEqual(2, red.ListaDeClientes.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ReclamoYaExistenteException))]
        public void Agregar_CuandoRecibeUnReclamoseQueEstaCargado_DebeLanzarLaExcepcionReclamoYaExistenteException()
        {
            red += r1;
            red += r2;
            red += r1;
        }

    }
}
