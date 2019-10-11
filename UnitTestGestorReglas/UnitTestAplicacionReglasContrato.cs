using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos.Contrato;
using Saludsa.GestorReglaContratoCobertura;
using System;
using System.Linq;

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

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var temp = gestor.AplicarReglasContratoCobertura(out var mensajes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Producto Individual - Ideal 4d Sierra", listaContratosRespuesta.FirstOrDefault().NombrePlan);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionPosContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionPosIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Ideal 4d Sierra Producto Individual -", listaContratosRespuesta.FirstOrDefault().NombrePlan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void ValidarReglaCambioNombreSobreescribirContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombreSobreescribirIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Producto Individual -", listaContratosRespuesta.FirstOrDefault().NombrePlan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void ValidarReglaCambioNombrePosicionDesconocidaContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionDesconocidaIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Ideal 4d Sierra", listaContratosRespuesta.FirstOrDefault().NombrePlan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Validar regla cambio observaciones con posición
        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionPreContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionPreIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Producto Individual - Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratosRespuesta.FirstOrDefault().Observaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionPosPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionPosIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec Producto Individual -", listaContratosRespuesta.FirstOrDefault().Observaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void ValidarReglaCambioObservacionSobreescribirPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionSobreescribirIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Producto Individual -", listaContratosRespuesta.FirstOrDefault().Observaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void ValidarReglaCambioObservacionPosicionDesconocidaPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioObservacionPosicionDesconocidaIND();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual("Contrato impago, favor comuníquese con Saludsa al 6020920 o escribe al vive@saludsa.com.ec", listaContratosRespuesta.FirstOrDefault().Observaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Validar regla búsqueda expresiones lógicas correctas 1 proposición
        [TestMethod]
        public void ValidarReglaCoberturaMaximaContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima1Prep();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaDeducibleTotalContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal1Prep();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaCodigoPlanContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan1Prep();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        #endregion

        #region Validar regla búsqueda expresiones lógicas correctas 2 proposiciones
        [TestMethod]
        public void ValidarReglaCoberturaMaxima2PrepContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima2Prep();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaDeducibleTotal2PrepContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal2Prep();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaCodigoPlan2PrepContratoIND()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan2Prep();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Producto Individual", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        #endregion

        #region Validar regla búsqueda expresiones lógicas correctas 1 proposición fuera rango no cambios
        [TestMethod]
        public void ValidarReglaCoberturaMaximaContratoINDFueraRango()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCoberturaMaxima1PrepFueraRango();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Ideal 4d Sierra", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaDeducibleTotalContratoINDFueraRango()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleTotal1PrepFueraRango();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Ideal 4d Sierra", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaCodigoPlanContratoINDFueraRango()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCodigoPlan1PrepFueraRango();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].NombrePlan.Equals("Ideal 4d Sierra", StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.IsTrue(mensajes.Count == 0);
                Assert.IsTrue(listaContratosRespuesta[0].Beneficiarios.Where(b => b.Edad >= 18).ToList().TrueForAll(b => b.Observaciones.Equals("Producto corporativo")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        #endregion

        #endregion

        [TestMethod]
        public void ValidarReglaEntradaBeneficiarioNull()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaEntradaBeneficiarioNull();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                Assert.AreEqual(mensajes.Count, 0);
                Assert.AreEqual(listaContratosRespuesta[0].NombrePlan, "Producto Individual");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        [TestMethod]
        public void ValidarReglaSuperaDeducible()
        {
            var listaContratos = DatosPruebaContrato.ContratoCOR();
            var listaReglas = DatosPruebaRegla.ReglaSuperaDeducible();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                var beneficiario = listaContratosRespuesta[0].Beneficiarios.First(b => b.NumeroPersona == 692540);

                Assert.IsNotNull(beneficiario);
                Assert.AreEqual(mensajes.Count, 0);
                Assert.AreEqual(beneficiario.BeneficiosPlan.First(bp => bp.CodigoBeneficio == "A002").Valor, 12);
                Assert.IsTrue(beneficiario.BeneficiosPlan.Where(bp => bp.EsPorcentaje).ToList().TrueForAll(bp => !bp.Credito));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        [TestMethod]
        public void ValidarCambioNombrePlan()
        {
            var listaContratos = DatosPruebaContrato.ContratosUsuario0908848617();
            var listaReglas = DatosPruebaRegla.ReglasCambioNombrePlanDifare_ObservacionContratoVigente_NoCumpleDeducible_CreditoFalso();

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes);
                var contratosINDXPR = listaContratosRespuesta.Where(c => new[] { "IND", "XPR" }.Contains(c.Producto)).ToList();
                var contratosCORPOO = listaContratosRespuesta.Where(c => new[] { "COR", "POO" }.Contains(c.Producto)).ToList();

                //Assert.AreEqual(listaMensajes.Count, 1);
                //Assert.IsTrue(listaMensajes[0].Codigo.Equals("LISTA_REGLAS_VACIA"));

                Assert.AreEqual(mensajes.Count, 0);
                Assert.IsTrue(contratosINDXPR.TrueForAll(c => c.NombrePlan.Contains("<<SALUD - Cobro Fee + Min $ 10.00>>")));
                Assert.IsTrue(contratosCORPOO.TrueForAll(c => c.NombrePlan.Contains("<<SALUD>>")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void ValidarDeducibleContrato()
        {
            var listaContratos = DatosPruebaContrato.Contrato743089();
            var listaReglas = DatosPruebaRegla.ReglaDeducibleCendiavia();
            try
            {
                var gestor = new GestorReglaContrato<Contrato>(listaReglas, listaContratos);
                var listaContratosRespuesta = gestor.AplicarReglasContratoCobertura(out var mensajes, 5045201, 10319);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
