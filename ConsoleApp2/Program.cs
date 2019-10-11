using Saludsa.GestorReglaContratoCobertura;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos.Add(new Contrato { Region = "ABC", Producto = "DEF", Numero = 20 });
            contratos.Add(new Contrato { Region = "QWE", Producto = "RTY", Numero = 40 });

            try
            {
                var gestor = new GestorReglaContrato<Contrato>(new List<ReglaContrato>(), contratos);
                var temp = gestor.AplicarReglasContratoCobertura(out var mensajes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Contrato
    {
        public string Region { get; set; }
        public string Producto { get; set; }
        public int Numero { get; set; }
    }
}
