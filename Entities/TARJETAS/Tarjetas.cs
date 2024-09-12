using System.Data.SqlClient;
using System.Data;

namespace Web_Api_IyC.Entities.TARJETAS
{
    public class Tarjetas:DALBase
    {
        public int cod_tarjeta { get; set; }
        public string des_tarjeta { get; set; }
        public string imagen { get; set; }
        public int cod_paypertic { get; set; }
        public string promotionCode { get; set; }

        public Tarjetas()
        {
            cod_paypertic = 0;
            cod_tarjeta = 0;
            des_tarjeta = string.Empty; 
            imagen = string.Empty;  
            promotionCode = string.Empty;   
        }
        public static List<Tarjetas> getTarjetasWeb()
        {
            try
            {
                List<Tarjetas> lst = new List<Tarjetas>();
                Tarjetas obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT cod_tarjeta, des_tarjeta, imagen, cod_paypertic FROM TARJETAS_DEBITOS WHERE activa_web = 1";
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            obj = new Tarjetas();
                            if (!dr.IsDBNull(0))
                                obj.cod_tarjeta = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                obj.des_tarjeta = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                obj.imagen = dr.GetString(2);
                            if (!dr.IsDBNull(3))
                                obj.cod_paypertic = dr.GetInt32(3);
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Tarjetas> getTarjetasDesktop()
        {
            try
            {
                List<Tarjetas> lst = new List<Tarjetas>();
                Tarjetas obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT cod_tarjeta, des_tarjeta, imagen, cod_paypertic 
                                        FROM TARJETAS_DEBITOS 
                                        WHERE activa = 1 AND cod_tarjeta > 1";
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            obj = new Tarjetas();
                            if (!dr.IsDBNull(0))
                                obj.cod_tarjeta = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                obj.des_tarjeta = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                obj.imagen = dr.GetString(2);
                            if (!dr.IsDBNull(3))
                                obj.cod_paypertic = dr.GetInt32(3);
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Tarjetas getTarjetasByPk(int pk)
        {
            try
            {
                Tarjetas obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT cod_tarjeta, des_tarjeta, imagen, cod_paypertic FROM TARJETAS_DEBITOS WHERE cod_tarjeta = @pk";
                    cmd.Parameters.AddWithValue("@pk", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            obj = new Tarjetas();
                            if (!dr.IsDBNull(0))
                                obj.cod_tarjeta = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                obj.des_tarjeta = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                obj.imagen = dr.GetString(2);
                            if (!dr.IsDBNull(3))
                                obj.cod_paypertic = dr.GetInt32(3);
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Tarjetas getTarjetasByCodPayPerTic(int pk)
        {
            try
            {
                Tarjetas obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT cod_tarjeta, des_tarjeta, imagen, cod_paypertic FROM TARJETAS_DEBITOS WHERE cod_paypertic = @pk";
                    cmd.Parameters.AddWithValue("@pk", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            obj = new Tarjetas();
                            if (!dr.IsDBNull(0))
                                obj.cod_tarjeta = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                obj.des_tarjeta = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                obj.imagen = dr.GetString(2);
                            if (!dr.IsDBNull(3))
                                obj.cod_paypertic = dr.GetInt32(3);
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
