using GestorReglaContratoCobertura.Extensores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    internal static class Utilidades
    {
        internal static string ProcesarTexto(string textoRegla, string textoContrato, Posicion? posicion)
        {
            if (posicion.IsNull())
                return textoRegla.Trim();

            switch (posicion)
            {
                case Posicion.Pre:
                    return $"{textoRegla} {textoContrato}".Trim();

                case Posicion.Pos:
                    return $"{textoContrato} {textoRegla}".Trim();

                default:
                    return textoContrato.Trim();
            }
        }
    }

    internal class CambioTexto
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