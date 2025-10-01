using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC.Entities
{
    public class Resolucion_habilitacion_imprimir : DALBase
    {
        public int Legajo { get; set; }
        public DateTime Fecha_alta { get; set; }  // INDYCOM
        public string Nro_exp_mesa_ent { get; set; }  // INDYCOM
        public string Nro_cuit { get; set; }  //INDYCOM
        public string Nombre { get; set; }  //VECINO DIGITAL x CUIT
        public string Apellido { get; set; }  // VECINO DIGITAL x CUIT
        public string Des_com { get; set; }  //INDYCOM
        public string Nom_calle_dom_esp { get; set; }  //INDYCOM
        public string Nom_barrio_dom_esp { get; set; }  //INDYCOM
        public int nro_dom_esp { get; set; }  //INDYCOM
        public DateTime Fecha_inspeccion { get; set; } // RESOLUCION_HABILITACION
        public DateTime Fecha_hab { get; set; }   // RESOLUCION_HABILITACION
        public int Nro_sucursal { get; set; }  // RESOLUCION_HABILITACION
        public string Nro_res { get; set; }   // RESOLUCION_HABILITACION
        public Boolean Transporte { get; set; }  // RESOLUCION_HABILITACION
        public string? Marca { get; set; } // transportes
        public string? Modelo { get; set; }  // transportes
        public int? Anio { get; set; }  // transportes
        public string? Dominio { get; set; }  // transportes


        // public Resolucion_habilitacion_imprimir()
        // {
        //     Legajo = 0;
        //     Fecha_alta = DateTime.Now;
        //     Nro_exp_mesa_ent = String.Empty;
        //     Nro_cuit = String.Empty;
        //     Nombre = String.Empty;
        //     Apellido = String.Empty;
        //     Des_com = String.Empty;
        //     Nom_calle_dom_esp = String.Empty;
        //     Nom_barrio_dom_esp = String.Empty;
        //     nro_dom_esp = 0;
        //     Fecha_inspeccion = DateTime.MinValue;
        //     Fecha_hab = DateTime.Now;
        //     Nro_sucursal = 0;
        //     Nro_res = String.Empty;
        //     Transporte = false;
        //     Marca = String.Empty;
        //     Modelo = String.Empty;
        //     Anio = 0;
        //     Dominio = String.Empty;

        // }

        public bool ShouldSerializeMarca() => Transporte;
        public bool ShouldSerializeModelo() => Transporte;
        public bool ShouldSerializeAnio() => Transporte;
        public bool ShouldSerializeDominio() => Transporte;

    }
}