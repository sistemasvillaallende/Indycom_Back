using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Web_Api_IyC.Entities
{
    public class Bases_imponibles
    {
        public int legajo { get; set; }
        public string? periodo { get; set; }
        public int nro_transaccion { get; set; }
        public int anio { get; set; }
        public DateTime? fecha_presentacion_ddjj { get; set; }
        public int cod_rubro { get; set; }
        public string? concepto { get; set; }
        public decimal monto_original { get; set; }
        public decimal debe { get; set; }
        public float cantidad { get; set; }
        public decimal importe { get; set; }
        public decimal alicuota_oim { get; set; }
        public decimal alicuota_sys { get; set; }
        public decimal minimo_oim { get; set; }
        public decimal minimo_sys { get; set; }
        public int incluido_en_oim { get; set; }

        public Bases_imponibles()
        {
            legajo = 0;
            periodo = string.Empty;
            nro_transaccion = 0;
            anio = 0;
            fecha_presentacion_ddjj = null;
            cod_rubro = 0;
            concepto = string.Empty;
            monto_original = 0;
            debe = 0;
            cantidad = 0;
            importe = 0;
            alicuota_oim = 0;
            alicuota_sys = 0;
            minimo_oim = 0;
            minimo_sys = 0;
            incluido_en_oim = 0;
        }

        private static List<Bases_imponibles> mapeo(SqlDataReader dr)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            List<Bases_imponibles> lst = new List<Bases_imponibles>();
            Bases_imponibles obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int periodo = dr.GetOrdinal("periodo");
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int anio = dr.GetOrdinal("anio");
                int fecha_presentacion_ddjj = dr.GetOrdinal("fecha_presentacion_ddjj");
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int concepto = dr.GetOrdinal("concepto");
                int monto_original = dr.GetOrdinal("monto_original");
                int debe = dr.GetOrdinal("debe");
                int cantidad = dr.GetOrdinal("cantidad");
                int importe = dr.GetOrdinal("importe");
                int alicuota_oim = dr.GetOrdinal("alicuota_oim");
                int alicuota_sys = dr.GetOrdinal("alicuota_sys");
                int minimo_oim = dr.GetOrdinal("minimo_oim");
                int minimo_sys = dr.GetOrdinal("minimo_sys");
                int incluido_en_oim = dr.GetOrdinal("cantidad");
                while (dr.Read())
                {
                    obj = new Bases_imponibles();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(fecha_presentacion_ddjj)) { obj.fecha_presentacion_ddjj = dr.GetDateTime(fecha_presentacion_ddjj); }
                    if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                    if (!dr.IsDBNull(concepto)) { obj.concepto = dr.GetString(concepto); }
                    if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                    if (!dr.IsDBNull(cantidad)) { obj.cantidad = dr.GetFloat(cantidad); }
                    if (!dr.IsDBNull(importe)) { obj.importe = dr.GetDecimal(importe); }
                    if (!dr.IsDBNull(alicuota_oim)) { obj.alicuota_oim = dr.GetDecimal(alicuota_oim); }
                    if (!dr.IsDBNull(alicuota_sys)) { obj.alicuota_sys = dr.GetDecimal(alicuota_sys); }
                    if (!dr.IsDBNull(minimo_oim)) { obj.minimo_oim = dr.GetDecimal(minimo_oim); }
                    if (!dr.IsDBNull(minimo_sys)) { obj.minimo_sys = dr.GetDecimal(minimo_sys); }
                    //if (!dr.IsDBNull(incluido_en_oim)) { obj.incluido_en_oim = dr.GetInt16(incluido_en_oim); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Bases_imponibles> GetBasesImponibles(int legajo, string periodo_desde, string periodo_hasta)
        {
            try
            {
                List<Bases_imponibles> lstBases = new List<Bases_imponibles>();
                Bases_imponibles obj = new Bases_imponibles();
                string sql = @"SELECT
                                    dji.legajo, dji.periodo,
                                    rxdji.nro_transaccion,
                                    r.anio,
                                    dji.fecha_presentacion_ddjj,
                                    presentacion=
                                        CASE
                                        WHEN dji.presentacion_web=0 THEN 'Mostrador'
                                        WHEN dji.presentacion_web=1 THEN 'Web'
                                        END,
                                    rxdji.cod_rubro,
                                    r.concepto,
                                    ci.monto_original,
                                    ci.debe,
                                    rxdji.cantidad, rxdji.importe,
                                    r. alicuota_oim,
                                    r.alicuota_sys,
                                    r.minimo_oim,
                                    r.minimo_sys,
                                    r.incluido_en_oim
                                FROM RUBROS_X_DEC_JUR_IYC rxdji
                                JOIN RUBROS r ON
                                    r.cod_rubro=rxdji.cod_rubro
                                    join DEC_JUR_IYC dji ON
                                    dji.nro_transaccion=rxdji.nro_transaccion AND
                                    SUBSTRING(dji.periodo,1,4)=r.anio
                                    JOIN CTASCTES_INDYCOM ci ON
                                    ci.legajo=dji.legajo AND
                                    ci.nro_transaccion=dji.nro_transaccion AND
                                    ci.tipo_transaccion=1
                                WHERE dji.completa=1 and
                                    dji.legajo=@legajo and
                                    dji.periodo BETWEEN @desde AND @hasta
                                ORDER BY dji.periodo,  rxdji.cod_rubro";

                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@desde", periodo_desde);
                    cmd.Parameters.AddWithValue("@hasta", periodo_hasta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lstBases = mapeo(dr);
                    return lstBases;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
