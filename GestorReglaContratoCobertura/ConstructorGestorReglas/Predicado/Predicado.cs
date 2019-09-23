﻿using GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica;
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

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado
{
    public static class Predicado
    {
        public static ExprRegla GeneraPredicadoRegla(int convenio, int aplicacion, int plataforma)
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

        public static ExprContrato GeneraPredicadoContrato(ReglaEntradaContrato regla)
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
                regla.CodigoPlan.ForEach(codigo =>
                {
                    if (codigo.StartsWith("*") && codigo.EndsWith("*"))
                    {
                        ExprContrato criterio = contrato
                            => contrato.CodigoPlan.Contains(ExpresionRegular.EliminarComodin(codigo), StringComparison.InvariantCultureIgnoreCase);
                        predicado = predicado.Or(criterio);
                    }
                    else if (codigo.StartsWith("*"))
                    {
                        ExprContrato criterio = contrato
                            => contrato.CodigoPlan.EndsWith(ExpresionRegular.EliminarComodin(codigo), StringComparison.InvariantCultureIgnoreCase);
                        predicado = predicado.Or(criterio);
                    }
                    else if (codigo.EndsWith("*"))
                    {
                        ExprContrato criterio = contrato
                            => contrato.CodigoPlan.StartsWith(ExpresionRegular.EliminarComodin(codigo), StringComparison.InvariantCultureIgnoreCase);
                        predicado = predicado.Or(criterio);
                    }
                    else
                    {
                        ExprContrato criterio = contrato
                            => contrato.CodigoPlan.Equals(ExpresionRegular.EliminarComodin(codigo), StringComparison.InvariantCultureIgnoreCase);
                        predicado = predicado.Or(criterio);
                    }
                });
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

                ExprContrato criterio;
                if (expresionLogica.EsPredicadoSimple)
                {
                    switch (expresionLogica.Proposicion1.Operador)
                    {
                        case OperadoresRelacionales.Mayor:
                            criterio = contrato => contrato.CoberturaMaxima > expresionLogica.Proposicion1.Valor;
                            predicado = predicado.And(criterio);
                            break;

                        case OperadoresRelacionales.MayorIgual:
                            criterio = contrato => contrato.CoberturaMaxima >= expresionLogica.Proposicion1.Valor;
                            predicado = predicado.And(criterio);
                            break;

                        case OperadoresRelacionales.Menor:
                            criterio = contrato => contrato.CoberturaMaxima < expresionLogica.Proposicion1.Valor;
                            predicado = predicado.And(criterio);
                            break;

                        case OperadoresRelacionales.MenorIgual:
                            criterio = contrato => contrato.CoberturaMaxima <= expresionLogica.Proposicion1.Valor;
                            predicado = predicado.And(criterio);
                            break;

                        case OperadoresRelacionales.Igual:
                            criterio = contrato => contrato.CoberturaMaxima == expresionLogica.Proposicion1.Valor;
                            predicado = predicado.And(criterio);
                            break;

                        case OperadoresRelacionales.Diferente:
                            criterio = contrato => contrato.CoberturaMaxima != expresionLogica.Proposicion1.Valor;
                            predicado = predicado.And(criterio);
                            break;
                    }
                }
                else
                {
                    if (expresionLogica.OperadorLogico.Equals(OperadoresLogicos.Y, StringComparison.InvariantCultureIgnoreCase))
                    {
                        switch (expresionLogica.Proposicion1.Operador)
                        {
                            case OperadoresRelacionales.Mayor:
                                criterio = contrato => contrato.CoberturaMaxima > expresionLogica.Proposicion1.Valor;
                                predicado = predicado.And(criterio);
                                break;

                            case OperadoresRelacionales.MayorIgual:
                                criterio = contrato => contrato.CoberturaMaxima >= expresionLogica.Proposicion1.Valor;
                                predicado = predicado.And(criterio);
                                break;

                            case OperadoresRelacionales.Menor:
                                criterio = contrato => contrato.CoberturaMaxima < expresionLogica.Proposicion1.Valor;
                                predicado = predicado.And(criterio);
                                break;

                            case OperadoresRelacionales.MenorIgual:
                                criterio = contrato => contrato.CoberturaMaxima <= expresionLogica.Proposicion1.Valor;
                                predicado = predicado.And(criterio);
                                break;

                            case OperadoresRelacionales.Igual:
                                criterio = contrato => contrato.CoberturaMaxima == expresionLogica.Proposicion1.Valor;
                                predicado = predicado.And(criterio);
                                break;

                            case OperadoresRelacionales.Diferente:
                                criterio = contrato => contrato.CoberturaMaxima != expresionLogica.Proposicion1.Valor;
                                predicado = predicado.And(criterio);
                                break;
                        }
                    }
                }
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

        public static ExprBeneficiario GeneraPredicadoBeneficiario(ReglaEntradaBeneficiario regla)
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
            if (regla.Edad.IsNotNullOrEmpty())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.Edad == Convert.ToInt32(regla.Edad);
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

        public static ExprBeneficioPlan GeneraPredicadoBeneficioPlan(EntradaBeneficioPlan regla)
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
    }

    public static class ConstructorPredicadoComparacion
    {
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