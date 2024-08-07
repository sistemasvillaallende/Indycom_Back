﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Transactions;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Entities.IYC;

namespace Web_Api_IyC.Services
{
    public class IndycomServices : IIndycomServices
    {
        public void Delete(int legajo)
        {
            try
            {
                Entities.INDYCOM.Delete(legajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public INDYCOM GetByPk(int legajo)
        {
            try
            {
                return Entities.INDYCOM.GetByPk(legajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public int Insert(INDYCOM obj)
        //{
        //    try
        //    {
        //        return Entities.INDYCOM.Insert(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<INDYCOM> Read()
        {
            try
            {
                return Entities.INDYCOM.Read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(INDYCOM obj, INDYCOM objOriginal)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.objAuditoria.identificacion = obj.legajo.ToString();
                            obj.objAuditoria.proceso = "MODIFICACION INDYCOM";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            INDYCOM.Update(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Entities.TIPOS_LIQ_IYC> Tipos_liq_iyc()
        {
            try
            {
                return Entities.INDYCOM.Tipos_liq_iyc();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<Entities.TIPOS_PER_IYC> Tipos_per_iyc()
        {
            try
            {
                return Entities.INDYCOM.Tipos_per_iyc();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<Entities.TIPOS_DE_IVA> Tipos_iva()
        {
            try
            {
                return Entities.INDYCOM.Tipos_iva();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Combo> Tipos_entidad()
        {
            try
            {
                return Entities.INDYCOM.Tipos_entidad();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> Zonasiyc()
        {

            try
            {
                return Entities.INDYCOM.Zonasiyc();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Combo> Situacion_judicial()
        {
            try
            {
                return Entities.INDYCOM.Situacion_judicial();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void InsertDatosGeneral(INDYCOM obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.objAuditoria.identificacion = obj.legajo.ToString();
                            obj.objAuditoria.proceso = "NUEVO INDYCOM";
                            obj.objAuditoria.detalle = "";
                            obj.objAuditoria.observaciones += string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.INDYCOM.InsertDatosGeneral(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDatosGenerales(INDYCOM obj, INDYCOM objOriginal)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.objAuditoria.identificacion = obj.legajo.ToString();
                            obj.objAuditoria.proceso = "MODIFICACION INDYCOM";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.objAuditoria.observaciones += string.Format("Fecha auditoria: {0}", DateTime.Now);
                            INDYCOM.UpdateDatosGenerales(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateDatosDomPostal(INDYCOM obj, INDYCOM objOriginal)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.objAuditoria.identificacion = obj.legajo.ToString();
                            obj.objAuditoria.proceso = "CAMBIO DOMIC. POSTAL INDYCOM";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.objAuditoria.observaciones += string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.INDYCOM.UpdateDatosDomPostal(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveDatosAfip(INDYCOM obj, INDYCOM objOriginal)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.objAuditoria.identificacion = obj.legajo.ToString();
                            obj.objAuditoria.proceso = "GUARDAR DATOS AFIP EN IYC";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.objAuditoria.observaciones += string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.INDYCOM.SaveDatosAfip(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void SaveDatosLiquidacion(INDYCOM obj, INDYCOM objOriginal)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.objAuditoria.identificacion = obj.legajo.ToString();
                            obj.objAuditoria.proceso = "GUARDAR DATOS LIQUIDACION EN IYC";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.objAuditoria.observaciones += string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.INDYCOM.SaveDatosLiquidacion(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int Count()
        {
            try
            {
                return INDYCOM.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<INDYCOM> GetIndycomPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta)
        {
            try
            {
                return INDYCOM.GetIndycomPaginado(buscarPor, strParametro, registro_desde, registro_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Buscador> GetConvenios(string nom_convenio)
        {
            try
            {
                return INDYCOM.GetConvenios(nom_convenio);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Buscador> GetMinimos_indycom(string minimo)
        {
            try
            {
                return INDYCOM.GetMinimos_indycom(minimo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void BajaComercial(int legajo, string fecha_baja, INDYCOM objOriginal, Auditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.identificacion = legajo.ToString();
                            obj.proceso = "BAJA IYC";
                            obj.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.observaciones += string.Format("Baja IYC Legajo {0}, Fecha auditoria: {1}",
                                legajo, DateTime.Now);
                            INDYCOM.BajaComercial(legajo, fecha_baja, con, trx);
                            AuditoriaD.InsertAuditoria(obj, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void BajaSucursal(int legajo, int nro_sucursal, string fecha_baja, INDYCOM objOriginal, Auditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.identificacion = legajo.ToString();
                            obj.proceso = "BAJA SUCURSAL";
                            obj.detalle = JsonConvert.SerializeObject(objOriginal);
                            obj.observaciones += string.Format("Baja Sucursal {0}, del Legajo {1}, Fecha auditoria: {2}", nro_sucursal, legajo, DateTime.Now);
                            INDYCOM.BajaSucursal(legajo, nro_sucursal, fecha_baja, con, trx);
                            AuditoriaD.InsertAuditoria(obj, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Bases_imponibles> GetBasesImponibles(int legajo, string periodo_desde, string periodo_hasta)
        {
            try
            {
                return Bases_imponibles.GetBasesImponibles(legajo, periodo_desde, periodo_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Rubros_x_iyc> GetRubros_x_iyc(int legajo)
        {
            try
            {
                return Rubros_x_iyc.GetRubros_x_iyc(legajo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Sucursales_indycom GetSucuralByLegajo(int legajo, int nro_sucursal)
        {
            try
            {
                return Sucursales_indycom.GetSucuralByLegajo(legajo, nro_sucursal);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RUBROS> BuscarRubroxDescripcion(string descripcion)
        {
            try
            {
                return RUBROS.BuscarRubroxDescripcion(descripcion);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Informes> InformeCtaCteSoloDeuda(int legajo, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "IMPRIME_DEUDA_IYC";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            AuditoriaD.InsertAuditoria(objA, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                    return Informes.InformeCtaCteSoloDeuda(legajo, categoria_deuda, categoria_deuda2, per);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Informes> InformeCtaCteCompleto(int legajo, string per, Auditoria objA)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "IMPRIME_DEUDA_IYC";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            AuditoriaD.InsertAuditoria(objA, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                    return Informes.InformeCtaCteCompleto(legajo, per);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> ListarCategoriasIyc()
        {
            try
            {
                return INDYCOM.ListarCategoriasIyc();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Informes> Resumendeuda(int legajo, int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "IMPRIME_DEUDA_IYC";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            AuditoriaD.InsertAuditoria(objA, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                    return Informes.Resumendeuda(legajo, tipo_consulta, periodo, cate_deuda_desde, cate_deuda_hasta);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> GetCalle(string nomcalle)
        {
            try
            {
                return INDYCOM.GetCalle(nomcalle);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Indycomxcalle> ConsultaIyc_x_calles(string calledesde, string callehasta)
        {
            try
            {
                return Indycomxcalle.ConsultaIyc_x_calles(calledesde, callehasta);

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<BADEC> GetBadecByNombre(string nombre)
        {
            try
            {
                return BADEC.GetBadecByNombre(nombre);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<BADEC> GetBadecByCuit(string cuit)
        {
            try
            {
                return BADEC.GetBadecByCuit(cuit);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

