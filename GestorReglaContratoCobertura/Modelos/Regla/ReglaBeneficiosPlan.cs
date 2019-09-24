using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
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
}
