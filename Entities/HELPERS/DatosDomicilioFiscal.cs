namespace Web_Api_IyC.Entities.HELPERS
{
    public class DatosDomicilioFiscal
    {
        public string nom_calle_dom_esp { get; set; }
        public int nro_dom_esp { get; set; }
        public string piso_dpto_esp { get; set; }
        public string local_esp { get; set; }
        public string cod_postal { get; set; }
        public string nom_barrio { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string email_envio_cedulon { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public AUDITORIA.Auditoria objAuditoria { get; set; }

        public DatosDomicilioFiscal()
        {
            nom_calle_dom_esp = string.Empty;
            nro_dom_esp = 0;
            piso_dpto_esp = string.Empty;
            local_esp = string.Empty;
            cod_postal = string.Empty;
            nom_barrio = string.Empty;
            ciudad = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
            email_envio_cedulon = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            objAuditoria = new();
        }

    }
}