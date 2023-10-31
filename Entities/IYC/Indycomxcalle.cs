using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Web_Api_IyC.Entities.IYC
{
    public class Indycomxcalle : DALBase
    {
        public int legajo { get; set; }
        public string nombre { get; set; }
        public int cod_rubro { get; set; }
        public string concepto { get; set; }
        public string nom_calle { get; set; }
        public string nro_dom { get; set; }
        public string nom_bario { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string nom_fantasia { get; set; } = string.Empty;
        public string des_cond_ante_iva { get; set; }

        public Indycomxcalle()
        {
            legajo = 0;
            nombre = string.Empty;
            cod_rubro = 0;
            concepto = string.Empty;
            nom_calle = string.Empty;
            nro_dom = string.Empty;
            nom_bario = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            email = string.Empty;
            nom_fantasia = string.Empty;
            des_cond_ante_iva = string.Empty;
        }

        private static List<Indycomxcalle> mapeo(SqlDataReader dr)
        {
            List<Indycomxcalle> lst = new List<Indycomxcalle>();
            Indycomxcalle obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int nombre = dr.GetOrdinal("nombre");
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int concepto = dr.GetOrdinal("concepto");
                int nom_calle = dr.GetOrdinal("nom_calle");
                int nro_dom = dr.GetOrdinal("nro_dom");
                int nom_barrio = dr.GetOrdinal("nom_barrio");
                int telefono = dr.GetOrdinal("telefono");
                int celular = dr.GetOrdinal("celular");
                int email = dr.GetOrdinal("email");
                int des_cond_ante_iva = dr.GetOrdinal("des_cond_ante_iva");
                while (dr.Read())
                {
                    obj = new Indycomxcalle();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                    if (!dr.IsDBNull(concepto)) { obj.concepto = dr.GetString(concepto); }
                    if (!dr.IsDBNull(nom_calle)) { obj.nom_calle = dr.GetString(nom_calle); }
                    if (!dr.IsDBNull(nro_dom)) { obj.nro_dom = Convert.ToString(dr.GetInt32(nro_dom)); }
                    if (!dr.IsDBNull(nom_barrio)) { obj.nom_bario = dr.GetString(nom_barrio); }
                    if (!dr.IsDBNull(telefono)) { obj.telefono = dr.GetString(telefono); }
                    if (!dr.IsDBNull(celular)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(email)) { obj.email = dr.GetString(email); }
                    if (!dr.IsDBNull(des_cond_ante_iva)) { obj.des_cond_ante_iva = dr.GetString(des_cond_ante_iva); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Indycomxcalle> ConsultaIyc_x_calles(string calledesde, string callehasta)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Indycomxcalle> lst = new List<Indycomxcalle>();
                string strSQL = @"SELECT DISTINCT(a.legajo),b.nombre,d.cod_rubro,d.concepto,a.nom_calle,
                                       a.nro_dom, a.Nom_barrio,
                                       b.telefono, a.Nom_fantasia, t.des_cond_ante_iva,
                                       a.celular, b.E_MAIL as email                            
                                    FROM indycom a
                                    JOIN badec b on
                                    a.nro_bad=b.nro_bad
                                    JOIN rubros_x_iyc c on
                                    a.legajo=c.legajo
                                    JOIN rubros d on
                                    (d.cod_rubro<>71110000 AND d.cod_rubro<>71150000 AND
                                    d.cod_rubro<>71151000 AND d.cod_rubro<>73100000) AND
                                    c.cod_rubro=d.cod_rubro
                                    FULL JOIN TIPOS_DE_IVA t on
                                    a.cod_cond_ante_iva=t.cod_cond_ante_iva
                                    WHERE
                                    a.dado_baja=0
                                    AND a.nom_calle between @nombredesde and @nombrehasta
                                    ORDER BY  a.Nom_calle, a.nro_dom,  a.Nom_barrio";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nombredesde", calledesde + '%');
                    cmd.Parameters.AddWithValue("@nombrehasta", callehasta + '%');
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
