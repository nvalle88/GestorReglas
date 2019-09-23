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
            var predicadoRegla = Predicado.GeneraPredicadoRegla(convenio, aplicacion, plataforma);
            _listaReglas = _listaReglas.AsQueryable().Where(predicadoRegla).ToList();

            if (_listaReglas.Count == 0)
                return listaContratos;

            // Creación de constructores para Contrato - Beneficiario - BeneficioPlan
            var constructorContrato = new GestorReglaConstructorContrato(new Contrato());
            var directorContrato = new GestorReglaDirectorContrato(constructorContrato);
            var constructorBeneficiario = new GestorReglaConstructorBeneficiario(new Beneficiario());
            var directorBeneficiario = new GestorReglaDirectorBeneficiario(constructorBeneficiario);
            var constructorBeneficioPlan = new GestorReglaConstructorBeneficioPlan(new BeneficiosPlan());
            var directorBeneficioPlan = new GestorReglaDirectorBeneficioPlan(constructorBeneficioPlan);
            var listaContratoOriginal = listaContratos.CloneJson();

            _listaReglas.ForEach(regla =>
            {
                var predicadoContrato = Predicado.GeneraPredicadoContrato(regla.Entrada.EntradaContrato);
                //si falla al crear el predicado, no aplicar la regla
                //if (predicadoContrato.IsNull())
                var contratosPorAplicar = listaContratos.AsQueryable().Where(predicadoContrato).ToList();

                contratosPorAplicar.ForEach(contrato =>
                {
                    constructorContrato.IncorporarContrato(contrato);
                    directorContrato.ConstruirContratoConReglas(regla.Salida);

                    if (contrato.Beneficiarios.IsNotNull())
                    {
                        // Agregar deducible del contrato para validaciones en el beneficiario
                        regla.Entrada.EntradaBeneficiario.DeducibleTotal = contrato.DeducibleTotal;

                        var predicadoBeneficiario = Predicado.GeneraPredicadoBeneficiario(regla.Entrada.EntradaBeneficiario);
                        var beneficiariosPorAplicar = contrato.Beneficiarios.AsQueryable().Where(predicadoBeneficiario).ToList();

                        beneficiariosPorAplicar.ForEach(beneficiario =>
                        {
                            constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                            directorBeneficiario.ConstruirBeneficiarioConReglas(regla.Salida);

                            if (beneficiario.BeneficiosPlan.IsNotNull())
                            {
                                regla.Entrada.EntradaBeneficioPlan.ForEach(reglaBeneficio =>
                                {
                                    var predicadoBeneficioPlan = Predicado.GeneraPredicadoBeneficioPlan(reglaBeneficio.EntradaBeneficioPlan);
                                    var beneficiosPlanPorAplicar = beneficiario.BeneficiosPlan.AsQueryable().Where(predicadoBeneficioPlan).ToList();

                                    beneficiosPlanPorAplicar.ForEach(beneficioPlan =>
                                    {
                                        constructorBeneficioPlan.IncorporarBeneficioPlan(beneficioPlan);
                                        directorBeneficioPlan.ConstruirBeneficioPlanConReglas(reglaBeneficio.SalidaBeneficioPlan);
                                    });
                                });
                            }
                        });
                    }
                });
            });

            return listaContratos;
        }
    }
}
