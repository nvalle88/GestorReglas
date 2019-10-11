using System;
using System.Linq;
using System.Linq.Expressions;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado
{
    internal static class ConstructorPredicado
    {
        internal static Expression<Func<T, bool>> True<T>() => f => true;

        internal static Expression<Func<T, bool>> False<T>() => f => false;

        internal static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        internal static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}