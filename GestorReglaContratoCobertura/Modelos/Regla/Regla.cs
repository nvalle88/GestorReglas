using System;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
    public class Regla
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoActivo { get; set; }
        public DateTime? FechaInicioRegla { get; set; }
        public DateTime? FechaFinRegla { get; set; }
        public List<int> Convenio { get; set; }
        public List<int> Aplicacion { get; set; }
        public List<int> Plataforma { get; set; }
        public Entrada Entrada { get; set; }
        public Salida Salida { get; set; }
    }
}


//Estructura JSON completa para la regla
//[
//    {
//        "Codigo": "01",
//        "Descripcion": "Regla para",
//        "EstadoActivo": true,
//        "FechaInicioRegla": null,
//        "FechaFinRegla": null,
//        "Convenio": [],
//        "Aplicacion": [],
//        "Plataforma": [],
//        "Entrada": {
//            "EntradaContrato": {
//                "Region": [
//                    ""
//                ],
//                "Producto": [
//                    ""
//                ],
//                "CodigoEstado": [
//                    0
//                ],
//                "CodigoPlan": [
//                    ""
//                ],
//                "Version": [
//                    0
//                ],
//                "CoberturaMaxima": "",
//                "Nivel": [
//                    0
//                ],
//                "DeducibleTotal": "",
//                "TieneImpedimento": true,
//                "EsMoroso": true,
//                "NumeroEmpresa": [
//                    0
//                ],
//                "CodigoSucursal": [
//                    0
//                ],
//                "NumeroLista": [
//                    0
//                ],
//                "EsDeducibleAnual": true
//            },
//            "EntradaBeneficiario": {
//                "RelacionDependiente": [
//                    ""
//                ],
//                "Genero": [
//                    ""
//                ],
//                "Edad": "",
//                "DeducibleCubierto": "",
//                "EnCarencia": true,
//                "DiasFinCarencia": "",
//                "EnCarenciaHospitalaria": true,
//                "DiasFinCarenciaHospitalaria": "",
//                "BeneficioOda": true,
//                "Maternidad": true,
//                "SuperaDeducible": true
//            },
//            "EntradaBeneficioPlan": [
//                {
//                    "EntradaBeneficioPlan": {
//                        "CodigoBeneficio": [""],
//                        "EsPorcentaje": true
//                    },
//                    "SalidaBeneficioPlan": [
//                        {
//                            "NombrePropiedad": "",
//                            "Valor": "",
//                            "Posicion": ""
//                        }
//                    ]
//                }
//            ]
//        },
//        "Salida": {
//            "SalidaContrato": [
//                {
//                    "NombrePropiedad": "",
//                    "Valor": "",
//                    "Posicion": ""
//                }
//            ],
//            "SalidaBeneficiario": [
//                {
//                    "NombrePropiedad": "",
//                    "Valor": "",
//                    "Posicion": ""
//                }
//            ]
//        }
//    }
//]
