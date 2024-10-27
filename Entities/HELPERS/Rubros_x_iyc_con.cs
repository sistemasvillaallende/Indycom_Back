namespace Web_Api_IyC.Entities.HELPERS
{
    public class Rubros_x_iyc_con
    {
        public int legajo { get; set; }
        public int cod_rubro { get; set; }
        public int Nro_sucursal { get; set; }
        public int cod_minimo { get; set; }
        public int cod_convenio { get; set; }
        public Single cantidad { get; set; }
        public bool exento { get; set; }
        public bool descuento { get; set; }
        public decimal valor { get; set; }
        public string concepto { get; set; }
        public Rubros_x_iyc_con()
        {
            legajo = 0;
            cod_rubro = 0;
            Nro_sucursal = 0;
            cod_minimo = 0;
            cod_convenio = 0;
            cantidad = 0;
            exento = false;
            descuento = false;
            valor = 0;
            concepto = String.Empty;
        }
    }
}