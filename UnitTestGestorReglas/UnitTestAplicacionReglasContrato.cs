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
            var listaContratos = DatosPruebaContrato.ContratoVacio();
            var listaReglas = DatosPruebaRegla.ReglaVacia();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual(0, listaContratos.Count);
            Assert.AreEqual(0, listaReglas.Count);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionPreContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionPreIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Producto Individual - Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionPosContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionPosIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Ideal 4d Sierra Producto Individual -", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombreSobreescribirContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombreSobreescribirIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Producto Individual -", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionDesconocidaContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionDesconocidaIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionPreContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionPreIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Producto Individual - Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionPosPlanContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionPosIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec Producto Individual -", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionSobreescribirPlanContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionSobreescribirIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Producto Individual -", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionDesconocidaPlanContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionDesconocidaIND();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.AreEqual("Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratos.FirstOrDefault().Observaciones);
        }


        [TestMethod]
        public void ValidarReglaCoberturaMaximaContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.IsTrue(listaMensajes.Count == 0);
        }

        [TestMethod]
        public void ValidarReglaDeducibleTotalContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.IsTrue(listaMensajes.Count == 1);
            Assert.IsTrue(listaMensajes[0].Mensaje.Contains("No es una expresión lógica"));
        }


        [TestMethod]
        public void ValidarReglaCodigoPlanContratoIND()
        {
            // Arrange
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            // Assert
            Assert.IsTrue(listaMensajes.Count == 1);
            Assert.IsTrue(listaMensajes[0].Mensaje.Contains("CodigoPlan"));
        }
    }
}
