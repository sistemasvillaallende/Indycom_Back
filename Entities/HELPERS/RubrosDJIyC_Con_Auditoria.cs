namespace Web_Api_IyC.Entities.HELPERS
{
    public class RubrosDJIyC_Con_Auditoria
    {
        public int legajo { get; set; }
        public List<Rubros_x_dec_jur_iyc> lst { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }

        public RubrosDJIyC_Con_Auditoria()
        {
            legajo = 0;
            lst = new List<Rubros_x_dec_jur_iyc>();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
