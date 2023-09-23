using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class TIPOS_DE_IVA : DALBase
    {
        public int cod_cond_ante_iva { get; set; }
        public string des_cond_ante_iva { get; set; }
        public decimal alicuota { get; set; }

        public TIPOS_DE_IVA()
        {
            cod_cond_ante_iva = 0;
            des_cond_ante_iva = string.Empty;
            alicuota = 0;
        }

        private static List<TIPOS_DE_IVA> mapeo(SqlDataReader dr)
        {
            List<TIPOS_DE_IVA> lst = new List<TIPOS_DE_IVA>();
            TIPOS_DE_IVA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TIPOS_DE_IVA();
                    if (!dr.IsDBNull(0)) { obj.cod_cond_ante_iva = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.des_cond_ante_iva = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.alicuota = dr.GetDecimal(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TIPOS_DE_IVA> read()
        {
            try
            {
                List<TIPOS_DE_IVA> lst = new List<TIPOS_DE_IVA>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TIPOS_DE_IVA";
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

        public static TIPOS_DE_IVA getByPk(
        int cod_cond_ante_iva)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TIPOS_DE_IVA WHERE");
                sql.AppendLine("cod_cond_ante_iva = @cod_cond_ante_iva");
                TIPOS_DE_IVA obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", cod_cond_ante_iva);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TIPOS_DE_IVA> lst = mapeo(dr);
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

        public static int insert(TIPOS_DE_IVA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TIPOS_DE_IVA(");
                sql.AppendLine("cod_cond_ante_iva");
                sql.AppendLine(", des_cond_ante_iva");
                sql.AppendLine(", alicuota");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_cond_ante_iva");
                sql.AppendLine(", @des_cond_ante_iva");
                sql.AppendLine(", @alicuota");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@des_cond_ante_iva", obj.des_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@alicuota", obj.alicuota);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(TIPOS_DE_IVA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TIPOS_DE_IVA SET");
                sql.AppendLine("des_cond_ante_iva=@des_cond_ante_iva");
                sql.AppendLine(", alicuota=@alicuota");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_cond_ante_iva=@cod_cond_ante_iva");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@des_cond_ante_iva", obj.des_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@alicuota", obj.alicuota);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(TIPOS_DE_IVA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  TIPOS_DE_IVA ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_cond_ante_iva=@cod_cond_ante_iva");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
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

