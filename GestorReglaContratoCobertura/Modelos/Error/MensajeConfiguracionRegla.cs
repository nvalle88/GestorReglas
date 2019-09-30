namespace GestorReglaContratoCobertura.Modelos.Error
{
    public class MensajeConfiguracionRegla
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
    }

    public static class GenerarMensajeConfiguracionRegla
    {
        public static string MensajeErrorExpresionLogica(string campo)
            => $"{MensajeErrorParametro(campo)} No es una expresión lógica";

        public static string MensajeErrorParametro(string campo)
            => $"Error en la configuración del parametro {campo}.";
    }
}
