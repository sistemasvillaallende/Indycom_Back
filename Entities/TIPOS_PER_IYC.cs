using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_IyC.Entities
{
    public class TIPOS_PER_IYC : DALBase
    {
        public int cod_tipo_per { get; set; }
        public string des_tipo_per { get; set; }
        public Int16 cuotas { get; set; }

        public TIPOS_PER_IYC()
        {
            cod_tipo_per = 0;
            des_tipo_per = string.Empty;
            cuotas = 0;
        }

        private static List<TIPOS_PER_IYC> mapeo(SqlDataReader dr)
        {
            List<TIPOS_PER_IYC> lst = new List<TIPOS_PER_IYC>();
            TIPOS_PER_IYC obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TIPOS_PER_IYC();
                    if (!dr.IsDBNull(0)) { obj.cod_tipo_per = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.des_tipo_per = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.cuotas = dr.GetInt16(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TIPOS_PER_IYC> read()
        {
            try
            {
                List<TIPOS_PER_IYC> lst = new List<TIPOS_PER_IYC>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM TIPOS_PER_IYC";
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

        public static TIPOS_PER_IYC getByPk(
        int cod_tipo_per)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TIPOS_PER_IYC WHERE");
                sql.AppendLine("cod_tipo_per = @cod_tipo_per");
                TIPOS_PER_IYC obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_per", cod_tipo_per);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TIPOS_PER_IYC> lst = mapeo(dr);
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

        public static int insert(TIPOS_PER_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TIPOS_PER_IYC(");
                sql.AppendLine("cod_tipo_per");
                sql.AppendLine(", des_tipo_per");
                sql.AppendLine(", cuotas");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_tipo_per");
                sql.AppendLine(", @des_tipo_per");
                sql.AppendLine(", @cuotas");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_per", obj.cod_tipo_per);
                    cmd.Parameters.AddWithValue("@des_tipo_per", obj.des_tipo_per);
                    cmd.Parameters.AddWithValue("@cuotas", obj.cuotas);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(TIPOS_PER_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TIPOS_PER_IYC SET");
                sql.AppendLine("des_tipo_per=@des_tipo_per");
                sql.AppendLine(", cuotas=@cuotas");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_per=@cod_tipo_per");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_per", obj.cod_tipo_per);
                    cmd.Parameters.AddWithValue("@des_tipo_per", obj.des_tipo_per);
                    cmd.Parameters.AddWithValue("@cuotas", obj.cuotas);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(TIPOS_PER_IYC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  TIPOS_PER_IYC ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_per=@cod_tipo_per");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_per", obj.cod_tipo_per);
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

