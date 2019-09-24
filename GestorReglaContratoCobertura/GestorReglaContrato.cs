using GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using Saludsa.UtilidadesRest;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (listaContratos.Count == 0)
                return listaContratos;

            _listaReglas = Predicado.ObtenerReglasCandidatas(_listaReglas, convenio, aplicacion, plataforma);

            if (_listaReglas.Count == 0)
                return listaContratos;

            // Creación de constructores para Contrato - Beneficiario - BeneficioPlan
            var constructorContrato = new GestorReglaConstructorContrato(new Contrato());
            var directorContrato = new GestorReglaDirectorContrato(constructorContrato);
            var constructorBeneficiario = new GestorReglaConstructorBeneficiario(new Beneficiario());
            var directorBeneficiario = new GestorReglaDirectorBeneficiario(constructorBeneficiario);
            var constructorBeneficioPlan = new GestorReglaConstructorBeneficioPlan(new BeneficiosPlan());
            var directorBeneficioPlan = new GestorReglaDirectorBeneficioPlan(constructorBeneficioPlan);

            // lista de respaldo
            var listaContratoOriginal = listaContratos.CloneJson();

            //Variables auxiliares
            var modificarBeneficiario = false;
            var modificarContrato = false;

            foreach (var regla in _listaReglas)
            {
                try
                {
                    var contratosCandidatos = Predicado.ObtenerContratosCandidatos(listaContratos, regla.Entrada.EntradaContrato);
                    if (contratosCandidatos.IsNotNull2())
                    {
                        throw new Exception();
                    }

                    foreach (var contrato in contratosCandidatos)
                    {
                        regla.Entrada.EntradaBeneficiario.DeducibleTotal = contrato.DeducibleTotal;
                        var beneficiariosCandidatos = Predicado.ObtenerBeneficiariosCandidatos(contrato.Beneficiarios, regla.Entrada.EntradaBeneficiario);

                        if (beneficiariosCandidatos.IsNull2())
                        {
                            throw new Exception();
                        }

                        modificarContrato = false;

                        foreach (var beneficiario in beneficiariosCandidatos)
                        {
                            if (regla.Entrada.EntradaBeneficioPlan.IsNotNullOrEmpty2())
                            {
                                modificarBeneficiario = false;
                                foreach (var reglaBeneficio in regla.Entrada.EntradaBeneficioPlan)
                                {
                                    var beneficiosPlanCandidatos = Predicado.ObtenerBeneficiosPlanCandidatos(beneficiario.BeneficiosPlan, reglaBeneficio.EntradaBeneficioPlan);
                                    if (beneficiosPlanCandidatos.IsNull2())
                                    {
                                        throw new Exception();
                                    }
                                   
                                    foreach (var beneficioPlan in beneficiosPlanCandidatos)
                                    {
                                        modificarBeneficiario = true;
                                        constructorBeneficioPlan.IncorporarBeneficioPlan(beneficioPlan);
                                        directorBeneficioPlan.ConstruirBeneficioPlanConReglas(reglaBeneficio.SalidaBeneficioPlan);
                                    }
                                }
                            }
                            else
                            {
                                constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                directorBeneficiario.ConstruirBeneficiarioConReglas(regla.Salida);
                                modificarContrato = true;
                            }

                            if (modificarBeneficiario)
                            {
                                constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                directorBeneficiario.ConstruirBeneficiarioConReglas(regla.Salida);
                                modificarContrato = true;
                            }
                        }
                        if (beneficiariosCandidatos.IsNullOrEmpty())
                        {
                            constructorContrato.IncorporarContrato(contrato);
                            directorContrato.ConstruirContratoConReglas(regla.Salida);
                        }
                        if (modificarContrato)
                        {
                            constructorContrato.IncorporarContrato(contrato);
                            directorContrato.ConstruirContratoConReglas(regla.Salida);
                        }
                    }
                }
                catch (System.Exception)
                {
                    continue;
                }
            }

            return listaContratos;
        }
    }
}
