using ConstructorRegla;
using ConstructorRegla.Utiles;
using Newtonsoft.Json;
using Saludsa.UtilidadesRest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var convenio = 11715; // Convenio de Difare para cambio de texto en parámetro
            var aplicacion = 11715; // Convenio de Difare para cambio de texto en parámetro
            var plataforma = 11715; // Convenio de Difare para cambio de texto en parámetro
            var listaContratos = DatosPrueba.ObtenerContratoCobertura();
            var listaReglas = DatosPrueba.ObtenerReglas()
                .Where(regla => regla.EstadoActivo
                && Validaciones.ValidarFechaRegla(regla)
                && regla.Convenio.IsNotNullOrEmpty() ? regla.Convenio.Contains(convenio) : true
                && regla.Aplicacion.IsNotNullOrEmpty() ? regla.Aplicacion.Contains(aplicacion) : true
                && regla.Plataforma.IsNotNullOrEmpty() ? regla.Plataforma.Contains(plataforma) : true).ToList();


            listaReglas.ForEach(regla =>
            {
                if (regla.Entrada.IsNotNull() || regla.Salida.IsNotNull())
                {
                    if (regla.Entrada.EntradaContrato.IsNotNull())
                    {
                        Validaciones.ValidarReglasContrato();
                    }

                    if (regla.Entrada.EntradaBeneficiario.IsNotNull())
                    {
                        Validaciones.ValidarReglasBeneficiarios();
                    }

                    if (regla.Entrada.EntradaBeneficioPlan.IsNotNull())
                    {
                        Validaciones.ValidarBeneficiosPlan();
                    }

                    var predicado = Predicado.GeneraPredicado(regla);
                    var contratosPorAplicar = listaContratos.AsQueryable().Where(predicado).ToList();

                    if (contratosPorAplicar.Count > 0)
                    {
                        contratosPorAplicar.ForEach(contrato =>
                        {
                            var constructor = new GestorReglaConstructor(contrato);
                            var director = new GestorReglaDirector(constructor);
                            director.ConstruirContratoConReglas(regla.Salida);
                        });
                    }
                }
            });

            Console.WriteLine(JsonConvert.SerializeObject(listaContratos));
        }
    }
}
