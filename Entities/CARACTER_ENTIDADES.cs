using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class CARACTER_ENTIDADES : DALBase
    {
        public int cod_entidad { get; set; }
        public string descripcion { get; set; }
        public CARACTER_ENTIDADES()
        {
            cod_entidad = 0;
            descripcion = string.Empty;
        }
        private static List<CARACTER_ENTIDADES> mapeo(SqlDataReader dr)
        {
            List<CARACTER_ENTIDADES> lst = new List<CARACTER_ENTIDADES>();
            CARACTER_ENTIDADES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CARACTER_ENTIDADES();
                    if (!dr.IsDBNull(0)) { obj.cod_entidad = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CARACTER_ENTIDADES> read()
        {
            try
            {
                List<CARACTER_ENTIDADES> lst = new List<CARACTER_ENTIDADES>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CARACTER_ENTIDADES";
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

        public static CARACTER_ENTIDADES getByPk(int Cod_entidad)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CARACTER_ENTIDADES WHERE");
                sql.AppendLine("Cod_entidad = @Cod_entidad");
                CARACTER_ENTIDADES? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Cod_entidad", Cod_entidad);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CARACTER_ENTIDADES> lst = mapeo(dr);
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

        public static int insert(CARACTER_ENTIDADES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CARACTER_ENTIDADES(");
                sql.AppendLine("Cod_entidad");
                sql.AppendLine(", Descripcion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Cod_entidad");
                sql.AppendLine(", @Descripcion");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Cod_entidad", obj.cod_entidad);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.descripcion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CARACTER_ENTIDADES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CARACTER_ENTIDADES SET");
                sql.AppendLine("Descripcion=@Descripcion");
                sql.AppendLine("WHERE");
                sql.AppendLine("Cod_entidad=@Cod_entidad");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Cod_entidad", obj.cod_entidad);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.descripcion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CARACTER_ENTIDADES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CARACTER_ENTIDADES ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Cod_entidad=@Cod_entidad");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Cod_entidad", obj.cod_entidad);
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

