using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class TIPOS_RIESGO_IYC : DALBase
    {
        public int id_riesgo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public bool activo { get; set; }
        public decimal desde_mts { get; set; }
        public decimal hasta_mts { get; set; }

        public TIPOS_RIESGO_IYC()
        {
            id_riesgo = 0;
            descripcion = string.Empty;
            fecha = DateTime.Now;
            activo = false;
            desde_mts = 0;
            hasta_mts = 0;
        }

        private static List<TIPOS_RIESGO_IYC> mapeo(SqlDataReader dr)
        {
            List<TIPOS_RIESGO_IYC> lst = new List<TIPOS_RIESGO_IYC>();
            TIPOS_RIESGO_IYC obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TIPOS_RIESGO_IYC();
                    if (!dr.IsDBNull(0)) { obj.id_riesgo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.activo = dr.GetBoolean(3); }
                    if (!dr.IsDBNull(4)) { obj.desde_mts = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.hasta_mts = dr.GetDecimal(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TIPOS_RIESGO_IYC> read()
        {
            try
            {
                List<TIPOS_RIESGO_IYC> lst = new List<TIPOS_RIESGO_IYC>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TIPOS_RIESGO_IYC";
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

        public static TIPOS_RIESGO_IYC getBySuperficie(double superficie)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM TIPOS_RIESGO_IYC WHERE");
                TIPOS_RIESGO_IYC obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@superficie", superficie);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TIPOS_RIESGO_IYC> lst = mapeo(dr);
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

        //public static int insert(TIPOS_RIESGO_IYC obj)
        //{
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("INSERT INTO TIPOS_RIESGO_IYC(");
        //        sql.AppendLine("id_riesgo");
        //        sql.AppendLine(", descripcion");
        //        sql.AppendLine(", fecha");
        //        sql.AppendLine(", activo");
        //        sql.AppendLine(", hasta_mts");
        //        sql.AppendLine(")");
        //        sql.AppendLine("VALUES");
        //        sql.AppendLine("(");
        //        sql.AppendLine("@id_riesgo");
        //        sql.AppendLine(", @descripcion");
        //        sql.AppendLine(", @fecha");
        //        sql.AppendLine(", @activo");
        //        sql.AppendLine(", @hasta_mts");
        //        sql.AppendLine(")");
        //        sql.AppendLine("SELECT SCOPE_IDENTITY()");
        //        using (SqlConnection con = GetConnectionSIIMVA())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@id_riesgo", obj.id_riesgo);
        //            cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
        //            cmd.Parameters.AddWithValue("@fecha", obj.fecha);
        //            cmd.Parameters.AddWithValue("@activo", obj.activo);
        //            cmd.Parameters.AddWithValue("@hasta_mts", obj.hasta_mts);
        //            cmd.Connection.Open();
        //            return Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void update(TIPOS_RIESGO_IYC obj)
        //{
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("UPDATE  TIPOS_RIESGO_IYC SET");
        //        sql.AppendLine("id_riesgo=@id_riesgo");
        //        sql.AppendLine(", descripcion=@descripcion");
        //        sql.AppendLine(", fecha=@fecha");
        //        sql.AppendLine(", activo=@activo");
        //        sql.AppendLine(", hasta_mts=@hasta_mts");
        //        sql.AppendLine("WHERE");
        //        using (SqlConnection con = GetConnectionSIIMVA())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@id_riesgo", obj.id_riesgo);
        //            cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
        //            cmd.Parameters.AddWithValue("@fecha", obj.fecha);
        //            cmd.Parameters.AddWithValue("@activo", obj.activo);
        //            cmd.Parameters.AddWithValue("@hasta_mts", obj.hasta_mts);
        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void delete(TIPOS_RIESGO_IYC obj)
        //{
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("DELETE  TIPOS_RIESGO_IYC ");
        //        sql.AppendLine("WHERE");
        //        using (SqlConnection con = GetConnectionSIIMVA())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}

