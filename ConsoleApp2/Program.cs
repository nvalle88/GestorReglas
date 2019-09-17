using ConstructorRegla;
using Newtonsoft.Json;
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
            var listaContratos = DatosPrueba.ObtenerContratoCobertura();
            var listaReglas = DatosPrueba.ObtenerReglas();

            var listaContratosModificados = new List<Contrato>();

            if (convenio > 0)
                listaReglas = listaReglas
                    .Where(r => r.Entrada.Convenio == convenio)
                    .ToList();


            listaReglas.ForEach(regla =>
            {
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
            });

            Console.WriteLine(JsonConvert.SerializeObject(listaContratos));
        }
    }
}
