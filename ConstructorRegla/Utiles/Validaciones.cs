using Saludsa.UtilidadesRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructorRegla.Utiles
{
   public static class Validaciones
    {
        public static bool ValidarFechaRegla(Regla regla)
        {
            if (regla.FechaInicioRegla.IsNotNull() && regla.FechaFinRegla.IsNull())
                return DateTime.Now.Date >= regla.FechaInicioRegla.Value.Date ;


            if (regla.FechaInicioRegla.IsNull() && regla.FechaFinRegla.IsNotNull())
                return DateTime.Now.Date <= regla.FechaFinRegla.Value.Date;


            if (regla.FechaInicioRegla.IsNotNull() && regla.FechaFinRegla.IsNotNull())
            {
                var fechaActual = DateTime.Now.Date;
                return (fechaActual >= regla.FechaInicioRegla.Value.Date ) && (fechaActual <= regla.FechaFinRegla.Value.Date);
            }

            return true;
        }

        public static List<Contrato> ValidarReglasContrato(List<Contrato> contratos,Regla regla)
        {
            return null;
        }

        public static List<Contrato> ValidarReglasContrato(List<Contrato> contratos, ReglaEntradaContrato reglaEntradaContrato )
        {
            if (reglaEntradaContrato.CodigoEstado.IsNotNullOrEmpty())
            {
                contratos.Where(x => reglaEntradaContrato.CodigoEstado.Contains(x.CodigoEstado));
            }
            return null;
        }

        public static void ValidarReglasBeneficiarios()
        {
            throw new NotImplementedException();
        }

        public static void ValidarBeneficiosPlan()
        {
            throw new NotImplementedException();
        }
    }
}
