using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_IyC.Entities
{
    public class TIPOS_LIQ_IYC : DALBase
    {
        public int cod_tipo_liq { get; set; }
        public string descripcion_tipo_liq { get; set; }

        public TIPOS_LIQ_IYC()
        {
            cod_tipo_liq = 0;
            descripcion_tipo_liq = string.Empty;
        }

        private static List<TIPOS_LIQ_IYC> mapeo(SqlDataReader dr)
        {
            List<TIPOS_LIQ_IYC> lst = new List<TIPOS_LIQ_IYC>();
            TIPOS_LIQ_IYC obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TIPOS_LIQ_IYC();
                    if (!dr.IsDBNull(0)) { obj.cod_tipo_liq = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.descripcion_tipo_liq = dr.GetString(1); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TIPOS_LIQ_IYC> read()
        {
            try
            {
                List<TIPOS_LIQ_IYC> lst = new List<TIPOS_LIQ_IYC>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM TIPOS_LIQ_IYC";
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

        public static TIPOS_LIQ_IYC getByPk(
        int cod_tipo_liq)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TIPOS_LIQ_IYC WHERE");
                sql.AppendLine("cod_tipo_liq = @cod_tipo_liq");
                TIPOS_LIQ_IYC obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", cod_tipo_liq);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TIPOS_LIQ_IYC> lst = mapeo(dr);
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

        public static int insert(TIPOS_LIQ_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TIPOS_LIQ_IYC(");
                sql.AppendLine("cod_tipo_liq");
                sql.AppendLine(", descripcion_tipo_liq");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_tipo_liq");
                sql.AppendLine(", @descripcion_tipo_liq");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", obj.cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@descripcion_tipo_liq", obj.descripcion_tipo_liq);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(TIPOS_LIQ_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TIPOS_LIQ_IYC SET");
                sql.AppendLine("descripcion_tipo_liq=@descripcion_tipo_liq");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_liq=@cod_tipo_liq");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", obj.cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@descripcion_tipo_liq", obj.descripcion_tipo_liq);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(TIPOS_LIQ_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  TIPOS_LIQ_IYC ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_liq=@cod_tipo_liq");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", obj.cod_tipo_liq);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

