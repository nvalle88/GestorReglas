using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
    public class Salida
    {
        public List<SalidaGenerica> SalidaContrato { get; set; }
        public List<SalidaGenerica> SalidaBeneficiario { get; set; }
    }

    public class SalidaGenerica
    {
        public string NombrePropiedad { get; set; }
        public string Valor { get; set; }
        public Posicion? Posicion { get; set; }
    }
}
