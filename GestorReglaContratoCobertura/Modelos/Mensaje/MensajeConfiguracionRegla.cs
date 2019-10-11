namespace Saludsa.GestorReglaContratoCobertura.Mensaje
{
    public class MensajeConfiguracionRegla
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
    }

    internal static class GenerarMensajeConfiguracionRegla
    {
        internal static string MensajeErrorExpresionLogica(string campo)
            => $"{MensajeErrorParametro(campo)} No es una expresión lógica";

        internal static string MensajeErrorParametro(string campo)
            => $"Error en la configuración del parametro {campo}.";
    }

    internal static class CrearMensajeConfiguracionRegla
    {
        internal static MensajeConfiguracionRegla ObtenerMensajeErrorExpresionLogica(string nombrePropiedad, string regla)
            => new MensajeConfiguracionRegla
            {
                Mensaje = $"{GenerarMensajeConfiguracionRegla.MensajeErrorExpresionLogica(nombrePropiedad)} ({regla})"
            };

        internal static MensajeConfiguracionRegla ObtenerMensajeErrorParametro(string nombrePropiedad)
            => new MensajeConfiguracionRegla
            {
                Mensaje = GenerarMensajeConfiguracionRegla.MensajeErrorParametro(nombrePropiedad)
            };
    }
}