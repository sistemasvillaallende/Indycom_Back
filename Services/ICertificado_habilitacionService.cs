
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC
{
    public interface ICertificado_habilitacionService
    {
        public List<Certificado_habilitacion> read();
        public Certificado_habilitacion GetByLegajo(int legajo);
        public List<Certificado_habilitacionDTO> GetPrincipalByLegajo(int legajo);
        public List<Certificado_habilitacionDTO> GetSucursalByLegajo(int legajo);
        public void Insert(Certificado_habilitacion_Con_Auditoria obj);
        public List<Certificado_habilitacionImp> GetCertificadoPrincipal(int legajo);
        public List<Certificado_habilitacionImp> GetCertificadoSucursal(int legajo);
        
    }
}
