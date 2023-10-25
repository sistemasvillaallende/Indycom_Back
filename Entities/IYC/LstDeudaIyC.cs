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
        public int nro_proc { get; set; }
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
            nro_proc = 0;
        }
        public static List<LstDeudaIyC> getListDeudaIndyCom(int legajo)
        {
            List<LstDeudaIyC> oLstAuto = new List<LstDeudaIyC>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            string sql = 
                    @"SELECT C.periodo, C.monto_original, C.debe -
                    (SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.legajo = C.legajo) as debe,
                    vencimiento, b.des_categoria,
                    c.pagado, c.nro_transaccion, c.cod_cate_deuda, c.nro_cedulon_paypertic,
                    c.recargo,
                    C.pago_parcial, 
                    (SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.legajo = C.legajo) as pago_a_cuenta, C.NRO_PROCURACION
                    FROM CTASCTES_INDYCOM C
                    inner join CATE_DEUDA_INDYCOM b on c.cod_cate_deuda = b.cod_categoria
                    WHERE
                    c.pagado = 0
                    AND c.tipo_transaccion = 1
                    AND c.nro_plan IS NULL
                    AND c.nro_procuracion IS NULL
                    AND c.legajo = @legajo AND vencimiento <= GETDATE() ORDER BY C.periodo ASC";


            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaIyC oIndyCom = new LstDeudaIyC();
                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                    { oIndyCom.periodo = dr.GetString(dr.GetOrdinal("periodo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("monto_original")))
                    { oIndyCom.monto_original = dr.GetDecimal(dr.GetOrdinal("monto_original")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("debe")))
                    { oIndyCom.debe = dr.GetDecimal(dr.GetOrdinal("debe")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("vencimiento")))
                    {
                        oIndyCom.vencimiento = dr.GetDateTime(
                        dr.GetOrdinal("vencimiento")).ToShortDateString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("des_categoria")))
                    { oIndyCom.desCategoria = dr.GetString(dr.GetOrdinal("des_categoria")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pagado")))
                    { oIndyCom.pagado = 0; }//Convert.ToInt32(dr.GetSqlBinary(dr.GetOrdinal("pagado"))); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_transaccion")))
                    { oIndyCom.nroTtransaccion = dr.GetInt32(dr.GetOrdinal("nro_transaccion")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_cate_deuda")))
                    { oIndyCom.categoriaDeuda = dr.GetInt32(dr.GetOrdinal("cod_cate_deuda")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("recargo")))
                    { oIndyCom.recargo = dr.GetDecimal(dr.GetOrdinal("recargo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cedulon_paypertic")))
                    { oIndyCom.nro_cedulon_paypertic = dr.GetInt32(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oIndyCom.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oIndyCom.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oIndyCom.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }

                    oLstAuto.Add(oIndyCom);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally { cn.Close(); }
            return oLstAuto;
        }
        public static List<LstDeudaIyC> getListDeudaIndyComNoVencida(int legajo)
        {
            List<LstDeudaIyC> oLstAuto = new List<LstDeudaIyC>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            string sql =
                @"SELECT C.periodo, C.monto_original, C.debe -
                    (SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.legajo = C.legajo) as debe,
                    C.vencimiento, b.des_categoria,
                    c.pagado, c.nro_transaccion, b.cod_categoria, c.nro_cedulon_paypertic,
                    c.recargo,
                    C.pago_parcial,
                    (SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.legajo = C.legajo) as pago_a_cuenta, C.NRO_PROCURACION
                    FROM CTASCTES_INDYCOM C
                    inner join CATE_DEUDA_INDYCOM b on c.cod_cate_deuda = b.cod_categoria
                    WHERE
                    c.pagado = 0
                    AND c.tipo_transaccion = 1
                    AND c.nro_plan IS NULL
                    AND c.nro_procuracion IS NULL
                    AND c.legajo = @legajo AND c.vencimiento > GETDATE() ORDER BY C.periodo ASC
                ";


            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaIyC oAuto = new LstDeudaIyC();
                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                    { oAuto.periodo = dr.GetString(dr.GetOrdinal("periodo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("monto_original")))
                    { oAuto.monto_original = dr.GetDecimal(dr.GetOrdinal("monto_original")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("debe")))
                    { oAuto.debe = dr.GetDecimal(dr.GetOrdinal("debe")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("vencimiento")))
                    {
                        oAuto.vencimiento = dr.GetDateTime(
                        dr.GetOrdinal("vencimiento")).ToShortDateString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("des_categoria")))
                    { oAuto.desCategoria = dr.GetString(dr.GetOrdinal("des_categoria")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pagado")))
                    { oAuto.pagado = 0; }//Convert.ToInt32(dr.GetSqlBinary(dr.GetOrdinal("pagado"))); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_transaccion")))
                    { oAuto.nroTtransaccion = dr.GetInt32(dr.GetOrdinal("nro_transaccion")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("categoria_deuda")))
                    { oAuto.categoriaDeuda = dr.GetInt32(dr.GetOrdinal("categoria_deuda")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("recargo")))
                    { oAuto.recargo = dr.GetDecimal(dr.GetOrdinal("recargo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cedulon_paypertic")))
                    { oAuto.nro_cedulon_paypertic = dr.GetInt32(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oAuto.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oAuto.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oAuto.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }
                    oLstAuto.Add(oAuto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally { cn.Close(); }
            return oLstAuto;
        }
        public static List<LstDeudaIyC> getListDeudaIYCProcurada(int legajo)
        {
            List<LstDeudaIyC> oLstAuto = new List<LstDeudaIyC>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;
            StringBuilder strSQL = new StringBuilder();

             string sql = @"SELECT C.periodo, C.monto_original, C.debe -
                (SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE
                C2.nro_transaccion=C.nro_transaccion  AND
                C2.legajo = C.legajo) as debe,
                vencimiento, b.des_categoria,
                c.pagado, c.nro_transaccion, c.cod_cate_deuda, c.nro_cedulon_paypertic,
                c.recargo,
                C.pago_parcial,
                (SELECT SUM(haber) FROM CTASCTES_INDYCOM C2 WHERE
                C2.nro_transaccion=C.nro_transaccion  AND
                C2.legajo = C.legajo) as pago_a_cuenta, C.NRO_PROCURACION
                FROM CTASCTES_INDYCOM C
                inner join CATE_DEUDA_INDYCOM b on c.cod_cate_deuda = b.cod_categoria
                WHERE
                c.pagado = 0
                AND c.tipo_transaccion = 1
                AND c.nro_plan IS NULL
                AND c.nro_procuracion IS NOT NULL
                AND c.legajo = @legajo ORDER BY C.periodo ASC";


            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaIyC oAuto = new LstDeudaIyC();
                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                    { oAuto.periodo = dr.GetString(dr.GetOrdinal("periodo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("monto_original")))
                    { oAuto.monto_original = dr.GetDecimal(dr.GetOrdinal("monto_original")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("debe")))
                    { oAuto.debe = dr.GetDecimal(dr.GetOrdinal("debe")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("vencimiento")))
                    {
                        oAuto.vencimiento = dr.GetDateTime(
                        dr.GetOrdinal("vencimiento")).ToShortDateString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("des_categoria")))
                    { oAuto.desCategoria = dr.GetString(dr.GetOrdinal("des_categoria")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pagado")))
                    { oAuto.pagado = 0; }//Convert.ToInt32(dr.GetSqlBinary(dr.GetOrdinal("pagado"))); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_transaccion")))
                    { oAuto.nroTtransaccion = dr.GetInt32(dr.GetOrdinal("nro_transaccion")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("categoria_deuda")))
                    { oAuto.categoriaDeuda = dr.GetInt32(dr.GetOrdinal("categoria_deuda")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("recargo")))
                    { oAuto.recargo = dr.GetDecimal(dr.GetOrdinal("recargo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cedulon_paypertic")))
                    { oAuto.nro_cedulon_paypertic = dr.GetInt32(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oAuto.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oAuto.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oAuto.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }
                    oLstAuto.Add(oAuto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally { cn.Close(); }
            return oLstAuto;
        }
    }
}
