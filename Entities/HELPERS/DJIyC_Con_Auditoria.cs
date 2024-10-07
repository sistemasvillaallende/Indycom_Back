namespace Web_Api_IyC.Entities.HELPERS
{
    public class DJIyC_Con_Auditoria
    {
        public int legajo { get; set; }
        public Dec_jur_iyc objDDJJ { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }

        public DJIyC_Con_Auditoria()
        {
            legajo = 0;
            objDDJJ = new Dec_jur_iyc();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
