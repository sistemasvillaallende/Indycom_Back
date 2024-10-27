namespace Web_Api_IyC.Entities.HELPERS
{
    public class RubroInfo
    {
        public string periodo { get; set; }
        public string concepto { get; set; }
        public int nro_transaccion { get; set; }
        public Rubros_x_dec_jur_iyc rdji { get; set; }
        public RubroInfo()
        {
            periodo = string.Empty;
            concepto = string.Empty;
            nro_transaccion = 0;
            rdji = new Rubros_x_dec_jur_iyc();
        }


    }
}