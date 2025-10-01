using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC.Entities
{
    public class Resolucion_habilitacion : DALBase
    {
        public int Legajo { get; set; }
        public int Nro_sucursal { get; set; }
        public int Nro_item { get; set; }
        public string Nro_res { get; set; }
        public DateTime Fecha_inspeccion { get; set; }
        public DateTime Fecha_hab { get; set; }
        public Boolean Transporte { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }

        public Resolucion_habilitacion()
        {

            Legajo = 0;
            Nro_sucursal = 0;
            Nro_item = 0;
            Nro_res = String.Empty;
            Fecha_inspeccion = DateTime.MinValue;
            Fecha_hab = DateTime.Now;
            Transporte = false;
            Usuario = String.Empty;
            Fecha = DateTime.Now;
        }


        private static List<Resolucion_habilitacion> mapeo(SqlDataReader dr)
        {
            List<Resolucion_habilitacion> lst = new List<Resolucion_habilitacion>();
            Resolucion_habilitacion obj;
            if (dr.HasRows)
            {
                int Legajo = dr.GetOrdinal("Legajo");
                int Nro_sucursal = dr.GetOrdinal("Nro_sucursal");
                int Nro_item = dr.GetOrdinal("Nro_item");
                int Nro_res = dr.GetOrdinal("Nro_res");
                int Fecha_inspeccion = dr.GetOrdinal("Fecha_inspeccion");
                int Fecha_hab = dr.GetOrdinal("Fecha_hab");
                int Transporte = dr.GetOrdinal("Transporte");
                int Usuario = dr.GetOrdinal("Usuario");
                int Fecha = dr.GetOrdinal("Fecha");


                while (dr.Read())
                {
                    obj = new Resolucion_habilitacion();
                    if (!dr.IsDBNull(Legajo)) { obj.Legajo = dr.GetInt32(Legajo); }
                    if (!dr.IsDBNull(Nro_sucursal)) { obj.Nro_sucursal = dr.GetInt32(Nro_sucursal); }
                    if (!dr.IsDBNull(Nro_item)) { obj.Nro_item = dr.GetInt32(Nro_item); }
                    if (!dr.IsDBNull(Nro_res)) { obj.Nro_res = dr.GetString(Nro_res); }
                    if (!dr.IsDBNull(Fecha_inspeccion)) { obj.Fecha_inspeccion = dr.GetDateTime(Fecha_inspeccion); }
                    if (!dr.IsDBNull(Fecha_hab)) { obj.Fecha_hab = dr.GetDateTime(Fecha_hab); }
                    if (!dr.IsDBNull(Transporte)) { obj.Transporte = dr.GetBoolean(Transporte); }
                    if (!dr.IsDBNull(Usuario)) { obj.Usuario = dr.GetString(Usuario); }
                    if (!dr.IsDBNull(Fecha)) { obj.Fecha = dr.GetDateTime(Fecha); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Resolucion_habilitacion> read()
        {
            try
            {
                List<Resolucion_habilitacion> lst = new List<Resolucion_habilitacion>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM  RESOLUCION_HABILITACION";
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


        public static List<Resolucion_habilitacion> getByLegajo(int legajo)
        {
            try
            {
                List<Resolucion_habilitacion> lst = new List<Resolucion_habilitacion>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @" SELECT *
                                FROM RESOLUCION_HABILITACION
                                WHERE legajo= @legajo
                                ORDER BY legajo,nro_sucursal
                                ";

                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insert(int Legajo, int Nro_sucursal, int Nro_item, string Nro_res, DateTime Fecha_inspeccion,
            DateTime Fecha_hab, bool Transporte, string Usuario, DateTime Fecha, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @" 
                                INSERT INTO RESOLUCION_HABILITACION
                                (
                                    Legajo
                                    ,Nro_sucursal
                                    ,Nro_item
                                    ,Nro_res
                                    ,Fecha_inspeccion
                                    ,Fecha_hab
                                    ,Transporte
                                    ,Usuario
                                    ,Fecha
                                )
                                VALUES
                                (   
                                    @Legajo,
                                    @Nro_sucursal,
                                    @Nro_item,
                                    @Nro_res, 
                                    @Fecha_inspeccion, 
                                    @Fecha_hab,  
                                    @Transporte, 
                                    @Usuario, 
                                    @Fecha 
                                ) ";

                cmd.Parameters.AddWithValue("@Legajo", Legajo);
                cmd.Parameters.AddWithValue("@Nro_sucursal", Nro_sucursal);
                cmd.Parameters.AddWithValue("@Nro_item", Nro_item);
                cmd.Parameters.AddWithValue("@Nro_res", Nro_res);
                cmd.Parameters.AddWithValue("@Fecha_inspeccion", Fecha_inspeccion);
                cmd.Parameters.AddWithValue("@Fecha_hab", Fecha_hab);
                cmd.Parameters.AddWithValue("@Transporte", Transporte);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ObtenerUltimoNroItem(int Legajo, SqlConnection con, SqlTransaction trx)
        {
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Nro_item), 0) FROM  RESOLUCION_HABILITACION  where legajo=@Legajo", con, trx);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);

            return (int)cmd.ExecuteScalar();
        }



        // public static Resolucion_habilitacion_imprimir GetResolucion(int legajo)
        // {
        //     try
        //     {

        //         using (SqlConnection con = GetConnection())
        //         {
        //             SqlCommand cmd = con.CreateCommand();
        //             cmd.CommandType = CommandType.Text;
        //             cmd.CommandText = @"
        //                             SELECT  
        //                                 I.Legajo,
        //                                 I.Fecha_alta,
        //                                 I.Nro_exp_mesa_ent,
        //                                 I.Nro_cuit,
        //                                 VD.Nombre,
        //                                 VD.Apellido,
        //                                 I.Des_com,
        //                                 I.Nom_calle_dom_esp,
        //                                 I.Nom_barrio_dom_esp,
        //                                 I.nro_dom_esp,
        //                                 RH.Fecha_inspeccion,
        //                                 RH.Fecha_hab,
        //                                 RH.Nro_sucursal,
        //                                 RH.Nro_res,
        //                                 RH.Transporte
        //                             FROM INDYCOM I
        //                             OUTER APPLY (
        //                                 SELECT TOP 1 *
        //                                 FROM RESOLUCION_HABILITACION RH
        //                                 WHERE RH.Legajo = I.Legajo
        //                                 ORDER BY RH.Nro_item DESC
        //                             ) RH
        //                             LEFT JOIN VECINO_DIGITAL VD 
        //                                 ON VD.Cuit = I.Nro_cuit
        //                             WHERE I.Legajo = @Legajo;
        //                             ";

        //             cmd.Parameters.AddWithValue("@Legajo", legajo);

        //             con.Open();
        //             SqlDataReader dr = cmd.ExecuteReader();

        //             if (dr.Read())
        //             {
        //                 int ordLegajo = dr.GetOrdinal("Legajo");
        //                 int ordFechaAlta = dr.GetOrdinal("Fecha_alta");
        //                 int ordNroExpMesaEnt = dr.GetOrdinal("Nro_exp_mesa_ent");
        //                 int ordNroCuit = dr.GetOrdinal("Nro_cuit");
        //                 int ordNombre = dr.GetOrdinal("Nombre");
        //                 int ordApellido = dr.GetOrdinal("Apellido");
        //                 int ordDesCom = dr.GetOrdinal("Des_com");
        //                 int ordNomCalle = dr.GetOrdinal("Nom_calle_dom_esp");
        //                 int ordNomBarrio = dr.GetOrdinal("Nom_barrio_dom_esp");
        //                 int ordNroDom = dr.GetOrdinal("nro_dom_esp");
        //                 int ordFechaInsp = dr.GetOrdinal("Fecha_inspeccion");
        //                 int ordFechaHab = dr.GetOrdinal("Fecha_hab");
        //                 int ordNroSucursal = dr.GetOrdinal("Nro_sucursal");
        //                 int ordNroRes = dr.GetOrdinal("Nro_res");
        //                 int ordTransporte = dr.GetOrdinal("Transporte");

        //                 Resolucion_habilitacion_imprimir obj = new Resolucion_habilitacion_imprimir();

        //                 if (!dr.IsDBNull(ordLegajo)) obj.Legajo = dr.GetInt32(ordLegajo);
        //                 if (!dr.IsDBNull(ordFechaAlta)) obj.Fecha_alta = dr.GetDateTime(ordFechaAlta);
        //                 if (!dr.IsDBNull(ordNroExpMesaEnt)) obj.Nro_exp_mesa_ent = dr.GetString(ordNroExpMesaEnt);
        //                 if (!dr.IsDBNull(ordNroCuit)) obj.Nro_cuit = dr.GetString(ordNroCuit);
        //                 if (!dr.IsDBNull(ordNombre)) obj.Nombre = dr.GetString(ordNombre);
        //                 if (!dr.IsDBNull(ordApellido)) obj.Apellido = dr.GetString(ordApellido);
        //                 if (!dr.IsDBNull(ordDesCom)) obj.Des_com = dr.GetString(ordDesCom);
        //                 if (!dr.IsDBNull(ordNomCalle)) obj.Nom_calle_dom_esp = dr.GetString(ordNomCalle);
        //                 if (!dr.IsDBNull(ordNomBarrio)) obj.Nom_barrio_dom_esp = dr.GetString(ordNomBarrio);
        //                 if (!dr.IsDBNull(ordNroDom)) obj.nro_dom_esp = dr.GetInt32(ordNroDom);
        //                 if (!dr.IsDBNull(ordFechaInsp)) obj.Fecha_inspeccion = dr.GetDateTime(ordFechaInsp);
        //                 if (!dr.IsDBNull(ordFechaHab)) obj.Fecha_hab = dr.GetDateTime(ordFechaHab);
        //                 if (!dr.IsDBNull(ordNroSucursal)) obj.Nro_sucursal = dr.GetInt32(ordNroSucursal);
        //                 if (!dr.IsDBNull(ordNroRes)) obj.Nro_res = dr.GetString(ordNroRes);
        //                 if (!dr.IsDBNull(ordTransporte)) obj.Transporte = dr.GetBoolean(ordTransporte);

        //                 return obj;

        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw;
        //     }

        //     return null;
        // }

        public static Resolucion_habilitacion_imprimir GetResolucion(int legajo)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                SELECT  
                    I.Legajo,
                    I.Fecha_alta,
                    I.Nro_exp_mesa_ent,
                    I.Nro_cuit,
                    VD.Nombre,
                    VD.Apellido,
                    I.Des_com,
                    I.Nom_calle_dom_esp,
                    I.Nom_barrio_dom_esp,
                    I.nro_dom_esp,
                    RH.Fecha_inspeccion,
                    RH.Fecha_hab,
                    RH.Nro_sucursal,
                    RH.Nro_res,
                    RH.Transporte
                FROM INDYCOM I
                OUTER APPLY (
                    SELECT TOP 1 *
                    FROM RESOLUCION_HABILITACION RH
                    WHERE RH.Legajo = I.Legajo
                    ORDER BY RH.Nro_item DESC
                ) RH
                LEFT JOIN VECINO_DIGITAL VD 
                    ON VD.Cuit = I.Nro_cuit
                WHERE I.Legajo = @Legajo;";
                    cmd.Parameters.AddWithValue("@Legajo", legajo);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.Read()) return null;

                    var obj = new Resolucion_habilitacion_imprimir();

                    int ordLegajo = dr.GetOrdinal("Legajo");
                    int ordFechaAlta = dr.GetOrdinal("Fecha_alta");
                    int ordNroExpMesaEnt = dr.GetOrdinal("Nro_exp_mesa_ent");
                    int ordNroCuit = dr.GetOrdinal("Nro_cuit");
                    int ordNombre = dr.GetOrdinal("Nombre");
                    int ordApellido = dr.GetOrdinal("Apellido");
                    int ordDesCom = dr.GetOrdinal("Des_com");
                    int ordNomCalle = dr.GetOrdinal("Nom_calle_dom_esp");
                    int ordNomBarrio = dr.GetOrdinal("Nom_barrio_dom_esp");
                    int ordNroDom = dr.GetOrdinal("nro_dom_esp");
                    int ordFechaInsp = dr.GetOrdinal("Fecha_inspeccion");
                    int ordFechaHab = dr.GetOrdinal("Fecha_hab");
                    int ordNroSucursal = dr.GetOrdinal("Nro_sucursal");
                    int ordNroRes = dr.GetOrdinal("Nro_res");
                    int ordTransporte = dr.GetOrdinal("Transporte");

                    if (!dr.IsDBNull(ordLegajo)) obj.Legajo = dr.GetInt32(ordLegajo);
                    if (!dr.IsDBNull(ordFechaAlta)) obj.Fecha_alta = dr.GetDateTime(ordFechaAlta);
                    if (!dr.IsDBNull(ordNroExpMesaEnt)) obj.Nro_exp_mesa_ent = dr.GetString(ordNroExpMesaEnt);
                    if (!dr.IsDBNull(ordNroCuit)) obj.Nro_cuit = dr.GetString(ordNroCuit);
                    if (!dr.IsDBNull(ordNombre)) obj.Nombre = dr.GetString(ordNombre);
                    if (!dr.IsDBNull(ordApellido)) obj.Apellido = dr.GetString(ordApellido);
                    if (!dr.IsDBNull(ordDesCom)) obj.Des_com = dr.GetString(ordDesCom);
                    if (!dr.IsDBNull(ordNomCalle)) obj.Nom_calle_dom_esp = dr.GetString(ordNomCalle);
                    if (!dr.IsDBNull(ordNomBarrio)) obj.Nom_barrio_dom_esp = dr.GetString(ordNomBarrio);
                    if (!dr.IsDBNull(ordNroDom)) obj.nro_dom_esp = dr.GetInt32(ordNroDom);
                    if (!dr.IsDBNull(ordFechaInsp)) obj.Fecha_inspeccion = dr.GetDateTime(ordFechaInsp);
                    if (!dr.IsDBNull(ordFechaHab)) obj.Fecha_hab = dr.GetDateTime(ordFechaHab);
                    if (!dr.IsDBNull(ordNroSucursal)) obj.Nro_sucursal = dr.GetInt32(ordNroSucursal);
                    if (!dr.IsDBNull(ordNroRes)) obj.Nro_res = dr.GetString(ordNroRes);
                    if (!dr.IsDBNull(ordTransporte)) obj.Transporte = dr.GetBoolean(ordTransporte);

                    dr.Close(); 

                    if (obj.Transporte)
                    {
                        SqlCommand cmdT = con.CreateCommand();
                        cmdT.CommandType = CommandType.Text;
                        cmdT.CommandText = @"
                    SELECT TOP 1 Marca, Modelo, Anio, Dominio
                    FROM TRANSPORTES
                    WHERE Legajo = @Legajo;";
                        cmdT.Parameters.AddWithValue("@Legajo", legajo);

                        using (var drT = cmdT.ExecuteReader())
                        {
                            if (drT.Read())
                            {
                                int ordMarca = drT.GetOrdinal("Marca");
                                int ordModelo = drT.GetOrdinal("Modelo");
                                int ordAnio = drT.GetOrdinal("Anio");
                                int ordDominio = drT.GetOrdinal("Dominio");

                                if (!drT.IsDBNull(ordMarca)) obj.Marca = drT.GetString(ordMarca);
                                if (!drT.IsDBNull(ordModelo)) obj.Modelo = drT.GetString(ordModelo);
                                if (!drT.IsDBNull(ordAnio)) obj.Anio = drT.GetInt32(ordAnio);
                                if (!drT.IsDBNull(ordDominio)) obj.Dominio = drT.GetString(ordDominio);
                            }
                        }
                    }

                    return obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Resolucion_habilitacion_imprimir> GetAllResolucion(int legajo)
        {
            try
            {
                List<Resolucion_habilitacion_imprimir> lst = new List<Resolucion_habilitacion_imprimir>();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                              SELECT 			I.Legajo,
		                                        I.Fecha_alta,
		                                        I.Nro_exp_mesa_ent,
		                                        I.Nro_cuit,
		                                        VD.Nombre,
		                                        VD.Apellido,
		                                        I.Des_com,
		                                        I.Nom_calle_dom_esp,
		                                        I.Nom_barrio_dom_esp,
		                                        I.nro_dom_esp,
		                                        RH.Fecha_inspeccion,
		                                        RH.Fecha_hab,
		                                        RH.Nro_sucursal,
		                                        RH.Nro_res,
		                                        RH.Transporte,
                                                T.Marca,
                                                T.Modelo,
                                                T.Anio,
                                                T.Dominio
		                                    FROM INDYCOM I
		                                    OUTER APPLY (
		                                        SELECT  *
		                                        FROM RESOLUCION_HABILITACION RH
		                                        WHERE RH.Legajo = I.Legajo		                                   
		                                    ) RH
		                                    LEFT JOIN VECINO_DIGITAL VD 
		                                        ON VD.Cuit = I.Nro_cuit
                                            LEFT JOIN TRANSPORTES T
	                                            ON T.Legajo = I.Legajo
		                                    WHERE I.Legajo = @Legajo
                                    ";

                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ordLegajo = dr.GetOrdinal("Legajo");
                        int ordFechaAlta = dr.GetOrdinal("Fecha_alta");
                        int ordNroExpMesaEnt = dr.GetOrdinal("Nro_exp_mesa_ent");
                        int ordNroCuit = dr.GetOrdinal("Nro_cuit");
                        int ordNombre = dr.GetOrdinal("Nombre");
                        int ordApellido = dr.GetOrdinal("Apellido");
                        int ordDesCom = dr.GetOrdinal("Des_com");
                        int ordNomCalle = dr.GetOrdinal("Nom_calle_dom_esp");
                        int ordNomBarrio = dr.GetOrdinal("Nom_barrio_dom_esp");
                        int ordNroDom = dr.GetOrdinal("nro_dom_esp");
                        int ordFechaInsp = dr.GetOrdinal("Fecha_inspeccion");
                        int ordFechaHab = dr.GetOrdinal("Fecha_hab");
                        int ordNroSucursal = dr.GetOrdinal("Nro_sucursal");
                        int ordNroRes = dr.GetOrdinal("Nro_res");
                        int ordTransporte = dr.GetOrdinal("Transporte");
                        int ordMarca = dr.GetOrdinal("Marca");
                        int ordModelo = dr.GetOrdinal("Modelo");
                        int ordAnio = dr.GetOrdinal("Anio");
                        int ordDominio = dr.GetOrdinal("Dominio");

                        while (dr.Read())
                        {
                            Resolucion_habilitacion_imprimir obj = new Resolucion_habilitacion_imprimir();
                            if (!dr.IsDBNull(ordLegajo)) obj.Legajo = dr.GetInt32(ordLegajo);
                            if (!dr.IsDBNull(ordFechaAlta)) obj.Fecha_alta = dr.GetDateTime(ordFechaAlta);
                            if (!dr.IsDBNull(ordNroExpMesaEnt)) obj.Nro_exp_mesa_ent = dr.GetString(ordNroExpMesaEnt);
                            if (!dr.IsDBNull(ordNroCuit)) obj.Nro_cuit = dr.GetString(ordNroCuit);
                            if (!dr.IsDBNull(ordNombre)) obj.Nombre = dr.GetString(ordNombre);
                            if (!dr.IsDBNull(ordApellido)) obj.Apellido = dr.GetString(ordApellido);
                            if (!dr.IsDBNull(ordDesCom)) obj.Des_com = dr.GetString(ordDesCom);
                            if (!dr.IsDBNull(ordNomCalle)) obj.Nom_calle_dom_esp = dr.GetString(ordNomCalle);
                            if (!dr.IsDBNull(ordNomBarrio)) obj.Nom_barrio_dom_esp = dr.GetString(ordNomBarrio);
                            if (!dr.IsDBNull(ordNroDom)) obj.nro_dom_esp = dr.GetInt32(ordNroDom);
                            if (!dr.IsDBNull(ordFechaInsp)) obj.Fecha_inspeccion = dr.GetDateTime(ordFechaInsp);
                            if (!dr.IsDBNull(ordFechaHab)) obj.Fecha_hab = dr.GetDateTime(ordFechaHab);
                            if (!dr.IsDBNull(ordNroSucursal)) obj.Nro_sucursal = dr.GetInt32(ordNroSucursal);
                            if (!dr.IsDBNull(ordNroRes)) obj.Nro_res = dr.GetString(ordNroRes);
                            if (!dr.IsDBNull(ordTransporte)) obj.Transporte = dr.GetBoolean(ordTransporte);
                            
                            if (obj.Transporte)
                            {
                                if (!dr.IsDBNull(ordMarca)) obj.Marca = dr.GetString(ordMarca);
                                if (!dr.IsDBNull(ordModelo)) obj.Modelo = dr.GetString(ordModelo);
                                if (!dr.IsDBNull(ordAnio)) obj.Anio = dr.GetInt32(ordAnio);
                                if (!dr.IsDBNull(ordDominio)) obj.Dominio = dr.GetString(ordDominio);
                            }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}