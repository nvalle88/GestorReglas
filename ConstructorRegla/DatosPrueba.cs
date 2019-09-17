﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConstructorRegla
{
    public static class DatosPrueba
    {
        public static List<Contrato> ObtenerContratoCobertura()
            => JsonConvert.DeserializeObject<List<Contrato>>("[{\"Region\":\"Costa\",\"Producto\":\"IND\",\"Numero\":692005,\"CodigoPlan\":\"55-PLUS-C\",\"Codigo\":5389876,\"Estado\":\"Activo\",\"CodigoEstado\":1,\"NombrePlan\":\"Elite 5b Costa\",\"Version\":20,\"CoberturaMaxima\":29000,\"Nivel\":5,\"Titular\":{\"Numero\":5385438,\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Genero\":\"F\"},\"DeducibleTotal\":0,\"TieneImpedimento\":false,\"MotivoImpedimento\":\"\",\"EsMoroso\":false,\"NombreComercialPlan\":\"\u00c9lite\",\"FechaInicio\":\"2012-09-25T00:00:00\",\"FechaVigencia\":\"2019-09-25T00:00:00\",\"CodigoPmf\":\"IND00015\",\"Empresa\":\"SALUD INDIVIDUALES S.A.\",\"NumeroEmpresa\":1,\"Sucursal\":\"Guayaquil\",\"CodigoSucursal\":101,\"NombreLista\":\"Salud Individuales S.a.\",\"NumeroLista\":1,\"EsDeducibleAnual\":false,\"Deducibles\":[],\"Beneficiarios\":[{\"NumeroPersona\":5486199,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Sophia\",\"Apellidos\":\"Savinovich Bazan\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"09088486174\",\"FechaNacimiento\":\"2008-11-05T00:00:00\",\"Edad\":10,\"FechaInclusion\":\"2012-09-25T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":true,\"Observaciones\":\"\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":6804728,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":4.5,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6804729,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6804730,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6804731,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6804732,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":60,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6804733,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6804734,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6804735,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6804736,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":20,\"Disponibles\":20}]}]},{\"Region\":\"Sierra\",\"Producto\":\"XPR\",\"Numero\":10000000,\"CodigoPlan\":\"XPR-1M-5000\",\"Codigo\":989531,\"Estado\":\"Activo\",\"CodigoEstado\":1,\"NombrePlan\":\"Experience 1m Ded 5000\",\"Version\":20,\"CoberturaMaxima\":1000000,\"Nivel\":8,\"Titular\":{\"Numero\":5385438,\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Genero\":\"F\"},\"DeducibleTotal\":5000,\"TieneImpedimento\":false,\"MotivoImpedimento\":\"\",\"EsMoroso\":false,\"NombreComercialPlan\":null,\"FechaInicio\":\"2017-08-17T00:00:00\",\"FechaVigencia\":\"2019-08-17T00:00:00\",\"CodigoPmf\":\"297371\",\"Empresa\":\"SALUD INDIVIDUALES S.A.\",\"NumeroEmpresa\":1,\"Sucursal\":\"Quito\",\"CodigoSucursal\":1,\"NombreLista\":\"Salud Individuales S.a.\",\"NumeroLista\":1,\"EsDeducibleAnual\":false,\"Deducibles\":[{\"Codigo\":\"PERSONAL\",\"Region\":\"Sierra\",\"CodigoProducto\":\"XPR\",\"CodigoPlan\":\"XPR-1M-5000\",\"VersionPlan\":20,\"TipoCobertura\":\"Ambos\",\"Monto\":5000}],\"Beneficiarios\":[{\"NumeroPersona\":5385438,\"RelacionDependiente\":\"Titular\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Edad\":44,\"FechaInclusion\":\"2017-08-17T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[{\"CodigoDiagnostico\":\"N602\",\"Descripcion\":\"Fibroadenosis de la Mama\",\"FechaInicio\":\"2017-08-17T00:00:00\",\"DiasFaltanCobertura\":-395}],\"BeneficioOda\":false,\"Observaciones\":\"El contrato no se encuentra vigente. No se puede generar la Oda.\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":6949218,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":4.5,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949219,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949220,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949221,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949222,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949223,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949224,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6949225,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6949226,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":40,\"Disponibles\":40}]},{\"NumeroPersona\":1182383,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Fabiola Sara\",\"Apellidos\":\"Gonzalez Savinovich\",\"Genero\":\"F\",\"TipoDocumento\":\"P\",\"NumeroDocumento\":\"518978064\",\"FechaNacimiento\":\"2003-12-13T00:00:00\",\"Edad\":15,\"FechaInclusion\":\"2017-08-17T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"El contrato no se encuentra vigente. No se puede generar la Oda.\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":6949218,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":4.5,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949219,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949220,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949221,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949222,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949223,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949224,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6949225,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6949226,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":40,\"Disponibles\":40}]},{\"NumeroPersona\":5610990,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Victoria Maria\",\"Apellidos\":\"Gonzalez Savinovich\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0958007981\",\"FechaNacimiento\":\"2002-12-22T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2017-08-17T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[{\"CodigoDiagnostico\":\"S62\",\"Descripcion\":\"Fractura a Nivel de la Mu\u00f1eca y de la Mano\",\"FechaInicio\":\"2017-08-17T00:00:00\",\"DiasFaltanCobertura\":-395}],\"BeneficioOda\":false,\"Observaciones\":\"El contrato no se encuentra vigente. No se puede generar la Oda.\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":6949218,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":4.5,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949219,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949220,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949221,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949222,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949223,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":6949224,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6949225,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":20,\"Disponibles\":20},{\"IdBeneficioConvenio\":6949226,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":false,\"Total\":40,\"Disponibles\":40}]}]},{\"Region\":\"Sierra\",\"Producto\":\"COR\",\"Numero\":1397237,\"CodigoPlan\":\"AF0071207044\",\"Codigo\":1397237,\"Estado\":\"Activo\",\"CodigoEstado\":1,\"NombrePlan\":\"Suscripcion 01-06-2019 al 01-06-2020\",\"Version\":0,\"CoberturaMaxima\":60000,\"Nivel\":7,\"Titular\":{\"Numero\":5385438,\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Genero\":\"F\"},\"DeducibleTotal\":140,\"TieneImpedimento\":false,\"MotivoImpedimento\":\"\",\"EsMoroso\":false,\"NombreComercialPlan\":\"Ejecutivos Gye\",\"FechaInicio\":\"2019-06-01T00:00:00\",\"FechaVigencia\":\"2020-06-01T00:00:00\",\"CodigoPmf\":\"547411\",\"Empresa\":\"SISTEMA DE MEDICINA PREPAGADA DEL ECUADOR S.A.\",\"NumeroEmpresa\":61807,\"Sucursal\":\"Quito\",\"CodigoSucursal\":1,\"NombreLista\":\"Sistema de Medicina Prepagada del Ecuador S.a. Producto Smartplan Gye Max:60000 Nivel:7\",\"NumeroLista\":71207044,\"EsDeducibleAnual\":false,\"Deducibles\":[{\"Codigo\":\"PER\",\"Region\":\"Sierra\",\"CodigoProducto\":\"COR\",\"CodigoPlan\":\"AF0071207044\",\"VersionPlan\":0,\"TipoCobertura\":\"Ambos\",\"Monto\":140}],\"Beneficiarios\":[{\"NumeroPersona\":5385438,\"RelacionDependiente\":\"Titular\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Edad\":44,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":70.27,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":8511608,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":10,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511609,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511610,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511611,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511612,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511613,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511614,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10},{\"IdBeneficioConvenio\":8511615,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10},{\"IdBeneficioConvenio\":8511616,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10}]},{\"NumeroPersona\":58294877,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Gonzalez\",\"Genero\":\"F\",\"TipoDocumento\":\"P\",\"NumeroDocumento\":\"566610448\",\"FechaNacimiento\":\"2002-12-13T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":8511608,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":10,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511609,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511610,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511611,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511612,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511613,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511614,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10},{\"IdBeneficioConvenio\":8511615,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10},{\"IdBeneficioConvenio\":8511616,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10}]},{\"NumeroPersona\":5610990,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Victoria Maria\",\"Apellidos\":\"Gonzalez Savinovich\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0958007981\",\"FechaNacimiento\":\"2002-12-22T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":true,\"BeneficiosPlan\":[{\"IdBeneficioConvenio\":8511608,\"CodigoBeneficio\":\"A002\",\"Nombre\":\"Consulta Medica\",\"Valor\":10,\"EsPorcentaje\":false,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511609,\"CodigoBeneficio\":\"A003\",\"Nombre\":\"Laboratorio Clinico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511610,\"CodigoBeneficio\":\"A004\",\"Nombre\":\"Laboratorio Imagen\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511611,\"CodigoBeneficio\":\"A005\",\"Nombre\":\"Procedimientos Diagnostico\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511612,\"CodigoBeneficio\":\"A010\",\"Nombre\":\"Medicinas Marca\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511613,\"CodigoBeneficio\":\"A011\",\"Nombre\":\"Medicinas Genericas\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":0,\"Disponibles\":0},{\"IdBeneficioConvenio\":8511614,\"CodigoBeneficio\":\"AH01\",\"Nombre\":\"Terapia Respiratoria\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10},{\"IdBeneficioConvenio\":8511615,\"CodigoBeneficio\":\"AH02\",\"Nombre\":\"Terapia de Lenguaje\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10},{\"IdBeneficioConvenio\":8511616,\"CodigoBeneficio\":\"AH03\",\"Nombre\":\"Terapia Fisica\",\"Valor\":80,\"EsPorcentaje\":true,\"EstadoActivo\":true,\"Credito\":true,\"Total\":10,\"Disponibles\":10}]}]},{\"Region\":\"Sierra\",\"Producto\":\"EXE\",\"Numero\":1397238,\"CodigoPlan\":\"AF0071207046\",\"Codigo\":1397238,\"Estado\":\"Activo\",\"CodigoEstado\":1,\"NombrePlan\":\"Suscripcion 01-06-2019 al 01-06-2020\",\"Version\":0,\"CoberturaMaxima\":0,\"Nivel\":7,\"Titular\":{\"Numero\":5385438,\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Genero\":\"F\"},\"DeducibleTotal\":0,\"TieneImpedimento\":false,\"MotivoImpedimento\":\"\",\"EsMoroso\":false,\"NombreComercialPlan\":\"Exequial\",\"FechaInicio\":\"2019-06-01T00:00:00\",\"FechaVigencia\":\"2020-06-01T00:00:00\",\"CodigoPmf\":null,\"Empresa\":\"SISTEMA DE MEDICINA PREPAGADA DEL ECUADOR S.A.\",\"NumeroEmpresa\":61807,\"Sucursal\":\"Quito\",\"CodigoSucursal\":1,\"NombreLista\":\"Sistema de Medicina Prepagada del Ecuador S.a. Producto Smartplan Max:1000 Nivel:3\",\"NumeroLista\":71207046,\"EsDeducibleAnual\":false,\"Deducibles\":[],\"Beneficiarios\":[{\"NumeroPersona\":5385438,\"RelacionDependiente\":\"Titular\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Edad\":44,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":false,\"BeneficiosPlan\":[]},{\"NumeroPersona\":58294877,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Gonzalez\",\"Genero\":\"F\",\"TipoDocumento\":\"P\",\"NumeroDocumento\":\"566610448\",\"FechaNacimiento\":\"2002-12-13T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":false,\"BeneficiosPlan\":[]},{\"NumeroPersona\":5610990,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Victoria Maria\",\"Apellidos\":\"Gonzalez Savinovich\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0958007981\",\"FechaNacimiento\":\"2002-12-22T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":false,\"BeneficiosPlan\":[]}]},{\"Region\":\"Sierra\",\"Producto\":\"DEN\",\"Numero\":1399269,\"CodigoPlan\":\"AF0071207053\",\"Codigo\":1399269,\"Estado\":\"Activo\",\"CodigoEstado\":1,\"NombrePlan\":\"Suscripci\u00f3n 01-06-2019 al 01-06-2020\",\"Version\":0,\"CoberturaMaxima\":0,\"Nivel\":0,\"Titular\":{\"Numero\":5385438,\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Genero\":\"F\"},\"DeducibleTotal\":0,\"TieneImpedimento\":false,\"MotivoImpedimento\":\"\",\"EsMoroso\":false,\"NombreComercialPlan\":\"Dental Privilegio\",\"FechaInicio\":\"2019-06-01T00:00:00\",\"FechaVigencia\":\"2020-06-01T00:00:00\",\"CodigoPmf\":null,\"Empresa\":\"SISTEMA DE MEDICINA PREPAGADA DEL ECUADOR S.A.\",\"NumeroEmpresa\":61807,\"Sucursal\":\"Quito\",\"CodigoSucursal\":1,\"NombreLista\":\"Sistema de Medicina Prepagada del Ecuador S.a. Producto Smartplan Dental Privilegio Max:1000 Nivel:3\",\"NumeroLista\":71207053,\"EsDeducibleAnual\":false,\"Deducibles\":[],\"Beneficiarios\":[{\"NumeroPersona\":5385438,\"RelacionDependiente\":\"Titular\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Savinovich Espinel\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0908848617\",\"FechaNacimiento\":\"1975-07-06T00:00:00\",\"Edad\":44,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":false,\"BeneficiosPlan\":[]},{\"NumeroPersona\":58294877,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Fabiola\",\"Apellidos\":\"Gonzalez\",\"Genero\":\"F\",\"TipoDocumento\":\"P\",\"NumeroDocumento\":\"566610448\",\"FechaNacimiento\":\"2002-12-13T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":false,\"BeneficiosPlan\":[]},{\"NumeroPersona\":5610990,\"RelacionDependiente\":\"Hijo\",\"Nombres\":\"Victoria Maria\",\"Apellidos\":\"Gonzalez Savinovich\",\"Genero\":\"F\",\"TipoDocumento\":\"C\",\"NumeroDocumento\":\"0958007981\",\"FechaNacimiento\":\"2002-12-22T00:00:00\",\"Edad\":16,\"FechaInclusion\":\"2019-06-01T00:00:00\",\"DeducibleCubierto\":0,\"EnCarencia\":false,\"DiasFinCarencia\":0,\"EnCarenciaHospitalaria\":false,\"DiasFinCarenciaHospitalaria\":0,\"Preexistencias\":[],\"BeneficioOda\":false,\"Observaciones\":\"La lista no permite emisi\u00f3n de odas. No se puede generar la Oda.\",\"Maternidad\":false,\"BeneficiosPlan\":[]}]}]");

        public static List<Regla> ObtenerReglas()
            => JsonConvert.DeserializeObject<List<Regla>>("[{\"Codigo\":\"01\",\"Descripcion\":\"Regla para productos individuales con convenio VERIS y cambio de nombre plan\",\"Entrada\":{\"Producto\":\"IND\",\"Convenio\":11715},\"Salida\":{\"NombrePlan\":{\"Campo\":\"NombrePlan\",\"Texto\":\"Producto Individual - \"}}},{\"Codigo\":\"02\",\"Descripcion\":\"Regla para productos pool sin convenio y cambio de nombre plan\",\"Entrada\":{\"Producto\":\"IND\"},\"Salida\":{\"NombrePlan\":{\"Campo\":\"NombrePlan\",\"Texto\":\"Producto Individual - \"}}}]");
    }
}