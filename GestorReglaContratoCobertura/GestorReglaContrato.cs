using GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura
{
    public class GestorReglaContrato
    {
        private List<Regla> _listaReglas;

        public GestorReglaContrato()
        {
            _listaReglas = DatosPrueba.ObtenerReglas();
        }

        public GestorReglaContrato(List<Regla> listaReglas)
        {
            _listaReglas = listaReglas;
        }

        public List<Contrato> AplicarReglasContratoCobertura(List<Contrato> listaContratos, int convenio = 0, int aplicacion = 0, int plataforma = 0)
        {
            if (listaContratos.IsNullOrEmpty2())
                return listaContratos;

            // lista de respaldo
            var listaContratoOriginal = listaContratos.Clonar();

            try
            {
                _listaReglas = Predicado.ObtenerReglasCandidatas(_listaReglas, convenio, aplicacion, plataforma);

                if (_listaReglas.IsNullOrEmpty2())
                    return listaContratoOriginal;

                // Creación de constructores para Contrato - Beneficiario - BeneficioPlan
                var constructorContrato = new GestorReglaConstructorContrato(new Contrato());
                var constructorBeneficiario = new GestorReglaConstructorBeneficiario(new Beneficiario());
                var constructorBeneficioPlan = new GestorReglaConstructorBeneficioPlan(new BeneficiosPlan());

                //Variables auxiliares
                var modificarBeneficiario = false;
                var modificarContrato = false;

                foreach (var regla in _listaReglas)
                {
                    try
                    {
                        var contratosCandidatos = Predicado.ObtenerContratosCandidatos(listaContratos, regla.Entrada.EntradaContrato);
                        if (contratosCandidatos.IsNullOrEmpty2())
                        {
                            throw new Exception();
                        }

                        foreach (var contrato in contratosCandidatos)
                        {
                            regla.Entrada.EntradaBeneficiario.DeducibleTotal = contrato.DeducibleTotal;
                            var beneficiariosCandidatos = Predicado.ObtenerBeneficiariosCandidatos(contrato.Beneficiarios, regla.Entrada.EntradaBeneficiario);
                            if (beneficiariosCandidatos.IsNull2())
                            {
                                continue;
                            }

                            foreach (var beneficiario in beneficiariosCandidatos)
                            {
                                if (regla.Entrada.EntradaBeneficioPlan.IsNotNullOrEmpty2())
                                {
                                    modificarBeneficiario = false;
                                    foreach (var reglaBeneficio in regla.Entrada.EntradaBeneficioPlan)
                                    {
                                        var beneficiosPlanCandidatos = Predicado.ObtenerBeneficiosPlanCandidatos(beneficiario.BeneficiosPlan, reglaBeneficio.EntradaBeneficioPlan);

                                        foreach (var beneficioPlan in beneficiosPlanCandidatos)
                                        {
                                            modificarBeneficiario = true;
                                            constructorBeneficioPlan.IncorporarBeneficioPlan(beneficioPlan);
                                            constructorBeneficioPlan.AplicarRegla(reglaBeneficio.SalidaBeneficioPlan);
                                        }
                                    }
                                }
                                else
                                {
                                    constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                    constructorBeneficiario.AplicarRegla(regla.Salida.SalidaBeneficiario);
                                    modificarContrato = true;
                                }

                                if (modificarBeneficiario)
                                {
                                    constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                    constructorBeneficiario.AplicarRegla(regla.Salida.SalidaBeneficiario);
                                    modificarContrato = true;
                                }
                            }
                            if (beneficiariosCandidatos.IsNullOrEmpty2() || modificarContrato)
                            {
                                constructorContrato.IncorporarContrato(contrato);
                                constructorContrato.AplicarRegla(regla.Salida.SalidaContrato);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                return listaContratos;
            }
            catch (Exception)
            {
                return listaContratoOriginal;
            }
        }
    }
}
