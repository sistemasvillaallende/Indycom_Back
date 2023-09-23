using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_IyC.Entities.IYC
{
    public class LstDeudaIyC : DALBase
    {
        public string periodo { get; set; }
        public decimal monto_original { get; set; }
        public decimal debe { get; set; }
        public string vencimiento { get; set; }
        public string desCategoria { get; set; }
        public int pagado { get; set; }
        public int nroTtransaccion { get; set; }
        public int categoriaDeuda { get; set; }
        public int nro_cedulon_paypertic { get; set; }
        public decimal recargo { get; set; }
        public bool pago_parcial { get; set; }
        public decimal pago_a_cuenta { get; set; }

        public LstDeudaIyC()
        {
            periodo = string.Empty;
            monto_original = 0;
            debe = 0;
            vencimiento = string.Empty;
            desCategoria = string.Empty;
            pagado = 0;
            nroTtransaccion = 0;
            categoriaDeuda = 0;
            nro_cedulon_paypertic = 0;
            recargo = 0;
            pago_parcial = false;
            pago_a_cuenta = 0;
        }
        public static List<LstDeudaIyC> getListDeudaIyC(int legajo)
        {
            List<LstDeudaIyC> oLstIyC = new List<LstDeudaIyC>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection? cn = null;
            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT C.periodo, C.monto_original, C.debe -");
            strSQL.AppendLine("(SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE");
            strSQL.AppendLine("C2.nro_transaccion=C.nro_transaccion  AND");
            strSQL.AppendLine("C2.legajo = C.legajo) as debe,");
            strSQL.AppendLine("vencimiento, b.des_categoria,");
            strSQL.AppendLine("c.pagado, c.nro_transaccion, c.cod_cate_deuda, c.nro_cedulon_paypertic,");
            strSQL.AppendLine("c.recargo,");
            strSQL.AppendLine("C.pago_parcial,");
            strSQL.AppendLine("(SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE");
            strSQL.AppendLine("C2.nro_transaccion=C.nro_transaccion  AND");
            strSQL.AppendLine("C2.legajo = C.legajo) as pago_a_cuenta");
            strSQL.AppendLine("FROM CTASCTES_INDYCOM C");
            strSQL.AppendLine("inner join CATE_DEUDA_INDYCOM b on c.cod_cate_deuda = b.cod_categoria");
            strSQL.AppendLine("WHERE");
            strSQL.AppendLine("c.pagado = 0");
            strSQL.AppendLine("AND c.tipo_transaccion = 1");
            strSQL.AppendLine("AND c.deuda_activa = 1");
            strSQL.AppendLine("AND c.nro_plan IS NULL");
            strSQL.AppendLine("AND c.nro_procuracion IS NULL");
            strSQL.AppendLine("AND c.legajo = @legajo");

            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));

            try
            {
                cn = DALBase.GetConnectionSIIMVA();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LstDeudaIyC oIyC = new LstDeudaIyC();
                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                    { oIyC.periodo = dr.GetString(dr.GetOrdinal("periodo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("monto_original")))
                    { oIyC.monto_original = dr.GetDecimal(dr.GetOrdinal("monto_original")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("debe")))
                    { oIyC.debe = dr.GetDecimal(dr.GetOrdinal("debe")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("vencimiento")))
                    {
                        oIyC.vencimiento = dr.GetDateTime(
                        dr.GetOrdinal("vencimiento")).ToShortDateString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("des_categoria")))
                    { oIyC.desCategoria = dr.GetString(dr.GetOrdinal("des_categoria")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pagado")))
                    { oIyC.pagado = 0; }//Convert.ToInt32(dr.GetSqlBinary(dr.GetOrdinal("pagado"))); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_transaccion")))
                    { oIyC.nroTtransaccion = dr.GetInt32(dr.GetOrdinal("nro_transaccion")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_cate_deuda")))
                    { oIyC.categoriaDeuda = dr.GetInt32(dr.GetOrdinal("cod_cate_deuda")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("recargo")))
                    { oIyC.recargo = dr.GetDecimal(dr.GetOrdinal("recargo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cedulon_paypertic")))
                    { oIyC.nro_cedulon_paypertic = dr.GetInt32(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oIyC.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oIyC.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }

                    oLstIyC.Add(oIyC);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw;
            }
            finally { cn.Close(); }
            return oLstIyC;
        }
    }
}
