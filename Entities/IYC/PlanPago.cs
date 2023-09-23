using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_IyC.Entities.IYC
{
    public class PlanPago : DALBase
    {
        public int nro_plan { get; set; }
        public decimal monto_original { get; set; }
        public decimal descuento { get; set; }
        public decimal saldo_financiado { get; set; }
        public decimal anticipo { get; set; }
        public decimal interes { get; set; }
        public decimal valor_cuota { get; set; }
        public string fecha_plan { get; set; }
        public int cantidad_cuotas { get; set; }
        public string fecha_pri_cuota { get; set; }
        public decimal imp_total { get; set; }
        public decimal imp_pagado { get; set; }
        public decimal imp_adeudado { get; set; }
        public decimal imp_vencido { get; set; }
        public decimal cuotas_pagadas { get; set; }
        public int cuotas_vencidas { get; set; }
        public string fecha_ultimo_pago { get; set; }
        public string procuraciones_incluidas { get; set; }
        public DetallePlanPago[] lstDetallePlan  { get; set; }
        public Chequera[] lstChequera { get; set; } 

        public PlanPago() { }

        public static PlanPago get(int nroPlan)
        {
            PlanPago? obj = null;
            try
            {
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_proc_get_plan_pago";
                    cmd.Parameters.AddWithValue("@nro_plan", nroPlan);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int NRO_PLAN = dr.GetOrdinal("NRO_PLAN");
                        int FECHA_PLAN = dr.GetOrdinal("fecha_plan");
                        //int fecha_pri_cuota = dr.GetOrdinal("fecha_pri_cuota");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int descuento = dr.GetOrdinal("descuento");
                        int saldo_financiado = dr.GetOrdinal("saldo_financiado");
                        int anticipo = dr.GetOrdinal("anticipo");
                        int cantidad_cuotas = dr.GetOrdinal("cantidad_cuotas");
                        int interes = dr.GetOrdinal("interes");
                        int valor_cuota = dr.GetOrdinal("valor_cuota");
                        int imp_pagado = dr.GetOrdinal("imp_pagado");
                        int imp_adeudado = dr.GetOrdinal("imp_adeudado");
                        int imp_vencido = dr.GetOrdinal("imp_vencido");
                        int cuotas_pagadas = dr.GetOrdinal("cuotas_pagadas");
                        int cuotas_vencidas = dr.GetOrdinal("cuotas_vencidas");
                        int fecha_ultimo_pago = dr.GetOrdinal("fecha_ultimo_pago");

                        while (dr.Read())
                        {
                            obj = new PlanPago();
                            if (!dr.IsDBNull(NRO_PLAN)) { obj.nro_plan = dr.GetInt32(NRO_PLAN); }
                            if (!dr.IsDBNull(FECHA_PLAN))
                            {
                                obj.fecha_plan = dr.GetDateTime(FECHA_PLAN).ToShortDateString();
                            }
                            if (!dr.IsDBNull(monto_original))
                            {
                                obj.monto_original = dr.GetDecimal(monto_original);
                            }
                            if (!dr.IsDBNull(descuento))
                            {
                                obj.descuento = dr.GetDecimal(descuento);
                            }
                            if (!dr.IsDBNull(saldo_financiado))
                            {
                                obj.saldo_financiado = dr.GetDecimal(saldo_financiado);
                            }
                            if (!dr.IsDBNull(anticipo))
                            {
                                obj.anticipo = dr.GetDecimal(anticipo);
                            }
                            if (!dr.IsDBNull(cantidad_cuotas))
                            {
                                obj.cantidad_cuotas = dr.GetInt16(cantidad_cuotas);
                            }
                            if (!dr.IsDBNull(interes))
                            {
                                obj.interes = dr.GetDecimal(interes);
                            }
                            if (!dr.IsDBNull(valor_cuota))
                            {
                                obj.valor_cuota = dr.GetDecimal(valor_cuota);
                            }
                            if (!dr.IsDBNull(imp_pagado))
                            {
                                obj.imp_pagado = dr.GetDecimal(imp_pagado);
                            }
                            if (!dr.IsDBNull(imp_adeudado))
                            {
                                obj.imp_adeudado = dr.GetDecimal(imp_adeudado);
                            }
                            if (!dr.IsDBNull(imp_vencido))
                            {
                                obj.imp_vencido = dr.GetDecimal(imp_vencido);
                            }
                            if (!dr.IsDBNull(cuotas_pagadas))
                            {
                                obj.cuotas_pagadas = dr.GetInt32(cuotas_pagadas);
                            }
                            if (!dr.IsDBNull(cuotas_vencidas))
                            {
                                obj.cuotas_vencidas = dr.GetInt32(cuotas_vencidas);
                            }
                            if (!dr.IsDBNull(fecha_ultimo_pago))
                            {
                                obj.fecha_ultimo_pago = dr.GetString(fecha_ultimo_pago);
                            }
                        }
                    }
                }
                obj.lstDetallePlan = DetallePlanPago.read(nroPlan).ToArray();
                obj.lstChequera = Chequera.read(nroPlan).ToArray(); 
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int exists(int nroProc, int subSistema)
        {
            StringBuilder sql = new StringBuilder();
            switch (subSistema)
            {
                case 1:
                    sql.AppendLine("SELECT nro_plan FROM CTASCTES_INMUEBLES");
                    break;
                case 3:
                    sql.AppendLine("SELECT nro_plan FROM CTASCTES_INDYCOM");
                    break;
                case 4:
                    sql.AppendLine("SELECT nro_plan FROM CTASCTES_AUTOMOTORES");
                    break;
                default:
                    break;
            }
            sql.AppendLine("WHERE nro_procuracion = @nro_proc");
            sql.AppendLine("GROUP BY nro_plan");
            try
            {
                int ret = 0;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_proc", nroProc);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0)) { ret = dr.GetInt32(0); }
                        }
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string getProcuraciones(int nroPlan, int subSistema)
        {
            StringBuilder sql = new StringBuilder();
            switch (subSistema)
            {
                case 1:
                    sql.AppendLine("SELECT nro_procuracion FROM CTASCTES_INMUEBLES");
                    break;
                case 3:
                    sql.AppendLine("SELECT nro_procuracion FROM CTASCTES_INDYCOM");
                    break;
                case 4:
                    sql.AppendLine("SELECT nro_procuracion FROM CTASCTES_AUTOMOTORES");
                    break;
                default:
                    break;
            }

            sql.AppendLine("WHERE nro_plan = @nro_plan");
            sql.AppendLine("GROUP BY nro_procuracion");
            string ret = string.Empty;
            try
            {
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_plan", nroPlan);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                                ret += dr.GetInt32(0) + ", ";
                        }
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }
   
        public static int MaxPlan()
        {
            try
            {
                int ret = 0;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT MAX(NRO_PLAN) FROM PLANES_PAGO";

                    cmd.Connection.Open();

                    ret = (int)cmd.ExecuteScalar();
                }
                return ret + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
 
        public static void insertDeudasPlanPago(int nroPlan, int nroTran)
        {
            try
            {
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO DEUDAS_X_PLAN_PAGO (NRO_PLAN, NRO_TRANSACCION) VALUES (@nroPlan, @nroTran)";
                    cmd.Parameters.AddWithValue("@nroPlan", nroPlan);
                    cmd.Parameters.AddWithValue("@nroTran", nroTran);
                    cmd.Connection.Open();

                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void updateCtasCtes(int nroPlan, List<int> lst)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in lst)
                    str.AppendFormat("{0},", item);

                string det = str.ToString().Substring(0, str.ToString().Length - 1);

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTASCTES_INDYCOM");
                sql.AppendLine("SET nro_plan = @nroPlan");
                sql.AppendFormat("WHERE nro_transaccion IN ({0})", det);
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nroPlan", nroPlan);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void updateCtasCtesIyC(int nroPlan, List<int> lst)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in lst)
                    str.AppendFormat("{0},", item);
                string det = str.ToString().Substring(0, str.ToString().Length - 1);
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTASCTES_INDYCOM");
                sql.AppendLine("SET nro_plan = @nroPlan");
                sql.AppendFormat("WHERE nro_transaccion IN ({0})", det);
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nroPlan", nroPlan);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    

    }
}
