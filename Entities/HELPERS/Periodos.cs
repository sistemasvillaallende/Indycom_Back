namespace Web_Api_IyC.Entities
{
    public class Periodos : DALBase
    {
        public string periodo { get; set; }
        public int nro_transaccion { get; set; }
        public decimal monto_original { get; set; }
        public decimal debe { get; set; }
        public string vencimiento { get; set; }
        public int tipo_transaccion { get; set; }
        public Periodos()
        {
            periodo = string.Empty;
            nro_transaccion = 0;
            monto_original = 0;
            debe = 0;
            vencimiento = string.Empty;
            tipo_transaccion=0;
        }

    }
}
