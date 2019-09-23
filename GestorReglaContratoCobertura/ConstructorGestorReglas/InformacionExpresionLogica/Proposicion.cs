namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class Proposicion
    {
        public string Operador { get; set; }
        public double Valor { get; set; }

        public Proposicion(string operador, string valor)
        {
            Operador = operador;
            Valor = double.Parse(valor);
        }
    }
}
