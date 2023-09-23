namespace Web_Api_IyC.Entities.HELPERS
{
    public class VCtasctes
    {
        public int nro_cedulon { get; set; }
        public int tipo_transaccion { get; set; }
        public int nro_transaccion { get; set; }
        public string? periodo { get; set; }
        public decimal importe { get; set; }
        public string? fecha_vencimiento { get; set; }
        public int categoria_deuda { get; set; }
        public decimal deudaOriginal { get; set; }
        public decimal intereses { get; set; }
        public int nro_cedulon_paypertic { get; set; }
        public bool pago_parcial { get; set; }
        public decimal pago_a_cuenta { get; set; }
        public VCtasctes()
        {
            Clear();
        }
        public void Clear()
        {
            nro_cedulon = 0;
            tipo_transaccion = 1;
            nro_transaccion = -1;
            periodo = "";
            importe = 0;
            fecha_vencimiento = "";
            categoria_deuda = 0;
            deudaOriginal = 0;
            intereses = 0;
            nro_cedulon_paypertic = 0;
            pago_parcial = false;
            pago_a_cuenta = 0;
        }


    }
}
