using System.Data.SqlClient;
using System.Data;
using Web_Api_IyC.Entities;

namespace Web_Api_IyC.Entities.IYC
{
    public class DetallePlanPago : DALBase
    {
        public string periodo { get; set; }
        public decimal deuda { get; set; }
        public string des_categoria { get; set; }

        public DetallePlanPago()
        { }
        public static List<DetallePlanPago> read(int nroPlan)
        {
            List<DetallePlanPago> lst = new List<DetallePlanPago>();
            DetallePlanPago obj;
            try
            {
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_proc_get_detalle_plan";
                    cmd.Parameters.AddWithValue("@nro_plan", nroPlan);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int periodo = dr.GetOrdinal("periodo");
                        int deuda = dr.GetOrdinal("deuda");
                        int des_categoria = dr.GetOrdinal("des_categoria");

                        while (dr.Read())
                        {
                            obj = new DetallePlanPago();
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(deuda)) { obj.deuda = dr.GetDecimal(deuda); }
                            if (!dr.IsDBNull(des_categoria)) { obj.des_categoria = dr.GetString(des_categoria); }
                            lst.Add(obj);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lst;
        }

        public static List<DetallePlanPago> readIyC(int nroPlan)
        {
            List<DetallePlanPago> lst = new List<DetallePlanPago>();
            DetallePlanPago obj;
            try
            {
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_proc_get_detalle_plan_iyc";
                    cmd.Parameters.AddWithValue("@nro_plan", nroPlan);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int periodo = dr.GetOrdinal("periodo");
                        int deuda = dr.GetOrdinal("deuda");
                        int des_categoria = dr.GetOrdinal("des_categoria");
                        while (dr.Read())
                        {
                            obj = new DetallePlanPago();
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(deuda)) { obj.deuda = dr.GetDecimal(deuda); }
                            if (!dr.IsDBNull(des_categoria)) { obj.des_categoria = dr.GetString(des_categoria); }
                            lst.Add(obj);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lst;
        }
    }
}
