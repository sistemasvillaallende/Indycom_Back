namespace Web_Api_IyC.Entities.HELPERS
{
    public class ImpresionDDJJ
    {

        public DateTime vencimiento { get; set; }
        public int nro_transaccion { get; set; }
        public string periodo { get; set; }
        public int legajo { get; set; }
        public string cuit { get; set; }
        public string nom_calle { get; set; }
        public string nom_barrio { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public List<Rubro> rubros { get; set; }

        public ImpresionDDJJ()
        {
            legajo = 0;
            nro_transaccion = 0;
            periodo = string.Empty;
            vencimiento = DateTime.MinValue;
            cuit = string.Empty;
            nom_calle = string.Empty;
            nom_barrio = string.Empty;
            ciudad = string.Empty;
            provincia = string.Empty;
            rubros = new List<Rubro>();
        }
    }

    public class Rubro
    {
        public int cod_rubro { get; set; }
        public decimal importe { get; set; }
        public string? concepto { get; set; }
    }

}
