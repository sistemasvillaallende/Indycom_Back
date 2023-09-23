using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_IyC.Entities
{
    public class DETALLE_DEUDA : DALBase
    {
        public string concepto { get; set; }
        public decimal importe { get; set; }
        public DETALLE_DEUDA()
        {
            concepto = string.Empty;
            importe = 0;
        }

        public static List<DETALLE_DEUDA> read(int nroTransaccion)
        {
            try
            {
                DETALLE_DEUDA? obj = null;
                List<DETALLE_DEUDA> lst = new List<DETALLE_DEUDA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = @"SELECT 
                                        B.des_concepto_iyc,
                                        A.importe_actual
                                        FROM DETALLE_DEUDA_IYC A
                                        INNER JOIN CONCEPTOS_IYC B 
                                        ON A.cod_concepto_iyc=B.cod_concepto_iyc
                                        WHERE nro_transaccion = @nroTransaccion";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nroTransaccion", nroTransaccion);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int des_concepto_iyc = dr.GetOrdinal("des_concepto_iyc");
                        int importe_actual = dr.GetOrdinal("importe_actual");

                        while (dr.Read())
                        {
                            obj = new DETALLE_DEUDA();
                            if (!dr.IsDBNull(des_concepto_iyc))
                            { obj.concepto = dr.GetString(des_concepto_iyc); }
                            if (!dr.IsDBNull(importe_actual))
                            { obj.importe = dr.GetDecimal(importe_actual); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
