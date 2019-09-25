using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    public interface IGestorReglaConstructorBeneficiario
    {
        void AplicarRegla(List<SalidaGenerica> salida);
        void IncorporarBeneficiario(Beneficiario beneficiario);
    }
}
