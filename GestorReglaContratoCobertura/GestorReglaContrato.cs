using GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using Saludsa.UtilidadesRest;
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

            _listaReglas.ForEach(regla =>
            {
                var contratosCandidatos = Predicado.ObtenerContratosCandidatos(listaContratos, regla.Entrada.EntradaContrato);

                contratosCandidatos.ForEach(contrato =>
                {
                    if (contrato.Beneficiarios.IsNotNull())
                    {
                        // Agregar deducible del contrato para validaciones en el beneficiario
                        regla.Entrada.EntradaBeneficiario.DeducibleTotal = contrato.DeducibleTotal;

                        var beneficiariosCandidatos = Predicado.ObtenerBeneficiariosCandidatos(contrato.Beneficiarios, regla.Entrada.EntradaBeneficiario);

                        beneficiariosCandidatos.ForEach(beneficiario =>
                        {
                            if (beneficiario.BeneficiosPlan.IsNotNull())
                            {
                                if (regla.Entrada.EntradaBeneficioPlan.IsNotNullOrEmpty())
                                {
                                    regla.Entrada.EntradaBeneficioPlan.ForEach(reglaBeneficio =>
                                    {
                                        var beneficiosPlanCandidatos = Predicado.ObtenerBeneficiosPlanCandidatos(beneficiario.BeneficiosPlan, reglaBeneficio.EntradaBeneficioPlan);

                                        beneficiosPlanCandidatos.ForEach(beneficioPlan =>
                                        {
                                            constructorBeneficioPlan.IncorporarBeneficioPlan(beneficioPlan);
                                            directorBeneficioPlan.ConstruirBeneficioPlanConReglas(reglaBeneficio.SalidaBeneficioPlan);
                                            constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                            directorBeneficiario.ConstruirBeneficiarioConReglas(regla.Salida);
                                            constructorContrato.IncorporarContrato(contrato);
                                            directorContrato.ConstruirContratoConReglas(regla.Salida);
                                        });
                                    });
                                }
                                else
                                {
                                    constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                    directorBeneficiario.ConstruirBeneficiarioConReglas(regla.Salida);
                                    constructorContrato.IncorporarContrato(contrato);
                                    directorContrato.ConstruirContratoConReglas(regla.Salida);
                                }
                            }
                            else
                            {
                                constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                directorBeneficiario.ConstruirBeneficiarioConReglas(regla.Salida);
                                constructorContrato.IncorporarContrato(contrato);
                                directorContrato.ConstruirContratoConReglas(regla.Salida);
                            }
                        });
                    }
                    else
                    {
                        constructorContrato.IncorporarContrato(contrato);
                        directorContrato.ConstruirContratoConReglas(regla.Salida);
                    }
                });
            });

            return listaContratos;
        }
    }
}
