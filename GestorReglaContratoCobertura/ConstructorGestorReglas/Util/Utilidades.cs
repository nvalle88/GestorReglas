using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    public static class Utilidades
    {
        public static string ProcesarTexto(string textoRegla, string textoContrato, Posicion posicion)
        {
            switch (posicion)
            {
                case Posicion.Pre:
                    return $"{textoRegla}{textoContrato}";
                case Posicion.Post:
                    return $"{textoContrato}{textoRegla}";
                case Posicion.Sobreescribir:
                    return textoRegla;
                default:
                    return textoContrato;
            }
        }
    }
}
