using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities
{
    public class Sucursales_indycom : DALBase
    {
        public int Legajo { get; set; }
        public int? Nro_sucursal { get; set; }
        public string Des_com { get; set; }
        public string Nom_fantasia { get; set; }
        public int Cod_calle { get; set; }
        public string Nom_calle { get; set; }
        public int Nro_dom { get; set; }
        public int Cod_barrio { get; set; }
        public string Nom_barrio { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Cod_postal { get; set; }
        public string Nro_res { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_Baja { get; set; }
        public DateTime? Fecha_hab { get; set; }
        public bool Dado_baja { get; set; }
        public string nro_exp_mesa_ent { get; set; }
        public DateTime? fecha_alta { get; set; }
        public string cod_zona { get; set; }
        public string Nro_local { get; set; }
        public string Piso_dpto { get; set; }
        public DateTime? Vto_inscripcion { get; set; }

        public Sucursales_indycom()
        {
            Legajo = 0;
            Nro_sucursal = 0;
            Des_com = string.Empty;
            Nom_fantasia = string.Empty;
            Cod_calle = 0;
            Nom_calle = string.Empty;
            Nro_dom = 0;
            Cod_barrio = 0;
            Nom_barrio = string.Empty;
            Ciudad = string.Empty;
            Provincia = string.Empty;
            Pais = string.Empty;
            Cod_postal = string.Empty;
            Nro_res = string.Empty;
            Fecha_inicio = null; // DateTime.Now;
            Fecha_Baja = null; //DateTime.Now;
            Fecha_hab = null; // DateTime.Now;
            Dado_baja = false;
            nro_exp_mesa_ent = string.Empty;
            fecha_alta = null; // DateTime.Now;
            cod_zona = string.Empty;
            Nro_local = string.Empty;
            Piso_dpto = string.Empty;
            Vto_inscripcion = null; //DateTime.Now;
        }
        private static List<Sucursales_indycom> mapeo(SqlDataReader dr)
        {
            List<Sucursales_indycom> lst = new List<Sucursales_indycom>();
            Sucursales_indycom obj;
            if (dr.HasRows)
            {
                int Legajo = dr.GetOrdinal("Legajo");
                int Nro_sucursal = dr.GetOrdinal("Nro_sucursal");
                int Des_com = dr.GetOrdinal("Des_com");
                int Nom_fantasia = dr.GetOrdinal("Nom_fantasia");
                int Cod_calle = dr.GetOrdinal("Cod_calle");
                int Nom_calle = dr.GetOrdinal("Nom_calle");
                int Nro_dom = dr.GetOrdinal("Nro_dom");
                int Cod_barrio = dr.GetOrdinal("Cod_barrio");
                int Nom_barrio = dr.GetOrdinal("Nom_barrio");
                int Ciudad = dr.GetOrdinal("Ciudad");
                int Provincia = dr.GetOrdinal("Provincia");
                int Pais = dr.GetOrdinal("Pais");
                int Cod_postal = dr.GetOrdinal("Cod_postal");
                int Nro_res = dr.GetOrdinal("Nro_res");
                int Fecha_inicio = dr.GetOrdinal("Fecha_inicio");
                int Fecha_Baja = dr.GetOrdinal("Fecha_Baja");
                int Fecha_hab = dr.GetOrdinal("Fecha_hab");
                int Dado_baja = dr.GetOrdinal("Dado_baja");
                int nro_exp_mesa_ent = dr.GetOrdinal("nro_exp_mesa_ent");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int cod_zona = dr.GetOrdinal("cod_zona");
                int Nro_local = dr.GetOrdinal("Nro_local");
                int Piso_dpto = dr.GetOrdinal("Piso_dpto");
                int Vto_inscripcion = dr.GetOrdinal("Vto_inscripcion");
                while (dr.Read())
                {
                    obj = new Sucursales_indycom();
                    if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                    if (!dr.IsDBNull(Nro_sucursal)) { obj.Nro_sucursal = dr.GetInt32(Nro_sucursal); }
                    if (!dr.IsDBNull(Des_com)) { obj.Des_com = dr.GetString(Des_com); }
                    if (!dr.IsDBNull(Nom_fantasia)) { obj.Nom_fantasia = dr.GetString(Nom_fantasia); }
                    if (!dr.IsDBNull(Cod_calle)) { obj.Cod_calle = dr.GetInt32(Cod_calle); }
                    if (!dr.IsDBNull(Nom_calle)) { obj.Nom_calle = dr.GetString(Nom_calle); }
                    if (!dr.IsDBNull(Nro_dom)) { obj.Nro_dom = dr.GetInt32(Nro_dom); }
                    if (!dr.IsDBNull(Cod_barrio)) { obj.Cod_barrio = dr.GetInt32(Cod_barrio); }
                    if (!dr.IsDBNull(Nom_barrio)) { obj.Nom_barrio = dr.GetString(Nom_barrio); }
                    if (!dr.IsDBNull(Ciudad)) { obj.Ciudad = dr.GetString(Ciudad); }
                    if (!dr.IsDBNull(Provincia)) { obj.Provincia = dr.GetString(Provincia); }
                    if (!dr.IsDBNull(Pais)) { obj.Pais = dr.GetString(Pais); }
                    if (!dr.IsDBNull(Cod_postal)) { obj.Cod_postal = dr.GetString(Cod_postal); }
                    if (!dr.IsDBNull(Nro_res)) { obj.Nro_res = dr.GetString(Nro_res); }
                    if (!dr.IsDBNull(Fecha_inicio)) { obj.Fecha_inicio = dr.GetDateTime(Fecha_inicio); }
                    if (!dr.IsDBNull(Fecha_Baja)) { obj.Fecha_Baja = dr.GetDateTime(Fecha_Baja); }
                    if (!dr.IsDBNull(Fecha_hab)) { obj.Fecha_hab = dr.GetDateTime(Fecha_hab); }
                    if (!dr.IsDBNull(Dado_baja)) { obj.Dado_baja = dr.GetBoolean(Dado_baja); }
                    if (!dr.IsDBNull(nro_exp_mesa_ent)) { obj.nro_exp_mesa_ent = dr.GetString(nro_exp_mesa_ent); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(cod_zona)) { obj.cod_zona = dr.GetString(cod_zona); }
                    if (!dr.IsDBNull(Nro_local)) { obj.Nro_local = dr.GetString(Nro_local); }
                    if (!dr.IsDBNull(Piso_dpto)) { obj.Piso_dpto = dr.GetString(Piso_dpto); }
                    if (!dr.IsDBNull(Vto_inscripcion)) { obj.Vto_inscripcion = dr.GetDateTime(Vto_inscripcion); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Sucursales_indycom> read()
        {
            try
            {
                List<Sucursales_indycom> lst = new List<Sucursales_indycom>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Sucursales_indycom";
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
        // public static Sucursales_indycom getByPk()
        // {
        //     try
        //     {
        //         StringBuilder sql = new StringBuilder();
        //         sql.AppendLine("SELECT * FROM Sucursales_indycom WHERE");
        //         Sucursales_indycom obj = new();
        //         using (SqlConnection con = GetConnectionSIIMVA())
        //         {
        //             SqlCommand cmd = con.CreateCommand();
        //             cmd.CommandType = CommandType.Text;
        //             cmd.CommandText = sql.ToString();
        //             cmd.Connection.Open();
        //             SqlDataReader dr = cmd.ExecuteReader();
        //             List<Sucursales_indycom> lst = mapeo(dr);
        //             if (lst.Count != 0)
        //                 obj = lst[0];
        //         }
        //         return obj;
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
        // }
        public static Sucursales_indycom GetSucuralByLegajo(int legajo, int nro_sucursal)
        {
            try
            {
                Sucursales_indycom obj = new Sucursales_indycom();
                string sql = @"SELECT  *
                               FROM Sucursales_indycom 
                               WHERE legajo=@legajo AND
                                     nro_sucursal=@nro_sucursal AND
                                     dado_baja = 0";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@nro_sucursal", nro_sucursal);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Sucursales_indycom> lst = mapeo(dr);
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
        public static int insert(Sucursales_indycom obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Sucursales_indycom(");
                sql.AppendLine("Legajo");
                sql.AppendLine(", Nro_sucursal");
                sql.AppendLine(", Des_com");
                sql.AppendLine(", Nom_fantasia");
                sql.AppendLine(", Cod_calle");
                sql.AppendLine(", Nom_calle");
                sql.AppendLine(", Nro_dom");
                sql.AppendLine(", Cod_barrio");
                sql.AppendLine(", Nom_barrio");
                sql.AppendLine(", Ciudad");
                sql.AppendLine(", Provincia");
                sql.AppendLine(", Pais");
                sql.AppendLine(", Cod_postal");
                sql.AppendLine(", Nro_res");
                sql.AppendLine(", Fecha_inicio");
                sql.AppendLine(", Fecha_Baja");
                sql.AppendLine(", Fecha_hab");
                sql.AppendLine(", Dado_baja");
                sql.AppendLine(", nro_exp_mesa_ent");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", cod_zona");
                sql.AppendLine(", Nro_local");
                sql.AppendLine(", Piso_dpto");
                sql.AppendLine(", Vto_inscripcion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Legajo");
                sql.AppendLine(", @Nro_sucursal");
                sql.AppendLine(", @Des_com");
                sql.AppendLine(", @Nom_fantasia");
                sql.AppendLine(", @Cod_calle");
                sql.AppendLine(", @Nom_calle");
                sql.AppendLine(", @Nro_dom");
                sql.AppendLine(", @Cod_barrio");
                sql.AppendLine(", @Nom_barrio");
                sql.AppendLine(", @Ciudad");
                sql.AppendLine(", @Provincia");
                sql.AppendLine(", @Pais");
                sql.AppendLine(", @Cod_postal");
                sql.AppendLine(", @Nro_res");
                sql.AppendLine(", @Fecha_inicio");
                sql.AppendLine(", @Fecha_Baja");
                sql.AppendLine(", @Fecha_hab");
                sql.AppendLine(", @Dado_baja");
                sql.AppendLine(", @nro_exp_mesa_ent");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @cod_zona");
                sql.AppendLine(", @Nro_local");
                sql.AppendLine(", @Piso_dpto");
                sql.AppendLine(", @Vto_inscripcion");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Legajo", obj.Legajo);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                    cmd.Parameters.AddWithValue("@Des_com", obj.Des_com);
                    cmd.Parameters.AddWithValue("@Nom_fantasia", obj.Nom_fantasia);
                    cmd.Parameters.AddWithValue("@Cod_calle", obj.Cod_calle);
                    cmd.Parameters.AddWithValue("@Nom_calle", obj.Nom_calle);
                    cmd.Parameters.AddWithValue("@Nro_dom", obj.Nro_dom);
                    cmd.Parameters.AddWithValue("@Cod_barrio", obj.Cod_barrio);
                    cmd.Parameters.AddWithValue("@Nom_barrio", obj.Nom_barrio);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("@Cod_postal", obj.Cod_postal);
                    cmd.Parameters.AddWithValue("@Nro_res", obj.Nro_res);
                    cmd.Parameters.AddWithValue("@Fecha_inicio", obj.Fecha_inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Baja", obj.Fecha_Baja);
                    cmd.Parameters.AddWithValue("@Fecha_hab", obj.Fecha_hab);
                    cmd.Parameters.AddWithValue("@Dado_baja", obj.Dado_baja);
                    cmd.Parameters.AddWithValue("@nro_exp_mesa_ent", obj.nro_exp_mesa_ent);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Parameters.AddWithValue("@Nro_local", obj.Nro_local);
                    cmd.Parameters.AddWithValue("@Piso_dpto", obj.Piso_dpto);
                    cmd.Parameters.AddWithValue("@Vto_inscripcion", obj.Vto_inscripcion);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void update(Sucursales_indycom obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Sucursales_indycom SET");
                sql.AppendLine("Legajo=@Legajo");
                sql.AppendLine(", Nro_sucursal=@Nro_sucursal");
                sql.AppendLine(", Des_com=@Des_com");
                sql.AppendLine(", Nom_fantasia=@Nom_fantasia");
                sql.AppendLine(", Cod_calle=@Cod_calle");
                sql.AppendLine(", Nom_calle=@Nom_calle");
                sql.AppendLine(", Nro_dom=@Nro_dom");
                sql.AppendLine(", Cod_barrio=@Cod_barrio");
                sql.AppendLine(", Nom_barrio=@Nom_barrio");
                sql.AppendLine(", Ciudad=@Ciudad");
                sql.AppendLine(", Provincia=@Provincia");
                sql.AppendLine(", Pais=@Pais");
                sql.AppendLine(", Cod_postal=@Cod_postal");
                sql.AppendLine(", Nro_res=@Nro_res");
                sql.AppendLine(", Fecha_inicio=@Fecha_inicio");
                sql.AppendLine(", Fecha_Baja=@Fecha_Baja");
                sql.AppendLine(", Fecha_hab=@Fecha_hab");
                sql.AppendLine(", Dado_baja=@Dado_baja");
                sql.AppendLine(", nro_exp_mesa_ent=@nro_exp_mesa_ent");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", cod_zona=@cod_zona");
                sql.AppendLine(", Nro_local=@Nro_local");
                sql.AppendLine(", Piso_dpto=@Piso_dpto");
                sql.AppendLine(", Vto_inscripcion=@Vto_inscripcion");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Legajo", obj.Legajo);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                    cmd.Parameters.AddWithValue("@Des_com", obj.Des_com);
                    cmd.Parameters.AddWithValue("@Nom_fantasia", obj.Nom_fantasia);
                    cmd.Parameters.AddWithValue("@Cod_calle", obj.Cod_calle);
                    cmd.Parameters.AddWithValue("@Nom_calle", obj.Nom_calle);
                    cmd.Parameters.AddWithValue("@Nro_dom", obj.Nro_dom);
                    cmd.Parameters.AddWithValue("@Cod_barrio", obj.Cod_barrio);
                    cmd.Parameters.AddWithValue("@Nom_barrio", obj.Nom_barrio);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("@Cod_postal", obj.Cod_postal);
                    cmd.Parameters.AddWithValue("@Nro_res", obj.Nro_res);
                    cmd.Parameters.AddWithValue("@Fecha_inicio", obj.Fecha_inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Baja", obj.Fecha_Baja);
                    cmd.Parameters.AddWithValue("@Fecha_hab", obj.Fecha_hab);
                    cmd.Parameters.AddWithValue("@Dado_baja", obj.Dado_baja);
                    cmd.Parameters.AddWithValue("@nro_exp_mesa_ent", obj.nro_exp_mesa_ent);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Parameters.AddWithValue("@Nro_local", obj.Nro_local);
                    cmd.Parameters.AddWithValue("@Piso_dpto", obj.Piso_dpto);
                    cmd.Parameters.AddWithValue("@Vto_inscripcion", obj.Vto_inscripcion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(int legajo,int nro_sucursal, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Sucursales_indycom");
                sql.AppendLine("WHERE Legajo = @Legajo AND Nro_sucursal = @Nro_sucursal");

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();

                cmd.Parameters.AddWithValue("@Legajo", legajo);
                cmd.Parameters.AddWithValue("@Nro_sucursal", nro_sucursal);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la sucursal", ex);
            }
        }



        public static List<Sucursales_indycom> GetSucursales(int legajo)
        {
            try
            {
                List<Sucursales_indycom> lst = new List<Sucursales_indycom>();
                string sql = @"SELECT  *
                               FROM Sucursales_indycom 
                               WHERE legajo=@legajo AND
                                     dado_baja = 0";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);

                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void BajaSucursal(int legajo, int nro_sucursal, string fecha_baja,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Sucursales_Indycom SET");
                sql.AppendLine("dado_baja=1,");
                sql.AppendLine("fecha_baja=@fecha_baja");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo AND ");
                sql.AppendLine("nro_sucursal=@nro_sucursal");
                //
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@nro_sucursal", nro_sucursal);
                cmd.Parameters.AddWithValue("@fecha_baja", Convert.ToDateTime(fecha_baja, culturaFecArgentina).ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerUltimoNroSucursal(int legajo, SqlConnection con, SqlTransaction trx)
        {
            int ultimoNroSucursal = 0;

            string strSQL = @"
                                 SELECT MAX(Nro_sucursal) AS UltimoNroSucursal
                                 FROM Sucursales_Indycom
                                 WHERE legajo = @legajo;";

            SqlCommand cmd = con.CreateCommand();
            cmd.Transaction = trx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@legajo", legajo);

            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value && result != null)
            {
                ultimoNroSucursal = Convert.ToInt32(result);
            }

            return ultimoNroSucursal;
        }


        public static void NuevaSucursal(int legajo, Sucursales_indycom sucursal,
                  SqlConnection con, SqlTransaction trx)
        {
            try
            {
                int nroSucursal = ObtenerUltimoNroSucursal(legajo, con, trx);
                Console.WriteLine(nroSucursal);
                string strSQL = @"
                               INSERT INTO Sucursales_Indycom 
                                    (Legajo, Nro_sucursal, Des_com, Nom_fantasia, Cod_calle, Nom_calle, Nro_dom, 
                                     Cod_barrio, Nom_barrio, Ciudad, Provincia, Pais, Cod_postal, Nro_res, 
                                     Fecha_inicio, Fecha_Baja, Fecha_hab, Dado_baja, nro_exp_mesa_ent, fecha_alta, 
                                     cod_zona, Nro_local, Piso_dpto, Vto_inscripcion) 
                               VALUES 
                                    (@Legajo, @Nro_sucursal, @Des_com, @Nom_fantasia, @Cod_calle, @Nom_calle, @Nro_dom, 
                                     @Cod_barrio, @Nom_barrio, @Ciudad, @Provincia, @Pais, @Cod_postal, @Nro_res, 
                                     @Fecha_inicio, @Fecha_Baja, @Fecha_hab, @Dado_baja, @nro_exp_mesa_ent, @fecha_alta, 
                                     @cod_zona, @Nro_local, @Piso_dpto, @Vto_inscripcion);";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                cmd.Parameters.AddWithValue("@Legajo", sucursal.Legajo);
                cmd.Parameters.AddWithValue("@Nro_sucursal", nroSucursal + 1);
                cmd.Parameters.AddWithValue("@Des_com", sucursal.Des_com ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nom_fantasia", sucursal.Nom_fantasia ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Cod_calle", sucursal.Cod_calle);
                cmd.Parameters.AddWithValue("@Nom_calle", sucursal.Nom_calle ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nro_dom", sucursal.Nro_dom);
                cmd.Parameters.AddWithValue("@Cod_barrio", sucursal.Cod_barrio);
                cmd.Parameters.AddWithValue("@Nom_barrio", sucursal.Nom_barrio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ciudad", sucursal.Ciudad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Provincia", sucursal.Provincia ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Pais", sucursal.Pais ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Cod_postal", sucursal.Cod_postal ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nro_res", sucursal.Nro_res ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Fecha_inicio", sucursal.Fecha_inicio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_baja", sucursal.Fecha_Baja ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Fecha_hab", sucursal.Fecha_hab ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Dado_baja", sucursal.Dado_baja);
                cmd.Parameters.AddWithValue("@nro_exp_mesa_ent", sucursal.nro_exp_mesa_ent ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_alta", sucursal.fecha_alta ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_zona", sucursal.cod_zona ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nro_local", sucursal.Nro_local ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Piso_dpto", sucursal.Piso_dpto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Vto_inscripcion", sucursal.Vto_inscripcion ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ModificarSucursal(int legajo, int nroSucursal, Sucursales_indycom sucursal, SqlConnection con, SqlTransaction trx)
        {
            string strSQL = @"
                             UPDATE Sucursales_Indycom
                             SET Des_com = @Des_com,
                                 Nom_fantasia = @Nom_fantasia,
                                 Cod_calle = @Cod_calle,
                                 Nom_calle = @Nom_calle,
                                 Nro_dom = @Nro_dom,
                                 Cod_barrio = @Cod_barrio,
                                 Nom_barrio = @Nom_barrio,
                                 Ciudad = @Ciudad,
                                 Provincia = @Provincia,
                                 Pais = @Pais,
                                 Cod_postal = @Cod_postal,
                                 Nro_res = @Nro_res,
                                 Fecha_inicio = @Fecha_inicio,
                                 Fecha_Baja = @Fecha_Baja,
                                 Fecha_hab = @Fecha_hab,
                                 Dado_baja = @Dado_baja,
                                 nro_exp_mesa_ent = @nro_exp_mesa_ent,
                                 fecha_alta = @fecha_alta,
                                 cod_zona = @cod_zona,
                                 Nro_local = @Nro_local,
                                 Piso_dpto = @Piso_dpto,
                                 Vto_inscripcion = @Vto_inscripcion
                             WHERE Legajo = @Legajo AND Nro_sucursal = @Nro_sucursal;";

            SqlCommand cmd = con.CreateCommand();
            cmd.Transaction = trx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;

            cmd.Parameters.AddWithValue("@Legajo", legajo);
            cmd.Parameters.AddWithValue("@Nro_sucursal", nroSucursal);
            cmd.Parameters.AddWithValue("@Des_com", sucursal.Des_com ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Nom_fantasia", sucursal.Nom_fantasia ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Cod_calle", sucursal.Cod_calle);
            cmd.Parameters.AddWithValue("@Nom_calle", sucursal.Nom_calle ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Nro_dom", sucursal.Nro_dom);
            cmd.Parameters.AddWithValue("@Cod_barrio", sucursal.Cod_barrio);
            cmd.Parameters.AddWithValue("@Nom_barrio", sucursal.Nom_barrio ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Ciudad", sucursal.Ciudad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Provincia", sucursal.Provincia ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Pais", sucursal.Pais ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Cod_postal", sucursal.Cod_postal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Nro_res", sucursal.Nro_res ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Fecha_inicio", sucursal.Fecha_inicio ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Fecha_Baja", sucursal.Fecha_Baja ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Fecha_hab", sucursal.Fecha_hab ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Dado_baja", sucursal.Dado_baja);
            cmd.Parameters.AddWithValue("@nro_exp_mesa_ent", sucursal.nro_exp_mesa_ent ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fecha_alta", sucursal.fecha_alta ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@cod_zona", sucursal.cod_zona ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Nro_local", sucursal.Nro_local ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Piso_dpto", sucursal.Piso_dpto ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Vto_inscripcion", sucursal.Vto_inscripcion ?? (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }



    }
}

