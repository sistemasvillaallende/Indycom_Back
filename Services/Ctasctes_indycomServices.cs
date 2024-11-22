using System.Data.SqlClient;
using System.Transactions;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Entities.IYC;

namespace Web_Api_IyC.Services
{
    public class Ctasctes_indycomServices : ICtasctes_indycomServices
    {
        public List<Periodos> IniciarCtacte(int legajo)
        {
            try
            {
                return Ctasctes_indycom.IniciarCtacte(legajo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Ctasctes_indycom> ListarCtacte(int legajo, int tipo_consulta,
                                                        int cate_deuda_desde, int cate_deuda_hasta)
        {
            try
            {
                return Ctasctes_indycom.ListarCtacte(legajo, tipo_consulta, cate_deuda_desde, cate_deuda_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            try
            {
                return Ctasctes_indycom.Datos_transaccion(tipo_transaccion, nro_transaccion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Ctasctes_indycom> Listar_periodos_a_cancelar(int legajo)
        {
            try
            {
                return Ctasctes_indycom.Listar_periodos_a_cancelar(legajo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Confirma_cancelacion_ctasctes(int tipo_transaccion, int legajo, List<Ctasctes_indycom> lst, Auditoria objA)
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
                            string string_detalle = "Se Elimino total o parcial: ";
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "CANCELACION CUENTA CORRIENTE";
                            objA.detalle = "";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Ctasctes_indycom.InsertCancelacioMasiva(tipo_transaccion, legajo, lst, con, trx);
                            Ctasctes_indycom.MarcopagadalaCtacte(legajo, lst, con, trx);
                            foreach (var item in lst)
                            {
                                string_detalle += string.Format("Periodo {0} : ", item.periodo);
                            }
                            objA.detalle = string_detalle;
                            AuditoriaD.InsertAuditoria(objA, con, trx);
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
        public List<Ctasctes_indycom> Listar_Periodos_cancelados(int legajo)
        {
            try
            {
                return Ctasctes_indycom.Listar_Periodos_cancelados(legajo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Confirma_elimina_cancelacion(int legajo, List<Ctasctes_indycom> lst, Auditoria objA)
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
                            string string_detalle = "Se cancelo total o parcial: ";
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "ELIMINA CANCELACION OPERATIVA";
                            objA.detalle = "";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Ctasctes_indycom.Confirma_elimina_cancelacion(legajo, lst, con, trx);
                            Ctasctes_indycom.MarconopagadalaCtacte(legajo, lst, con, trx);
                            foreach (var item in lst)
                            {
                                string_detalle += string.Format("Periodo {0} : ", item.periodo);
                            }
                            objA.detalle = string_detalle;
                            AuditoriaD.InsertAuditoria(objA, con, trx);
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
        public List<Ctasctes_indycom> Listar_periodos_a_reliquidar(int legajo)
        {
            try
            {
                return Ctasctes_indycom.Listar_periodos_a_reliquidar(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Confirma_reliquidacion(int legajo, int tipo_liquidacion, List<Ctasctes_indycom> lst, Auditoria objA)
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
                            string string_detalle = "Se Reliquido los : ";
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "RECALCULO DEUDA IYC";
                            objA.detalle = "";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Ctasctes_indycom.Confirma_reliquidacion(legajo, tipo_liquidacion, lst, con, trx);
                            foreach (var item in lst)
                            {
                                string_detalle += string.Format("Periodo {0} : ", item.periodo);
                            }
                            objA.detalle = string_detalle;
                            AuditoriaD.InsertAuditoria(objA, con, trx);
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
        public List<Ctasctes_indycom> Reliquidar_periodos(int legajo, List<Ctasctes_indycom> lst)
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
                            List<Ctasctes_indycom> lstCtasctes = new();
                            lstCtasctes = Ctasctes_indycom.Reliquidar_periodos(legajo, lst, con, trx);
                            trx.Commit();
                            return lstCtasctes;
                        }
                        catch (Exception ex)
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
        public void Confirma_iniciar_ctacte(int legajo, List<Ctasctes_indycom> lst, Auditoria objA)
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
                            string string_detalle = " Periodos incluidos : ";
                            objA.identificacion = legajo.ToString();
                            objA.proceso = "INICIALIZACION CUENTA IYC";
                            objA.detalle = "";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            foreach (var item in lst)
                            {
                                string_detalle += string.Format("Periodo {0} : ", item.periodo);
                            }
                            objA.detalle += string_detalle;
                            Ctasctes_indycom.Confirma_iniciar_ctacte(legajo, lst, con, trx);
                            AuditoriaD.InsertAuditoria(objA, con, trx);
                            trx.Commit();
                        }
                        catch (Exception ex)
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
        public DETALLE_PAGO DetallePago(int nroCedulon, int nroTransaccion)
        {
            try
            {
                DETALLE_PAGO objDet = DETALLE_PAGO.read(nroCedulon, nroTransaccion);
                return objDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DETALLE_DEUDA> DetalleDeuda(int nroTransaccion)
        {
            try
            {
                return DETALLE_DEUDA.read(nroTransaccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GrillaIyC DetalleProcuracion(int nro_proc)
        {
            try
            {
                return GrillaIyC.DetalleProcuracion(nro_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PlanPago DetPlanPago(int nro_plan)
        {
            try
            {
                PlanPago objPlan = PlanPago.get(nro_plan);
                objPlan.procuraciones_incluidas = PlanPago.getProcuraciones(nro_plan, 3);

                return objPlan;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<LstDeudaIyC> getListDeudaIyC(int legajo)
        {
            try
            {
                return Entities.IYC.LstDeudaIyC.getListDeudaIndyCom(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<LstDeudaIyC> getListDeudaIyCProcurada(int legajo)
        {
            try
            {
                return Entities.IYC.LstDeudaIyC.getListDeudaIYCProcurada(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<LstDeudaIyC> getListDeudaIyCNoVencida(int legajo)
        {
            try
            {
                return LstDeudaIyC.getListDeudaIndyComNoVencida(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Deudas
        public List<Ctasctes_indycom> ListarDeudas(int legajo)
        {
            try
            {
                return Ctasctes_indycom.ListarDeudas(legajo);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<CateDeudaIyC> ListarCategoriaDeudas()
        {
            try
            {
                return Ctasctes_indycom.ListarCategoriaDeudas();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void NuevaDeuda(CtasCtes_Con_Auditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.auditoria.identificacion = obj.legajo.ToString();
                            obj.auditoria.proceso = "NUEVA DEUDA INDYCOM";
                            obj.auditoria.detalle = obj.legajo.ToString();
                            obj.auditoria.observaciones += string.Format(" Fecha nueva deuda: {0} ", DateTime.Now);


                            foreach (var aux in obj.lstCtastes)
                            {
                                var ultimoRegistro = Ctasctes_indycom.ObtenerUltimoNroTransaccion(con, trx);
                                Ctasctes_indycom.insertNvaDeuda(aux, con, trx, ultimoRegistro + 1);
                            }
                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
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

        public void modificarDeuda(CtasCtes_Con_Auditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.auditoria.identificacion = obj.legajo.ToString();
                            obj.auditoria.proceso = "MODIFICACION DEUDA INDYCOM";
                            obj.auditoria.detalle = obj.legajo.ToString();
                            obj.auditoria.observaciones += string.Format(" Fecha modificar deuda: {0} ", DateTime.Now);
                            foreach (var aux in obj.lstCtastes)
                            {
                                Ctasctes_indycom.updateDeuda(aux, con, trx);
                            }
                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
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
        public void eliminarDeuda(int legajo, int nro_transaccion, Auditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.identificacion = legajo.ToString();
                            obj.proceso = "ELIMINA DEUDA INDYCOM";
                            obj.detalle = legajo.ToString();
                            obj.observaciones += string.Format(" Fecha eliminar deuda: {0} ", DateTime.Now);
                            Ctasctes_indycom.deleteDeuda(legajo, nro_transaccion, con, trx);
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


        #endregion
    }
}
