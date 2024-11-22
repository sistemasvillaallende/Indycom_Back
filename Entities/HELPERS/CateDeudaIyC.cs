namespace Web_Api_IyC.Entities.HELPERS
{
    public class CateDeudaIyC
    {
        public int cod_categoria { get; set; }
        public string des_categoria { get; set; }
        public int id_subrubro { get; set; }
        public int tipo_deuda { get; set; }
        public CateDeudaIyC()
        {
            cod_categoria = 0;
            des_categoria = string.Empty;
            id_subrubro = 0;
            tipo_deuda = 0;

        }


    }
}
