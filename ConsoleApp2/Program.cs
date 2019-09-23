using GestorReglaContratoCobertura;
using Newtonsoft.Json;
using System;
using UnitTestGestorReglas;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var convenio = 0; // Convenio de Difare para cambio de texto en parámetro
            var aplicacion = 0;
            var plataforma = 0;
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombreIND();

            var gestorReglas = new GestorReglaContrato(listaReglas);
            listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos);

            Console.WriteLine(JsonConvert.SerializeObject(listaContratos));
        }
    }
}
