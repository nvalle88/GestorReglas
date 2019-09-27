using GestorReglaContratoCobertura.Modelos.Regla;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTestGestorReglas
{
    public static class DatosPruebaRegla
    {
        public static List<Regla> ReglaVacia() => new List<Regla>();

        public static List<Regla> ReglaCambioNombrePosicionPreIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pre\"}]}}]");

        public static List<Regla> ReglaCambioNombrePosicionPosIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pos\"}]}}]");

        public static List<Regla> ReglaCambioNombreSobreescribirIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\"}]}}]");

        public static List<Regla> ReglaCambioNombrePosicionDesconocidaIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"222\"}]}}]");




        public static List<Regla> ReglaCambioObservacionPosicionPreIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pre\"}]}}]");

        public static List<Regla> ReglaCambioObservacionPosicionPosIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pos\"}]}}]");

        public static List<Regla> ReglaCambioObservacionSobreescribirIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\"}]}}]");

        public static List<Regla> ReglaCambioObservacionPosicionDesconocidaIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"222\"}]}}]");










        public static List<Regla> ReglaCambioObservacionIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales cambio de observacion contrato\",\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"EstadoActivo\":true,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"ObservacionesContrato\",\"Valor\":\"Cambio de Observaciu00f3n - \"}]}}]");

        public static List<Regla> ReglaCoberturaMaximaMayorIgualValor()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales cambio de nombre plan\",\"FechaInicioRegla\":null,\"FechaFinRegla\":\"2019-09-30\",\"EstadoActivo\":true,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"],\"CoberturaMaxima\":\">=50000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual - \"}]}}]");

        public static List<Regla> ReglaCodigoPlan()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales que contengan uno de los codigos plan especificados\",\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"EstadoActivo\":true,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"],\"CodigoPlan\":[\"N5*\",\"55-PLUS-C\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"ObservacionesContrato\",\"Valor\":\"Cambio de Observaciu00f3n -\"}]}}]");

        public static List<Regla> ReglaCoberturaMaxima()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales que contengan cobertura mu00e1xima entre rango 29.000 a 60.000\",\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"EstadoActivo\":true,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"],\"CoberturaMaxima\":\">=29000&&<=60000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"ObservacionesContrato\",\"Valor\":\"PCambio de Observaciu00f3n -\"}]}}]");
    }
}
