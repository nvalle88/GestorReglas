namespace ConstructorRegla.Modelos.Regla
{
    public class Regla
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Entrada Entrada { get; set; }
        public Salida Salida { get; set; }
    }

    public class Entrada
    {
        public string Producto { get; set; }
        public string Plan { get; set; }
        public string Nivel { get; set; }
        public bool? EnCarencia { get; set; }
        public Deducible Deducible { get; set; }
        public bool? Mora { get; set; }
        public string Prexistencia { get; set; }
        public int Convenio { get; set; }

    }

    public class Deducible
    {
        public bool? BeneficiariosCubrenDeducible { get; set; }
        public bool? ContratosSinDeducible{ get; set; }
    }

    public class Salida
    {
        public NombrePlan NombrePlan { get; set; }
        public ValorFee ValorFee { get; set; }
    }

    public class NombrePlan
    {
        public string Campo { get; set; }
        public string Texto { get; set; }
    }

    public class ValorFee
    {
        public double Valor { get; set; }
        public string CodigoBeneficio { get; set; }
    }
}
