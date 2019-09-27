using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    public static class Validaciones
    {
        public static bool ValidarFechaRegla(Regla regla)
        {
            try
            {
                if (regla.FechaInicioRegla.IsNotNull() && regla.FechaFinRegla.IsNull())
                    return DateTime.Now.Date >= regla.FechaInicioRegla.Value.Date;


                if (regla.FechaInicioRegla.IsNull() && regla.FechaFinRegla.IsNotNull())
                    return DateTime.Now.Date <= regla.FechaFinRegla.Value.Date;


                if (regla.FechaInicioRegla.IsNotNull() && regla.FechaFinRegla.IsNotNull())
                {
                    var fechaActual = DateTime.Now.Date;
                    return (fechaActual >= regla.FechaInicioRegla.Value.Date) && (fechaActual <= regla.FechaFinRegla.Value.Date);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
