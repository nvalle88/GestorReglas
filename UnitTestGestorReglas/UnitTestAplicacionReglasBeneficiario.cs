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
            var convenio = 0; // Convenio de Difare para cambio de texto en parámetro
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratoVacio();
            var listaReglas = DatosPruebaRegla.ReglaVacia();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, convenio, aplicacion, plataforma);

            // Assert
            Assert.AreEqual(0, listaContratos.Count);
        }
    }
}
