using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    public static class Validaciones
    {
        public static bool ValidarFechaRegla(Regla regla)
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
