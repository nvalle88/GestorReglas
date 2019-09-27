using System;
using System.Linq;
using GestorReglaContratoCobertura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestGestorReglas;

namespace UnitTestReglasBeneficiarios
{
    [TestClass]
    public class UnitTestReglasBeneficiario
    {
        [TestMethod]
        public void CambioDatosBeneficiario()
        {
            var convenio = 0;
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioBeneficiarioContrato();

            // Act
            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, convenio, aplicacion, plataforma);

            // Assert
            Assert.AreEqual("Titular del contrato", listaContratos.FirstOrDefault().Beneficiarios.FirstOrDefault().RelacionDependiente);
            Assert.AreEqual("Ana Basulto", listaContratos.FirstOrDefault().Beneficiarios.FirstOrDefault().Nombres);
            Assert.AreEqual(10, listaContratos.FirstOrDefault().Version);
            Assert.AreEqual("<<Saludsa>> Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }
    }
}
