using GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using Newtonsoft.Json;
using Saludsa.GestorReglaContratoCobertura.Mensaje;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saludsa.GestorReglaContratoCobertura
{
    public class GestorReglaContrato<T>
    {
        private List<ReglaContrato> _listaReglas;
        private List<Contrato> _listaContratos;
        public bool puedeAplicarRegla { get; }


        public GestorReglaContrato(List<ReglaContrato> listaReglas, List<T> listaContrato)
        {
            puedeAplicarRegla = false;

            if (listaReglas.IsNullOrEmpty())
                throw new Exception("Lista de reglas vacía");

            if (listaContrato.IsNullOrEmpty())
                throw new Exception("Lista de contratos vacía");

            try
            {
                _listaContratos = JsonConvert.DeserializeObject<List<Contrato>>(JsonConvert.SerializeObject(listaContrato));
                if (_listaContratos.IsNullOrEmpty()
                    || _listaContratos.Any(c => c.Numero.IsNull())
                    || _listaContratos.Any(c => c.Producto.IsNullOrEmpty())
                    || _listaContratos.Any(c => c.Region.IsNullOrEmpty())
                    || _listaContratos.Any(c => c.Codigo.IsNull()))
                    throw new Exception($"Lista de contratos no cumple con las validaciones requeridas");
            }
            catch (Exception ex)
            {
                throw new Exception($"No se puede deserializar la lista de contratos: {ex.Message}");
            }

            _listaReglas = listaReglas;
            puedeAplicarRegla = true;
        }

        public List<T> AplicarReglasContratoCobertura(out List<MensajeConfiguracionRegla> listaMensajes, int convenio = 0, int aplicacion = 0, int plataforma = 0)
        {
            listaMensajes = new List<MensajeConfiguracionRegla>();

            if (!puedeAplicarRegla)
            {
                listaMensajes.Add(new MensajeConfiguracionRegla
                {
                    Codigo = "NO_PUEDE_APLICAR",
                    Mensaje = "No se puede aplicar la regla"
                });
                return null;
            }

            // lista de respaldo
            var listaContratoOriginal = _listaContratos.Clonar();

            try
            {
                _listaReglas = Predicado.ObtenerReglasCandidatas(_listaReglas, convenio, aplicacion, plataforma);

                if (_listaReglas.IsNullOrEmpty())
                {
                    listaMensajes.Add(new MensajeConfiguracionRegla
                    {
                        Codigo = "LISTA_REGLAS_VACIA",
                        Mensaje = "Lista de reglas vacia"
                    });
                    return _listaContratos.DeserializarGenerico<T>();
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
                        var contratosCandidatos = Predicado.ObtenerContratosCandidatos(_listaContratos, regla, out var listaMensajesContrato);
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
                                            if (reglaBeneficio.SalidaBeneficioPlan.IsNotNullOrEmpty())
                                            {
                                                constructorBeneficioPlan.IncorporarBeneficioPlan(beneficioPlan);
                                                constructorBeneficioPlan.AplicarRegla(reglaBeneficio.SalidaBeneficioPlan);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (regla.Salida.IsNotNull() && regla.Salida.SalidaBeneficiario.IsNotNullOrEmpty())
                                    {
                                        constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                        constructorBeneficiario.AplicarRegla(regla.Salida.SalidaBeneficiario);
                                    }
                                    modificarContrato = true;
                                }

                                if (modificarBeneficiario)
                                {
                                    if (regla.Salida.IsNotNull() && regla.Salida.SalidaBeneficiario.IsNotNullOrEmpty())
                                    {
                                        constructorBeneficiario.IncorporarBeneficiario(beneficiario);
                                        constructorBeneficiario.AplicarRegla(regla.Salida.SalidaBeneficiario);
                                    }
                                    modificarContrato = true;
                                }
                            }
                            if (beneficiariosCandidatos.IsNullOrEmpty() || modificarContrato && regla.Salida.SalidaContrato.IsNotNullOrEmpty())
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

                return _listaContratos.DeserializarGenerico<T>();
            }
            catch (Exception)
            {
                return listaContratoOriginal.DeserializarGenerico<T>();
            }
        }
    }
}