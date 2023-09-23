using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC.Services
{
    public interface IIndycomServices
    {
        public int Insert(Entities.INDYCOM obj);
        public void Update(Entities.INDYCOM obj);
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
        public void UpdateDatosDomPostal(Entities.INDYCOM obj);
        public void SaveDatosAfip(Entities.INDYCOM obj);
        public void SaveDatosLiquidacion(Entities.INDYCOM obj);
        public Task<int> Count();
        public Task<List<Entities.INDYCOM>> GetIndycomPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta);
        public List<Buscador> GetConvenios(string nom_convenio);
        public List<Buscador> GetMinimos_indycom(string nom_convenio);
        public void BajaComercial(int legajo, string fecha_baja, Auditoria obj);
        public void BajaSucursal(int legajo, int nro_sucursal, string fecha_baja, Auditoria obj);

    }
}