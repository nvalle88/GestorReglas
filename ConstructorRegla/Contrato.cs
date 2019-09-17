using System;
using System.Collections.Generic;

namespace ConstructorRegla
{
    public class Titular
    {
        public int Numero { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
    }

    public class Deducible
    {
        public string Codigo { get; set; }
        public string Region { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoPlan { get; set; }
        public int VersionPlan { get; set; }
        public string TipoCobertura { get; set; }
        public double Monto { get; set; }
    }

    public class Preexistencia
    {
        public string CodigoDiagnostico { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int DiasFaltanCobertura { get; set; }
    }

    public class BeneficiosPlan
    {
        public int IdBeneficioConvenio { get; set; }
        public string CodigoBeneficio { get; set; }
        public string Nombre { get; set; }
        public double Valor { get; set; }
        public bool EsPorcentaje { get; set; }
        public bool EstadoActivo { get; set; }
        public bool Credito { get; set; }
        public int Total { get; set; }
        public int Disponibles { get; set; }
    }

    public class Beneficiario
    {
        public int NumeroPersona { get; set; }
        public string RelacionDependiente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime FechaInclusion { get; set; }
        public double DeducibleCubierto { get; set; }
        public bool EnCarencia { get; set; }
        public int DiasFinCarencia { get; set; }
        public bool EnCarenciaHospitalaria { get; set; }
        public int DiasFinCarenciaHospitalaria { get; set; }
        public List<Preexistencia> Preexistencias { get; set; }
        public bool BeneficioOda { get; set; }
        public string Observaciones { get; set; }
        public bool Maternidad { get; set; }
        public List<BeneficiosPlan> BeneficiosPlan { get; set; }
    }

    public class Contrato
    {
        public string Region { get; set; }
        public string Producto { get; set; }
        public int Numero { get; set; }
        public string CodigoPlan { get; set; }
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public int CodigoEstado { get; set; }
        public string NombrePlan { get; set; }
        public int Version { get; set; }
        public double CoberturaMaxima { get; set; }
        public int Nivel { get; set; }
        public Titular Titular { get; set; }
        public double DeducibleTotal { get; set; }
        public bool TieneImpedimento { get; set; }
        public string MotivoImpedimento { get; set; }
        public bool EsMoroso { get; set; }
        public string NombreComercialPlan { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVigencia { get; set; }
        public string CodigoPmf { get; set; }
        public string Empresa { get; set; }
        public int NumeroEmpresa { get; set; }
        public string Sucursal { get; set; }
        public int CodigoSucursal { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreLista { get; set; }
        public int NumeroLista { get; set; }
        public bool EsDeducibleAnual { get; set; }
        public List<Deducible> Deducibles { get; set; }
        public List<Beneficiario> Beneficiarios { get; set; }
    }
}
