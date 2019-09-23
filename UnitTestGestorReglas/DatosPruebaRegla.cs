using GestorReglaContratoCobertura.Modelos.Regla;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTestGestorReglas
{
    public static class DatosPruebaRegla
    {
        public static List<Regla> ReglaVacia() => new List<Regla>();

        public static List<Regla> ReglaCambioNombreIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\": \"01\",\"Descripcion\": \"Regla para productos individuales cambio de nombre plan\",\"FechaInicioRegla\": null,\"FechaFinRegla\": \"2019-09-30\",\"EstadoActivo\": true,\"Convenio\": [],\"Aplicacion\": [],\"Plataforma\": [],\"Entrada\": {\"EntradaContrato\": {\"Producto\": [\"IND\"],\"CoberturaMaxima\": \">=50000\"},\"EntradaBeneficiario\": {},\"EntradaBeneficioPlan\": []},\"Salida\": {\"NombrePlan\": {\"Campo\": \"NombrePlan\",\"Texto\": \"Producto Individual - \"}}}]");

        public static List<Regla> ReglaCambioObservacionIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales cambio de observacion contrato\",\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"EstadoActivo\":true,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"ObservacionesContrato\":{\"Texto\":\"Cambio de Observaci\u00f3n - \"}}}]");
    }
}
