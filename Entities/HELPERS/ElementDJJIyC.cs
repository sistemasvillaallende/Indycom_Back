namespace Web_Api_IyC.Entities.HELPERS
{
    public class ElementDJJIyC
    {
        public string periodo { get; set; }
        public decimal monto_original { get; set; }
        public String vencimiento { get; set; }
        public string categoria { get; set; }

        public ElementDJJIyC()
        {
            periodo = string.Empty;
            monto_original = 0;
            vencimiento =  string.Empty;
            categoria = String.Empty;
        }
    }
}