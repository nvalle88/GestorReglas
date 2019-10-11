using Newtonsoft.Json;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System.Collections.Generic;

namespace UnitTestGestorReglas
{
    public static class DatosPruebaRegla
    {
        #region Reglas Contrato
        #region Regla Vacia
        public static List<ReglaContrato> ReglaVacia() => new List<ReglaContrato>();
        #endregion

        #region Regla cambio nombre plan contrato con posición 
        public static List<ReglaContrato> ReglaCambioNombrePosicionPreIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pre\"}]}}]");

        public static List<ReglaContrato> ReglaCambioNombrePosicionPosIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pos\"}]}}]");

        public static List<ReglaContrato> ReglaCambioNombreSobreescribirIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\"}]}}]");

        public static List<ReglaContrato> ReglaCambioNombrePosicionDesconocidaIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"222\"}]}}]");
        #endregion

        #region Regla cambio observaciones contrato con posición
        public static List<ReglaContrato> ReglaCambioObservacionPosicionPreIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pre\"}]}}]");

        public static List<ReglaContrato> ReglaCambioObservacionPosicionPosIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"Pos\"}]}}]");

        public static List<ReglaContrato> ReglaCambioObservacionSobreescribirIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\"}]}}]");

        public static List<ReglaContrato> ReglaCambioObservacionPosicionDesconocidaIND()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto Individual -\",\"Posicion\":\"222\"}]}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 1 proposición correcta
        public static List<ReglaContrato> ReglaCodigoPlan1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N4*\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglaCoberturaMaxima1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CoberturaMaxima\":\">=20000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglaDeducibleTotal1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"DeducibleTotal\":\">=100\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 2 proposición incorrecta
        public static List<ReglaContrato> ReglaCodigoPlan2Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N4*\", \"*-S\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglaCoberturaMaxima2Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CoberturaMaxima\":\">=20000&&<=60000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglaDeducibleTotal2Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"DeducibleTotal\":\">=100&&<=200\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 1 proposición correcta fuera de rango
        public static List<ReglaContrato> ReglaCodigoPlan1PrepFueraRango()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N5*\"]},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglaCoberturaMaxima1PrepFueraRango()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CoberturaMaxima\":\"<40000\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglaDeducibleTotal1PrepFueraRango()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"DeducibleTotal\":\"<80\"},\"EntradaBeneficiario\":{},\"EntradaBeneficioPlan\":[]},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");
        #endregion
        #endregion



        #region Reglas Beneficiario

        #region Regla busqueda supera deducible
        public static List<ReglaContrato> ReglaSuperaDeducible()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaBeneficiario\":{\"SuperaDeducible\":true},\"EntradaBeneficios\":[{\"EntradaBeneficioPlan\":{\"EsPorcentaje\":true},\"SalidaBeneficioPlan\":[{\"NombrePropiedad\":\"Credito\",\"Valor\":\"false\"}]},{\"EntradaBeneficioPlan\":{\"CodigoBeneficio\":[\"A002\"]},\"SalidaBeneficioPlan\":[{\"NombrePropiedad\":\"Valor\",\"Valor\":\"12\"}]}]},\"Salida\":{}}]");
        #endregion

        #region Regla busqueda expresiones lógicas 1 proposición correcta
        public static List<ReglaContrato> ReglaEdad1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaBeneficiario\":{\"Edad\":\">=18\"}},\"Salida\":{\"SalidaBeneficiario\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Producto corporativo\"}]}}]");

        public static List<ReglaContrato> ReglaDeducibleCubierto1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("");

        public static List<ReglaContrato> ReglaDiasFinCarencia1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("");

        public static List<ReglaContrato> ReglaDiasFinCarenciaHospitalaria1Prep()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("");
        #endregion

        #endregion



        public static List<ReglaContrato> ReglaEntradaBeneficiarioNull()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"CodigoPlan\":[\"N4*\"]}},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"Producto Individual\"}]}}]");

        public static List<ReglaContrato> ReglasCambioNombrePlanDifare_ObservacionContratoVigente_NoCumpleDeducible_CreditoFalso()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"REG01\",\"Descripcion\":\"Regla para cambio de mensaje en nombre plan para consultas desde Difare a productos IND - XPR\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[52876],\"Aplicacion\":[92],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\",\"XPR\"]}},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"<<SALUD - Cobro Fee + Min $ 10.00>>\",\"Posicion\":\"Pre\"}]}},{\"Codigo\":\"REG02\",\"Descripcion\":\"Regla para cambio de mensaje en nombre plan para consultas desde Difare a productos COR - POO\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[52876],\"Aplicacion\":[92],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"COR\",\"POO\"]}},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"NombrePlan\",\"Valor\":\"<<SALUD>>\",\"Posicion\":\"Pre\"}]}},{\"Codigo\":\"REG03\",\"Descripcion\":\"Regla para cambio de mensaje en observaciones para contratos que no se encuentran vigentes\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"EsVigente\":false}},\"Salida\":{\"SalidaContrato\":[{\"NombrePropiedad\":\"Observaciones\",\"Valor\":\"Comunicate con el usuario para renovar el contrato\",\"Posicion\":\"Pos\"}]}},{\"Codigo\":\"REG04\",\"Descripcion\":\"Regla para cambio de credito si no cumple deducible\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[],\"Aplicacion\":[],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"COR\"]},\"EntradaBeneficiario\":{\"SuperaDeducible\":false},\"EntradaBeneficios\":[{\"EntradaBeneficioPlan\":{\"EsPorcentaje\":true},\"SalidaBeneficioPlan\":[{\"NombrePropiedad\":\"Credito\",\"Valor\":\"false\"}]}]}}]");

        public static List<ReglaContrato> ReglaDeducibleCendiavia()
            => JsonConvert.DeserializeObject<List<ReglaContrato>>("[{\"Codigo\":\"REG01-Cendiavia\",\"Descripcion\":\"Regla para modificar el valor del fee para citas m\u00e9dicas en productos individuales que no hayan superado el deducible en Cendiavia\",\"EstadoActivo\":true,\"FechaInicioRegla\":null,\"FechaFinRegla\":null,\"Convenio\":[5045201],\"Aplicacion\":[10319],\"Plataforma\":[],\"Entrada\":{\"EntradaContrato\":{\"Producto\":[\"IND\"]},\"EntradaBeneficiario\":{\"SuperaDeducible\":false},\"EntradaBeneficios\":[{\"EntradaBeneficioPlan\":{\"CodigoBeneficio\":[\"A002\"]},\"SalidaBeneficioPlan\":[{\"NombrePropiedad\":\"Valor\",\"Valor\":\"12\"}]}]}}]");


    }
}
