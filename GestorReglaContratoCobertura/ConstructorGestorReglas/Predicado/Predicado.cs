using GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using Saludsa.UtilidadesRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ExprRegla = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Regla.Regla, bool>>;
using ExprContrato = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.Contrato, bool>>;
using ExprBeneficiario = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.Beneficiario, bool>>;
using ExprBeneficioPlan = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.BeneficiosPlan, bool>>;
using System.Collections;
using System.Reflection;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado
{
    public static class Predicado
    {
        private static ExprRegla GeneraPredicadoRegla(int convenio, int aplicacion, int plataforma)
        {
            //_listaReglas = _listaReglas
            //.Where(r => r.EstadoActivo && convenio > 0 ? r.Convenio.Contains(convenio) : true)
            //.ToList();

            ExprRegla predicado = ConstructorPredicado.True<Regla>();

            var fechaActual = DateTime.Now.Date;
            ExprRegla criterioFecha = regla
                => (fechaActual >= regla.FechaInicioRegla.Value.Date || regla.FechaInicioRegla == null)
                && (fechaActual <= regla.FechaFinRegla.Value.Date || regla.FechaFinRegla == null);

            // Todo: Probar nuevo orden en validación de fechas
            //ExpresionRegla cFecha = regla
            //    => (regla.FechaInicioRegla == null || regla.FechaInicioRegla <= fechaActual) &&
            //    (regla.FechaFinRegla == null || regla.FechaFinRegla >= fechaActual);

            if (convenio > 0)
            {
                ExprRegla criterio = regla => regla.Convenio.Contains(convenio);
                predicado = predicado.And(criterio);
            }

            if (aplicacion > 0)
            {
                ExprRegla criterio = regla => regla.Aplicacion.Contains(aplicacion);
                predicado = predicado.And(criterio);
            }

            if (plataforma > 0)
            {
                ExprRegla criterio = regla => regla.Plataforma.Contains(plataforma);
                predicado = predicado.And(criterio);
            }

            return predicado;
        }

        private static ExprContrato GeneraPredicadoContrato(ReglaEntradaContrato regla)
        {
            ExprContrato predicado = ConstructorPredicado.True<Contrato>();

            if (regla.Region.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.Region.Contains(contrato.Region, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And(criterio);
            }

            if (regla.Producto.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.Producto.Contains(contrato.Producto, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And(criterio);
            }

            if (regla.CodigoEstado.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.CodigoEstado.Contains(contrato.CodigoEstado);
                predicado = predicado.And(criterio);
            }

            if (regla.CodigoPlan.IsNotNullOrEmpty())
            {
                var filtros = new List<ExpressionFilter>();
                regla.CodigoPlan.ForEach(codigo =>
                {
                    var filtro = new ExpressionFilter
                    {
                        NombrePropiedad = "CodigoPlan",
                        Valor = ExpresionRegular.EliminarComodin(codigo)
                    };
                    if (codigo.StartsWith("*") && codigo.EndsWith("*"))
                        filtro.Operador = Operador.Contiene;
                    else if (codigo.StartsWith("*"))
                        filtro.Operador = Operador.TerminaCon;
                    else if (codigo.EndsWith("*"))
                        filtro.Operador = Operador.IniciaCon;
                    else
                        filtro.Operador = Operador.IgualQue;
                    filtros.Add(filtro);
                });

                ExprContrato exprOr = ConstruirArbolExpresionOr<Contrato>(filtros);
                predicado = predicado.And(exprOr);
            }

            if (regla.Version.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.Version.Contains(contrato.Version);
                predicado = predicado.And(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo >1000 && <5000
            if (regla.CoberturaMaxima.IsNotNullOrEmpty())
            {
                var expresionLogica = new ExpresionLogica(regla.CoberturaMaxima);
                if (!expresionLogica.EsExpresionLogica)
                    return null; // Todo: Eliminar la regla por falsa formación y no aplicar en capa superior.

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "CoberturaMaxima"; return x; }).ToList();

                ExprContrato exprAnd = ConstruirArbolExpresionAnd<Contrato>(expresionLogica.Proposiciones);
                predicado = predicado.And(exprAnd);
            }

            if (regla.Nivel.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.Nivel.Contains(contrato.Nivel);
                predicado = predicado.And(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DeducibleTotal.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => contrato.DeducibleTotal == Convert.ToInt32(regla.DeducibleTotal);
                predicado = predicado.And(criterio);
            }

            if (regla.TieneImpedimento.IsNotNull())
            {
                ExprContrato criterio = contrato => contrato.TieneImpedimento == regla.TieneImpedimento;
                predicado = predicado.And(criterio);
            }

            if (regla.EsMoroso.IsNotNull())
            {
                ExprContrato criterio = contrato => contrato.EsMoroso == regla.EsMoroso;
                predicado = predicado.And(criterio);
            }

            if (regla.NumeroEmpresa.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.NumeroEmpresa.Contains(contrato.NumeroEmpresa);
                predicado = predicado.And(criterio);
            }

            if (regla.CodigoSucursal.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.CodigoSucursal.Contains(contrato.CodigoSucursal);
                predicado = predicado.And(criterio);
            }

            if (regla.NumeroLista.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.NumeroLista.Contains(contrato.NumeroLista);
                predicado = predicado.And(criterio);
            }

            if (regla.EsDeducibleAnual.IsNotNull())
            {
                ExprContrato criterio = contrato => contrato.EsDeducibleAnual == regla.EsDeducibleAnual;
                predicado = predicado.And(criterio);
            }

            return predicado;
        }

        private static ExprBeneficiario GeneraPredicadoBeneficiario(ReglaEntradaBeneficiario regla)
        {
            ExprBeneficiario predicado = ConstructorPredicado.True<Beneficiario>();

            if (regla.RelacionDependiente.IsNotNullOrEmpty())
            {
                ExprBeneficiario criterio = beneficiario => regla.RelacionDependiente.Contains(beneficiario.RelacionDependiente, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And(criterio);
            }

            if (regla.Genero.IsNotNullOrEmpty())
            {
                ExprBeneficiario criterio = beneficiario => regla.Genero.Contains(beneficiario.Genero, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.Edad.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.Edad == regla.Edad;
                predicado = predicado.And(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DeducibleCubierto.IsNotNullOrEmpty())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.DeducibleCubierto == Convert.ToInt32(regla.DeducibleCubierto);
                predicado = predicado.And(criterio);
            }

            if (regla.EnCarencia.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.EnCarencia == regla.EnCarencia;
                predicado = predicado.And(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DiasFinCarencia.IsNotNullOrEmpty())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.DiasFinCarencia == Convert.ToInt32(regla.DiasFinCarencia);
                predicado = predicado.And(criterio);
            }

            if (regla.EnCarenciaHospitalaria.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.EnCarenciaHospitalaria == regla.EnCarenciaHospitalaria;
                predicado = predicado.And(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DiasFinCarenciaHospitalaria.IsNotNullOrEmpty())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.DiasFinCarenciaHospitalaria == Convert.ToInt32(regla.DiasFinCarenciaHospitalaria);
                predicado = predicado.And(criterio);
            }

            if (regla.BeneficioOda.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.BeneficioOda == regla.BeneficioOda;
                predicado = predicado.And(criterio);
            }

            if (regla.Maternidad.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.Maternidad == regla.Maternidad;
                predicado = predicado.And(criterio);
            }

            return predicado;
        }

        [Obsolete("Se realiza el filtro directamente en la lista de beneficios plan método ObtenerBeneficiosPlanCandidatos")]
        private static ExprBeneficioPlan GeneraPredicadoBeneficioPlan(EntradaBeneficioPlan regla)
        {
            ExprBeneficioPlan predicado = ConstructorPredicado.True<BeneficiosPlan>();

            if (regla.CodigoBeneficio.IsNotNull())
            {
                ExprBeneficioPlan criterio = beneficioPlan => regla.CodigoBeneficio.Contains(beneficioPlan.CodigoBeneficio, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And(criterio);
            }

            if (regla.EsPorcentaje.IsNotNull())
            {
                ExprBeneficioPlan criterio = beneficioPlan => beneficioPlan.EsPorcentaje == regla.EsPorcentaje;
                predicado = predicado.And(criterio);
            }

            return predicado;
        }

        internal static List<Regla> ObtenerReglasCandidatas(List<Regla> reglas, int convenio, int aplicacion, int plataforma)
        {
            return reglas.Where(regla => regla.EstadoActivo
                && Validaciones.ValidarFechaRegla(regla)
                && regla.Convenio.IsNotNullOrEmpty() ? regla.Convenio.Contains(convenio) : true
                && regla.Aplicacion.IsNotNullOrEmpty()  ? regla.Aplicacion.Contains(aplicacion) : true
                && regla.Plataforma.IsNotNullOrEmpty() ? regla.Plataforma.Contains(plataforma) : true).ToList();;
        }

        internal static List<Contrato> ObtenerContratosCandidatos(List<Contrato> contratos, ReglaEntradaContrato regla)
        {
            // Todo: si falla al crear el predicado, no aplicar la regla
            var predicado = GeneraPredicadoContrato(regla);

            return predicado.IsNull()
                ? null
                : contratos.AsQueryable().Where(predicado).ToList();
        }

        internal static List<Beneficiario> ObtenerBeneficiariosCandidatos(List<Beneficiario> beneficiarios, ReglaEntradaBeneficiario regla)
        {
            var predicado = GeneraPredicadoBeneficiario(regla);

            return predicado.IsNull()
                ? null
                : beneficiarios.AsQueryable().Where(predicado).ToList();
        }

        internal static List<BeneficiosPlan> ObtenerBeneficiosPlanCandidatos(List<BeneficiosPlan> beneficiosPlan, EntradaBeneficioPlan regla)
        {
            return beneficiosPlan.Where(bp =>
            regla.CodigoBeneficio.IsNotNullOrEmpty()
                ? regla.CodigoBeneficio.Contains(bp.CodigoBeneficio, StringComparison.InvariantCultureIgnoreCase)
                : true
            &&

            regla.EsPorcentaje.IsNotNull()
                ? bp.EsPorcentaje == regla.EsPorcentaje
                : true).ToList();
        }

        private static Expression<Func<T, bool>> ConstruirArbolExpresionOr<T>(List<ExpressionFilter> filtros)
        {
            if (filtros.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filtros.Count == 1)
            {
                exp = ExpressionRetriever.GetExpression<T>(param, filtros[0]);
            }
            else
            {
                exp = ExpressionRetriever.GetExpression<T>(param, filtros[0]);
                for (int i = 1; i < filtros.Count; i++)
                {
                    exp = Expression.Or(exp, ExpressionRetriever.GetExpression<T>(param, filtros[i]));
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression<Func<T, bool>> ConstruirArbolExpresionAnd<T>(List<ExpressionFilter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
            {
                exp = ExpressionRetriever.GetExpression<T>(param, filters[0]);
            }
            else
            {
                exp = ExpressionRetriever.GetExpression<T>(param, filters[0]);
                for (int i = 1; i < filters.Count; i++)
                {
                    exp = Expression.And(exp, ExpressionRetriever.GetExpression<T>(param, filters[i]));
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

    }


    public class ExpressionFilter
    {
        public string NombrePropiedad { get; set; }
        public object Valor { get; set; }
        public Operador Operador { get; set; }

        public ExpressionFilter()
        {
        }

        public ExpressionFilter(string operador, object valor)
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
            Valor = valor;
        }
    }

    public enum Operador
    {
        Igual,
        Menor,
        MenorIgual,
        Mayor,
        MayorIgual,
        Diferente,
        Contiene, //for strings  
        IniciaCon, //for strings  
        TerminaCon, //for strings  
        IgualQue // for strings
    }

    public static class ExpressionRetriever
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static MethodInfo equalsMethod = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });

        public static Expression GetExpression<T>(ParameterExpression param, ExpressionFilter filter)
        {
            MemberExpression member = Expression.Property(param, filter.NombrePropiedad);
            ConstantExpression constant = Expression.Constant(filter.Valor);
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




    public static class ConstructorPredicado
    {
        public static Expression<Func<T, bool>> True<T>() => f => true;
        public static Expression<Func<T, bool>> False<T>() => f => false;
        public static Expression<Func<T, bool>> Or2<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> And2<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        // Sección segundo tutorial
        public static Expression<Func<T, bool>> Crear<T>(Expression<Func<T, bool>> predicado)
            => predicado;

        /// <summary>    
        /// Combines the first predicate with the second using the logical "and".    
        /// </summary>    
        public static Expression<Func<T, bool>> And3<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "or".    
        /// </summary>    
        public static Expression<Func<T, bool>> Or3<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>    
        /// Negates the predicate.    
        /// </summary>    
        public static Expression<Func<T, bool>> Not3<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>    
        /// Combines the first expression with the second using the specified merge function.    
        /// </summary>    
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)    
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first    
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression    
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }
    }
}
