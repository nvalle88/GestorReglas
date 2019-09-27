using GestorReglaContratoCobertura;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnitTestGestorReglas;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutar(InicioRegla(), InicioContrato());
            Console.ReadLine();
        }

        public static List<Contrato>  InicioContrato()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            listaContratos.AddRange(DatosPruebaContrato.ContratoPOO());
            listaContratos.AddRange(DatosPruebaContrato.ContratosIND());
            return listaContratos;
        }

        public static List<Regla> InicioRegla()
        {
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionDesconocidaIND();
            listaReglas.AddRange(DatosPruebaRegla.ReglaCambioObservacionIND());
            listaReglas.AddRange(DatosPruebaRegla.ReglaCambioObservacionPosicionDesconocidaIND());
            listaReglas.AddRange(DatosPruebaRegla.ReglaCoberturaMaxima());
            listaReglas.AddRange(DatosPruebaRegla.ReglaCoberturaMaximaMayorIgualValor());
            listaReglas.AddRange(DatosPruebaRegla.ReglaCodigoPlan());
            return listaReglas;
        }

        public static void Ejecutar(List<Regla> listaReglas,List<Contrato> listaContratos)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            stopwatch.Start();
            Parallel.For(0,10000,r=>
            {
                var convenio = 0; // Convenio de Difare para cambio de texto en parámetro
                var aplicacion = 0;
                var plataforma = 0;
                var gestorReglas = new GestorReglaContrato(listaReglas);
                listaContratos = gestorReglas.AplicarReglasContratoCobertura(listaContratos);
            });

            stopwatch.Stop();
            Console.WriteLine($" [Tiempo sin carga data: {stopwatch.ElapsedMilliseconds}] ,");
            Console.ReadLine();
            Ejecutar(InicioRegla(),InicioContrato());
        }
    }
}
