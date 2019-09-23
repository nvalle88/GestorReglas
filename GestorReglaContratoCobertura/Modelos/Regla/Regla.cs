using System;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
    public class Regla
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoActivo { get; set; }
        public DateTime? FechaInicioRegla { get; set; }
        public DateTime? FechaFinRegla { get; set; }
        public List<int> Convenio { get; set; }
        public List<int> Aplicacion { get; set; }
        public List<int> Plataforma { get; set; }
        public Entrada Entrada { get; set; }
        public Salida Salida { get; set; }
    }

    public class Entrada
    {
        public ReglaEntradaContrato EntradaContrato { get; set; }
        public ReglaEntradaBeneficiario EntradaBeneficiario { get; set; }
        public List<ReglaEntradaBeneficioPlan> EntradaBeneficioPlan { get; set; }
    }


    public class ReglaEntradaContrato
    {
        public List<string> Region { get; set; }
        public List<string> Producto { get; set; }
        public List<int> CodigoEstado { get; set; }
        public List<string> CodigoPlan { get; set; }
        public List<int> Version { get; set; }
        public string CoberturaMaxima { get; set; }
        public List<int> Nivel { get; set; }
        public string DeducibleTotal { get; set; }
        public bool? TieneImpedimento { get; set; }
        public bool? EsMoroso { get; set; }
        public List<int> NumeroEmpresa { get; set; }
        public List<int> CodigoSucursal { get; set; }
        public List<int> NumeroLista { get; set; }
        public bool? EsDeducibleAnual { get; set; }
    }

    public class ReglaEntradaBeneficiario
    {
        public List<string> RelacionDependiente { get; set; }
        public List<string> Genero { get; set; }
        public string Edad { get; set; }
        public string DeducibleCubierto { get; set; }
        public bool? EnCarencia { get; set; }
        public string DiasFinCarencia { get; set; }
        public bool? EnCarenciaHospitalaria { get; set; }
        public string DiasFinCarenciaHospitalaria { get; set; }
        public bool? BeneficioOda { get; set; }
        public bool? Maternidad { get; set; }
        // Propiedad para recuperar deducible del contrato
        public double DeducibleTotal { get; set; }
    }

    public class ReglaEntradaBeneficioPlan
    {
        public EntradaBeneficioPlan EntradaBeneficioPlan { get; set; }
        public SalidaBeneficioPlan SalidaBeneficioPlan { get; set; }
    }

    public class EntradaBeneficioPlan
    {
        public List<string> CodigoBeneficio { get; set; }
        public bool? EsPorcentaje { get; set; }
    }

    public class SalidaBeneficioPlan
    {
        public string Nombre { get; set; }
        public double Valor { get; set; }
        public bool EsPorcentaje { get; set; }
        public bool EstadoActivo { get; set; }
        public bool Credito { get; set; }
        public int Total { get; set; }
        public int Disponibles { get; set; }
    }


    public class Salida
    {
        #region Salidas para Contrato
        public NombrePlan NombrePlan { get; set; }
        public ObservacionesContrato ObservacionesContrato { get; set; }
        #endregion Salidas para Contrato

        #region Salidas para Beneficiario
        public Carencia Carencia { get; set; }
        #endregion Salidas para Beneficiario
    }


    #region Clases salida Contrato
    public class NombrePlan : CambioTexto
    {
    }

    public class ObservacionesContrato : CambioTexto
    {
    }
    #endregion Clases salida Contrato

    #region Clases salida Beneficiario

    public class Deducible
    {
        public double DeducibleCubierto { get; set; }
    }

    public class Carencia
    {
        public bool EnCarencia { get; set; }
        public short DiasFinCarencia { get; set; }
    }

    public class CarenciaHospitalaria
    {
        public bool EnCarenciaHospitalaria { get; set; }
        public bool DiasFinCarenciaHospitalaria { get; set; }
    }

    public class BeneficioODA
    {

    }

    public class ObservacionesBeneficiario : CambioTexto
    {
    }

    public class MaternidadBeneficiario
    {
        public bool Maternidad { get; set; }
    }

    #endregion Clases salida Beneficiario

    public class CambioTexto
    {
        public string Texto { get; set; }
        public Posicion Posicion { get; set; }
    }

    public enum Posicion
    {
        Pre,
        Post,
        Sobreescribir
    }
}
