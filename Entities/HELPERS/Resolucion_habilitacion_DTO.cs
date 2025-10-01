using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC.Entities
{
    public class Resolucion_habilitacion_DTO : DALBase
    {
        public int Legajo { get; set; }
        public int Nro_sucursal { get; set; } 
        public string Nro_res { get; set; }  
        public DateTime Fecha_inspeccion { get; set; } 
        public DateTime Fecha_hab { get; set; } 
        public Boolean Transporte { get; set; } 
        public string Usuario { get; set; } 

        public Resolucion_habilitacion_DTO()
        {
            Legajo = 0;
            Nro_sucursal = 0;
            Nro_res = String.Empty;
            Fecha_inspeccion = DateTime.MinValue;
            Fecha_hab = DateTime.Now;
            Transporte = false;
            Usuario = String.Empty;
        }


    }
}