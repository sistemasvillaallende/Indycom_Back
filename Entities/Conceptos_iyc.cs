using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class Conceptos_iyc : DALBase
    {
        public int cod_concepto_iyc { get; set; }
        public string des_concepto_iyc { get; set; }
        public bool suma { get; set; }
        

        public Conceptos_iyc()
        {
            cod_concepto_iyc = 0;
            des_concepto_iyc = string.Empty;
            suma = false;    
        }

        private static List<Conceptos_iyc> mapeo(SqlDataReader dr)
        {
            List<Conceptos_iyc> lst = new List<Conceptos_iyc>();
            Conceptos_iyc obj;
            if (dr.HasRows)
            {
                int cod_concepto_iyc = dr.GetOrdinal("cod_concepto_iyc");
                int des_concepto_iyc = dr.GetOrdinal("des_concepto_iyc");
                int suma = dr.GetOrdinal("suma");
                while (dr.Read())
                {
                    obj = new Conceptos_iyc();
                    if (!dr.IsDBNull(cod_concepto_iyc)) { obj.cod_concepto_iyc = dr.GetInt32(cod_concepto_iyc); }
                    if (!dr.IsDBNull(des_concepto_iyc)) { obj.des_concepto_iyc = dr.GetString(des_concepto_iyc); }
                    if (!dr.IsDBNull(suma)) { obj.suma = dr.GetBoolean(suma); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Conceptos_iyc> read()
        {
            try
            {
                List<Conceptos_iyc> lst = new List<Conceptos_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Conceptos_iyc";
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

        public static Conceptos_iyc getByPk(
        int cod_concepto_iyc)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Conceptos_iyc WHERE");
                sql.AppendLine("cod_concepto_iyc = @cod_concepto_iyc");
                Conceptos_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", cod_concepto_iyc);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Conceptos_iyc> lst = mapeo(dr);
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

        public static int insert(Conceptos_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Conceptos_iyc(");
                sql.AppendLine("cod_concepto_iyc");
                sql.AppendLine(", des_concepto_iyc");
                sql.AppendLine(", suma");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_concepto_iyc");
                sql.AppendLine(", @des_concepto_iyc");
                sql.AppendLine(", @suma");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", obj.cod_concepto_iyc);
                    cmd.Parameters.AddWithValue("@des_concepto_iyc", obj.des_concepto_iyc);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Conceptos_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Conceptos_iyc SET");
                sql.AppendLine("des_concepto_iyc=@des_concepto_iyc");
                sql.AppendLine(", suma=@suma");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_concepto_iyc=@cod_concepto_iyc");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", obj.cod_concepto_iyc);
                    cmd.Parameters.AddWithValue("@des_concepto_iyc", obj.des_concepto_iyc);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Conceptos_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Conceptos_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_concepto_iyc=@cod_concepto_iyc");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", obj.cod_concepto_iyc);
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

