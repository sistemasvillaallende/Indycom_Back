using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Web_Api_IyC.Entities.HELPERS
{

    public class Certificado_habilitacionImp : DALBase
    {
        public int Legajo { get; set; }
        public string Certificado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nom_fantasia { get; set; }
        public string Nro_cuit { get; set; }
        public string Nombre_calle { get; set; }
        public int Nro_domicilio { get; set; }
        public int Anio_certificado { get; set; }
        public int Nro_sucursal { get; set; }
        public int Cod_rubro  { get; set; }
        public string Des_comercio { get; set; }
        public string Emision { get; set; }
        public string VtoCertificado { get; set; }
        public string Url { get; set; }
        public string Qr { get; set; }

        public Certificado_habilitacionImp()
        {
            Legajo = 0;
            Certificado = String.Empty;
            Nombre = String.Empty;
            Apellido = String.Empty;
            Nom_fantasia = String.Empty;
            Nro_cuit = String.Empty;
            Nombre_calle = String.Empty;
            Nro_domicilio = 0;
            Anio_certificado = 0;
            Nro_sucursal = 0;
            Cod_rubro = 0;
            Des_comercio = String.Empty;
            Emision = String.Empty;
            VtoCertificado = String.Empty;
            Url = String.Empty;
            Qr = String.Empty;
        }

    }
}
