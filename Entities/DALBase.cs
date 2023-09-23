using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_IyC.Entities
{
    public class DALBase
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection("Data Source=10.11.15.107;Initial Catalog=SIIMVA;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlConnection GetConnectionSIIMVA()
        {
            try
            {
                return new SqlConnection("Data Source=10.11.15.107;Initial Catalog=SIIMVA;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlConnection GetConnection(string strDB)
        {
            try
            {
                return new SqlConnection("Data Source=10.11.15.107;Initial Catalog=" + strDB + ";User ID=general");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static long GetMaxID(string tableName, string campo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine(@"SELECT ISNULL(MAX(" + campo + "),0) as mayor");
                sql.AppendLine(@"FROM" + tableName);
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@campo", campo);
                    cmd.Connection.Open();
                    return Convert.ToInt64(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int GetNroTransaccion(SqlConnection cn, SqlTransaction trx, int subsistema)
        {
            try
            {
                int nro_transaccion = 0;
                string strSQL = string.Empty;
                switch (subsistema)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        strSQL = @"SELECT ISNULL(MAX(nro_tran_iyc),0) as nro_transaccion
                                   FROM Numeros_Claves";
                        break;
                    case 4:
                        strSQL = @"SELECT ISNULL(MAX(nro_tran_automotor),0) as nro_transaccion
                                   FROM Numeros_Claves";
                        break;
                    default:
                        break;
                }
                //
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Transaction = trx;
                nro_transaccion = Convert.ToInt32(cmd.ExecuteScalar());
                return nro_transaccion + 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateNroTransaccion(SqlConnection cn, SqlTransaction trx, int subsistema, int nro_transaccion)
        {
            try
            {
                string strSQL = string.Empty;
                switch (subsistema)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        strSQL = @"UPDATE Numeros_claves
                                   Set nro_tran_iyc = @nro_transaccion
                                   FROM Numeros_Claves";
                        break;
                    case 4:
                        strSQL = @"UPDATE Numeros_claves
                                   Set nro_tran_automotor = @nro_transaccion
                                   FROM Numeros_Claves";
                        break;
                    default:
                        break;
                }
                //
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Transaction = trx;
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
