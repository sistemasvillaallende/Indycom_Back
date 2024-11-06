namespace Web_Api_IyC.Entities.HELPERS
{
    public class Sucursal_Con_Auditoria
    {
        public Sucursales_indycom sucursal { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }

        public Sucursal_Con_Auditoria()
        {
            sucursal = new Sucursales_indycom();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}