using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_IyC.Entities.TARJETAS
{
    public class PLANES_COBRO: DALBase
    {
        public int cod_plan { get; set; }
        public int subsistema { get; set; }
        public int cod_tarjeta { get; set; }
        public int cod_paypertic { get; set; }
        public string descripcion { get; set; }
        public Int16 Con_dto_interes { get; set; }
        public decimal ali_dto_interes { get; set; }
        public Int16 Con_costo_financiero { get; set; }
        public decimal ali_costo_financiero { get; set; }
        public bool suma_descadic { get; set; }
        public decimal valor_min_cuota { get; set; }
        public Int16 cant_cuotas { get; set; }
        public Int16 activo_windows { get; set; }
        public bool activo_web { get; set; }
        public Int16 Con_dto_obras { get; set; }
        public string promotionCode { get; set; }
        public decimal ali_prescripto { get; set; }
        public decimal desc_capital { get; set; }
        public decimal ali_obras { get; set; }

        public PLANES_COBRO()
        {
            cod_plan = 0;
            subsistema = 0;
            cod_tarjeta = 0;
            cod_paypertic = 0;
            descripcion = string.Empty;
            Con_dto_interes = 0;
            ali_dto_interes = 0;
            Con_costo_financiero = 0;
            ali_costo_financiero = 0;
            suma_descadic = false;
            valor_min_cuota = 0;
            cant_cuotas = 0;
            activo_windows = 0;
            activo_web = false;
            Con_dto_obras = 0;
            promotionCode = string.Empty;
            ali_prescripto = 0;
            desc_capital = 0;
            ali_obras = 0;
        }
        private static List<PLANES_COBRO> mapeo(SqlDataReader dr)
        {
            List<PLANES_COBRO> lst = new List<PLANES_COBRO>();
            PLANES_COBRO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PLANES_COBRO();
                    if (!dr.IsDBNull(0)) { obj.cod_plan = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.subsistema = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.cod_tarjeta = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.cod_paypertic = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.descripcion = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.Con_dto_interes = dr.GetInt16(5); }
                    if (!dr.IsDBNull(6)) { obj.ali_dto_interes = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.Con_costo_financiero = dr.GetInt16(7); }
                    if (!dr.IsDBNull(8)) { obj.ali_costo_financiero = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.suma_descadic = dr.GetBoolean(9); }
                    if (!dr.IsDBNull(10)) { obj.valor_min_cuota = dr.GetDecimal(10); }
                    if (!dr.IsDBNull(11)) { obj.cant_cuotas = dr.GetInt16(11); }
                    if (!dr.IsDBNull(12)) { obj.activo_windows = dr.GetInt16(12); }
                    if (!dr.IsDBNull(13)) { obj.activo_web = dr.GetBoolean(13); }
                    if (!dr.IsDBNull(14)) { obj.Con_dto_obras = dr.GetInt16(14); }
                    if (!dr.IsDBNull(15)) { obj.promotionCode = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.ali_prescripto = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.desc_capital = dr.GetDecimal(17); }
                    if (!dr.IsDBNull(18)) { obj.ali_obras = dr.GetDecimal(18); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PLANES_COBRO> read()
        {
            try
            {
                List<PLANES_COBRO> lst = new List<PLANES_COBRO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PLANES_COBRO";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<PLANES_COBRO> getBySubsistema(int subsistema, decimal deuda, int cod_tarjeta)
        {
            try
            {
                List<PLANES_COBRO> lst = new List<PLANES_COBRO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "SELECT *FROM PLANES_COBRO WHERE subsistema=@subsistema AND cod_tarjeta = @cod_tarjeta AND activo_windows=1 AND valor_min_cuota <= @DEUDA";
                    cmd.Parameters.AddWithValue("subsistema", subsistema);
                    cmd.Parameters.AddWithValue("cod_tarjeta", cod_tarjeta);
                    cmd.Parameters.AddWithValue("DEUDA", deuda);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PLANES_COBRO getByPk(
        int cod_plan)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PLANES_COBRO WHERE");
                sql.AppendLine("cod_plan = @cod_plan");
                PLANES_COBRO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_plan", cod_plan);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PLANES_COBRO> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
