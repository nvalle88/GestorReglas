using System.Collections.Generic;

namespace Saludsa.GestorReglaContratoCobertura.Regla
{
    public class ReglaEntradaBeneficioPlan
    {
        public EntradaBeneficioPlan EntradaBeneficioPlan { get; set; }
        public List<SalidaGenerica> SalidaBeneficioPlan { get; set; }
    }

    public class EntradaBeneficioPlan
    {
        public List<string> CodigoBeneficio { get; set; }
        public bool? EsPorcentaje { get; set; }
    }
}