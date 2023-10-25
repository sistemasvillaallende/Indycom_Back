using System.Data.SqlClient;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.IYC;

namespace Web_Api_IyC.Services
{
    public interface ICtasctes_indycomServices
    {
        public List<Entities.Periodos> IniciarCtacte(int legajo);
        public List<Entities.Ctasctes_indycom> ListarCtacte(int legajo, int tipo_consulta,
         int cate_deuda_desde, int cate_deuda_hasta);
        //public List<Ctasctes_indycom> PeriodosRecalculo(int legajo);
        public string Datos_transaccion(int tipo_transaccion, int nro_transaccion);
        public List<Ctasctes_indycom> Listar_periodos_a_cancelar(int legajo);
        public List<Ctasctes_indycom> Listar_Periodos_cancelados(int legajo);
        public void Confirma_elimina_cancelacion(int legajo, List<Ctasctes_indycom> lst, Auditoria objA);
        public void Confirma_cancelacion_ctasctes(int tipo_transaccion, int legajo, List<Ctasctes_indycom> lst, Auditoria objA);
        public List<Ctasctes_indycom> Listar_periodos_a_reliquidar(int legajo);
        public void Confirma_reliquidacion(int legajo, int tipo_liquidacion, List<Ctasctes_indycom> lst, Auditoria objA);
        public List<Ctasctes_indycom> Reliquidar_periodos(int legajo, List<Ctasctes_indycom> lst);
        public void Confirma_iniciar_ctacte(int legajo, List<Ctasctes_indycom> lst, Auditoria objA);
        public DETALLE_PAGO DetallePago(int nroCedulon, int nroTransaccion);
        public List<DETALLE_DEUDA> DetalleDeuda(int nroTransaccion);
        public GrillaIyC DetalleProcuracion(int nro_proc);
        public PlanPago DetPlanPago(int nro_plan);

        public List<LstDeudaIyC> getListDeudaIyC(int legajo);
        public List<LstDeudaIyC> getListDeudaIyCProcurada(int legajo);
        public List<LstDeudaIyC> getListDeudaIyCNoVencida(int legajo);
    }
}
