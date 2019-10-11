using GestorReglaContratoCobertura.Extensores;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    internal static class Validaciones
    {
        internal static bool ValidarFechaRegla(ReglaContrato regla)
        {
            var fechaActual = DateTime.Now.Date;
            try
            {
                return (regla.FechaInicioRegla.IsNull() || regla.FechaInicioRegla <= fechaActual) &&
                    (regla.FechaFinRegla.IsNull() || regla.FechaFinRegla >= fechaActual);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}