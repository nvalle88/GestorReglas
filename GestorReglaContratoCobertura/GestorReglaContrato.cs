using GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Error;
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

        public List<Contrato> AplicarReglasContratoCobertura(List<Contrato> listaContratos, out List<MensajeConfiguracionRegla> listaMensajes, int convenio = 0, int aplicacion = 0, int plataforma = 0)
        {
            listaMensajes = new List<MensajeConfiguracionRegla>();

            if (listaContratos.IsNullOrEmpty())
            {
                listaMensajes.Add(new MensajeConfiguracionRegla
                {
                    Codigo = "LISTA_CONTRATOS_VACIA",
                    Mensaje = "Lista de contratos vacia"
                });
                return listaContratos;
            }

            // lista de respaldo
            var listaContratoOriginal = listaContratos.Clonar();

            try
            {
                _listaReglas = Predicado.ObtenerReglasCandidatas(_listaReglas, convenio, aplicacion, plataforma, out listaMensajes);

                if (_listaReglas.IsNullOrEmpty())
                {
                    listaMensajes.Add(new MensajeConfiguracionRegla
                    {
                        Codigo = "LISTA_REGLAS_VACIA",
                        Mensaje = "Lista de reglas vacia"
                    });

                    listaMensajes.AddRange(listaMensajes);

                    return listaContratos;
                }

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
                        var contratosCandidatos = Predicado.ObtenerContratosCandidatos(listaContratos, regla, out var listaMensajesContrato);
                        if (contratosCandidatos.IsNullOrEmpty())
                        {
                            listaMensajes.AddRange(listaMensajesContrato);
                            throw new Exception();
                        }

                        foreach (var contrato in contratosCandidatos)
                        {
                            if (regla.Entrada.EntradaBeneficiario.IsNotNull())
                                regla.Entrada.EntradaBeneficiario.DeducibleTotal = contrato.DeducibleTotal;

                            var beneficiariosCandidatos = Predicado.ObtenerBeneficiariosCandidatos(contrato.Beneficiarios, regla, out var listaMensajesBeneficiarios);
                            if (beneficiariosCandidatos.IsNull())
                            {
                                listaMensajes.AddRange(listaMensajesBeneficiarios);
                                continue;
                            }

                            foreach (var beneficiario in beneficiariosCandidatos)
                            {
                                if (regla.Entrada.EntradaBeneficios.IsNotNullOrEmpty())
                                {
                                    modificarBeneficiario = false;
                                    foreach (var reglaBeneficio in regla.Entrada.EntradaBeneficios)
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
                            if (beneficiariosCandidatos.IsNullOrEmpty() || modificarContrato)
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
