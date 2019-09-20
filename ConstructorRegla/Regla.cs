using System;
using System.Collections.Generic;

namespace ConstructorRegla
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
        public double Valor { get; set; }
    }


    public class Salida
    {
        public NombrePlan NombrePlan { get; set; }
        public Carencia Carencia { get; set; }
        public BeneficioPlan BeneficioPlan { get; set; }
    }

    public class NombrePlan
    {
        public string Campo { get; set; }
        public string Texto { get; set; }
    }

    public class Carencia
    {
        public bool EnCarencia { get; set; }
        public short DiasFinCarencia { get; set; }
        public bool Credito { get; set; }
    }

    public class BeneficioPlan
    {
        public double Valor { get; set; }
    }
}
