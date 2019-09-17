using System.Collections.Generic;

namespace ConstructorRegla
{
    public class GestorReglaConstructor : IGestorReglaContructor
    {
        public Contrato _contrato;

        public GestorReglaConstructor(Contrato contrato)
        {
            _contrato = contrato;
        }

        public void AplicarReglaCambioTexto(NombrePlan nombrePlan)
        {
            _contrato.NombrePlan = $"{nombrePlan.Texto} {_contrato.NombrePlan}";
        }

        public void AplicarReglaCarencia()
        {
            throw new System.NotImplementedException();
        }

        public void AplicarReglaDeducible()
        {
            throw new System.NotImplementedException();
        }

        public void AplicarReglaMora()
        {
            throw new System.NotImplementedException();
        }

        public Contrato ObtenerContrato()
        {
            var contratoModificado = _contrato;
            LimpiarContrato();
            return contratoModificado;
        }

        private void LimpiarContrato() => _contrato = new Contrato();
    }
}
