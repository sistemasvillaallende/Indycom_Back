namespace Web_Api_IyC.Entities.HELPERS
{
    public class CtasCtes_Con_Auditoria
    {
        public int legajo { get; set; }
        public List<Ctasctes_indycom> lstCtastes { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }
        public CtasCtes_Con_Auditoria()
        {
            legajo = 0;
            lstCtastes = new List<Ctasctes_indycom>();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
