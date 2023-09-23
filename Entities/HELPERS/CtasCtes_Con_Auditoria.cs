namespace Web_Api_IyC.Entities.HELPERS
{
    public class CtasCtes_Con_Auditoria
    {
        public string dominio { get; set; }
        public List<Ctasctes_indycom> lstCtasTes { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }  

        public CtasCtes_Con_Auditoria() { 
            dominio = string.Empty;
            lstCtasTes = new List<Ctasctes_indycom>();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
