namespace Web_Api_IyC.Entities.HELPERS
{
    public class RubrosIyC_Con_Auditoria
    {
        public Rubros_x_iyc rubro { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }

        public RubrosIyC_Con_Auditoria(){
            rubro = new Rubros_x_iyc();
        auditoria = new AUDITORIA.Auditoria();
        }
}
}