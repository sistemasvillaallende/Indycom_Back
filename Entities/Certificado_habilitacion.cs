using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC.Entities
{


    public class Certificado_habilitacion : DALBase
    {
        public int Legajo { get; set; }
        public int Anio_certificado { get; set; }
        public int Nro_certificado { get; set; }
        public int Nro_sucursal { get; set; }
        public int Cod_rubro { get; set; }
        public string Certificado { get; set; }
        public DateTime Vto_certificado { get; set; }
        public DateTime Fecha_emision { get; set; }
        public Int16 Anulado { get; set; }
        public int id_estado_certificado { get; set; }
        public string url { get; set; }
        public string qr { get; set; }

        public Certificado_habilitacion()
        {

            Legajo = 0;
            Anio_certificado = 0;
            Nro_certificado = 0;
            Nro_sucursal = 0;
            Cod_rubro = 0;
            Certificado = String.Empty;
            Vto_certificado = DateTime.MinValue;
            Fecha_emision = DateTime.Now;
            Anulado = 0;
            id_estado_certificado = 0;
            url = String.Empty;
            qr = String.Empty;
        }

        private static List<Certificado_habilitacion> mapeo(SqlDataReader dr)
        {
            List<Certificado_habilitacion> lst = new List<Certificado_habilitacion>();
            Certificado_habilitacion obj;
            if (dr.HasRows)
            {
                int Legajo = dr.GetOrdinal("Legajo");
                int Anio_certificado = dr.GetOrdinal("Anio_certificado");
                int Nro_certificado = dr.GetOrdinal("Nro_certificado");
                int Nro_sucursal = dr.GetOrdinal("Nro_sucursal");
                int Cod_rubro = dr.GetOrdinal("Cod_rubro");
                int Certificado = dr.GetOrdinal("Certificado");
                int Vto_certificado = dr.GetOrdinal("Vto_certificado");
                int Fecha_emision = dr.GetOrdinal("Fecha_emision");
                int Anulado = dr.GetOrdinal("Anulado");
                int id_estado_certificado = dr.GetOrdinal("id_estado_certificado");
                int url = dr.GetOrdinal("url");
                int qr = dr.GetOrdinal("qr");


                while (dr.Read())
                {
                    obj = new Certificado_habilitacion();
                    if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                    if (!dr.IsDBNull(Anio_certificado)) { obj.Anio_certificado = dr.GetInt32(Anio_certificado); }
                    if (!dr.IsDBNull(Nro_certificado)) { obj.Nro_certificado = dr.GetInt32(Nro_certificado); }
                    if (!dr.IsDBNull(Nro_sucursal)) { obj.Nro_sucursal = dr.GetInt32(Nro_sucursal); }
                    if (!dr.IsDBNull(Cod_rubro)) { obj.Cod_rubro = dr.GetInt32(Cod_rubro); }
                    if (!dr.IsDBNull(Certificado)) { obj.Certificado = dr.GetString(Certificado); }
                    if (!dr.IsDBNull(Vto_certificado)) { obj.Vto_certificado = dr.GetDateTime(Vto_certificado); }
                    if (!dr.IsDBNull(Fecha_emision)) { obj.Fecha_emision = dr.GetDateTime(Fecha_emision); }
                    if (!dr.IsDBNull(Anulado)) { obj.Anulado = dr.GetInt16(Anulado); }
                    if (!dr.IsDBNull(id_estado_certificado)) { obj.id_estado_certificado = dr.GetInt32(id_estado_certificado); }
                    if (!dr.IsDBNull(url)) { obj.url = dr.GetString(url); }
                    if (!dr.IsDBNull(qr)) { obj.qr = dr.GetString(qr); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Certificado_habilitacion> read()
        {
            try
            {
                List<Certificado_habilitacion> lst = new List<Certificado_habilitacion>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM  CERTIFICADO_HABILITACION_IYC";
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

        public static Certificado_habilitacion getByLegajo(int legajo)
        {
            try
            {
                Certificado_habilitacion obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @" SELECT * FROM  CERTIFICADO_HABILITACION_IYC chi where  chi.Legajo = @legajo";

                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Certificado_habilitacion> lst = mapeo(dr);
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


        public static List<Certificado_habilitacionDTO> GetPrincipalByLegajo(int legajo)
        {
            try
            {
                List<Certificado_habilitacionDTO> certificados = new List<Certificado_habilitacionDTO>();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                                SELECT chi.Certificado,
                                    chi.anio_certificado,
                                    chi.Legajo,
                                    chi.Nro_sucursal, 
                                    chi.cod_rubro,
                                    CASE chi.cod_rubro
                                        WHEN 0  THEN i.des_com
                                        ELSE
                                            (SELECT r.concepto 
                                                FROM RUBROS r
                                                WHERE r.cod_rubro=chi.cod_rubro
                                                AND r.activo=1)
                                    END AS des_com,
                                    Emision=CONVERT(VARCHAR(10), chi.fecha_emision, 103),
                                    Vto_certificado=CONVERT(VARCHAR(10), chi.Vto_certificado, 103),
                                    chi.url,
                                    chi.qr
                                FROM CERTIFICADO_HABILITACION_IYC chi
                                LEFT JOIN INDYCOM i ON i.Legajo = chi.Legajo
                                WHERE chi.Legajo = @legajo
                                AND chi.nro_sucursal = 0
                                ORDER BY chi.Legajo, chi.Vto_certificado";

                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int Certificado = dr.GetOrdinal("Certificado");
                        int AnioCertificado = dr.GetOrdinal("anio_certificado");
                        int Legajo = dr.GetOrdinal("Legajo");
                        int NroSucursal = dr.GetOrdinal("Nro_Sucursal");
                        int CodRubro = dr.GetOrdinal("cod_rubro");
                        int DesCom = dr.GetOrdinal("des_com");
                        int Emision = dr.GetOrdinal("Emision");
                        int VtoCertificado = dr.GetOrdinal("Vto_certificado");
                        int Url = dr.GetOrdinal("url");
                        int Qr = dr.GetOrdinal("qr");

                        while (dr.Read())
                        {

                            Certificado_habilitacionDTO obj = new Certificado_habilitacionDTO();
                            if (!dr.IsDBNull(Certificado)) { obj.Certificado = dr.GetString(Certificado); }
                            if (!dr.IsDBNull(AnioCertificado)) { obj.AnioCertificado = dr.GetInt32(AnioCertificado); }
                            if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                            if (!dr.IsDBNull(NroSucursal)) { obj.NroSucursal = dr.GetInt32(NroSucursal); }
                            if (!dr.IsDBNull(CodRubro)) { obj.CodRubro = dr.GetInt32(CodRubro); }
                            if (!dr.IsDBNull(DesCom)) { obj.DesCom = dr.GetString(DesCom); }
                            if (!dr.IsDBNull(Emision)) { obj.Emision = dr.GetString(Emision); }
                            if (!dr.IsDBNull(VtoCertificado)) { obj.VtoCertificado = dr.GetString(VtoCertificado); }
                            if (!dr.IsDBNull(Url)) { obj.Url = dr.GetString(Url); }
                            if (!dr.IsDBNull(Qr)) { obj.Qr = dr.GetString(Qr); }

                            certificados.Add(obj);
                        }
                    }
                }
                return certificados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Certificado_habilitacionDTO> GetSucursalByLegajo(int legajo)
        {
            try
            {
                List<Certificado_habilitacionDTO> certificados = new List<Certificado_habilitacionDTO>();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                                SELECT chi.Certificado,
                                        chi.anio_certificado,
                                        chi.Legajo,
                                        chi.Nro_sucursal, 
                                            chi.cod_rubro,
                                        CASE chi.cod_rubro
                                        WHEN 0  THEN i.des_com
                                        ELSE	
                                            (SELECT r.concepto
                                            FROM RUBROS r
                                            WHERE r.cod_rubro=chi.cod_rubro
                                                AND r.activo=1)
                                        END
                                        AS des_com
                                        , Emision=CONVERT(VARCHAR(10), chi.fecha_emision, 103),
                                        Vto_certificado=CONVERT(VARCHAR(10), chi.Vto_certificado, 103),
                                        chi.url,
                                        chi.qr
                                    FROM CERTIFICADO_HABILITACION_IYC chi
                                    LEFT JOIN SUCURSALES_INDYCOM  i
                                        ON i.Legajo = chi.Legajo
                                        AND chi.Nro_sucursal=i.Nro_sucursal
                                    WHERE chi.Legajo= @legajo
                                    and chi.nro_sucursal<>0

                                    ORDER BY chi.Legajo,chi.Nro_sucursal,chi.Vto_certificado
                                    ";

                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int Certificado = dr.GetOrdinal("Certificado");
                        int AnioCertificado = dr.GetOrdinal("anio_certificado");
                        int Legajo = dr.GetOrdinal("Legajo");
                        int NroSucursal = dr.GetOrdinal("Nro_Sucursal");
                        int CodRubro = dr.GetOrdinal("cod_rubro");
                        int DesCom = dr.GetOrdinal("des_com");
                        int Emision = dr.GetOrdinal("Emision");
                        int VtoCertificado = dr.GetOrdinal("Vto_certificado");
                        int Url = dr.GetOrdinal("url");
                        int Qr = dr.GetOrdinal("qr");

                        while (dr.Read())
                        {

                            Certificado_habilitacionDTO obj = new Certificado_habilitacionDTO();
                            if (!dr.IsDBNull(Certificado)) { obj.Certificado = dr.GetString(Certificado); }
                            if (!dr.IsDBNull(AnioCertificado)) { obj.AnioCertificado = dr.GetInt32(AnioCertificado); }
                            if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                            if (!dr.IsDBNull(NroSucursal)) { obj.NroSucursal = dr.GetInt32(NroSucursal); }
                            if (!dr.IsDBNull(CodRubro)) { obj.CodRubro = dr.GetInt32(CodRubro); }
                            if (!dr.IsDBNull(DesCom)) { obj.DesCom = dr.GetString(DesCom); }
                            if (!dr.IsDBNull(Emision)) { obj.Emision = dr.GetString(Emision); }
                            if (!dr.IsDBNull(VtoCertificado)) { obj.VtoCertificado = dr.GetString(VtoCertificado); }
                            if (!dr.IsDBNull(Url)) { obj.Url = dr.GetString(Url); }
                            if (!dr.IsDBNull(Qr)) { obj.Qr = dr.GetString(Qr); }

                            certificados.Add(obj);
                        }
                    }
                }
                return certificados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int ObtenerUltimoNroCertificado(SqlConnection con, SqlTransaction trx)
        {
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Nro_certificado), 0) FROM  CERTIFICADO_HABILITACION_IYC ", con, trx);
            return (int)cmd.ExecuteScalar();
        }


        public static int insert(int legajo, int nro_certificado, int anio_certificado, int nro_sucursal, int cod_rubro, string certificado, DateTime fecha_emision, DateTime vto_certificado, string qr, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                int result = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @" 
                        INSERT INTO CERTIFICADO_HABILITACION_IYC
                        (
                            Legajo,
                            Nro_certificado,
                            Anio_certificado,
                            Nro_sucursal,
                            Cod_rubro,
                            Certificado,
                            Vto_certificado,
                            Fecha_emision,
                            Anulado, 
                            id_estado_certificado,
                            url,
                            qr
                        )
                        VALUES
                        (
                            @legajo,
                            @nro_certificado,
                            @anio_certificado,
                            @nro_sucursal,
                            @cod_rubro,
                            @certificado,
                            @vto_certificado,
                            @fecha_emision,
                            0,
                            @id_estado_certificado,
                            @url,
                            @qr
                        )

                                ";

                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@nro_certificado", nro_certificado);
                cmd.Parameters.AddWithValue("@anio_certificado", anio_certificado);
                cmd.Parameters.AddWithValue("@Nro_sucursal", nro_sucursal);
                cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                cmd.Parameters.AddWithValue("@certificado", certificado);
                cmd.Parameters.AddWithValue("@vto_certificado", vto_certificado);
                cmd.Parameters.AddWithValue("@Fecha_emision", fecha_emision);
                cmd.Parameters.AddWithValue("@id_estado_certificado", 0);
                cmd.Parameters.AddWithValue("@url", "https://tinyurl.com/2x3jfux5?");
                cmd.Parameters.AddWithValue("@qr", qr);

                //cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<Certificado_habilitacionImp> GetCertificadoPrincipal(int legajo)
        {
            try
            {
                List<Certificado_habilitacionImp> certificados = new List<Certificado_habilitacionImp>();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"                                                            
                                SELECT 
                                    chi.Legajo, 
                                    chi.Certificado,
                                    COALESCE(vd.NOMBRE, b.NOMBRE) AS NOMBRE,
                                    vd.APELLIDO,
                                    i.nom_fantasia,
                                    i.nro_cuit,
                                    i.nom_calle_dom_esp,
                                    i.nro_dom_esp,
                                    chi.anio_certificado,
                                    chi.Nro_sucursal, 
                                    chi.cod_rubro,
                                    CASE chi.cod_rubro
                                        WHEN 0 THEN i.des_com
                                        ELSE (
                                            SELECT r.concepto 
                                            FROM RUBROS r
                                            WHERE r.cod_rubro = chi.cod_rubro
                                            AND r.activo = 1
                                        )
                                    END AS des_com,
                                    Emision = CONVERT(VARCHAR(10), chi.fecha_emision, 103),
                                    Vto_certificado = CONVERT(VARCHAR(10), chi.Vto_certificado, 103),
                                    chi.url,
                                    chi.qr,
                                    COALESCE(vd.apellido + ', ' + vd.nombre, b.NOMBRE) AS contribuyente
                                FROM CERTIFICADO_HABILITACION_IYC chi
                                LEFT JOIN INDYCOM i 
                                    ON i.Legajo = chi.Legajo
                                LEFT JOIN VECINO_DIGITAL vd 
                                    ON vd.CUIT = i.nro_cuit
                                LEFT JOIN (
                                    SELECT CUIT, MAX(NOMBRE) AS NOMBRE
                                    FROM BADEC
                                    GROUP BY CUIT
                                ) b ON b.CUIT = i.nro_cuit
                                WHERE chi.Legajo = @legajo
                                AND chi.nro_sucursal = 0
                                ORDER BY chi.Legajo, chi.Vto_certificado;
                                    ";

                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int Legajo = dr.GetOrdinal("Legajo");
                        int Certificado = dr.GetOrdinal("Certificado");
                        int Nombre = dr.GetOrdinal("NOMBRE");
                        int Apellido = dr.GetOrdinal("APELLIDO");
                        int Nom_fantasia = dr.GetOrdinal("nom_fantasia");
                        int Nro_cuit = dr.GetOrdinal("nro_cuit");
                        int Nombre_calle = dr.GetOrdinal("nom_calle_dom_esp");
                        int Nro_domicilio = dr.GetOrdinal("nro_dom_esp");
                        int AnioCertificado = dr.GetOrdinal("anio_certificado");
                        int NroSucursal = dr.GetOrdinal("Nro_Sucursal");
                         int CodRubro = dr.GetOrdinal("cod_rubro");
                        int DesCom = dr.GetOrdinal("des_com");
                        int Emision = dr.GetOrdinal("Emision");
                        int VtoCertificado = dr.GetOrdinal("Vto_certificado");
                        int Url = dr.GetOrdinal("url");
                        int Qr = dr.GetOrdinal("qr");

                        while (dr.Read())
                        {

                            Certificado_habilitacionImp obj = new Certificado_habilitacionImp();
                            if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                            if (!dr.IsDBNull(Certificado)) { obj.Certificado = dr.GetString(Certificado); }
                            if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                            if (!dr.IsDBNull(Apellido)) { obj.Apellido = dr.GetString(Apellido); }
                            if (!dr.IsDBNull(Nom_fantasia)) { obj.Nom_fantasia = dr.GetString(Nom_fantasia); }
                            if (!dr.IsDBNull(Nro_cuit)) { obj.Nro_cuit = dr.GetString(Nro_cuit); }
                            if (!dr.IsDBNull(Nombre_calle)) { obj.Nombre_calle = dr.GetString(Nombre_calle); }
                            if (!dr.IsDBNull(Nro_domicilio)) { obj.Nro_domicilio = dr.GetInt32(Nro_domicilio); }
                            if (!dr.IsDBNull(AnioCertificado)) { obj.Anio_certificado = dr.GetInt32(AnioCertificado); }
                            if (!dr.IsDBNull(NroSucursal)) { obj.Nro_sucursal = dr.GetInt32(NroSucursal); }
                            if (!dr.IsDBNull(CodRubro)) { obj.Cod_rubro = dr.GetInt32(CodRubro); }
                            if (!dr.IsDBNull(DesCom)) { obj.Des_comercio = dr.GetString(DesCom); }
                            if (!dr.IsDBNull(Emision)) { obj.Emision = dr.GetString(Emision); }
                            if (!dr.IsDBNull(VtoCertificado)) { obj.VtoCertificado = dr.GetString(VtoCertificado); }
                            if (!dr.IsDBNull(Url)) { obj.Url = dr.GetString(Url); }
                            if (!dr.IsDBNull(Qr)) { obj.Qr = dr.GetString(Qr); }

                            certificados.Add(obj);
                        }
                    }
                }
                return certificados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public static List<Certificado_habilitacionImp> GetCertificadoSucursal(int legajo)
        {
            try
            {
                List<Certificado_habilitacionImp> certificados = new List<Certificado_habilitacionImp>();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                                SELECT DISTINCT
                                        chi.Legajo,    
                                        chi.Certificado,
                                        COALESCE(vd.NOMBRE, b.NOMBRE) AS NOMBRE,
                                        vd.APELLIDO,
                                        si.Nom_fantasia,
                                        i.nro_cuit,  
                                        si.Nom_calle,
                                        si.Nro_dom,
                                        chi.anio_certificado,
                                        chi.Nro_sucursal, 
                                        chi.cod_rubro,
                                        CASE chi.cod_rubro
                                            WHEN 0 THEN si.des_com
                                            ELSE (
                                                SELECT r.concepto
                                                FROM RUBROS r
                                                WHERE r.cod_rubro = chi.cod_rubro
                                                AND r.activo = 1
                                            )
                                        END AS des_com,
                                        Emision = CONVERT(VARCHAR(10), chi.fecha_emision, 103),
                                        Vto_certificado = CONVERT(VARCHAR(10), chi.Vto_certificado, 103),
                                        chi.url,
                                        chi.qr
                                    FROM CERTIFICADO_HABILITACION_IYC chi
                                    LEFT JOIN SUCURSALES_INDYCOM si 
                                        ON si.Legajo = chi.Legajo
                                        AND si.Nro_sucursal = chi.Nro_sucursal  
                                    LEFT JOIN INDYCOM i 
                                        ON i.Legajo = chi.Legajo
                                    LEFT JOIN VECINO_DIGITAL vd 
                                        ON vd.CUIT = i.nro_cuit
                                    LEFT JOIN (
                                        SELECT CUIT, MAX(NOMBRE) AS NOMBRE
                                        FROM BADEC
                                        GROUP BY CUIT
                                    ) b ON b.CUIT = i.nro_cuit
                                    WHERE chi.Legajo = @legajo
                                    AND chi.nro_sucursal <> 0
                                    ORDER BY chi.Legajo, chi.Nro_sucursal, Vto_certificado;
                                    ";

                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int Legajo = dr.GetOrdinal("Legajo");
                        int Certificado = dr.GetOrdinal("Certificado");
                        int Nombre = dr.GetOrdinal("NOMBRE");
                        int Apellido = dr.GetOrdinal("APELLIDO");
                        int Nom_fantasia = dr.GetOrdinal("Nom_fantasia");
                        int Nro_cuit = dr.GetOrdinal("nro_cuit");
                        int Nombre_calle = dr.GetOrdinal("Nom_calle");
                        int Nro_domicilio = dr.GetOrdinal("Nro_dom");
                        int AnioCertificado = dr.GetOrdinal("anio_certificado");
                        int NroSucursal = dr.GetOrdinal("Nro_Sucursal");
                         int CodRubro = dr.GetOrdinal("cod_rubro");
                        int DesCom = dr.GetOrdinal("des_com");
                        int Emision = dr.GetOrdinal("Emision");
                        int VtoCertificado = dr.GetOrdinal("Vto_certificado");
                        int Url = dr.GetOrdinal("url");
                        int Qr = dr.GetOrdinal("qr");

                        while (dr.Read())
                        {

                            Certificado_habilitacionImp obj = new Certificado_habilitacionImp();
                            if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                            if (!dr.IsDBNull(Certificado)) { obj.Certificado = dr.GetString(Certificado); }
                            if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                            if (!dr.IsDBNull(Apellido)) { obj.Apellido = dr.GetString(Apellido); }
                            if (!dr.IsDBNull(Nom_fantasia)) { obj.Nom_fantasia = dr.GetString(Nom_fantasia); }
                            if (!dr.IsDBNull(Nro_cuit)) { obj.Nro_cuit = dr.GetString(Nro_cuit); }
                            if (!dr.IsDBNull(Nombre_calle)) { obj.Nombre_calle = dr.GetString(Nombre_calle); }
                            if (!dr.IsDBNull(Nro_domicilio)) { obj.Nro_domicilio = dr.GetInt32(Nro_domicilio); }
                            if (!dr.IsDBNull(AnioCertificado)) { obj.Anio_certificado = dr.GetInt32(AnioCertificado); }
                            if (!dr.IsDBNull(NroSucursal)) { obj.Nro_sucursal = dr.GetInt32(NroSucursal); }
                            if (!dr.IsDBNull(CodRubro)) { obj.Cod_rubro = dr.GetInt32(CodRubro); }
                            if (!dr.IsDBNull(DesCom)) { obj.Des_comercio = dr.GetString(DesCom); }
                            if (!dr.IsDBNull(Emision)) { obj.Emision = dr.GetString(Emision); }
                            if (!dr.IsDBNull(VtoCertificado)) { obj.VtoCertificado = dr.GetString(VtoCertificado); }
                            if (!dr.IsDBNull(Url)) { obj.Url = dr.GetString(Url); }
                            if (!dr.IsDBNull(Qr)) { obj.Qr = dr.GetString(Qr); }

                            certificados.Add(obj);
                        }
                    }
                }
                return certificados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
