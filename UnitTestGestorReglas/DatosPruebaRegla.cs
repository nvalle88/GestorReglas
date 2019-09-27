using GestorReglaContratoCobertura.Modelos.Regla;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTestGestorReglas
{
    public static class DatosPruebaRegla
    {
        public static List<Regla> ReglaVacia() => new List<Regla>();

        public static List<Regla> ReglaCambioNombreIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales cambio de nombre plan\",\"FechaInicioRegla\":null,\"FechaFinRegla\":\"2019-09-30\",\"EstadoActivo\":false,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"],\"CodigoPlan\":[\"*-D*\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual - \"}]}}]");
        public static List<Regla> ReglaCambioBeneficiarioContrato()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales Propiedades del beneficiario y del contrato\",\"FechaInicioRegla\":null,\"FechaFinRegla\":\"2019-09-30\",\"EstadoActivo\":false,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaBeneficiario\":{\"Genero\":[\"F\"],\"RelacionDependiente\":[\"Titular\"]},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"<<Saludsa>>\",\"Posicion\":0},{\"NombrePropiedad\":\"Version\",\"Valor\":\"10\"}],\"SalidaBeneficiario\":[{\"NombrePropiedad\":\"RelacionDependiente\",\"Valor\":\"Titular del contrato\"},{\"NombrePropiedad\":\"Nombres\",\"Valor\":\"Ana Basulto\"}]}}]");

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
