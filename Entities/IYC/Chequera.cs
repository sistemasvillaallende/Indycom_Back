using System.Data.SqlClient;
using System.Data;

namespace Web_Api_IyC.Entities.IYC
{
    public class Chequera : DALBase
    {
        public int NRO_PLAN { get; set; }
        public int NRO_CUOTA { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public decimal INTERES_ACUMULADO { get; set; }
        public decimal MONTO_ADEUDADO { get; set; }
        public string? VENCIMIENTO { get; set; }
        public string? FECHA_PAGO { get; set; }
        public decimal monto_pagado { get; set; }
        public string? vencimiento_original { get; set; }
        public decimal monto_a_acreditar { get; set; }
        public decimal monto_actualizado { get; set; }

        public static List<Chequera> read(int plan)
        {
            List<Chequera> lst = new List<Chequera>();
            Chequera obj;

            try
            {
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CHEQUERA_PLAN_PAGO where NRO_PLAN = @plan";
                    cmd.Parameters.AddWithValue("@plan", plan);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int NRO_PLAN = dr.GetOrdinal("NRO_CUOTA");
                        int NRO_CUOTA = dr.GetOrdinal("NRO_CUOTA");
                        int MONTO_ORIGINAL = dr.GetOrdinal("monto_original");
                        int INTERES_ACUMULADO = dr.GetOrdinal("INTERES_ACUMULADO");
                        int MONTO_ADEUDADO = dr.GetOrdinal("MONTO_ADEUDADO");
                        int VENCIMIENTO = dr.GetOrdinal("VENCIMIENTO");
                        int FECHA_PAGO = dr.GetOrdinal("FECHA_PAGO");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        int vencimiento_original = dr.GetOrdinal("vencimiento_original");
                        int monto_a_acreditar = dr.GetOrdinal("monto_a_acreditar");
                        int monto_actualizado = dr.GetOrdinal("monto_actualizado");

                        while (dr.Read())
                        {
                            obj = new Chequera();
                            if (!dr.IsDBNull(NRO_PLAN)) { obj.NRO_PLAN = dr.GetInt32(NRO_PLAN); }
                            if (!dr.IsDBNull(NRO_CUOTA)) { obj.NRO_CUOTA = dr.GetInt32(NRO_CUOTA); }
                            if (!dr.IsDBNull(MONTO_ORIGINAL)) { obj.MONTO_ORIGINAL = dr.GetDecimal(MONTO_ORIGINAL); }
                            if (!dr.IsDBNull(INTERES_ACUMULADO)) { obj.INTERES_ACUMULADO = dr.GetDecimal(INTERES_ACUMULADO); }
                            if (!dr.IsDBNull(MONTO_ADEUDADO)) { obj.MONTO_ADEUDADO = dr.GetDecimal(MONTO_ADEUDADO); }
                            if (!dr.IsDBNull(VENCIMIENTO)) { obj.VENCIMIENTO = dr.GetDateTime(VENCIMIENTO).ToShortDateString(); }
                            if (!dr.IsDBNull(FECHA_PAGO))
                                obj.FECHA_PAGO = dr.GetDateTime(FECHA_PAGO).ToShortDateString();
                            else
                                obj.FECHA_PAGO = null;
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            if (!dr.IsDBNull(vencimiento_original)) { obj.vencimiento_original = dr.GetDateTime(vencimiento_original).ToShortDateString(); }
                            if (!dr.IsDBNull(monto_a_acreditar)) { obj.monto_a_acreditar = dr.GetDecimal(monto_a_acreditar); }
                            if (!dr.IsDBNull(monto_actualizado)) { obj.monto_actualizado = dr.GetDecimal(monto_actualizado); }
                            lst.Add(obj);
                        }
                    }

                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
