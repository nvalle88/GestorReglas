using System;
using System.Text.RegularExpressions;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    /// <summary>
    /// Recopila las expresiones regulares usadas en el gestor de reglas
    /// </summary>
    internal static class ExpresionRegular
    {
        private const string patronEliminarComodin = @"[*]";
        private const string patronEliminarEspacio = @"\s";
        private const string patronExpresionLogica = @"^(>|>=|<|<=|=|!=)(\d+)((&&|\|\||!)(>|>=|<|<=|=|!=)(\d+))?$";

        #region Expresiones de reemplazo

        /// <summary>
        /// Elimina el caracter comodín * de la cadena que se envíe
        /// </summary>
        /// <param name="cadena">Cadena con comodín *</param>
        /// <returns>Cadena sin comodín *</returns>
        internal static string EliminarComodin(string cadena)
        {
            try
            {
                return Regex.Replace(EliminarEspacio(cadena), patronEliminarComodin, "");
            }
            catch (Exception)
            {
                return cadena;
            }
        }

        /// <summary>
        /// Elimina todos los espacios en la cadena
        /// </summary>
        /// <param name="cadena">Cadena con espacios en blanco</param>
        /// <returns>Cadena sin espacios en blanco</returns>
        internal static string EliminarEspacio(string cadena)
        {
            try
            {
                return Regex.Replace(cadena, patronEliminarEspacio, "");
            }
            catch (Exception)
            {
                return cadena;
            }
        }

        #endregion Expresiones de reemplazo

        #region Expresiones de validación

        /// <summary>
        ///
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        internal static Match ValidarExpresionLogica(string cadena)
        {
            try
            {
                return Regex.Match(cadena, patronExpresionLogica);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion Expresiones de validación
    }
}