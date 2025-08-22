using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Web_Api_IyC.Entities.HELPERS
{

    public class Certificado_habilitacionDTO : DALBase
    {
    public string Certificado { get; set; }
    public int AnioCertificado { get; set; }
    public int Legajo { get; set; }
    public int NroSucursal { get; set; }
    public int CodRubro { get; set; }
    public string DesCom { get; set; }   // este es nuevo
    public string Emision { get; set; }
    public string VtoCertificado { get; set; }
    public string Url { get; set; }
    public string Qr { get; set; }

        public Certificado_habilitacionDTO()
        {
            Certificado = String.Empty;
            AnioCertificado = 0;
            Legajo = 0;
            NroSucursal = 0;
            CodRubro = 0;
            DesCom = String.Empty;
            Emision = String.Empty;
            VtoCertificado =  String.Empty;
            Url = String.Empty;
            Qr = String.Empty;
        }


    }
}
