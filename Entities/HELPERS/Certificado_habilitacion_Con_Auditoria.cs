
namespace Web_Api_IyC.Entities.HELPERS
{
    public class Certificado_habilitacion_Con_Auditoria

    {

        public int legajo { get; set; }
        public string rubro { get; set; }
        public int cod_rubro { get; set; }
        public int nro_sucursal { get; set; }
        public string titular { get; set; }
        public string domicilio  { get; set; }
        public DateTime vecimiento  { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }

        public Certificado_habilitacion_Con_Auditoria()
        {
            rubro = String.Empty;
            titular = String.Empty;
            domicilio = String.Empty;
            vecimiento = DateTime.Now;
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}