using System.Data.SqlClient;
using System.Data;

namespace Web_Api_IyC.Entities.IYC
{
    public class Informes : DALBase
    {
        public DateTime? vencimiento { get; set; }
        public int nro_transaccion { get; set; }
        public int tipo_transaccion { get; set; }
        public string des_transaccion { get; set; }
        public string categoria { get; set; }
        public string periodo { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public int nro_plan { get; set; }
        public int nro_procuracion { get; set; }

        public Informes()
        {
            vencimiento = null;
            nro_transaccion = 0;
            tipo_transaccion = 0;
            des_transaccion = string.Empty;
            categoria = string.Empty;
            periodo = string.Empty;
            debe = 0;
            haber = 0;
            nro_plan = 0;
            nro_procuracion = 0;
        }
        private static List<Informes> mapeo(SqlDataReader dr)
        {
            List<Informes> lst = new List<Informes>();
            Informes obj;
            if (dr.HasRows)
            {
                int vencimiento = dr.GetOrdinal("vencimiento");
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                int des_transaccion = dr.GetOrdinal("des_transaccion");
                int categoria = dr.GetOrdinal("categoria");
                int periodo = dr.GetOrdinal("periodo");
                int debe = dr.GetOrdinal("debe");
                int haber = dr.GetOrdinal("haber");
                int nro_plan = dr.GetOrdinal("nro_plan");
                int nro_procuracion = dr.GetOrdinal("nro_procuracion");

                while (dr.Read())
                {
                    obj = new Informes();
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                    if (!dr.IsDBNull(des_transaccion)) { obj.des_transaccion = dr.GetString(des_transaccion); }
                    if (!dr.IsDBNull(categoria)) { obj.categoria = dr.GetString(categoria); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                    if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                    if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                    if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Informes> InformeCtaCteSoloDeuda(int legajo, int categoria_deuda, int categoria_deuda2, string per)
        {
            try
            {
                List<Informes> lst = new List<Informes>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                        SELECT 
                            A.vencimiento,
                            A.nro_transaccion,
                            A.tipo_transaccion,
	                        CASE TIPO_TRANSACCION 
		                        WHEN 1 THEN 'Deuda'
		                        WHEN 2 THEN 'Pago'
	                        END AS des_transaccion,  
	                        B.des_categoria AS CATEGORIA,
	                        A.PERIODO,
	                        DEBE = (SELECT SUM(DEBE)-SUM(HABER)
                                     FROM CTASCTES_INDYCOM C WITH (NOLOCK)
                                     WHERE
				                        C.NRO_TRANSACCION=A.NRO_TRANSACCION),
                            A.HABER,
	                        A.NRO_PLAN, 
	                        A.NRO_PROCURACION
                        FROM 
                          CTASCTES_INDYCOM A WITH (NOLOCK), 
                          CATE_DEUDA_INDYCOM B
                        WHERE
                          A.tipo_transaccion = 1 AND
                          A.legajo=@legajo AND 
                          A.cod_cate_deuda < @categoria_deuda  AND
                          A.periodo>=@per AND
                          A.cod_cate_deuda=B.cod_categoria AND
                          (SELECT SUM(DEBE)-SUM(HABER)
                           FROM CTASCTES_INDYCOM C WITH (NOLOCK)
                           WHERE
                           C.NRO_TRANSACCION=A.NRO_TRANSACCION)  > 0

                        UNION

                        SELECT
                            A.vencimiento,
                            A.nro_transaccion,
                            A.tipo_transaccion,
	                        CASE TIPO_TRANSACCION 
		                        WHEN 1 THEN 'Deuda'
		                        WHEN 2 THEN 'Pago'
	                        END AS des_transaccion, 
	                        B.des_categoria AS CATEGORIA,
	                        A.PERIODO,
	                        DEBE = (SELECT SUM(DEBE)-SUM(HABER)
                                         FROM CTASCTES_INDYCOM C WITH (NOLOCK)
                                         WHERE
                                         C.NRO_TRANSACCION=A.NRO_TRANSACCION),
                            A.HABER,
	                        A.NRO_PLAN, 
	                        A.NRO_PROCURACION
                        FROM
                          CTASCTES_INDYCOM A WITH (NOLOCK),
                          CATE_DEUDA_INDYCOM B                                              
                        WHERE
                          A.tipo_transaccion = 1 AND
                          A.legajo=@legajo AND
                          A.cod_cate_deuda = @categoria_deuda2 AND
                          A.periodo>=@per AND
                          A.cod_cate_deuda=B.cod_categoria AND
                          (SELECT SUM(DEBE)-SUM(HABER)
                           FROM CTASCTES_INDYCOM C WITH (NOLOCK)
                           WHERE
                           C.NRO_TRANSACCION=A.NRO_TRANSACCION)  > 0
                        ORDER BY
                          A.vencimiento, A.nro_transaccion, des_transaccion, A.periodo";
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@categoria_deuda", categoria_deuda);
                    cmd.Parameters.AddWithValue("@categoria_deuda2", categoria_deuda2);
                    cmd.Parameters.AddWithValue("@per", per);
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
        public static List<Informes> InformeCtaCteCompleto(int legajo, string per)
        {
            try
            {
                List<Informes> lst = new List<Informes>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
                                            A.vencimiento,
                                            A.nro_transaccion,
                                            A.tipo_transaccion,
                                            CASE A.TIPO_TRANSACCION 
		                                        WHEN 1 THEN 'Deuda'
		                                        WHEN 2 THEN 'Pago'
                                                WHEN 3 THEN 'Fin de Plan'
                                                WHEN 4 THEN 'Bonificación'
                                                WHEN 5 THEN 'Ajuste Positivo'
                                                WHEN 6 THEN 'Ajuste Negativo'
                                                WHEN 7 THEN 'Cancelación'
                                                WHEN 8 THEN 'Decreto/resolución'
                                                WHEN 9 THEN 'Baja Plan'
                                            END as des_transaccion,
                                            B.des_categoria AS CATEGORIA,
	                                        A.PERIODO,
                                            A.DEBE,
                                            A.HABER,
                                            A.NRO_PLAN, 
                                            A.NRO_PROCURACION
                                        FROM
                                        CTASCTES_INDYCOM A WITH (NOLOCK)
                                        JOIN CATE_DEUDA_INDYCOM B ON
                                          A.cod_cate_deuda=B.cod_categoria
                                        WHERE
                                        A.legajo=@legajo AND 
                                        A.periodo>=@per
                                        ORDER BY
                                        A.periodo";

                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@per", per);
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

    }
}
