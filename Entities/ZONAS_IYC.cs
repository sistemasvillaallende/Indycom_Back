using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class ZONAS_IYC : DALBase
    {
        public string cod_zona { get; set; }

        public ZONAS_IYC()
        {
            cod_zona = string.Empty;
        }

        private static List<ZONAS_IYC> mapeo(SqlDataReader dr)
        {
            List<ZONAS_IYC> lst = new List<ZONAS_IYC>();
            ZONAS_IYC obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ZONAS_IYC();
                    if (!dr.IsDBNull(0)) { obj.cod_zona = dr.GetString(0); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ZONAS_IYC> read()
        {
            try
            {
                List<ZONAS_IYC> lst = new List<ZONAS_IYC>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM ZONAS_IYC";
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

        public static ZONAS_IYC getByPk(
        char cod_zona)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM ZONAS_IYC WHERE");
                sql.AppendLine("cod_zona = @cod_zona");
                ZONAS_IYC obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_zona", cod_zona);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ZONAS_IYC> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int insert(ZONAS_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ZONAS_IYC(");
                sql.AppendLine("cod_zona");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_zona");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ZONAS_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ZONAS_IYC SET");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_zona=@cod_zona");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ZONAS_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ZONAS_IYC ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_zona=@cod_zona");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
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

