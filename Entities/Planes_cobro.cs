using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace Web_Api_IyC.Entities
{
    public class Planes_cobro : DALBase
    {
        public int cod_plan { get; set; }
        public int subsistema { get; set; }
        public int cod_tarjeta { get; set; }
        public int cod_paypertic { get; set; }
        public string descripcion { get; set; }
        public Int16 con_dto_interes { get; set; }
        public decimal ali_dto_interes { get; set; }
        public Int16 con_costo_financiero { get; set; }
        public decimal ali_costo_financiero { get; set; }
        public bool suma_descadic { get; set; }
        public decimal valor_min_cuota { get; set; }
        public Int16 cant_cuotas { get; set; }
        public Int16 activo_windows { get; set; }
        public bool activo_web { get; set; }
        public Int16 con_dto_obras { get; set; }
        public string promotionCode { get; set; }
        public decimal ali_prescripto { get; set; }
        public decimal desc_capital { get; set; }
        public decimal ali_obras { get; set; }
        public int debito { get; set; }
        public string des_tarjeta { get; set; }

        public Planes_cobro()
        {
            cod_plan = 0;
            subsistema = 0;
            cod_tarjeta = 0;
            cod_paypertic = 0;
            descripcion = string.Empty;
            con_dto_interes = 0;
            ali_dto_interes = 0;
            con_costo_financiero = 0;
            ali_costo_financiero = 0;
            suma_descadic = false;
            valor_min_cuota = 0;
            cant_cuotas = 0;
            activo_windows = 0;
            activo_web = false;
            con_dto_obras = 0;
            promotionCode = string.Empty;
            ali_prescripto = 0;
            desc_capital = 0;
            ali_obras = 0;
            debito = 0;
            des_tarjeta = string.Empty;
        }

        private static List<Planes_cobro> mapeo(SqlDataReader dr)
        {
            List<Planes_cobro> lst = new List<Planes_cobro>();
            Planes_cobro obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Planes_cobro();
                    if (!dr.IsDBNull(0)) { obj.cod_plan = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.subsistema = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.cod_tarjeta = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.cod_paypertic = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.descripcion = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.con_dto_interes = dr.GetInt16(5); }
                    if (!dr.IsDBNull(6)) { obj.ali_dto_interes = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.con_costo_financiero = dr.GetInt16(7); }
                    if (!dr.IsDBNull(8)) { obj.ali_costo_financiero = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.suma_descadic = dr.GetBoolean(9); }
                    if (!dr.IsDBNull(10)) { obj.valor_min_cuota = dr.GetDecimal(10); }
                    if (!dr.IsDBNull(11)) { obj.cant_cuotas = dr.GetInt16(11); }
                    if (!dr.IsDBNull(12)) { obj.activo_windows = dr.GetInt16(12); }
                    if (!dr.IsDBNull(13)) { obj.activo_web = dr.GetBoolean(13); }
                    if (!dr.IsDBNull(14)) { obj.con_dto_obras = dr.GetInt16(14); }
                    if (!dr.IsDBNull(15)) { obj.promotionCode = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.ali_prescripto = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.desc_capital = dr.GetDecimal(17); }
                    if (!dr.IsDBNull(18)) { obj.ali_obras = dr.GetDecimal(18); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Planes_cobro> read()
        {
            try
            {
                List<Planes_cobro> lst = new List<Planes_cobro>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT * FROM Planes_cobro";
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

        public static Planes_cobro getByPk()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Planes_cobro WHERE");
                Planes_cobro? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Planes_cobro> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int insert(Planes_cobro obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Planes_cobro(");
                sql.AppendLine("cod_plan");
                sql.AppendLine(", subsistema");
                sql.AppendLine(", cod_tarjeta");
                sql.AppendLine(", cod_paypertic");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", Con_dto_interes");
                sql.AppendLine(", ali_dto_interes");
                sql.AppendLine(", Con_costo_financiero");
                sql.AppendLine(", ali_costo_financiero");
                sql.AppendLine(", suma_descadic");
                sql.AppendLine(", valor_min_cuota");
                sql.AppendLine(", cant_cuotas");
                sql.AppendLine(", activo_windows");
                sql.AppendLine(", activo_web");
                sql.AppendLine(", Con_dto_obras");
                sql.AppendLine(", promotionCode");
                sql.AppendLine(", ali_prescripto");
                sql.AppendLine(", desc_capital");
                sql.AppendLine(", ali_obras");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_plan");
                sql.AppendLine(", @subsistema");
                sql.AppendLine(", @cod_tarjeta");
                sql.AppendLine(", @cod_paypertic");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @Con_dto_interes");
                sql.AppendLine(", @ali_dto_interes");
                sql.AppendLine(", @Con_costo_financiero");
                sql.AppendLine(", @ali_costo_financiero");
                sql.AppendLine(", @suma_descadic");
                sql.AppendLine(", @valor_min_cuota");
                sql.AppendLine(", @cant_cuotas");
                sql.AppendLine(", @activo_windows");
                sql.AppendLine(", @activo_web");
                sql.AppendLine(", @Con_dto_obras");
                sql.AppendLine(", @promotionCode");
                sql.AppendLine(", @ali_prescripto");
                sql.AppendLine(", @desc_capital");
                sql.AppendLine(", @ali_obras");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_plan", obj.cod_plan);
                    cmd.Parameters.AddWithValue("@subsistema", obj.subsistema);
                    cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
                    cmd.Parameters.AddWithValue("@cod_paypertic", obj.cod_paypertic);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@Con_dto_interes", obj.con_dto_interes);
                    cmd.Parameters.AddWithValue("@ali_dto_interes", obj.ali_dto_interes);
                    cmd.Parameters.AddWithValue("@Con_costo_financiero", obj.con_costo_financiero);
                    cmd.Parameters.AddWithValue("@ali_costo_financiero", obj.ali_costo_financiero);
                    cmd.Parameters.AddWithValue("@suma_descadic", obj.suma_descadic);
                    cmd.Parameters.AddWithValue("@valor_min_cuota", obj.valor_min_cuota);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    cmd.Parameters.AddWithValue("@activo_windows", obj.activo_windows);
                    cmd.Parameters.AddWithValue("@activo_web", obj.activo_web);
                    cmd.Parameters.AddWithValue("@Con_dto_obras", obj.con_dto_obras);
                    cmd.Parameters.AddWithValue("@promotionCode", obj.promotionCode);
                    cmd.Parameters.AddWithValue("@ali_prescripto", obj.ali_prescripto);
                    cmd.Parameters.AddWithValue("@desc_capital", obj.desc_capital);
                    cmd.Parameters.AddWithValue("@ali_obras", obj.ali_obras);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void update(Planes_cobro obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Planes_cobro SET");
                sql.AppendLine("cod_plan=@cod_plan");
                sql.AppendLine(", subsistema=@subsistema");
                sql.AppendLine(", cod_tarjeta=@cod_tarjeta");
                sql.AppendLine(", cod_paypertic=@cod_paypertic");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine(", Con_dto_interes=@Con_dto_interes");
                sql.AppendLine(", ali_dto_interes=@ali_dto_interes");
                sql.AppendLine(", Con_costo_financiero=@Con_costo_financiero");
                sql.AppendLine(", ali_costo_financiero=@ali_costo_financiero");
                sql.AppendLine(", suma_descadic=@suma_descadic");
                sql.AppendLine(", valor_min_cuota=@valor_min_cuota");
                sql.AppendLine(", cant_cuotas=@cant_cuotas");
                sql.AppendLine(", activo_windows=@activo_windows");
                sql.AppendLine(", activo_web=@activo_web");
                sql.AppendLine(", Con_dto_obras=@Con_dto_obras");
                sql.AppendLine(", promotionCode=@promotionCode");
                sql.AppendLine(", ali_prescripto=@ali_prescripto");
                sql.AppendLine(", desc_capital=@desc_capital");
                sql.AppendLine(", ali_obras=@ali_obras");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_plan", obj.cod_plan);
                    cmd.Parameters.AddWithValue("@subsistema", obj.subsistema);
                    cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
                    cmd.Parameters.AddWithValue("@cod_paypertic", obj.cod_paypertic);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@Con_dto_interes", obj.con_dto_interes);
                    cmd.Parameters.AddWithValue("@ali_dto_interes", obj.ali_dto_interes);
                    cmd.Parameters.AddWithValue("@Con_costo_financiero", obj.con_costo_financiero);
                    cmd.Parameters.AddWithValue("@ali_costo_financiero", obj.ali_costo_financiero);
                    cmd.Parameters.AddWithValue("@suma_descadic", obj.suma_descadic);
                    cmd.Parameters.AddWithValue("@valor_min_cuota", obj.valor_min_cuota);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    cmd.Parameters.AddWithValue("@activo_windows", obj.activo_windows);
                    cmd.Parameters.AddWithValue("@activo_web", obj.activo_web);
                    cmd.Parameters.AddWithValue("@Con_dto_obras", obj.con_dto_obras);
                    cmd.Parameters.AddWithValue("@promotionCode", obj.promotionCode);
                    cmd.Parameters.AddWithValue("@ali_prescripto", obj.ali_prescripto);
                    cmd.Parameters.AddWithValue("@desc_capital", obj.desc_capital);
                    cmd.Parameters.AddWithValue("@ali_obras", obj.ali_obras);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void delete(Planes_cobro obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE Planes_cobro ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

