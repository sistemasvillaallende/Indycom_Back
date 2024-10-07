using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class Rubros_x_dec_jur_iyc : DALBase
    {
        public int nro_transaccion { get; set; }
        public int cod_rubro { get; set; }
        public Single cantidad { get; set; }
        public decimal importe { get; set; }
        public Rubros_x_dec_jur_iyc()
        {
            nro_transaccion = 0;
            cod_rubro = 0;
            cantidad = 0;
            importe = 0;
        }
        private static List<Rubros_x_dec_jur_iyc> mapeo(SqlDataReader dr)
        {
            List<Rubros_x_dec_jur_iyc> lst = new List<Rubros_x_dec_jur_iyc>();
            Rubros_x_dec_jur_iyc obj;
            if (dr.HasRows)
            {
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int cantidad = dr.GetOrdinal("cantidad");
                int importe = dr.GetOrdinal("importe");
                while (dr.Read())
                {
                    obj = new Rubros_x_dec_jur_iyc();
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                    if (!dr.IsDBNull(cantidad)) { obj.cantidad = dr.GetFloat(cantidad); }
                    if (!dr.IsDBNull(importe)) { obj.importe = dr.GetDecimal(importe); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Rubros_x_dec_jur_iyc> read()
        {
            try
            {
                List<Rubros_x_dec_jur_iyc> lst = new List<Rubros_x_dec_jur_iyc>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Rubros_x_dec_jur_iyc";
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
        public static Rubros_x_dec_jur_iyc getByPk(int nro_transaccion, int cod_rubro)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Rubros_x_dec_jur_iyc WHERE");
                sql.AppendLine("nro_transaccion = @nro_transaccion");
                sql.AppendLine("AND cod_rubro = @cod_rubro");
                Rubros_x_dec_jur_iyc? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Rubros_x_dec_jur_iyc> lst = mapeo(dr);
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
        public static int insert(Rubros_x_dec_jur_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Rubros_x_dec_jur_iyc(");
                sql.AppendLine("nro_transaccion");
                sql.AppendLine(", cod_rubro");
                sql.AppendLine(", cantidad");
                sql.AppendLine(", importe");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nro_transaccion");
                sql.AppendLine(", @cod_rubro");
                sql.AppendLine(", @cantidad");
                sql.AppendLine(", @importe");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@importe", obj.importe);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void update(Rubros_x_dec_jur_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Rubros_x_dec_jur_iyc");
                sql.AppendLine("SET cantidad=@cantidad");
                sql.AppendLine(", importe=@importe");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND cod_rubro=@cod_rubro");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@importe", obj.importe);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void delete(Rubros_x_dec_jur_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Rubros_x_dec_jur_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND cod_rubro=@cod_rubro");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Rubros_x_dec_jur_iyc> GetRubrosDJIyC(int nro_transaccion, int legajo)
        {
            try
            {
                string strSQL = @"SELECT *
                                  FROM RUBROS_X_DEC_JUR_IYC 
                                  WHERE nro_transaccion=@nro_transaccion";
                List<Rubros_x_dec_jur_iyc> lst = new();
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.CommandText = strSQL;
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
        public static void UpdateRubrosDJIyC(SqlConnection cn, SqlTransaction trx, List<Rubros_x_dec_jur_iyc> lst)
        {
            try
            {
                string strSQL = @"UPDATE RUBROS_X_DEC_JUR_IYC 
                                  set cantidad=@cantidad, importe=@importe   
                                  WHERE nro_transaccion=@nro_transaccion and
                                        cod_rubro=@cod_rubro";

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = trx;
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                cmd.Parameters.AddWithValue("@cod_rubro", 0);
                cmd.Parameters.AddWithValue("@cantidad", 0);
                cmd.Parameters.AddWithValue("@importe", 0);
                cmd.CommandText = strSQL;
                foreach (var item in lst)
                {
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.Parameters["@cod_rubro"].Value = item.cod_rubro;
                    cmd.Parameters["@cantidad"].Value = item.cantidad;
                    cmd.Parameters["@importe"].Value = item.importe;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SqlActualizaRubros(int nro_transaccion, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"UPDATE RUBROS_X_DEC_JUR_IYC 
                                 set cantidad=0, importe=0
                                 WHERE nro_transaccion=@nro_transaccion";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool VerificarMontosIngresados(int nro_transaccion, int legajo)
        {
            try
            {
                bool bRet = false;
                string strSQL = @"SELECT *
                                  FROM RUBROS_X_DEC_JUR_IYC 
                                  WHERE nro_transaccion=@nro_transaccion";
                List<Rubros_x_dec_jur_iyc> lst = new();
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.CommandText = strSQL;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);

                    foreach (var item in lst)
                    {
                        if (item.importe == 0)
                        {
                            bRet = true;
                            break;
                        }
                    }
                    return bRet;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
        public static List<Rubros_x_dec_jur_iyc> ListaRubrosDJIyC(int nro_transaccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Rubros_x_dec_jur_iyc ");
                sql.AppendLine("WHERE nro_transaccion = @nro_transaccion");
                Rubros_x_dec_jur_iyc? obj = null;
                List<Rubros_x_dec_jur_iyc> lst = new List<Rubros_x_dec_jur_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    //if (lst.Count != 0)
                    //    obj = lst[0];
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

