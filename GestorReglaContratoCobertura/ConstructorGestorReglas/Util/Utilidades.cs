using GestorReglaContratoCobertura.Extensores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    public static class Utilidades
    {
        public static string ProcesarTexto(string textoRegla, string textoContrato, Posicion? posicion)
        {
            if (posicion.IsNull())
                return textoRegla;

            switch (posicion)
            {
                case Posicion.Pre:
                    return $"{textoRegla} {textoContrato}";
                case Posicion.Pos:
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Posicion
    {
        Pre,
        Pos
    }
}
