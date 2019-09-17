namespace ConstructorRegla
{
    public interface IGestorReglaContructor
    {
        void AplicarReglaDeducible();
        void AplicarReglaCarencia();
        void AplicarReglaMora();
        void AplicarReglaCambioTexto(NombrePlan nombrePlan);
        Contrato ObtenerContrato();
    }
}
