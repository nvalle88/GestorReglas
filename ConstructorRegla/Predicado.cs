using Saludsa.UtilidadesRest;
using System;
using System.Linq.Expressions;

namespace ConstructorRegla
{
    public static class Predicado
    {
        public static Expression<Func<Contrato, bool>> GeneraPredicado(Regla regla)
        {
            Expression<Func<Contrato, bool>> predicadoContrato = contrato => contrato.Estado.Equals("Activo", StringComparison.InvariantCultureIgnoreCase);

            if (regla.Entrada.Producto.IsNotNullOrEmpty())
            {
                Expression<Func<Contrato, bool>> criterioProducto = contrato => contrato.Producto == regla.Entrada.Producto;
                predicadoContrato = predicadoContrato.And(criterioProducto);
            }

            return predicadoContrato;
        }
    }
}
