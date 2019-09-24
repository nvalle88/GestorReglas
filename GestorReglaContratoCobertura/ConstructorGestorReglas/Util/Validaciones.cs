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
                if (regla.FechaInicioRegla.IsNotNull2() && regla.FechaFinRegla.IsNull2())
                    return DateTime.Now.Date >= regla.FechaInicioRegla.Value.Date;


                if (regla.FechaInicioRegla.IsNull2() && regla.FechaFinRegla.IsNotNull2())
                    return DateTime.Now.Date <= regla.FechaFinRegla.Value.Date;


                if (regla.FechaInicioRegla.IsNotNull2() && regla.FechaFinRegla.IsNotNull2())
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
