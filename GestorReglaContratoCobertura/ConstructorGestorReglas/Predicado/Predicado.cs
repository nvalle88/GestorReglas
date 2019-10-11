using GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using Saludsa.GestorReglaContratoCobertura.Mensaje;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExprBeneficiario = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.Beneficiario, bool>>;
using ExprContrato = System.Linq.Expressions.Expression<System.Func<GestorReglaContratoCobertura.Modelos.Contrato.Contrato, bool>>;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado
{
    internal static class Predicado
    {
        private static ExprContrato GeneraPredicadoContrato(ReglaEntradaContrato regla, out List<MensajeConfiguracionRegla> listaMensajes)
        {
            listaMensajes = new List<MensajeConfiguracionRegla>();

            ExprContrato predicado = ConstructorPredicado.True<Contrato>();
            if (regla.IsNull())
            {
                return predicado;
            }

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
                var nombrePropiedad = "CodigoPlan";

                var filtros = new List<FiltroExpresion>();

                foreach (var codigo in regla.CodigoPlan)
                {
                    var valor = ExpresionRegular.EliminarComodin(codigo);
                    if (valor.IsNullOrEmpty())
                        continue;

                    var filtro = new FiltroExpresion
                    {
                        NombrePropiedad = nombrePropiedad,
                        Valor = valor
                    };
                    if (codigo.StartsWith("*") && codigo.EndsWith("*"))
                        filtro.Operador = Operador.Contiene;
                    else if (codigo.StartsWith("*"))
                        filtro.Operador = Operador.TerminaCon;
                    else if (codigo.EndsWith("*"))
                        filtro.Operador = Operador.IniciaCon;
                    else if (codigo.Trim().IsNotNullOrEmpty())
                        filtro.Operador = Operador.IgualQue;
                    filtros.Add(filtro);
                }

                ExprContrato exprOr = ConstruirArbolExpresionOr<Contrato>(filtros);
                if (exprOr.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprOr);
            }

            if (regla.Version.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.Version.Contains(contrato.Version);
                predicado = predicado.And(criterio);
            }

            if (regla.CoberturaMaxima.IsNotNullOrEmpty())
            {
                var nombrePropiedad = "CoberturaMaxima";
                var expresionLogica = new ExpresionLogica(regla.CoberturaMaxima);
                if (!expresionLogica.EsExpresionLogica)
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorExpresionLogica(nombrePropiedad, regla.CoberturaMaxima));
                    return null;
                }

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = nombrePropiedad; return x; }).ToList();

                ExprContrato exprAnd = ConstruirArbolExpresionAnd<Contrato>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprAnd);
            }

            if (regla.Nivel.IsNotNullOrEmpty())
            {
                ExprContrato criterio = contrato => regla.Nivel.Contains(contrato.Nivel);
                predicado = predicado.And(criterio);
            }

            if (regla.DeducibleTotal.IsNotNullOrEmpty())
            {
                var nombrePropiedad = "DeducibleTotal";
                var expresionLogica = new ExpresionLogica(regla.DeducibleTotal);
                if (!expresionLogica.EsExpresionLogica)
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorExpresionLogica(nombrePropiedad, regla.DeducibleTotal));
                    return null;
                }

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = nombrePropiedad; return x; }).ToList();

                ExprContrato exprAnd = ConstruirArbolExpresionAnd<Contrato>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprAnd);
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

            if (regla.EsVigente.IsNotNull())
            {
                if (regla.EsVigente.Value)
                {
                    ExprContrato criterio = contrato => contrato.FechaVigencia > DateTime.Now.Date;
                    predicado = predicado.And(criterio);
                }
                else
                {
                    ExprContrato criterio = contrato => contrato.FechaVigencia <= DateTime.Now.Date;
                    predicado = predicado.And(criterio);
                }
            }

            return predicado;
        }

        private static ExprBeneficiario GeneraPredicadoBeneficiario(ReglaEntradaBeneficiario regla, out List<MensajeConfiguracionRegla> listaMensajes)
        {
            listaMensajes = new List<MensajeConfiguracionRegla>();

            ExprBeneficiario predicado = ConstructorPredicado.True<Beneficiario>();

            if (regla.IsNull())
            {
                return predicado;
            }

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

            if (regla.Edad.IsNotNull())
            {
                var nombrePropiedad = "Edad";
                var expresionLogica = new ExpresionLogica(regla.Edad);
                if (!expresionLogica.EsExpresionLogica)
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorExpresionLogica(nombrePropiedad, regla.Edad));
                    return null;
                }

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = nombrePropiedad; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprAnd);
            }

            if (regla.DeducibleCubierto.IsNotNullOrEmpty())
            {
                var nombrePropiedad = "DeducibleCubierto";
                var expresionLogica = new ExpresionLogica(regla.DeducibleCubierto);
                if (!expresionLogica.EsExpresionLogica)
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorExpresionLogica(nombrePropiedad, regla.DeducibleCubierto));
                    return null;
                }

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = nombrePropiedad; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprAnd);
            }

            if (regla.EnCarencia.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.EnCarencia == regla.EnCarencia;
                predicado = predicado.And(criterio);
            }

            if (regla.DiasFinCarencia.IsNotNullOrEmpty())
            {
                var nombrePropiedad = "DiasFinCarencia";
                var expresionLogica = new ExpresionLogica(regla.DiasFinCarencia);
                if (!expresionLogica.EsExpresionLogica)
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorExpresionLogica(nombrePropiedad, regla.DiasFinCarencia));
                    return null;
                }

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = nombrePropiedad; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprAnd);
            }

            if (regla.EnCarenciaHospitalaria.IsNotNull())
            {
                ExprBeneficiario criterio = beneficiario => beneficiario.EnCarenciaHospitalaria == regla.EnCarenciaHospitalaria;
                predicado = predicado.And(criterio);
            }

            if (regla.DiasFinCarenciaHospitalaria.IsNotNullOrEmpty())
            {
                var nombrePropiedad = "DiasFinCarenciaHospitalaria";
                var expresionLogica = new ExpresionLogica(regla.DiasFinCarenciaHospitalaria);
                if (!expresionLogica.EsExpresionLogica)
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorExpresionLogica(nombrePropiedad, regla.DiasFinCarenciaHospitalaria));
                    return null;
                }

                expresionLogica.Proposiciones.Select(x => { x.NombrePropiedad = "DeducibleCubierto"; return x; }).ToList();

                ExprBeneficiario exprAnd = ConstruirArbolExpresionAnd<Beneficiario>(expresionLogica.Proposiciones);
                if (exprAnd.IsNull())
                {
                    listaMensajes.Add(CrearMensajeConfiguracionRegla.ObtenerMensajeErrorParametro(nombrePropiedad));
                    return null;
                }
                predicado = predicado.And(exprAnd);
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

            if (regla.SuperaDeducible.IsNotNull())
            {
                if (regla.SuperaDeducible.Value)
                {
                    ExprBeneficiario criterio = beneficiario => beneficiario.DeducibleCubierto >= regla.DeducibleTotal;
                    predicado = predicado.And(criterio);
                }
                else
                {
                    ExprBeneficiario criterio = beneficiario => beneficiario.DeducibleCubierto < regla.DeducibleTotal;
                    predicado = predicado.And(criterio);
                }
            }

            return predicado;
        }

        internal static List<ReglaContrato> ObtenerReglasCandidatas(List<ReglaContrato> reglas, int convenio, int aplicacion, int plataforma)
        {
            return reglas.Where(regla => regla.EstadoActivo
                    && Validaciones.ValidarFechaRegla(regla)
                    && regla.Convenio.IsNotNullOrEmpty() ? regla.Convenio.Contains(convenio) : true
                    && regla.Aplicacion.IsNotNullOrEmpty() ? regla.Aplicacion.Contains(aplicacion) : true
                    && regla.Plataforma.IsNotNullOrEmpty() ? regla.Plataforma.Contains(plataforma) : true)
                .ToList();
        }

        internal static List<Contrato> ObtenerContratosCandidatos(List<Contrato> contratos, ReglaContrato regla, out List<MensajeConfiguracionRegla> listaMensajesContrato)
        {
            listaMensajesContrato = new List<MensajeConfiguracionRegla>();

            var predicado = GeneraPredicadoContrato(regla.Entrada.EntradaContrato, out var listaMensajes);
            listaMensajesContrato.AddRange(listaMensajes.Select(m => { m.Codigo = regla.Codigo; return m; }));

            return predicado.IsNull()
                ? null
                : contratos.AsQueryable().Where(predicado).ToList();
        }

        internal static List<Beneficiario> ObtenerBeneficiariosCandidatos(List<Beneficiario> beneficiarios, ReglaContrato regla, out List<MensajeConfiguracionRegla> listaMensajesBeneficiario)
        {
            listaMensajesBeneficiario = new List<MensajeConfiguracionRegla>();

            var predicado = GeneraPredicadoBeneficiario(regla.Entrada.EntradaBeneficiario, out var listaMensajes);
            listaMensajesBeneficiario.AddRange(listaMensajes.Select(m => { m.Codigo = regla.Codigo; return m; }));

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