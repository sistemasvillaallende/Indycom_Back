using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_IyC.Entities
{
    public class RUBROS : DALBase
    {
        public int cod_rubro { get; set; }
        public int anio { get; set; }
        public string concepto { get; set; }
        public decimal alicuota_oim { get; set; }
        public decimal alicuota_sys { get; set; }
        public decimal minimo_oim { get; set; }
        public decimal minimo_sys { get; set; }
        public bool incluido_en_oim { get; set; }
        public string observaciones { get; set; }
        public bool activo { get; set; }
        public int cod_tipo_riesgo { get; set; }
        public int cod_tipo_actividad { get; set; }
        public string riesgo { get; set; }
        public string actividad { get; set; }
        public int valor_riesgo { get; set; }

        public RUBROS()
        {
            cod_rubro = 0;
            anio = 0;
            concepto = string.Empty;
            alicuota_oim = 0;
            alicuota_sys = 0;
            minimo_oim = 0;
            minimo_sys = 0;
            incluido_en_oim = false;
            observaciones = string.Empty;
            activo = false;
            cod_tipo_riesgo = 0;
            cod_tipo_actividad = 0;
            riesgo = string.Empty;
            actividad = string.Empty;
            valor_riesgo = 0;
        }
        private static List<RUBROS> mapeo(SqlDataReader dr)
        {
            List<RUBROS> lst = new List<RUBROS>();
            RUBROS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new RUBROS();
                    if (!dr.IsDBNull(0)) { obj.cod_rubro = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.anio = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.concepto = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.alicuota_oim = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.alicuota_sys = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.minimo_oim = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.minimo_sys = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.incluido_en_oim = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.observaciones = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.activo = dr.GetBoolean(9); }
                    if (!dr.IsDBNull(10)) { obj.cod_tipo_riesgo = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.cod_tipo_actividad = dr.GetInt32(11); }
                    if (!dr.IsDBNull(13)) { obj.riesgo = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.actividad = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.valor_riesgo = dr.GetInt32(15); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<RUBROS> read()
        {
            string strSQL = @"
                            SELECT a.*, b.descripcion as riesgo, 
                            c.descripcion as actividad,
                            a.cod_tipo_riesgo as valor_riesgo
                            FROM RUBROS a
                            full JOIN TIPO_RIESGO_IYC b on
                            a.cod_tipo_riesgo=b.cod_tipo_riesgo
                            full JOIN TIPO_ACTIVIDAD_IYC c on
                            a.cod_tipo_actividad=c.cod_tipo_actividad
                            WHERE
                            a.anio=year(getdate())";

            try
            {
                List<RUBROS> lst = new List<RUBROS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
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
        public static List<RUBROS> BuscarRubroxRiesgo(int tipo_riesgo)
        {
            string strSQL = @"
                            SELECT a.*, b.descripcion as riesgo, 
                            c.descripcion as actividad,
                            a.cod_tipo_riesgo as valor_riesgo
                            FROM RUBROS a
                            full JOIN TIPO_RIESGO_IYC b on
                            a.cod_tipo_riesgo=b.cod_tipo_riesgo
                            full JOIN TIPO_ACTIVIDAD_IYC c on
                            a.cod_tipo_actividad=c.cod_tipo_actividad
                            WHERE
                            a.cod_tipo_riesgo=@tipo_riesgo AND
                            a.anio=year(getdate())";
            try
            {
                List<RUBROS> lst = new List<RUBROS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@tipo_riesgo", tipo_riesgo);
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
        public static List<RUBROS> BuscarRubroxTipoActividad(int tipo_actividad)
        {
            string strSQL = @"
                            SELECT a.*, b.descripcion as riessgo, 
                            c.descripcion as actividad, 
                            a.cod_tipo_riesgo as valor_riesgo 
                            FROM RUBROS a
                            full JOIN TIPO_RIESGO_IYC b on
                            a.cod_tipo_riesgo=b.cod_tipo_riesgo
                            full JOIN TIPO_ACTIVIDAD_IYC c on
                            a.cod_tipo_actividad=c.cod_tipo_actividad
                            WHERE
                            a.cod_tipo_actividad=@tipo_actividad AND
                            a.anio=year(getdate())";
            try
            {
                List<RUBROS> lst = new List<RUBROS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@tipo_actividad", tipo_actividad);
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
        public static List<RUBROS> BuscarRubroxDescripcion(string descripcion)
        {
            string strSQL = @"
                            SELECT a.*, b.descripcion as riesgo, 
                            c.descripcion as actividad,
                            a.cod_tipo_riesgo as valor_riesgo 
                            FROM RUBROS a
                            full JOIN TIPO_RIESGO_IYC b on
                            a.cod_tipo_riesgo=b.cod_tipo_riesgo
                            full JOIN TIPO_ACTIVIDAD_IYC c on
                            a.cod_tipo_actividad=c.cod_tipo_actividad
                            WHERE
                            a.anio=year(getdate()) AND
                            a.concepto like @descripcion";

            try
            {
                List<RUBROS> lst = new List<RUBROS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@descripcion", descripcion + "%");
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
        public static RUBROS getByPk(int cod_rubro, int anio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM RUBROS WHERE");
                sql.AppendLine("cod_rubro = @cod_rubro");
                sql.AppendLine("AND anio = @anio");
                RUBROS obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<RUBROS> lst = mapeo(dr);
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
        public static int insert(RUBROS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO RUBROS(");
                sql.AppendLine("cod_rubro");
                sql.AppendLine(", anio");
                sql.AppendLine(", concepto");
                sql.AppendLine(", alicuota_oim");
                sql.AppendLine(", alicuota_sys");
                sql.AppendLine(", minimo_oim");
                sql.AppendLine(", minimo_sys");
                sql.AppendLine(", incluido_en_oim");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", activo");
                sql.AppendLine(", cod_tipo_riezgo");
                sql.AppendLine(", cod_tipo_actividad");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_rubro");
                sql.AppendLine(", @anio");
                sql.AppendLine(", @concepto");
                sql.AppendLine(", @alicuota_oim");
                sql.AppendLine(", @alicuota_sys");
                sql.AppendLine(", @minimo_oim");
                sql.AppendLine(", @minimo_sys");
                sql.AppendLine(", @incluido_en_oim");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @cod_tipo_riesgo");
                sql.AppendLine(", @cod_tipo_actividad");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@concepto", obj.concepto);
                    cmd.Parameters.AddWithValue("@alicuota_oim", obj.alicuota_oim);
                    cmd.Parameters.AddWithValue("@alicuota_sys", obj.alicuota_sys);
                    cmd.Parameters.AddWithValue("@minimo_oim", obj.minimo_oim);
                    cmd.Parameters.AddWithValue("@minimo_sys", obj.minimo_sys);
                    cmd.Parameters.AddWithValue("@incluido_en_oim", obj.incluido_en_oim);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@cod_tipo_riesgo", obj.cod_tipo_riesgo);
                    cmd.Parameters.AddWithValue("@cod_tipo_actividad", obj.cod_tipo_actividad);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(RUBROS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  RUBROS SET");
                sql.AppendLine("concepto=@concepto");
                sql.AppendLine(", alicuota_oim=@alicuota_oim");
                sql.AppendLine(", alicuota_sys=@alicuota_sys");
                sql.AppendLine(", minimo_oim=@minimo_oim");
                sql.AppendLine(", minimo_sys=@minimo_sys");
                sql.AppendLine(", incluido_en_oim=@incluido_en_oim");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", cod_tipo_riesgo=@cod_tipo_riesgo");
                sql.AppendLine(", cod_tipo_actividad=@cod_tipo_actividad");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_rubro=@cod_rubro");
                sql.AppendLine("AND anio=@anio");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@concepto", obj.concepto);
                    cmd.Parameters.AddWithValue("@alicuota_oim", obj.alicuota_oim);
                    cmd.Parameters.AddWithValue("@alicuota_sys", obj.alicuota_sys);
                    cmd.Parameters.AddWithValue("@minimo_oim", obj.minimo_oim);
                    cmd.Parameters.AddWithValue("@minimo_sys", obj.minimo_sys);
                    cmd.Parameters.AddWithValue("@incluido_en_oim", obj.incluido_en_oim);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@cod_tipo_riesgo", obj.cod_tipo_riesgo);
                    cmd.Parameters.AddWithValue("@cod_tipo_actividad", obj.cod_tipo_actividad);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(RUBROS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  RUBROS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_rubro=@cod_rubro");
                sql.AppendLine("AND anio=@anio");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
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

