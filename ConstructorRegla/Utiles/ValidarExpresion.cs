using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ConstructorRegla.Utiles
{
    public static class ValidarExpresion
    {
       

        public static ValorSigno ObtenerValor(this string expresion)
        {
            if (expresion.Contains(Signos.MayorIgualQue.ToString()))
            {
                return null;
            }
            if (expresion.Contains(Signos.Igual.ToString()))
            {
                return new ValorSigno
                {
                    Signo = Signos.Igual.ToString(),
                    Valor = expresion.Split(new char[] { Signos.Igual }, 2)[1]
                };
            }
            else
            {
                if (expresion.Contains(Signos.MayorQue.ToString()))
                {
                    return new ValorSigno
                    {
                        Signo = Signos.MayorQue.ToString(),
                        Valor = expresion.Split(new char[] { Signos.MayorQue }, 2)[1]
                    };
                }
                else
                {
                    if (expresion.Contains(Signos.MenorQue.ToString()))
                    {
                        return new ValorSigno
                        {
                            Signo = Signos.MenorQue.ToString(),
                            Valor = expresion.Split(new char[] { Signos.MenorQue }, 2)[1]
                        };
                    }
                }
            }
            return null;
        }

        public static Expression<Func<Contrato, bool>> ObtenerExpresionNivel(this ValorSigno valorSigno)
        {
            if (valorSigno.Signo==Signos.Igual.ToString())
            {
                Expression<Func<Contrato, bool>> criterioPlanIgual = contrato => contrato.Nivel == Convert.ToInt32(valorSigno.Valor);
                return criterioPlanIgual;
            }
            else
            {
                if (valorSigno.Signo == Signos.MayorQue.ToString())
                {
                    Expression<Func<Contrato, bool>> criterioPlanMayor = contrato => contrato.Nivel > Convert.ToInt32(valorSigno.Valor);
                    return criterioPlanMayor;
                }
                else
                {
                    if (valorSigno.Signo == Signos.MenorQue.ToString())
                    {
                        Expression<Func<Contrato, bool>> criterioPlanMenor = contrato => contrato.Nivel < Convert.ToInt32(valorSigno.Valor);
                        return criterioPlanMenor;
                    }
                }
            }
            return null;
           
        }
    }
}
