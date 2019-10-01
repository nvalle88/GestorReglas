using GestorReglaContratoCobertura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Newtonsoft.Json;


namespace UnitTestGestorReglas
{
    [TestClass]
    public class UnitTestAplicacionReglasContrato
    {
        #region Validar reglas Contrato

        #region Validar regla vacia
        [TestMethod]
        public void ValidarReglaContratoYReglaVacia()
        {
            var listaContratos = DatosPruebaContrato.ContratoVacio();
            var listaReglas = DatosPruebaRegla.ReglaVacia();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual(0, listaContratos.Count);
            Assert.AreEqual(0, listaReglas.Count);
        }
        #endregion

        #region Validar regla cambio nombre plan con posición
        [TestMethod]
        public void ValidarReglaCambioNombrePosicionPreContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionPreIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Producto Individual - Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionPosContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionPosIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Ideal 4d Sierra Producto Individual -", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombreSobreescribirContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombreSobreescribirIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Producto Individual -", listaContratos.FirstOrDefault().NombrePlan);
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionDesconocidaContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionDesconocidaIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Ideal 4d Sierra", listaContratos.FirstOrDefault().NombrePlan);
        }
        #endregion

        #region Validar regla cambio observaciones con posición
        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionPreContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionPreIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Producto Individual - Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionPosPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionPosIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec Producto Individual -", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionSobreescribirPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionSobreescribirIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Producto Individual -", listaContratos.FirstOrDefault().Observaciones);
        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionDesconocidaPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionDesconocidaIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual("Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratos.FirstOrDefault().Observaciones);
        }
        #endregion

        #region Validar regla búsqueda expresiones lógicas correctas 1 proposición
        [TestMethod]
        public void ValidarReglaCoberturaMaximaContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima1Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ValidarReglaDeducibleTotalContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal1Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ValidarReglaCodigoPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan1Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Validar regla búsqueda expresiones lógicas correctas 2 proposiciones
        [TestMethod]
        public void ValidarReglaCoberturaMaxima2PrepContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima2Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ValidarReglaDeducibleTotal2PrepContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal2Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ValidarReglaCodigoPlan2PrepContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan2Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Validar regla búsqueda expresiones lógicas correctas 1 proposición fuera rango no cambios
        [TestMethod]
        public void ValidarReglaCoberturaMaximaContratoINDFueraRango()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima1PrepFueraRango();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Ideal 4d Sierra", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ValidarReglaDeducibleTotalContratoINDFueraRango()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal1PrepFueraRango();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Ideal 4d Sierra", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ValidarReglaCodigoPlanContratoINDFueraRango()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan1PrepFueraRango();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].NombrePlan.Equals("Ideal 4d Sierra", StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #endregion


        #region Validar reglas Beneficiario

        #region Validar regla búsqueda expresiones lógicas correctas 1 proposición
        [TestMethod]
        public void ValidarReglaEdadContratoCOR()
        {
            var listaContratos = DatosPruebaContrato.ContratoCOR();
            var listaReglas = DatosPruebaRegla.ReglaEdad1Prep();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.IsTrue(listaMensajes.Count == 0);
            Assert.IsTrue(listaContratos[0].Beneficiarios.Where(b => b.Edad >= 18).ToList().TrueForAll(b => b.Observaciones.Equals("Producto corporativo")));
        }

        #endregion

        #endregion

        [TestMethod]
        public void ValidarReglaEntradaBeneficiarioNull()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaEntradaBeneficiarioNull();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            Assert.AreEqual(listaMensajes.Count, 0);
            Assert.AreEqual(listaContratos[0].NombrePlan, "Producto Individual");
        }

        [TestMethod]
        public void ValidarReglaSuperaDeducible()
        {
            var listaContratos = DatosPruebaContrato.ContratoCOR();
            var listaReglas = DatosPruebaRegla.ReglaSuperaDeducible();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos, out var listaMensajes);

            var beneficiario = listaContratos[0].Beneficiarios.First(b => b.NumeroPersona == 692540);

            Assert.IsNotNull(beneficiario);
            Assert.AreEqual(listaMensajes.Count, 0);
            Assert.AreEqual(beneficiario.BeneficiosPlan.First(bp => bp.CodigoBeneficio == "A002").Valor, 12);
            Assert.IsTrue(beneficiario.BeneficiosPlan.Where(bp => bp.EsPorcentaje).ToList().TrueForAll(bp => !bp.Credito));
        }

    }
}
