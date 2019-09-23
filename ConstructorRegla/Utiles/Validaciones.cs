using ConstructorRegla.Modelos.Regla;
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
                throw;
            }
        }

        public static List<Contrato> ValidarReglasContrato(List<Contrato> contratos,Regla regla)
        {
            if (regla.Entrada.EntradaContrato.Producto.IsNotNullOrEmpty())
            {
                contratos.Where(x => regla.Entrada.EntradaContrato.Producto.Contains(x.Producto));
            }



            return contratos.ToList();
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
           
        }

        public static void ValidarBeneficiosPlan()
        {
            throw new NotImplementedException();
        }
    }
}
