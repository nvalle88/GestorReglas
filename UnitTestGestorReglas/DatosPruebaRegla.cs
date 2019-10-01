using GestorReglaContratoCobertura.Modelos.Regla;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTestGestorReglas
{
    public static class DatosPruebaRegla
    {
        #region Reglas Contrato
        #region Regla Vacia
        public static List<Regla> ReglaVacia() => new List<Regla>();
        #endregion

        #region Regla cambio nombre plan contrato con posición 
        public static List<Regla> ReglaCambioNombrePosicionPreIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pre\"}]}}]");

        public static List<Regla> ReglaCambioNombrePosicionPosIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pos\"}]}}]");

        public static List<Regla> ReglaCambioNombreSobreescribirIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\"}]}}]");

        public static List<Regla> ReglaCambioNombrePosicionDesconocidaIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"222\"}]}}]");
        #endregion

        #region Regla cambio observaciones contrato con posición
        public static List<Regla> ReglaCambioObservacionPosicionPreIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pre\"}]}}]");

        public static List<Regla> ReglaCambioObservacionPosicionPosIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pos\"}]}}]");

        public static List<Regla> ReglaCambioObservacionSobreescribirIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\"}]}}]");

        public static List<Regla> ReglaCambioObservacionPosicionDesconocidaIND()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"222\"}]}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 1 proposición correcta
        public static List<Regla> ReglaCodigoPlan1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N4*\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<Regla> ReglaCoberturaMaxima1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CoberturaMaxima\":\">=20000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<Regla> ReglaDeducibleTotal1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"DeducibleTotal\":\">=100\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 2 proposición incorrecta
        public static List<Regla> ReglaCodigoPlan2Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N4*\", \"*-S\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<Regla> ReglaCoberturaMaxima2Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CoberturaMaxima\":\">=20000&&<=60000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<Regla> ReglaDeducibleTotal2Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"DeducibleTotal\":\">=100&&<=200\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 1 proposición correcta fuera de rango
        public static List<Regla> ReglaCodigoPlan1PrepFueraRango()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N5*\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<Regla> ReglaCoberturaMaxima1PrepFueraRango()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CoberturaMaxima\":\"<40000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<Regla> ReglaDeducibleTotal1PrepFueraRango()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"DeducibleTotal\":\"<80\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
        #endregion
        #endregion



        #region Reglas Beneficiario

        #region Regla busqueda supera deducible
        public static List<Regla> ReglaSuperaDeducible()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaBeneficiario\":{\"SuperaDeducible\":true},\"EntradaBeneficios\":[{\"EntradaBeneficioPlan\":{\"EsPorcentaje\":true},\"SalidaBeneficioPlan\":[{\"NombrePropiedad\":\"Credito\",\"Valor\":\"false\"}]},{\"EntradaBeneficioPlan\":{\"CodigoBeneficio\":[\"A002\"]},\"SalidaBeneficioPlan\":[{\"NombrePropiedad\":\"Valor\",\"Valor\":\"12\"}]}]},\"Salida\":{}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 1 proposición correcta
        public static List<Regla> ReglaEdad1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaBeneficiario\":{\"Edad\":\">=18\"}},\"Salida\":{\"SalidaBeneficiario\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto corporativo\"}]}}]");

        public static List<Regla> ReglaDeducibleCubierto1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("");

        public static List<Regla> ReglaDiasFinCarencia1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("");

        public static List<Regla> ReglaDiasFinCarenciaHospitalaria1Prep()
            => JsonConvert.DeserializeObject<List<Regla>>("");
        #endregion

        #endregion



        public static List<Regla> ReglaEntradaBeneficiarioNull()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N4*\"]}},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
    }
}
