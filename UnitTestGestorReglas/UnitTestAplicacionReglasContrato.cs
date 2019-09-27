using GestorReglaContratoCobertura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestGestorReglas
{
    [TestClass]
    public class UnitTestAplicacionReglasContrato
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
            Assert.AreEqual(0, listaReglas.Count);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePlanContratoIND()
        {
            // Arrange
            var convenio = 0;
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombreIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, convenio, aplicacion, plataforma);

            // Assert
            Assert.AreEqual("Producto Individual - ", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionesContratoIND()
        {
            // Arrange
            var convenio = 0;
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, convenio, aplicacion, plataforma);

            // Assert
            Assert.AreEqual("Cambio de Observación - Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePlanContratoINDBusquedaCodigoPlan()
        {
            // Arrange
            var convenio = 0;
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratosIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, convenio, aplicacion, plataforma);

            // Assert
            Assert.AreEqual("Producto Individual - Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePlanContratoINDBusquedaCoberturaMaxima()
        {
            // Arrange
            var convenio = 0;
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratosIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, convenio, aplicacion, plataforma);

            // Assert
            Assert.AreEqual("Producto Individual - Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }
    }
}
