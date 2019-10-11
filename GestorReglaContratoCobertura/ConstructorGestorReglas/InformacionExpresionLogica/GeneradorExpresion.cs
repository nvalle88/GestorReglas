using GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado
{
    internal static class GeneradorExpresion
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static MethodInfo equalsMethod = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });

        internal static Expression GetExpression<T>(ParameterExpression param, FiltroExpresion filter)
        {
            MemberExpression member = Expression.Property(param, filter.NombrePropiedad);
            ConstantExpression constant = Expression.Constant(Convert.ChangeType(filter.Valor, member.Type));

            switch (filter.Operador)
            {
                case Operador.Igual:
                    return Expression.Equal(member, constant);

                case Operador.Mayor:
                    return Expression.GreaterThan(member, constant);

                case Operador.MayorIgual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Operador.Menor:
                    return Expression.LessThan(member, constant);

                case Operador.MenorIgual:
                    return Expression.LessThanOrEqual(member, constant);

                case Operador.Diferente:
                    return Expression.NotEqual(member, constant);

                case Operador.Contiene:
                    return Expression.Call(member, containsMethod, constant);

                case Operador.IniciaCon:
                    return Expression.Call(member, startsWithMethod, constant);

                case Operador.TerminaCon:
                    return Expression.Call(member, endsWithMethod, constant);

                case Operador.IgualQue:
                    return Expression.Call(member, equalsMethod, constant);

                default:
                    return null;
            }
        }
    }
}