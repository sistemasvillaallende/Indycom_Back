using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace Web_Api_IyC.Entities
{
    public class TARJETAS_DEBITOS : DALBase
    {
        public int cod_tarjeta { get; set; }
        public string des_tarjeta { get; set; }
        public Int16 debito { get; set; }
        public Int16 activa { get; set; }
        public DateTime fecha_alta { get; set; }
        public int dias_acreditacion { get; set; }
        public bool activa_web { get; set; }
        public string imagen { get; set; }
        public int cod_paypertic { get; set; }

        public TARJETAS_DEBITOS()
        {
            cod_tarjeta = 0;
            des_tarjeta = string.Empty;
            debito = 0;
            activa = 0;
            fecha_alta = DateTime.Now;
            dias_acreditacion = 0;
            activa_web = false;
            imagen = string.Empty;
            cod_paypertic = 0;
        }

        private static List<TARJETAS_DEBITOS> mapeo(SqlDataReader dr)
        {
            List<TARJETAS_DEBITOS> lst = new List<TARJETAS_DEBITOS>();
            TARJETAS_DEBITOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TARJETAS_DEBITOS();
                    if (!dr.IsDBNull(0)) { obj.cod_tarjeta = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.des_tarjeta = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.debito = dr.GetInt16(2); }
                    if (!dr.IsDBNull(3)) { obj.activa = dr.GetInt16(3); }
                    if (!dr.IsDBNull(4)) { obj.fecha_alta = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.dias_acreditacion = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.activa_web = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.imagen = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.cod_paypertic = dr.GetInt32(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TARJETAS_DEBITOS> read()
        {
            try
            {
                List<TARJETAS_DEBITOS> lst = new List<TARJETAS_DEBITOS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TARJETAS_DEBITOS";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TARJETAS_DEBITOS getByPk(int cod_tarjeta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TARJETAS_DEBITOS WHERE");
                sql.AppendLine("cod_tarjeta = @cod_tarjeta");
                TARJETAS_DEBITOS? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tarjeta", cod_tarjeta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TARJETAS_DEBITOS> lst = mapeo(dr);
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

        public static int insert(TARJETAS_DEBITOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TARJETAS_DEBITOS(");
                sql.AppendLine("cod_tarjeta");
                sql.AppendLine(", des_tarjeta");
                sql.AppendLine(", debito");
                sql.AppendLine(", activa");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", dias_acreditacion");
                sql.AppendLine(", activa_web");
                sql.AppendLine(", imagen");
                sql.AppendLine(", cod_paypertic");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_tarjeta");
                sql.AppendLine(", @des_tarjeta");
                sql.AppendLine(", @debito");
                sql.AppendLine(", @activa");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @dias_acreditacion");
                sql.AppendLine(", @activa_web");
                sql.AppendLine(", @imagen");
                sql.AppendLine(", @cod_paypertic");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
                    cmd.Parameters.AddWithValue("@des_tarjeta", obj.des_tarjeta);
                    cmd.Parameters.AddWithValue("@debito", obj.debito);
                    cmd.Parameters.AddWithValue("@activa", obj.activa);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@dias_acreditacion", obj.dias_acreditacion);
                    cmd.Parameters.AddWithValue("@activa_web", obj.activa_web);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@cod_paypertic", obj.cod_paypertic);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void update(TARJETAS_DEBITOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TARJETAS_DEBITOS SET");
                sql.AppendLine("des_tarjeta=@des_tarjeta");
                sql.AppendLine(", debito=@debito");
                sql.AppendLine(", activa=@activa");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", dias_acreditacion=@dias_acreditacion");
                sql.AppendLine(", activa_web=@activa_web");
                sql.AppendLine(", imagen=@imagen");
                sql.AppendLine(", cod_paypertic=@cod_paypertic");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tarjeta=@cod_tarjeta");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
                    cmd.Parameters.AddWithValue("@des_tarjeta", obj.des_tarjeta);
                    cmd.Parameters.AddWithValue("@debito", obj.debito);
                    cmd.Parameters.AddWithValue("@activa", obj.activa);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@dias_acreditacion", obj.dias_acreditacion);
                    cmd.Parameters.AddWithValue("@activa_web", obj.activa_web);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@cod_paypertic", obj.cod_paypertic);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void delete(TARJETAS_DEBITOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  TARJETAS_DEBITOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tarjeta=@cod_tarjeta");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
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

