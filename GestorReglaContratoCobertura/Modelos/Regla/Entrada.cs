using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
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
}
