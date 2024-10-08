using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Entities.IYC;

namespace Web_Api_IyC.Services
{
    public interface IIndycomServices
    {
        //public int Insert(Entities.INDYCOM obj);
        public void Update(Entities.INDYCOM obj, INDYCOM objOriginal);
        public void Delete(int nro_bad);
        public List<Entities.INDYCOM> Read();
        public Entities.INDYCOM GetByPk(int nro_bad);
        public List<Entities.TIPOS_LIQ_IYC> Tipos_liq_iyc();
        public List<Entities.TIPOS_PER_IYC> Tipos_per_iyc();
        public List<Entities.TIPOS_DE_IVA> Tipos_iva();
        public List<Combo> Tipos_entidad();
        public List<Combo> Zonasiyc();
        public List<Combo> Situacion_judicial();
        public void InsertDatosGeneral(Entities.INDYCOM obj);
        public void UpdateDatosGenerales(INDYCOM obj, INDYCOM objOriginal);
        public void UpdateDatosDomPostal(Entities.INDYCOM obj, INDYCOM objOriginal);
        public void SaveDatosAfip(Entities.INDYCOM obj, INDYCOM objOriginal);
        public void SaveDatosLiquidacion(Entities.INDYCOM obj, INDYCOM objOriginal);
        public int Count();
        public List<Entities.INDYCOM> GetIndycomPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta);
        public List<Buscador> GetConvenios(string nom_convenio);
        public List<Buscador> GetMinimos_indycom(string nom_convenio);
        public void BajaComercial(int legajo, string fecha_baja, INDYCOM objOriginal, Auditoria obj);
        public void BajaSucursal(int legajo, int nro_sucursal, string fecha_baja, INDYCOM objOriginal, Auditoria obj);
        public List<Bases_imponibles> GetBasesImponibles(int legajo, string periodo_desde, string periodo_hasta);
        public List<Rubros_x_iyc> GetRubros_x_iyc(int legajo);
        public Sucursales_indycom GetSucuralByLegajo(int legajo, int nro_sucursal);
        public List<RUBROS> BuscarRubroxDescripcion(string descripcion);
        public List<Informes> InformeCtaCteSoloDeuda(int legajo, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA);
        public List<Informes> InformeCtaCteCompleto(int legajo, string per, Auditoria objA);
        public List<Combo> ListarCategoriasIyc();
        public List<Informes> Resumendeuda(int legajo, int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA);
        public List<Combo> GetCalle(string nomcalle);
        public List<Indycomxcalle> ConsultaIyc_x_calles(string calledesde, string callehasta);
        public List<BADEC> GetBadecByNombre(string nombre);
        public List<BADEC> GetBadecByCuit(string cuit);
        /* METODOS para la DECJUR*/
        public List<Dec_jur_iyc> GetPeriodosDJSinLiquidar(int legajo);
        public List<Rubros_x_dec_jur_iyc> GetRubrosDJIyC(int nro_transaccion, int legajo);
        public void UpdateRubrosDJIyC(int legajo, List<Rubros_x_dec_jur_iyc> lst, Auditoria objA);
        public void Liquidar_decjur(int legajo, Dec_jur_iyc obj, Auditoria objA);
        public bool VerificarMontosIngresados(int nro_transaccion, int legajo);
        public Dec_jur_iyc GetDecJur_completadas(int legajo, string periodo);
        public bool VerificaDecJurPagada(int nro_transaccion);
        public void EliminaDJIyC(Dec_jur_iyc objDDJJ, Auditoria objA);
        public Dec_jur_iyc GetPeriodoDJLiquidado (int legajo, string periodo);
        public List<Rubros_x_dec_jur_iyc> ListaRubrosDJIyC(int nro_transaccion);

        /*FIN DDJJ*/
    }
}