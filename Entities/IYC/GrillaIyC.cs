using System.Data.SqlClient;
using System.Data;

namespace Web_Api_IyC.Entities.IYC
{
    public class GrillaIyC : DALBase
    {
        public int legajo { get; set; }
        public int nro_procuracion { get; set; }
        public string descripcion_estado { get; set; }
        public string nombre_procurador { get; set; }
        public decimal saldo { get; set; }
        public string fecha_comienzo_procuracion { get; set; }
        public string fecha_comienzo_estado { get; set; }
        public string fecha_fin_estado { get; set; }

        public GrillaIyC()
        {
            legajo = 0;
            nro_procuracion = 0;
            descripcion_estado = string.Empty;
            nombre_procurador = string.Empty;
            saldo = 0;
            fecha_comienzo_procuracion = string.Empty;
            fecha_comienzo_estado = string.Empty;
            fecha_fin_estado = string.Empty;
        }

        public static GrillaIyC DetalleProcuracion(int nro_proc)
        {
            try
            {
                GrillaIyC? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_proc_readIyC_x_nro";
                    cmd.Parameters.AddWithValue("@nro_procuracion", nro_proc);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int legajo = dr.GetOrdinal("legajo");
                        int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                        int descripcion_estado = dr.GetOrdinal("descripcion_estado");
                        int nombre_procurador = dr.GetOrdinal("nombre_procurador");
                        int saldo = dr.GetOrdinal("saldo");
                        int fecha_comienzo_procuracion = dr.GetOrdinal("fecha_comienzo_procuracion");
                        int fecha_comienzo_estado = dr.GetOrdinal("fecha_comienzo_estado");
                        int fecha_fin_estado = dr.GetOrdinal("fecha_fin_estado");

                        while (dr.Read())
                        {
                            obj = new GrillaIyC();
                            if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                            if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                            if (!dr.IsDBNull(descripcion_estado)) { obj.descripcion_estado = dr.GetString(descripcion_estado); }
                            if (!dr.IsDBNull(nombre_procurador)) { obj.nombre_procurador = dr.GetString(nombre_procurador); }
                            if (!dr.IsDBNull(saldo)) { obj.saldo = dr.GetDecimal(saldo); }
                            if (!dr.IsDBNull(fecha_comienzo_procuracion)) { obj.fecha_comienzo_procuracion = dr.GetDateTime(fecha_comienzo_procuracion).ToShortDateString(); }
                            if (!dr.IsDBNull(fecha_comienzo_estado)) { obj.fecha_comienzo_estado = dr.GetDateTime(fecha_comienzo_estado).ToShortDateString(); }
                            if (!dr.IsDBNull(fecha_fin_estado)) { obj.fecha_fin_estado = dr.GetDateTime(fecha_fin_estado).ToShortDateString(); }
                        }

                    }
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
