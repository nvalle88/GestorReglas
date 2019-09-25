using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
    public class Salida
    {
        public List<SalidaGenerica> SalidaContrato { get; set; }
        public List<SalidaGenerica> SalidaBeneficiario { get; set; }
    }

    public class SalidaGenerica
    {
        public string NombrePropiedad { get; set; }
        public string Valor { get; set; }
        public Posicion? Posicion { get; set; }
    }

    public class Salida2
    {
        #region Salidas para Contrato
        public NombrePlan NombrePlan { get; set; }
        public ObservacionesContrato ObservacionesContrato { get; set; }
        #endregion Salidas para Contrato

        #region Salidas para Beneficiario
        public Deducible Deducible { get; set; }
        public Carencia Carencia { get; set; }
        public CarenciaHospitalaria CarenciaHospitalaria { get; set; }
        public BeneficioODA BeneficioODA { get; set; }
        public ObservacionesBeneficiario ObservacionesBeneficiario { get; set; }
        public MaternidadBeneficiario MaternidadBeneficiario { get; set; }
        #endregion Salidas para Beneficiario
    }


    public class SalidaGenerica
    {
        public string NombrePropiedad { get; set; }
        public string Valor { get; set; }
        public Posicion? Posicion { get; set; }
    }

    #region Clases salida Contrato
    public class NombrePlan : CambioTexto
    {
    }

    public class ObservacionesContrato : CambioTexto
    {
    }
    #endregion Clases salida Contrato

    #region Clases salida Beneficiario

    public class Deducible
    {
        public double DeducibleCubierto { get; set; }
    }

    public class Carencia
    {
        public bool EnCarencia { get; set; }
        public short DiasFinCarencia
        {
            get => EnCarencia ? DiasFinCarencia : (short)0;
            set { }
        }
    }

    public class CarenciaHospitalaria
    {
        public bool EnCarenciaHospitalaria { get; set; }
        public short DiasFinCarenciaHospitalaria
        {
            get => EnCarenciaHospitalaria ? DiasFinCarenciaHospitalaria : (short)0;
            set { }
        }
    }

    public class BeneficioODA
    {
        public bool BeneficioOda { get; set; }
    }

    public class ObservacionesBeneficiario : CambioTexto
    {
    }

    public class MaternidadBeneficiario
    {
        public bool Maternidad { get; set; }
    }

    #endregion Clases salida Beneficiario
}
