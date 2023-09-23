namespace Web_Api_IyC.Entities.HELPERS
{
    public class Tipo_pago
    {
        public int nro_movimiento { get; set; }
        public string tipo_pago { get; set; }
        public string forma_pago { get; set; }
        public string efectivo { get; set; }
        public string debito { get; set; }
        public string credito { get; set; }
        public string cheque { get; set; }
        public string documentos { get; set; }
        public string canje { get; set; }
        public string bonos { get; set; }
        public string bancos { get; set; }


        public Tipo_pago()
        {
            nro_movimiento = 0;
            tipo_pago = string.Empty;
            forma_pago = string.Empty;
            efectivo = string.Empty;
            debito = string.Empty;
            credito = string.Empty;
            cheque = string.Empty;
            documentos = string.Empty;
            canje = string.Empty;
            bonos = string.Empty;
            bancos = string.Empty;
        }



    }
}
