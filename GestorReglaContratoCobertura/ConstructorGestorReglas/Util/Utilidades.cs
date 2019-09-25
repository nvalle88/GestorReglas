using GestorReglaContratoCobertura.Extensores;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    public static class Utilidades
    {
        public static string ProcesarTexto(string textoRegla, string textoContrato, Posicion? posicion)
        {
            if (posicion.IsNull2())
                return textoRegla;

            switch (posicion)
            {
                case Posicion.Pre:
                    return $"{textoRegla} {textoContrato}";
                case Posicion.Post:
                    return $"{textoContrato} {textoRegla}";
                default:
                    return textoContrato;
            }
        }
    }

    public class CambioTexto
    {
        public string Texto { get; set; }
        public Posicion Posicion { get; set; }
    }

    public enum Posicion
    {
        Pre,
        Post
    }
}
