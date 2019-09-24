namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class Proposicion
    {
        public Operador Operador { get; set; }
        public double Valor { get; set; }

        public Proposicion(string operador, string valor)
        {
            switch (operador)
            {
                case OperadoresRelacionales.Mayor:
                    Operador = Operador.Mayor;
                    break;

                case OperadoresRelacionales.MayorIgual:
                    Operador = Operador.MayorIgual;
                    break;

                case OperadoresRelacionales.Menor:
                    Operador = Operador.Menor;
                    break;

                case OperadoresRelacionales.MenorIgual:
                    Operador = Operador.MenorIgual;
                    break;

                case OperadoresRelacionales.Igual:
                    Operador = Operador.Igual;
                    break;

                case OperadoresRelacionales.Diferente:
                    Operador = Operador.Diferente;
                    break;
            }
            Valor = double.Parse(valor);
        }
    }
}
