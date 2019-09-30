using GestorReglaContratoCobertura;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGestorReglas
{
    [TestClass]
    public class UnitTestAplicacionReglasBeneficiario
    {
        [TestMethod]
        public void ValidarReglaContratoYReglaVacia()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoVacio();
            var listaReglas = DatosPruebaRegla.ReglaVacia();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual(0, listaContratos.Count);
        }
    }
}
