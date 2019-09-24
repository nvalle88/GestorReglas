using GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExprBeneficiario = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.Beneficiario, bool>>;
using ExprBeneficioPlan = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.BeneficiosPlan, bool>>;
using ExprContrato = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.Contrato, bool>>;
using ExprRegla = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Regla.Regla, bool>>;

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
                predicado = predicado.And2(criterio);
            }

            if (aplicacion > 0)
            {
                ExprRegla criterio = regla => regla.Aplicacion.Contains(aplicacion);
                predicado = predicado.And2(criterio);
            }

            if (plataforma > 0)
            {
                ExprRegla criterio = regla => regla.Plataforma.Contains(plataforma);
                predicado = predicado.And2(criterio);
            }

            return predicado;
        }

        private static ExprContrato GeneraPredicadoContrato(ReglaEntradaContrato regla)
        {
            ExprContrato predicado = ConstructorPredicado.True<Contrato>();

            if (regla.Region.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.Region.Contains(contrato.Region, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And2(criterio);
            }

            if (regla.Producto.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.Producto.Contains(contrato.Producto, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And2(criterio);
            }

            if (regla.CodigoEstado.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.CodigoEstado.Contains(contrato.CodigoEstado);
                predicado = predicado.And2(criterio);
            }

            if (regla.CodigoPlan.IsNotNullOrEmpty2())
            {
                var filtros = new List<FiltroExpresion>();
                regla.CodigoPlan.ForEach(codigo =>
                {
                    var filtro = new FiltroExpresion
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
                if (exprOr.IsNull2())
                    return null;
                predicado = predicado.And2(exprOr);
            }

            if (regla.Version.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.Version.Contains(contrato.Version);
                predicado = predicado.And2(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo >1000 && <5000
            if (regla.CoberturaMaxima.IsNotNullOrEmpty2())
            {
                var expresionLogica = new ExpresionLogica(regla.CoberturaMaxima);
                if (!expresionLogica.EsExpresionLogica)
                    return null; // Todo: Eliminar la regla por falsa formación y no aplicar en capa superior.

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "CoberturaMaxima"; return x; }).ToList();

                ExprContrato exprAnd = ConstruirArbolExpresionAnd<Contrato>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull2())
                    return null;
                predicado = predicado.And2(exprAnd);
            }

            if (regla.Nivel.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.Nivel.Contains(contrato.Nivel);
                predicado = predicado.And2(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DeducibleTotal.IsNotNullOrEmpty2())
            {
                var expresionLogica = new ExpresionLogica(regla.DeducibleTotal);
                if (!expresionLogica.EsExpresionLogica)
                    return null;

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "DeducibleTotal"; return x; }).ToList();

                ExprContrato exprAnd = ConstruirArbolExpresionAnd<Contrato>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull2())
                    return null;
                predicado = predicado.And2(exprAnd);
            }

            if (regla.TieneImpedimento.IsNotNull2())
            {
                ExprContrato criterio = contrato => contrato.TieneImpedimento == regla.TieneImpedimento;
                predicado = predicado.And2(criterio);
            }

            if (regla.EsMoroso.IsNotNull2())
            {
                ExprContrato criterio = contrato => contrato.EsMoroso == regla.EsMoroso;
                predicado = predicado.And2(criterio);
            }

            if (regla.NumeroEmpresa.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.NumeroEmpresa.Contains(contrato.NumeroEmpresa);
                predicado = predicado.And2(criterio);
            }

            if (regla.CodigoSucursal.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.CodigoSucursal.Contains(contrato.CodigoSucursal);
                predicado = predicado.And2(criterio);
            }

            if (regla.NumeroLista.IsNotNullOrEmpty2())
            {
                ExprContrato criterio = contrato => regla.NumeroLista.Contains(contrato.NumeroLista);
                predicado = predicado.And2(criterio);
            }

            if (regla.EsDeducibleAnual.IsNotNull2())
            {
                ExprContrato criterio = contrato => contrato.EsDeducibleAnual == regla.EsDeducibleAnual;
                predicado = predicado.And2(criterio);
            }

            return predicado;
        }

        private static ExprBeneficiario GeneraPredicadoBeneficiario(ReglaEntradaBeneficiario regla)
        {
            ExprBeneficiario predicado = ConstructorPredicado.True<Beneficiario>();

            if (regla.RelacionDependiente.IsNotNullOrEmpty2())
            {
                ExprBeneficiario criterio = beneficiario => regla.RelacionDependiente.Contains(beneficiario.RelacionDependiente, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And2(criterio);
            }

            if (regla.Genero.IsNotNullOrEmpty2())
            {
                ExprBeneficiario criterio = beneficiario => regla.Genero.Contains(beneficiario.Genero, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And2(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.Edad.IsNotNull2())
            {
                var expresionLogica = new ExpresionLogica(regla.Edad);
                if (!expresionLogica.EsExpresionLogica)
                    return null; // Todo: Eliminar la regla por falsa formación y no aplicar en capa superior.

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "Edad"; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull2())
                    return null;
                predicado = predicado.And2(exprAnd);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DeducibleCubierto.IsNotNullOrEmpty2())
            {
                var expresionLogica = new ExpresionLogica(regla.Edad);
                if (!expresionLogica.EsExpresionLogica)
                    return null; // Todo: Eliminar la regla por falsa formación y no aplicar en capa superior.

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "DeducibleCubierto"; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull2())
                    return null;
                predicado = predicado.And2(exprAnd);
            }

            if (regla.EnCarencia.IsNotNull2())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.EnCarencia == regla.EnCarencia;
                predicado = predicado.And2(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DiasFinCarencia.IsNotNullOrEmpty2())
            {
                var expresionLogica = new ExpresionLogica(regla.Edad);
                if (!expresionLogica.EsExpresionLogica)
                    return null; // Todo: Eliminar la regla por falsa formación y no aplicar en capa superior.

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "DeducibleCubierto"; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull2())
                    return null;
                predicado = predicado.And2(exprAnd);
            }

            if (regla.EnCarenciaHospitalaria.IsNotNull2())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.EnCarenciaHospitalaria == regla.EnCarenciaHospitalaria;
                predicado = predicado.And2(criterio);
            }

            // Todo: Crear la búsqueda evaluando expresión lógica
            // Ejemplo > 1000 && <5000
            if (regla.DiasFinCarenciaHospitalaria.IsNotNullOrEmpty2())
            {
                var expresionLogica = new ExpresionLogica(regla.Edad);
                if (!expresionLogica.EsExpresionLogica)
                    return null; // Todo: Eliminar la regla por falsa formación y no aplicar en capa superior.

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "DeducibleCubierto"; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull2())
                    return null;
                predicado = predicado.And2(exprAnd);
            }

            if (regla.BeneficioOda.IsNotNull2())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.BeneficioOda == regla.BeneficioOda;
                predicado = predicado.And2(criterio);
            }

            if (regla.Maternidad.IsNotNull2())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.Maternidad == regla.Maternidad;
                predicado = predicado.And2(criterio);
            }

            return predicado;
        }

        [Obsolete("Se realiza el filtro directamente en la lista de beneficios plan método ObtenerBeneficiosPlanCandidatos")]
        private static ExprBeneficioPlan GeneraPredicadoBeneficioPlan(EntradaBeneficioPlan regla)
        {
            ExprBeneficioPlan predicado = ConstructorPredicado.True<BeneficiosPlan>();

            if (regla.CodigoBeneficio.IsNotNull2())
            {
                ExprBeneficioPlan criterio = beneficioPlan => regla.CodigoBeneficio.Contains(beneficioPlan.CodigoBeneficio, StringComparison.InvariantCultureIgnoreCase);
                predicado = predicado.And2(criterio);
            }

            if (regla.EsPorcentaje.IsNotNull2())
            {
                ExprBeneficioPlan criterio = beneficioPlan => beneficioPlan.EsPorcentaje == regla.EsPorcentaje;
                predicado = predicado.And2(criterio);
            }

            return predicado;
        }

        internal static List<Regla> ObtenerReglasCandidatas(List<Regla> reglas, int convenio, int aplicacion, int plataforma)
        {
            return reglas.Where(regla => regla.EstadoActivo
                && Validaciones.ValidarFechaRegla(regla)
                && regla.Convenio.IsNotNullOrEmpty2() ? regla.Convenio.Contains(convenio) : true
                && regla.Aplicacion.IsNotNullOrEmpty2() ? regla.Aplicacion.Contains(aplicacion) : true
                && regla.Plataforma.IsNotNullOrEmpty2() ? regla.Plataforma.Contains(plataforma) : true).ToList();
        }

        internal static List<Contrato> ObtenerContratosCandidatos(List<Contrato> contratos, ReglaEntradaContrato regla)
        {
            // Todo: si falla al crear el predicado, no aplicar la regla
            var predicado = GeneraPredicadoContrato(regla);

            return predicado.IsNull2()
                ? null
                : contratos.AsQueryable().Where(predicado).ToList();
        }

        internal static List<Beneficiario> ObtenerBeneficiariosCandidatos(List<Beneficiario> beneficiarios, ReglaEntradaBeneficiario regla)
        {
            var predicado = GeneraPredicadoBeneficiario(regla);

            return predicado.IsNull2()
                ? null
                : beneficiarios.AsQueryable().Where(predicado).ToList();
        }

        internal static List<BeneficiosPlan> ObtenerBeneficiosPlanCandidatos(List<BeneficiosPlan> beneficiosPlan, EntradaBeneficioPlan regla)
        {
            return beneficiosPlan.Where(bp =>
            regla.CodigoBeneficio.IsNotNullOrEmpty2()
                ? regla.CodigoBeneficio.Contains(bp.CodigoBeneficio, StringComparison.InvariantCultureIgnoreCase)
                : true
            &&

            regla.EsPorcentaje.IsNotNull2()
                ? bp.EsPorcentaje == regla.EsPorcentaje
                : true).ToList();
        }

        private static Expression<Func<T, bool>> ConstruirArbolExpresionOr<T>(List<FiltroExpresion> filtros)
        {
            if (filtros.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp;
            if (filtros.Count == 1)
            {
                exp = GeneradorExpresion.GetExpression<T>(param, filtros[0]);
            }
            else
            {
                exp = GeneradorExpresion.GetExpression<T>(param, filtros[0]);
                for (int i = 1; i < filtros.Count; i++)
                {
                    exp = Expression.Or(exp, GeneradorExpresion.GetExpression<T>(param, filtros[i]));
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression<Func<T, bool>> ConstruirArbolExpresionAnd<T>(List<FiltroExpresion> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp;
            if (filters.Count == 1)
            {
                exp = GeneradorExpresion.GetExpression<T>(param, filters[0]);
            }
            else
            {
                exp = GeneradorExpresion.GetExpression<T>(param, filters[0]);
                for (int i = 1; i < filters.Count; i++)
                {
                    exp = Expression.And(exp, GeneradorExpresion.GetExpression<T>(param, filters[i]));
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }
    }
}
