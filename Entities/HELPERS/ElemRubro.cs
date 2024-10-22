namespace Web_Api_IyC.Entities.HELPERS
{
    public class ElemRubro
    {
        public string concepto { get; set; }
        public int codigo { get; set; }
        public int anio { get; set; }
        public ElemRubro()
        {
            concepto = string.Empty;
            codigo = 0;
            anio = 0;
        }


    }
}