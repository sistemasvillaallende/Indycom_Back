using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_IyC.Entities.AUDITORIA;

namespace Web_Api_IyC.Entities
{
    public class Dec_jur_iyc : DALBase
    {
        public int nro_transaccion { get; set; }
        public int legajo { get; set; }
        public string periodo { get; set; }
        public bool completa { get; set; }
        public DateTime? fecha_presentacion_ddjj { get; set; }
        public Int16 presentacion_web { get; set; }
        public string cod_zona { get; set; }
        public Int16? cod_tipo_per { get; set; }
        public Dec_jur_iyc()
        {
            nro_transaccion = 0;
            legajo = 0;
            periodo = string.Empty;
            completa = false;
            fecha_presentacion_ddjj = null; // DateTime.Now;
            presentacion_web = 0;
            cod_zona = string.Empty;
            cod_tipo_per = 0;
        }
        private static List<Dec_jur_iyc> mapeo(SqlDataReader dr)
        {
            List<Dec_jur_iyc> lst = new List<Dec_jur_iyc>();
            Dec_jur_iyc obj;
            if (dr.HasRows)
            {
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int legajo = dr.GetOrdinal("legajo");
                int periodo = dr.GetOrdinal("periodo");
                int completa = dr.GetOrdinal("completa");
                int fecha_presentacion_ddjj = dr.GetOrdinal("fecha_presentacion_ddjj");
                int presentacion_web = dr.GetOrdinal("presentacion_web");
                while (dr.Read())
                {
                    obj = new Dec_jur_iyc();
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(completa)) { obj.completa = dr.GetBoolean(completa); }
                    if (!dr.IsDBNull(fecha_presentacion_ddjj)) { obj.fecha_presentacion_ddjj = dr.GetDateTime(fecha_presentacion_ddjj); }
                    if (!dr.IsDBNull(presentacion_web)) { obj.presentacion_web = dr.GetInt16(presentacion_web); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Dec_jur_iyc> read()
        {
            try
            {
                List<Dec_jur_iyc> lst = new List<Dec_jur_iyc>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Dec_jur_iyc";
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
        public static Dec_jur_iyc getByPk(int nro_transaccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Dec_jur_iyc WHERE");
                sql.AppendLine("nro_transaccion = @nro_transaccion");
                Dec_jur_iyc? obj = new();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Dec_jur_iyc> lst = mapeo(dr);
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
        public static int insert(Dec_jur_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Dec_jur_iyc(");
                sql.AppendLine("nro_transaccion");
                sql.AppendLine(", legajo");
                sql.AppendLine(", periodo");
                sql.AppendLine(", completa");
                sql.AppendLine(", fecha_presentacion_ddjj");
                sql.AppendLine(", presentacion_web");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nro_transaccion");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @completa");
                sql.AppendLine(", @fecha_presentacion_ddjj");
                sql.AppendLine(", @presentacion_web");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@completa", obj.completa);
                    cmd.Parameters.AddWithValue("@fecha_presentacion_ddjj", obj.fecha_presentacion_ddjj);
                    cmd.Parameters.AddWithValue("@presentacion_web", obj.presentacion_web);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void update(Dec_jur_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Dec_jur_iyc SET");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", completa=@completa");
                sql.AppendLine(", fecha_presentacion_ddjj=@fecha_presentacion_ddjj");
                sql.AppendLine(", presentacion_web=@presentacion_web");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_transaccion=@nro_transaccion");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@completa", obj.completa);
                    cmd.Parameters.AddWithValue("@fecha_presentacion_ddjj", obj.fecha_presentacion_ddjj);
                    cmd.Parameters.AddWithValue("@presentacion_web", obj.presentacion_web);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void delete(Dec_jur_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Dec_jur_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_transaccion=@nro_transaccion");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Dec_jur_iyc> GetPeriodosDJSinLiquidar(int legajo)
        {
            try
            {
                string strSQL = @"SELECT d.* 
                                  FROM DEC_JUR_IYC d, 
                                    CTASCTES_INDYCOM c
                                  WHERE 
                                    d.legajo=@legajo and
                                    d.completa=0 and
                                    d.nro_transaccion=c.nro_transaccion and
                                    c.tipo_transaccion=1 and
                                    c.pagado=0
                                  ORDER BY d.periodo";
                List<Dec_jur_iyc> lst = new List<Dec_jur_iyc>();
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@legajo", legajo);
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
        public static void Liquidar_decjur(SqlConnection cn, SqlTransaction trx, Dec_jur_iyc obj)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CALCULO_DDJJ_IYC";
                cmd.Parameters.Add(new SqlParameter("@legajo", obj.legajo));
                cmd.Parameters.Add(new SqlParameter("@periodo", obj.periodo));
                cmd.Parameters.Add(new SqlParameter("@nro_transaccion", obj.nro_transaccion));
                cmd.Parameters.Add(new SqlParameter("@cod_zona", obj.cod_zona));
                cmd.Parameters.Add(new SqlParameter("@cod_tipo_per", obj.cod_tipo_per));
                cmd.Parameters.Add(new SqlParameter("@presentacion_web", obj.presentacion_web));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            { throw; }
        }
        public static Dec_jur_iyc GetDecJur_completadas(int legajo, string periodo)
        {
            try
            {
                string strSQL = @"SELECT *
                                  FROM Dec_jur_iyc
                                  WHERE
                                    legajo=@legajo AND
                                    periodo=@periodo
                                  ORDER BY d.periodo desc";
                List<Dec_jur_iyc> lst = new List<Dec_jur_iyc>();
                Dec_jur_iyc? obj = new();
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    if (lst.Count > 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static bool VerificaDecJurPagada(int nro_transaccion)
        {
            try
            {
                int pagado = 0;
                string strSQL = @"SELECT ci.pagado 
                                  FROM CTASCTES_INDYCOM ci
                                  WHERE ci.tipo_transaccion=1 AND 
                                    ci.nro_transaccion=@nro_transaccion";
                using (SqlConnection cn = DALBase.GetConnection())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            pagado = dr.GetInt32(dr.GetOrdinal("pagado"));
                        }
                    }
                    dr.Close();
                    if (pagado == 1)
                        return true;
                    else return false;




                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SqlUpdateDDJJ(Dec_jur_iyc obj)
        {
            try
            {
                string strSQL = @"UPDATE DEC_JUR_IYC
                                 SET
                                   completa = 0,
                                   fecha_presentacion_ddjj=NULL,
                                   presentacion_web=0
                                 WHERE nro_transaccion=@nro_transaccion";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void SqlEliminaDetalle(Dec_jur_iyc obj)
        {
            try
            {
                string strSQL = @"DELETE
                                  FROM Detalle_deuda_iyc
                                  WHERE
                                  nro_transaccion=@nro_transaccion";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
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

