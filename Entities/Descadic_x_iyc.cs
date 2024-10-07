using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_IyC.Entities
{
    public class Descadic_x_iyc : DALBase
    {
        public int legajo { get; set; }
        public int cod_concepto_iyc { get; set; }
        public string des_concepto_iyc { get; set; }
        public Single porcentaje { get; set; }
        public decimal monto { get; set; }
        public DateTime vencimiento { get; set; }
        public int nro_decreto { get; set; }
        //public DateTime fecha_alta { get; set; }
        //public Int16 activo { get; set; }
        //public int anio_desde { get; set; }
        //public int anio_hasta { get; set; }
        //public string observaciones { get; set; }
        public AUDITORIA.Auditoria? objAuditoria { get; set; }
        public Descadic_x_iyc()
        {
            legajo = 0;
            cod_concepto_iyc = 0;
            porcentaje = 0;
            monto = 0;
            vencimiento = DateTime.Now;
            nro_decreto = 0;
            // fecha_alta = DateTime.Now;
            // activo = 0;
            // anio_desde = 0;
            // anio_hasta = 0;
            // observaciones = string.Empty;
            objAuditoria = new AUDITORIA.Auditoria();
            des_concepto_iyc = string.Empty;
        }

        private static List<Descadic_x_iyc> mapeo(SqlDataReader dr)
        {
            List<Descadic_x_iyc> lst = new List<Descadic_x_iyc>();
            Descadic_x_iyc obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int cod_concepto_iyc = dr.GetOrdinal("cod_concepto_iyc");
                int porcentaje = dr.GetOrdinal("porcentaje");
                int monto = dr.GetOrdinal("monto");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int nro_decreto = dr.GetOrdinal("nro_decreto");
                // int fecha_alta = dr.GetOrdinal("fecha_alta");
                // int activo = dr.GetOrdinal("activo");
                // int anio_desde = dr.GetOrdinal("anio_desde");
                // int anio_hasta = dr.GetOrdinal("anio_hasta");
                // int observaciones = dr.GetOrdinal("observaciones");
                int des_concepto_iyc = dr.GetOrdinal("des_concepto_iyc");
                while (dr.Read())
                {
                    obj = new Descadic_x_iyc();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(cod_concepto_iyc)) { obj.cod_concepto_iyc = dr.GetInt32(cod_concepto_iyc); }
                    if (!dr.IsDBNull(porcentaje)) { obj.porcentaje = dr.GetFloat(porcentaje); }
                    if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(nro_decreto)) { obj.nro_decreto = dr.GetInt32(nro_decreto); }
                    // if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    // if (!dr.IsDBNull(activo)) { obj.activo = dr.GetInt16(activo); }
                    // if (!dr.IsDBNull(anio_desde)) { obj.anio_desde = dr.GetInt32(anio_desde); }
                    // if (!dr.IsDBNull(anio_hasta)) { obj.anio_hasta = dr.GetInt32(anio_hasta); }
                    // if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(des_concepto_iyc)) { obj.des_concepto_iyc = dr.GetString(des_concepto_iyc); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Descadic_x_iyc> read(int legajo)
        {
            try
            {
                List<Descadic_x_iyc> lst = new List<Descadic_x_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                                    SELECT A.*, B.des_concepto_dominio 
                                    FROM Descadic_x_auto A
                                    INNER JOIN CONCEPTOS_IYC B ON 
                                    A.cod_concepto_iyc=B.cod_concepto_iyc
                                    WHERE legajo=@legajo";
                    cmd.Parameters.AddWithValue("@legajo", legajo);
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
        public static Descadic_x_iyc getByPk(
        int legajo, int cod_concepto_iyc)
        {
            try
            {
                string sql = @"
                            SELECT A.*, B.des_concepto_iyc 
                            FROM Descadic_x_iyc A
                            INNER JOIN CONCEPTOS_IYC B ON 
                            A.cod_concepto_iyc=B.cod_concepto_iyc
                            WHERE legajo = @legajo
                            AND A.cod_concepto_iyc = @cod_concepto_iyc";

                Descadic_x_iyc obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", cod_concepto_iyc);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Descadic_x_iyc> lst = mapeo(dr);
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
        public static List<Descadic_x_iyc> getConceptos_x_iyc( int legajo)
        {
            try
            {

                string sql = @"
                            SELECT A.*, B.des_concepto_iyc
                            FROM Descadic_x_iyc A
                            INNER JOIN CONCEPTOS_IYC B ON 
                            A.cod_concepto_iyc=B.cod_concepto_iyc
                            WHERE legajo = @legajo";

                List<Descadic_x_iyc> lst = new List<Descadic_x_iyc>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
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

        public static int insert(Descadic_x_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Descadic_x_iyc(");
                sql.AppendLine("legajo");
                sql.AppendLine(", cod_concepto_iyc");
                sql.AppendLine(", porcentaje");
                sql.AppendLine(", monto");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_decreto");
                // sql.AppendLine(", fecha_alta");
                // sql.AppendLine(", activo");
                // sql.AppendLine(", anio_desde");
                // sql.AppendLine(", anio_hasta");
                // sql.AppendLine(", observaciones");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @cod_concepto_iyc");
                sql.AppendLine(", @porcentaje");
                sql.AppendLine(", @monto");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_decreto");
                // sql.AppendLine(", @fecha_alta");
                // sql.AppendLine(", @activo");
                // sql.AppendLine(", @anio_desde");
                // sql.AppendLine(", @anio_hasta");
                // sql.AppendLine(", @observaciones");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", obj.cod_concepto_iyc);
                    cmd.Parameters.AddWithValue("@porcentaje", obj.porcentaje);
                    cmd.Parameters.AddWithValue("@monto", obj.monto);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_decreto", obj.nro_decreto);
                    // cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    // cmd.Parameters.AddWithValue("@activo", obj.activo);
                    // cmd.Parameters.AddWithValue("@anio_desde", obj.anio_desde);
                    // cmd.Parameters.AddWithValue("@anio_hasta", obj.anio_hasta);
                    // cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Descadic_x_iyc obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Descadic_x_iyc SET");
                sql.AppendLine("porcentaje=@porcentaje");
                sql.AppendLine(", monto=@monto");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", nro_decreto=@nro_decreto");
                // sql.AppendLine(", activo=@activo");
                // sql.AppendLine(", anio_desde=@anio_desde");
                // sql.AppendLine(", anio_hasta=@anio_hasta");
                // sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_concepto_iyc=@cod_concepto_iyc");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", obj.cod_concepto_iyc);
                    cmd.Parameters.AddWithValue("@porcentaje", obj.porcentaje);
                    cmd.Parameters.AddWithValue("@monto", obj.monto);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_decreto", obj.nro_decreto);
                    //cmd.Parameters.AddWithValue("@activo", obj.activo);
                    // cmd.Parameters.AddWithValue("@anio_desde", obj.anio_desde);
                    // cmd.Parameters.AddWithValue("@anio_hasta", obj.anio_hasta);
                    // cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int legajo, int cod_concepto_iyc)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Descadic_x_iyc ");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_concepto_iyc=@cod_concepto_iyc");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@cod_concepto_iyc", cod_concepto_iyc);
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

