using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Web_Api_IyC.Entities.AUDITORIA
{
    public class AuditoriaD : DALBase
    {
        public static void InsertAuditoria(Auditoria oAudita)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AUDITOR_V2";
                    //cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(oAudita.fecha, culturaFecArgentina).ToString()));
                    //la fecha se setea dentro del store
                    cmd.Parameters.Add(new SqlParameter("@usuario", oAudita.usuario));
                    cmd.Parameters.Add(new SqlParameter("@proceso", oAudita.proceso.ToString().ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@identificacion", oAudita.identificacion));
                    cmd.Parameters.Add(new SqlParameter("@autorizacion", string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@observaciones", oAudita.observaciones));
                    cmd.Parameters.Add(new SqlParameter("@detalle", oAudita.detalle));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            { throw; }
        }
        public static void InsertAuditoria(Auditoria oAudita, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                using (SqlCommand cmd = new SqlCommand("AUDITOR_V2", connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(oAudita.fecha, culturaFecArgentina).ToString()));
                    //la fecha se setea dentro del store
                    cmd.Parameters.Add(new SqlParameter("@usuario", oAudita.usuario));
                    cmd.Parameters.Add(new SqlParameter("@proceso", oAudita.proceso.ToString().ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@identificacion", oAudita.identificacion));
                    cmd.Parameters.Add(new SqlParameter("@autorizacion", string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@observaciones", oAudita.observaciones));
                    cmd.Parameters.Add(new SqlParameter("@detalle", oAudita.detalle));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}

