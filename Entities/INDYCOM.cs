using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Helpers;

namespace Web_Api_IyC.Entities
{
    public class INDYCOM : DALBase
    {
        public int legajo { get; set; }
        public int nro_bad { get; set; }
        public int nro_contrib { get; set; }
        public string des_com { get; set; }
        public string nom_fantasia { get; set; }
        public int cod_calle { get; set; }
        public int nro_dom { get; set; }
        public int cod_barrio { get; set; }
        public int cod_tipo_per { get; set; }
        public string cod_zona { get; set; }
        public string pri_periodo { get; set; }
        public int tipo_liquidacion { get; set; }
        public bool dado_baja { get; set; }
        public DateTime? fecha_baja { get; set; }
        public bool exento { get; set; }
        public DateTime? vencimiento_eximido { get; set; }
        public string per_ult { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_hab { get; set; }
        public string nro_res { get; set; }
        public string nro_exp_mesa_ent { get; set; }
        public string nro_ing_bruto { get; set; }
        public string nro_cuit { get; set; }
        public bool transporte { get; set; }
        public DateTime? fecha_alta { get; set; }
        public string nom_calle { get; set; }
        public string nom_barrio { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string cod_postal { get; set; }
        public int cod_calle_dom_esp { get; set; }
        public string nom_calle_dom_esp { get; set; }
        public int nro_dom_esp { get; set; }
        public string piso_dpto_esp { get; set; }
        public string local_esp { get; set; }
        public int cod_barrio_dom_esp { get; set; }
        public string nom_barrio_dom_esp { get; set; }
        public string ciudad_dom_esp { get; set; }
        public string provincia_dom_esp { get; set; }
        public string pais_dom_esp { get; set; }
        public string cod_postal_dom_esp { get; set; }
        public DateTime? fecha_cambio_domicilio { get; set; }
        public bool emite_cedulon { get; set; }
        public int cod_situacion_judicial { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public bool Ocupacion_vereda { get; set; }
        public bool Con_sucursal { get; set; }
        public int nro_sucursal { get; set; }
        public bool es_transferido { get; set; }
        public bool con_ddjj_anual { get; set; }
        public string cod_zona_liquidacion { get; set; }
        public bool debito_automatico { get; set; }
        public string clave_pago { get; set; }
        public DateTime? fecha_ddjj_anual { get; set; }
        public string email_envio_cedulon { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public bool Reempadronamiento { get; set; }
        public Int16 empadronado { get; set; }
        public DateTime? fecha_empadronado { get; set; }
        public Int16 es_agencia { get; set; }
        public string clave_gestion { get; set; }
        public string nro_local { get; set; }
        public Int16 cedulon_digital { get; set; }
        public string piso_dpto { get; set; }
        public int cod_cond_ante_iva { get; set; }
        public int cod_caracter { get; set; }
        public string categoria_iva { get; set; }
        public string otra_entidad { get; set; }
        public Int16 convenio_uni { get; set; }
        public string cod_nueva_zona { get; set; }//=> se liquida en base a este campo que identifica la zona
        public DateTime? fecha_vecino_digital { get; set; }
        public string cuit_vecino_digital { get; set; }
        public DateTime? vto_inscripcion { get; set; }
        public string titular { get; set; }

        public AUDITORIA.Auditoria objAuditoria { get; set; }

        public INDYCOM()
        {
            legajo = 0;
            nro_bad = 0;
            nro_contrib = 0;
            des_com = string.Empty;
            nom_fantasia = string.Empty;
            cod_calle = 0;
            nro_dom = 0;
            cod_barrio = 0;
            cod_tipo_per = 0;
            cod_zona = string.Empty;
            pri_periodo = string.Empty;
            tipo_liquidacion = 0;
            dado_baja = false;
            fecha_baja = DateTime.Now;
            exento = false;
            vencimiento_eximido = DateTime.Now;
            per_ult = string.Empty;
            fecha_inicio = DateTime.Now;
            fecha_hab = DateTime.Now;
            nro_res = string.Empty;
            nro_exp_mesa_ent = string.Empty;
            nro_ing_bruto = string.Empty;
            nro_cuit = string.Empty;
            transporte = false;
            fecha_alta = DateTime.Now;
            nom_calle = string.Empty;
            nom_barrio = string.Empty;
            ciudad = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
            cod_postal = string.Empty;
            cod_calle_dom_esp = 0;
            nom_calle_dom_esp = string.Empty;
            nro_dom_esp = 0;
            piso_dpto_esp = string.Empty;
            local_esp = string.Empty;
            cod_barrio_dom_esp = 0;
            nom_barrio_dom_esp = string.Empty;
            ciudad_dom_esp = string.Empty;
            provincia_dom_esp = string.Empty;
            pais_dom_esp = string.Empty;
            cod_postal_dom_esp = string.Empty;
            fecha_cambio_domicilio = DateTime.Now;
            emite_cedulon = false;
            cod_situacion_judicial = 1;
            Telefono1 = string.Empty;
            Telefono2 = string.Empty;
            Celular1 = string.Empty;
            Celular2 = string.Empty;
            Ocupacion_vereda = false;
            Con_sucursal = false;
            nro_sucursal = 0;
            es_transferido = false;
            con_ddjj_anual = false;
            cod_zona_liquidacion = string.Empty;
            debito_automatico = false;
            clave_pago = string.Empty;
            fecha_ddjj_anual = DateTime.Now;
            email_envio_cedulon = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            Reempadronamiento = false;
            empadronado = 0;
            fecha_empadronado = DateTime.Now;
            es_agencia = 0;
            clave_gestion = string.Empty;
            nro_local = string.Empty;
            cedulon_digital = 0;
            piso_dpto = string.Empty;
            cod_cond_ante_iva = 0;
            cod_caracter = 0;
            categoria_iva = string.Empty;
            otra_entidad = string.Empty;
            convenio_uni = 0;
            cod_nueva_zona = string.Empty;
            fecha_vecino_digital = DateTime.Now;
            cuit_vecino_digital = string.Empty;
            vto_inscripcion = DateTime.Now;
            titular = string.Empty;
            objAuditoria = new();
        }
        private static List<INDYCOM> mapeo(SqlDataReader dr)
        {
            List<INDYCOM> lst = new List<INDYCOM>();
            INDYCOM obj;
            if (dr.HasRows)
            {
                int legajo = dr.GetOrdinal("legajo");
                int nro_bad = dr.GetOrdinal("nro_bad");
                int nro_contrib = dr.GetOrdinal("nro_contrib");
                int des_com = dr.GetOrdinal("des_com");
                int nom_fantasia = dr.GetOrdinal("nom_fantasia");
                int cod_calle = dr.GetOrdinal("cod_calle");
                int nro_dom = dr.GetOrdinal("nro_dom");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                int cod_tipo_per = dr.GetOrdinal("cod_tipo_per");
                int cod_zona = dr.GetOrdinal("cod_zona");
                int pri_periodo = dr.GetOrdinal("pri_periodo");
                int tipo_liquidacion = dr.GetOrdinal("tipo_liquidacion");
                int dado_baja = dr.GetOrdinal("dado_baja");
                int fecha_baja = dr.GetOrdinal("fecha_baja");
                int exento = dr.GetOrdinal("exento");
                int vencimiento_eximido = dr.GetOrdinal("vencimiento_eximido");
                int per_ult = dr.GetOrdinal("per_ult");
                int fecha_inicio = dr.GetOrdinal("fecha_inicio");
                int fecha_hab = dr.GetOrdinal("fecha_hab");
                int nro_res = dr.GetOrdinal("nro_res");
                int nro_exp_mesa_ent = dr.GetOrdinal("nro_exp_mesa_ent");
                int nro_ing_bruto = dr.GetOrdinal("nro_ing_bruto");
                int nro_cuit = dr.GetOrdinal("nro_cuit");
                int transporte = dr.GetOrdinal("transporte");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int nom_calle = dr.GetOrdinal("nom_calle");
                int nom_barrio = dr.GetOrdinal("nom_barrio");
                int ciudad = dr.GetOrdinal("ciudad");
                int provincia = dr.GetOrdinal("provincia");
                int pais = dr.GetOrdinal("pais");
                int cod_postal = dr.GetOrdinal("cod_postal");
                int cod_calle_dom_esp = dr.GetOrdinal("cod_calle_dom_esp");
                int nom_calle_dom_esp = dr.GetOrdinal("nom_calle_dom_esp");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int piso_dpto_esp = dr.GetOrdinal("piso_dpto_esp");
                int local_esp = dr.GetOrdinal("local_esp");
                int cod_barrio_dom_esp = dr.GetOrdinal("cod_barrio_dom_esp");
                int nom_barrio_dom_esp = dr.GetOrdinal("nom_barrio_dom_esp");
                int ciudad_dom_esp = dr.GetOrdinal("ciudad_dom_esp");
                int provincia_dom_esp = dr.GetOrdinal("provincia_dom_esp");
                int pais_dom_esp = dr.GetOrdinal("pais_dom_esp");
                int cod_postal_dom_esp = dr.GetOrdinal("cod_postal_dom_esp");
                int fecha_cambio_domicilio = dr.GetOrdinal("fecha_cambio_domicilio");
                int emite_cedulon = dr.GetOrdinal("emite_cedulon");
                int cod_situacion_judicial = dr.GetOrdinal("cod_situacion_judicial");
                int Telefono1 = dr.GetOrdinal("Telefono1");
                int Telefono2 = dr.GetOrdinal("Telefono2");
                int Celular1 = dr.GetOrdinal("Celular1");
                int Celular2 = dr.GetOrdinal("Celular2");
                int Ocupacion_vereda = dr.GetOrdinal("Ocupacion_vereda");
                int Con_sucursal = dr.GetOrdinal("Con_sucursal");
                int Nro_sucursal = dr.GetOrdinal("Nro_sucursal");
                int es_transferido = dr.GetOrdinal("es_transferido");
                int Con_DDJJ_anual = dr.GetOrdinal("Con_DDJJ_anual");
                int cod_zona_liquidacion = dr.GetOrdinal("cod_zona_liquidacion");
                int debito_automatico = dr.GetOrdinal("debito_automatico");
                int clave_pago = dr.GetOrdinal("clave_pago");
                int fecha_DDJJ_Anual = dr.GetOrdinal("fecha_DDJJ_Anual");
                int email_envio_cedulon = dr.GetOrdinal("email_envio_cedulon");
                int telefono = dr.GetOrdinal("telefono");
                int celular = dr.GetOrdinal("celular");
                int Reempadronamiento = dr.GetOrdinal("Reempadronamiento");
                int Empadronado = dr.GetOrdinal("Empadronado");
                int Fecha_empadronado = dr.GetOrdinal("Fecha_empadronado");
                int Es_agencia = dr.GetOrdinal("Es_agencia");
                int clave_gestion = dr.GetOrdinal("clave_gestion");
                int Nro_local = dr.GetOrdinal("Nro_local");
                int Cedulon_digital = dr.GetOrdinal("Cedulon_digital");
                int Piso_dpto = dr.GetOrdinal("Piso_dpto");
                int cod_cond_ante_iva = dr.GetOrdinal("cod_cond_ante_iva");
                int cod_caracter = dr.GetOrdinal("cod_caracter");
                int Categoria_iva = dr.GetOrdinal("Categoria_iva");
                int otra_entidad = dr.GetOrdinal("otra_entidad");
                int convenio_uni = dr.GetOrdinal("convenio_uni");
                int Cod_nueva_zona = dr.GetOrdinal("Cod_nueva_zona");
                int FECHA_VECINO_DIGITAL = dr.GetOrdinal("FECHA_VECINO_DIGITAL");
                int CUIT_VECINO_DIGITAL = dr.GetOrdinal("CUIT_VECINO_DIGITAL");
                int Vto_inscripcion = dr.GetOrdinal("Vto_inscripcion");
                while (dr.Read())
                {
                    obj = new INDYCOM();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(nro_bad)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(nro_contrib)) { obj.nro_contrib = dr.GetInt32(nro_contrib); }
                    if (!dr.IsDBNull(des_com)) { obj.des_com = dr.GetString(des_com); }
                    if (!dr.IsDBNull(nom_fantasia)) { obj.nom_fantasia = dr.GetString(nom_fantasia); }
                    if (!dr.IsDBNull(cod_calle)) { obj.cod_calle = dr.GetInt32(cod_calle); }
                    if (!dr.IsDBNull(nro_dom)) { obj.nro_dom = dr.GetInt32(nro_dom); }
                    if (!dr.IsDBNull(cod_barrio)) { obj.cod_barrio = dr.GetInt32(cod_barrio); }
                    if (!dr.IsDBNull(cod_tipo_per)) { obj.cod_tipo_per = dr.GetInt32(cod_tipo_per); }
                    if (!dr.IsDBNull(cod_zona)) { obj.cod_zona = dr.GetString(cod_zona); }
                    if (!dr.IsDBNull(pri_periodo)) { obj.pri_periodo = dr.GetString(pri_periodo); }
                    if (!dr.IsDBNull(tipo_liquidacion)) { obj.tipo_liquidacion = dr.GetInt32(tipo_liquidacion); }
                    if (!dr.IsDBNull(dado_baja)) { obj.dado_baja = dr.GetBoolean(dado_baja); }
                    if (!dr.IsDBNull(fecha_baja)) { obj.fecha_baja = dr.GetDateTime(fecha_baja); }
                    if (!dr.IsDBNull(exento)) { obj.exento = dr.GetBoolean(exento); }
                    if (!dr.IsDBNull(vencimiento_eximido)) { obj.vencimiento_eximido = dr.GetDateTime(vencimiento_eximido); }
                    if (!dr.IsDBNull(per_ult)) { obj.per_ult = dr.GetString(per_ult); }
                    if (!dr.IsDBNull(fecha_inicio)) { obj.fecha_inicio = dr.GetDateTime(fecha_inicio); }
                    if (!dr.IsDBNull(fecha_hab)) { obj.fecha_hab = dr.GetDateTime(fecha_hab); }
                    if (!dr.IsDBNull(nro_res)) { obj.nro_res = dr.GetString(nro_res); }
                    if (!dr.IsDBNull(nro_exp_mesa_ent)) { obj.nro_exp_mesa_ent = dr.GetString(nro_exp_mesa_ent); }
                    if (!dr.IsDBNull(nro_ing_bruto)) { obj.nro_ing_bruto = dr.GetString(nro_ing_bruto); }
                    if (!dr.IsDBNull(nro_cuit)) { obj.nro_cuit = dr.GetString(nro_cuit); }
                    if (!dr.IsDBNull(transporte)) { obj.transporte = dr.GetBoolean(transporte); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(nom_calle)) { obj.nom_calle = dr.GetString(nom_calle); }
                    if (!dr.IsDBNull(nom_barrio)) { obj.nom_barrio = dr.GetString(nom_barrio); }
                    if (!dr.IsDBNull(ciudad)) { obj.ciudad = dr.GetString(ciudad); }
                    if (!dr.IsDBNull(provincia)) { obj.provincia = dr.GetString(provincia); }
                    if (!dr.IsDBNull(pais)) { obj.pais = dr.GetString(pais); }
                    if (!dr.IsDBNull(cod_postal)) { obj.cod_postal = dr.GetString(cod_postal); }
                    if (!dr.IsDBNull(cod_calle_dom_esp)) { obj.cod_calle_dom_esp = dr.GetInt32(cod_calle_dom_esp); }
                    if (!dr.IsDBNull(nom_calle_dom_esp)) { obj.nom_calle_dom_esp = dr.GetString(nom_calle_dom_esp); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(piso_dpto_esp)) { obj.piso_dpto_esp = dr.GetString(piso_dpto_esp); }
                    if (!dr.IsDBNull(local_esp)) { obj.local_esp = dr.GetString(local_esp); }
                    if (!dr.IsDBNull(cod_barrio_dom_esp)) { obj.cod_barrio_dom_esp = dr.GetInt32(cod_barrio_dom_esp); }
                    if (!dr.IsDBNull(nom_barrio_dom_esp)) { obj.nom_barrio_dom_esp = dr.GetString(nom_barrio_dom_esp); }
                    if (!dr.IsDBNull(ciudad_dom_esp)) { obj.ciudad_dom_esp = dr.GetString(ciudad_dom_esp); }
                    if (!dr.IsDBNull(provincia_dom_esp)) { obj.provincia_dom_esp = dr.GetString(provincia_dom_esp); }
                    if (!dr.IsDBNull(pais_dom_esp)) { obj.pais_dom_esp = dr.GetString(pais_dom_esp); }
                    if (!dr.IsDBNull(cod_postal_dom_esp)) { obj.cod_postal_dom_esp = dr.GetString(cod_postal_dom_esp); }
                    if (!dr.IsDBNull(fecha_cambio_domicilio)) { obj.fecha_cambio_domicilio = dr.GetDateTime(fecha_cambio_domicilio); }
                    if (!dr.IsDBNull(emite_cedulon)) { obj.emite_cedulon = dr.GetBoolean(emite_cedulon); }
                    if (!dr.IsDBNull(cod_situacion_judicial)) { obj.cod_situacion_judicial = dr.GetInt32(cod_situacion_judicial); }
                    if (!dr.IsDBNull(Telefono1)) { obj.Telefono1 = dr.GetString(Telefono1); }
                    if (!dr.IsDBNull(Telefono2)) { obj.Telefono2 = dr.GetString(Telefono2); }
                    if (!dr.IsDBNull(Celular1)) { obj.Celular1 = dr.GetString(Celular1); }
                    if (!dr.IsDBNull(Celular2)) { obj.Celular2 = dr.GetString(Celular2); }
                    if (!dr.IsDBNull(Ocupacion_vereda)) { obj.Ocupacion_vereda = dr.GetBoolean(Ocupacion_vereda); }
                    if (!dr.IsDBNull(Con_sucursal)) { obj.Con_sucursal = dr.GetBoolean(Con_sucursal); }
                    if (!dr.IsDBNull(Nro_sucursal)) { obj.nro_sucursal = dr.GetInt32(Nro_sucursal); }
                    if (!dr.IsDBNull(es_transferido)) { obj.es_transferido = dr.GetBoolean(es_transferido); }
                    if (!dr.IsDBNull(Con_DDJJ_anual)) { obj.con_ddjj_anual = dr.GetBoolean(Con_DDJJ_anual); }
                    if (!dr.IsDBNull(cod_zona_liquidacion)) { obj.cod_zona_liquidacion = dr.GetString(cod_zona_liquidacion); }
                    if (!dr.IsDBNull(debito_automatico)) { obj.debito_automatico = dr.GetBoolean(debito_automatico); }
                    if (!dr.IsDBNull(clave_pago)) { obj.clave_pago = dr.GetString(clave_pago); }
                    if (!dr.IsDBNull(fecha_DDJJ_Anual)) { obj.fecha_ddjj_anual = dr.GetDateTime(fecha_DDJJ_Anual); }
                    if (!dr.IsDBNull(email_envio_cedulon)) { obj.email_envio_cedulon = dr.GetString(email_envio_cedulon); }
                    if (!dr.IsDBNull(telefono)) { obj.telefono = dr.GetString(telefono); }
                    if (!dr.IsDBNull(celular)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(Reempadronamiento)) { obj.Reempadronamiento = dr.GetBoolean(Reempadronamiento); }
                    if (!dr.IsDBNull(Empadronado)) { obj.empadronado = dr.GetInt16(Empadronado); }
                    if (!dr.IsDBNull(Fecha_empadronado)) { obj.fecha_empadronado = dr.GetDateTime(Fecha_empadronado); }
                    if (!dr.IsDBNull(Es_agencia)) { obj.es_agencia = dr.GetInt16(Es_agencia); }
                    if (!dr.IsDBNull(clave_gestion)) { obj.clave_gestion = dr.GetString(clave_gestion); }
                    if (!dr.IsDBNull(Nro_local)) { obj.nro_local = dr.GetString(Nro_local); }
                    if (!dr.IsDBNull(Cedulon_digital)) { obj.cedulon_digital = dr.GetInt16(Cedulon_digital); }
                    if (!dr.IsDBNull(Piso_dpto)) { obj.piso_dpto = dr.GetString(Piso_dpto); }
                    if (!dr.IsDBNull(cod_cond_ante_iva)) { obj.cod_cond_ante_iva = dr.GetInt32(cod_cond_ante_iva); }
                    if (!dr.IsDBNull(cod_caracter)) { obj.cod_caracter = dr.GetInt32(cod_caracter); }
                    if (!dr.IsDBNull(Categoria_iva)) { obj.categoria_iva = dr.GetString(Categoria_iva); }
                    if (!dr.IsDBNull(otra_entidad)) { obj.otra_entidad = dr.GetString(otra_entidad); }
                    if (!dr.IsDBNull(convenio_uni)) { obj.convenio_uni = dr.GetInt16(convenio_uni); }
                    if (!dr.IsDBNull(Cod_nueva_zona)) { obj.cod_nueva_zona = dr.GetString(Cod_nueva_zona); }
                    if (!dr.IsDBNull(FECHA_VECINO_DIGITAL)) { obj.fecha_vecino_digital = dr.GetDateTime(FECHA_VECINO_DIGITAL); }
                    if (!dr.IsDBNull(CUIT_VECINO_DIGITAL)) { obj.cuit_vecino_digital = dr.GetString(CUIT_VECINO_DIGITAL); }
                    if (!dr.IsDBNull(Vto_inscripcion)) { obj.vto_inscripcion = dr.GetDateTime(Vto_inscripcion); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<INDYCOM> Read()
        {
            try
            {
                List<INDYCOM> lst = new List<INDYCOM>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT i.*, b.nombre as titular FROM INDYCOM i JOIN BADEC b on i.nro_bad=b.nro_bad";
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
        public static INDYCOM GetByPk(int legajo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM INDYCOM WHERE");
                sql.AppendLine("legajo = @legajo");
                INDYCOM? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INDYCOM> lst = mapeo(dr);
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
        public static int Insert(INDYCOM obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO INDYCOM(");
                sql.AppendLine("legajo");
                sql.AppendLine(", nro_bad");
                sql.AppendLine(", nro_contrib");
                sql.AppendLine(", des_com");
                sql.AppendLine(", nom_fantasia");
                sql.AppendLine(", cod_calle");
                sql.AppendLine(", nro_dom");
                sql.AppendLine(", cod_barrio");
                sql.AppendLine(", cod_tipo_per");
                sql.AppendLine(", cod_zona");
                sql.AppendLine(", pri_periodo");
                sql.AppendLine(", tipo_liquidacion");
                sql.AppendLine(", dado_baja");
                sql.AppendLine(", fecha_baja");
                sql.AppendLine(", exento");
                sql.AppendLine(", vencimiento_eximido");
                sql.AppendLine(", per_ult");
                sql.AppendLine(", fecha_inicio");
                sql.AppendLine(", fecha_hab");
                sql.AppendLine(", nro_res");
                sql.AppendLine(", nro_exp_mesa_ent");
                sql.AppendLine(", nro_ing_bruto");
                sql.AppendLine(", nro_cuit");
                sql.AppendLine(", transporte");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", nom_calle");
                sql.AppendLine(", nom_barrio");
                sql.AppendLine(", ciudad");
                sql.AppendLine(", provincia");
                sql.AppendLine(", pais");
                sql.AppendLine(", cod_postal");
                sql.AppendLine(", cod_calle_dom_esp");
                sql.AppendLine(", nom_calle_dom_esp");
                sql.AppendLine(", nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp");
                sql.AppendLine(", local_esp");
                sql.AppendLine(", cod_barrio_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp");
                sql.AppendLine(", ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp");
                sql.AppendLine(", cod_postal_dom_esp");
                sql.AppendLine(", fecha_cambio_domicilio");
                sql.AppendLine(", Emite_cedulon");
                sql.AppendLine(", cod_situacion_judicial");
                sql.AppendLine(", Telefono1");
                sql.AppendLine(", Telefono2");
                sql.AppendLine(", Celular1");
                sql.AppendLine(", Celular2");
                sql.AppendLine(", Ocupacion_vereda");
                sql.AppendLine(", Con_sucursal");
                sql.AppendLine(", Nro_sucursal");
                sql.AppendLine(", es_transferido");
                sql.AppendLine(", Con_DDJJ_anual");
                sql.AppendLine(", cod_zona_liquidacion");
                sql.AppendLine(", debito_automatico");
                sql.AppendLine(", clave_pago");
                sql.AppendLine(", fecha_DDJJ_Anual");
                sql.AppendLine(", email_envio_cedulon");
                sql.AppendLine(", telefono");
                sql.AppendLine(", celular");
                sql.AppendLine(", Reempadronamiento");
                sql.AppendLine(", Empadronado");
                sql.AppendLine(", Fecha_empadronado");
                sql.AppendLine(", Es_agencia");
                sql.AppendLine(", clave_gestion");
                sql.AppendLine(", Nro_local");
                sql.AppendLine(", Cedulon_digital");
                sql.AppendLine(", Piso_dpto");
                sql.AppendLine(", cod_cond_ante_iva");
                sql.AppendLine(", cod_caracter");
                sql.AppendLine(", Categoria_iva");
                sql.AppendLine(", otra_entidad");
                sql.AppendLine(", convenio_uni");
                sql.AppendLine(", cod_nueva_zona");
                sql.AppendLine(", FECHA_VECINO_DIGITAL");
                sql.AppendLine(", CUIT_VECINO_DIGITAL");
                sql.AppendLine(", Vto_inscripcion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @nro_bad");
                sql.AppendLine(", @nro_contrib");
                sql.AppendLine(", @des_com");
                sql.AppendLine(", @nom_fantasia");
                sql.AppendLine(", @cod_calle");
                sql.AppendLine(", @nro_dom");
                sql.AppendLine(", @cod_barrio");
                sql.AppendLine(", @cod_tipo_per");
                sql.AppendLine(", @cod_zona");
                sql.AppendLine(", @pri_periodo");
                sql.AppendLine(", @tipo_liquidacion");
                sql.AppendLine(", @dado_baja");
                sql.AppendLine(", @fecha_baja");
                sql.AppendLine(", @exento");
                sql.AppendLine(", @vencimiento_eximido");
                sql.AppendLine(", @per_ult");
                sql.AppendLine(", @fecha_inicio");
                sql.AppendLine(", @fecha_hab");
                sql.AppendLine(", @nro_res");
                sql.AppendLine(", @nro_exp_mesa_ent");
                sql.AppendLine(", @nro_ing_bruto");
                sql.AppendLine(", @nro_cuit");
                sql.AppendLine(", @transporte");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @nom_calle");
                sql.AppendLine(", @nom_barrio");
                sql.AppendLine(", @ciudad");
                sql.AppendLine(", @provincia");
                sql.AppendLine(", @pais");
                sql.AppendLine(", @cod_postal");
                sql.AppendLine(", @cod_calle_dom_esp");
                sql.AppendLine(", @nom_calle_dom_esp");
                sql.AppendLine(", @nro_dom_esp");
                sql.AppendLine(", @piso_dpto_esp");
                sql.AppendLine(", @local_esp");
                sql.AppendLine(", @cod_barrio_dom_esp");
                sql.AppendLine(", @nom_barrio_dom_esp");
                sql.AppendLine(", @ciudad_dom_esp");
                sql.AppendLine(", @provincia_dom_esp");
                sql.AppendLine(", @pais_dom_esp");
                sql.AppendLine(", @cod_postal_dom_esp");
                sql.AppendLine(", @fecha_cambio_domicilio");
                sql.AppendLine(", @Emite_cedulon");
                sql.AppendLine(", @cod_situacion_judicial");
                sql.AppendLine(", @Telefono1");
                sql.AppendLine(", @Telefono2");
                sql.AppendLine(", @Celular1");
                sql.AppendLine(", @Celular2");
                sql.AppendLine(", @Ocupacion_vereda");
                sql.AppendLine(", @Con_sucursal");
                sql.AppendLine(", @Nro_sucursal");
                sql.AppendLine(", @es_transferido");
                sql.AppendLine(", @Con_DDJJ_anual");
                sql.AppendLine(", @cod_zona_liquidacion");
                sql.AppendLine(", @debito_automatico");
                sql.AppendLine(", @clave_pago");
                sql.AppendLine(", @fecha_DDJJ_Anual");
                sql.AppendLine(", @email_envio_cedulon");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @celular");
                sql.AppendLine(", @Reempadronamiento");
                sql.AppendLine(", @Empadronado");
                sql.AppendLine(", @Fecha_empadronado");
                sql.AppendLine(", @Es_agencia");
                sql.AppendLine(", @clave_gestion");
                sql.AppendLine(", @Nro_local");
                sql.AppendLine(", @Cedulon_digital");
                sql.AppendLine(", @Piso_dpto");
                sql.AppendLine(", @cod_cond_ante_iva");
                sql.AppendLine(", @cod_caracter");
                sql.AppendLine(", @Categoria_iva");
                sql.AppendLine(", @otra_entidad");
                sql.AppendLine(", @convenio_uni");
                sql.AppendLine(", @cod_nueva_zona");
                sql.AppendLine(", @FECHA_VECINO_DIGITAL");
                sql.AppendLine(", @CUIT_VECINO_DIGITAL");
                sql.AppendLine(", @Vto_inscripcion");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@nro_contrib", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@des_com", obj.des_com);
                    cmd.Parameters.AddWithValue("@nom_fantasia", obj.nom_fantasia);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@cod_tipo_per", obj.cod_tipo_per);
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Parameters.AddWithValue("@pri_periodo", obj.pri_periodo);
                    cmd.Parameters.AddWithValue("@tipo_liquidacion", obj.tipo_liquidacion);
                    cmd.Parameters.AddWithValue("@dado_baja", obj.dado_baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@exento", obj.exento);
                    cmd.Parameters.AddWithValue("@vencimiento_eximido", obj.vencimiento_eximido);
                    cmd.Parameters.AddWithValue("@per_ult", obj.per_ult);
                    cmd.Parameters.AddWithValue("@fecha_inicio", obj.fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_hab", obj.fecha_hab);
                    cmd.Parameters.AddWithValue("@nro_res", obj.nro_res);
                    cmd.Parameters.AddWithValue("@nro_exp_mesa_ent", obj.nro_exp_mesa_ent);
                    cmd.Parameters.AddWithValue("@nro_ing_bruto", obj.nro_ing_bruto);
                    cmd.Parameters.AddWithValue("@nro_cuit", obj.nro_cuit);
                    cmd.Parameters.AddWithValue("@transporte", obj.transporte);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@nom_calle", obj.nom_calle);
                    cmd.Parameters.AddWithValue("@nom_barrio", obj.nom_barrio);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@cod_calle_dom_esp", obj.cod_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@local_esp", obj.local_esp);
                    cmd.Parameters.AddWithValue("@cod_barrio_dom_esp", obj.cod_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@cod_postal_dom_esp", obj.cod_postal_dom_esp);
                    cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio);
                    cmd.Parameters.AddWithValue("@emite_cedulon", obj.emite_cedulon);
                    cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                    cmd.Parameters.AddWithValue("@Telefono1", obj.Telefono1);
                    cmd.Parameters.AddWithValue("@Telefono2", obj.Telefono2);
                    cmd.Parameters.AddWithValue("@Celular1", obj.Celular1);
                    cmd.Parameters.AddWithValue("@Celular2", obj.Celular2);
                    cmd.Parameters.AddWithValue("@Ocupacion_vereda", obj.Ocupacion_vereda);
                    cmd.Parameters.AddWithValue("@Con_sucursal", obj.Con_sucursal);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.nro_sucursal);
                    cmd.Parameters.AddWithValue("@es_transferido", obj.es_transferido);
                    cmd.Parameters.AddWithValue("@Con_DDJJ_anual", obj.con_ddjj_anual);
                    cmd.Parameters.AddWithValue("@cod_zona_liquidacion", obj.cod_zona_liquidacion);
                    cmd.Parameters.AddWithValue("@debito_automatico", obj.debito_automatico);
                    cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                    cmd.Parameters.AddWithValue("@fecha_DDJJ_Anual", obj.fecha_ddjj_anual);
                    cmd.Parameters.AddWithValue("@email_envio_cedulon", obj.email_envio_cedulon);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@Reempadronamiento", obj.Reempadronamiento);
                    cmd.Parameters.AddWithValue("@Empadronado", obj.empadronado);
                    cmd.Parameters.AddWithValue("@Fecha_empadronado", obj.fecha_empadronado);
                    cmd.Parameters.AddWithValue("@Es_agencia", obj.es_agencia);
                    cmd.Parameters.AddWithValue("@clave_gestion", obj.clave_gestion);
                    cmd.Parameters.AddWithValue("@Nro_local", obj.nro_local);
                    cmd.Parameters.AddWithValue("@Cedulon_digital", obj.cedulon_digital);
                    cmd.Parameters.AddWithValue("@Piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@cod_caracter", obj.cod_caracter);
                    cmd.Parameters.AddWithValue("@Categoria_iva", obj.categoria_iva);
                    cmd.Parameters.AddWithValue("@otra_entidad", obj.otra_entidad);
                    cmd.Parameters.AddWithValue("@convenio_uni", obj.convenio_uni);
                    cmd.Parameters.AddWithValue("@cod_nueva_zona", obj.cod_nueva_zona);
                    cmd.Parameters.AddWithValue("@FECHA_VECINO_DIGITAL", obj.fecha_vecino_digital);
                    cmd.Parameters.AddWithValue("@CUIT_VECINO_DIGITAL", obj.cuit_vecino_digital);
                    cmd.Parameters.AddWithValue("@Vto_inscripcion", obj.vto_inscripcion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Update(INDYCOM obj)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INDYCOM SET");
                sql.AppendLine("nro_bad=@nro_bad");
                sql.AppendLine(", nro_contrib=@nro_contrib");
                sql.AppendLine(", des_com=@des_com");
                sql.AppendLine(", nom_fantasia=@nom_fantasia");
                sql.AppendLine(", cod_calle=@cod_calle");
                sql.AppendLine(", nro_dom=@nro_dom");
                sql.AppendLine(", cod_barrio=@cod_barrio");
                sql.AppendLine(", cod_tipo_per=@cod_tipo_per");
                sql.AppendLine(", cod_zona=@cod_zona");
                sql.AppendLine(", pri_periodo=@pri_periodo");
                sql.AppendLine(", tipo_liquidacion=@tipo_liquidacion");
                sql.AppendLine(", dado_baja=@dado_baja");
                sql.AppendLine(", fecha_baja=@fecha_baja");
                sql.AppendLine(", exento=@exento");
                sql.AppendLine(", vencimiento_eximido=@vencimiento_eximido");
                sql.AppendLine(", per_ult=@per_ult");
                sql.AppendLine(", fecha_inicio=@fecha_inicio");
                sql.AppendLine(", fecha_hab=@fecha_hab");
                sql.AppendLine(", nro_res=@nro_res");
                sql.AppendLine(", nro_exp_mesa_ent=@nro_exp_mesa_ent");
                sql.AppendLine(", nro_ing_bruto=@nro_ing_bruto");
                sql.AppendLine(", nro_cuit=@nro_cuit");
                sql.AppendLine(", transporte=@transporte");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", nom_calle=@nom_calle");
                sql.AppendLine(", nom_barrio=@nom_barrio");
                sql.AppendLine(", ciudad=@ciudad");
                sql.AppendLine(", provincia=@provincia");
                sql.AppendLine(", pais=@pais");
                sql.AppendLine(", cod_postal=@cod_postal");
                sql.AppendLine(", cod_calle_dom_esp=@cod_calle_dom_esp");
                sql.AppendLine(", nom_calle_dom_esp=@nom_calle_dom_esp");
                sql.AppendLine(", nro_dom_esp=@nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp=@piso_dpto_esp");
                sql.AppendLine(", local_esp=@local_esp");
                sql.AppendLine(", cod_barrio_dom_esp=@cod_barrio_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp=@nom_barrio_dom_esp");
                sql.AppendLine(", ciudad_dom_esp=@ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp=@provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp=@pais_dom_esp");
                sql.AppendLine(", cod_postal_dom_esp=@cod_postal_dom_esp");
                sql.AppendLine(", fecha_cambio_domicilio=@fecha_cambio_domicilio");
                sql.AppendLine(", emite_cedulon=@Emite_cedulon");
                sql.AppendLine(", cod_situacion_judicial=@cod_situacion_judicial");
                sql.AppendLine(", telefono1=@Telefono1");
                sql.AppendLine(", telefono2=@Telefono2");
                sql.AppendLine(", celular1=@Celular1");
                sql.AppendLine(", celular2=@Celular2");
                sql.AppendLine(", ocupacion_vereda=@Ocupacion_vereda");
                sql.AppendLine(", con_sucursal=@Con_sucursal");
                sql.AppendLine(", nro_sucursal=@Nro_sucursal");
                sql.AppendLine(", es_transferido=@es_transferido");
                sql.AppendLine(", con_DDJJ_anual=@Con_DDJJ_anual");
                sql.AppendLine(", cod_zona_liquidacion=@cod_zona_liquidacion");
                sql.AppendLine(", debito_automatico=@debito_automatico");
                sql.AppendLine(", clave_pago=@clave_pago");
                sql.AppendLine(", fecha_DDJJ_Anual=@fecha_DDJJ_Anual");
                sql.AppendLine(", email_envio_cedulon=@email_envio_cedulon");
                sql.AppendLine(", telefono=@telefono");
                sql.AppendLine(", celular=@celular");
                sql.AppendLine(", reempadronamiento=@Reempadronamiento");
                sql.AppendLine(", empadronado=@Empadronado");
                sql.AppendLine(", fecha_empadronado=@Fecha_empadronado");
                sql.AppendLine(", es_agencia=@Es_agencia");
                sql.AppendLine(", clave_gestion=@clave_gestion");
                sql.AppendLine(", nro_local=@Nro_local");
                sql.AppendLine(", cedulon_digital=@Cedulon_digital");
                sql.AppendLine(", piso_dpto=@Piso_dpto");
                sql.AppendLine(", cod_cond_ante_iva=@cod_cond_ante_iva");
                sql.AppendLine(", cod_caracter=@cod_caracter");
                sql.AppendLine(", categoria_iva=@Categoria_iva");
                sql.AppendLine(", otra_entidad=@otra_entidad");
                sql.AppendLine(", convenio_uni=@convenio_uni");
                sql.AppendLine(", cod_nueva_zona=@cod_nueva_zona");
                sql.AppendLine(", FECHA_VECINO_DIGITAL=@FECHA_VECINO_DIGITAL");
                sql.AppendLine(", CUIT_VECINO_DIGITAL=@CUIT_VECINO_DIGITAL");
                sql.AppendLine(", Vto_inscripcion=@Vto_inscripcion");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@nro_contrib", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@des_com", obj.des_com);
                    cmd.Parameters.AddWithValue("@nom_fantasia", obj.nom_fantasia);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@cod_tipo_per", obj.cod_tipo_per);
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Parameters.AddWithValue("@pri_periodo", obj.pri_periodo);
                    cmd.Parameters.AddWithValue("@tipo_liquidacion", obj.tipo_liquidacion);
                    cmd.Parameters.AddWithValue("@dado_baja", obj.dado_baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@exento", obj.exento);
                    cmd.Parameters.AddWithValue("@vencimiento_eximido", obj.vencimiento_eximido);
                    cmd.Parameters.AddWithValue("@per_ult", obj.per_ult);
                    cmd.Parameters.AddWithValue("@fecha_inicio", obj.fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_hab", obj.fecha_hab);
                    cmd.Parameters.AddWithValue("@nro_res", obj.nro_res);
                    cmd.Parameters.AddWithValue("@nro_exp_mesa_ent", obj.nro_exp_mesa_ent);
                    cmd.Parameters.AddWithValue("@nro_ing_bruto", obj.nro_ing_bruto);
                    cmd.Parameters.AddWithValue("@nro_cuit", obj.nro_cuit);
                    cmd.Parameters.AddWithValue("@transporte", obj.transporte);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@nom_calle", obj.nom_calle);
                    cmd.Parameters.AddWithValue("@nom_barrio", obj.nom_barrio);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@cod_calle_dom_esp", obj.cod_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@local_esp", obj.local_esp);
                    cmd.Parameters.AddWithValue("@cod_barrio_dom_esp", obj.cod_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@cod_postal_dom_esp", obj.cod_postal_dom_esp);
                    cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio);
                    cmd.Parameters.AddWithValue("@emite_cedulon", obj.emite_cedulon);
                    cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                    cmd.Parameters.AddWithValue("@Telefono1", obj.Telefono1);
                    cmd.Parameters.AddWithValue("@Telefono2", obj.Telefono2);
                    cmd.Parameters.AddWithValue("@Celular1", obj.Celular1);
                    cmd.Parameters.AddWithValue("@Celular2", obj.Celular2);
                    cmd.Parameters.AddWithValue("@Ocupacion_vereda", obj.Ocupacion_vereda);
                    cmd.Parameters.AddWithValue("@Con_sucursal", obj.Con_sucursal);
                    cmd.Parameters.AddWithValue("@Nro_sucursal", obj.nro_sucursal);
                    cmd.Parameters.AddWithValue("@es_transferido", obj.es_transferido);
                    cmd.Parameters.AddWithValue("@Con_DDJJ_anual", obj.con_ddjj_anual);
                    cmd.Parameters.AddWithValue("@cod_zona_liquidacion", obj.cod_zona_liquidacion);
                    cmd.Parameters.AddWithValue("@debito_automatico", obj.debito_automatico);
                    cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                    cmd.Parameters.AddWithValue("@fecha_DDJJ_Anual", obj.fecha_ddjj_anual);
                    cmd.Parameters.AddWithValue("@email_envio_cedulon", obj.email_envio_cedulon);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@Reempadronamiento", obj.Reempadronamiento);
                    cmd.Parameters.AddWithValue("@Empadronado", obj.empadronado);
                    cmd.Parameters.AddWithValue("@Fecha_empadronado", obj.fecha_empadronado);
                    cmd.Parameters.AddWithValue("@Es_agencia", obj.es_agencia);
                    cmd.Parameters.AddWithValue("@clave_gestion", obj.clave_gestion);
                    cmd.Parameters.AddWithValue("@Nro_local", obj.nro_local);
                    cmd.Parameters.AddWithValue("@Cedulon_digital", obj.cedulon_digital);
                    cmd.Parameters.AddWithValue("@Piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@cod_caracter", obj.cod_caracter);
                    cmd.Parameters.AddWithValue("@Categoria_iva", obj.categoria_iva);
                    cmd.Parameters.AddWithValue("@otra_entidad", obj.otra_entidad);
                    cmd.Parameters.AddWithValue("@convenio_uni", obj.convenio_uni);
                    cmd.Parameters.AddWithValue("@cod_nueva_zona", obj.cod_nueva_zona);
                    cmd.Parameters.AddWithValue("@FECHA_VECINO_DIGITAL", obj.fecha_vecino_digital);
                    cmd.Parameters.AddWithValue("@CUIT_VECINO_DIGITAL", obj.cuit_vecino_digital);
                    cmd.Parameters.AddWithValue("@vto_inscripcion", Convert.ToDateTime(obj.vto_inscripcion, culturaFecArgentina).AddDays(90));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int InsertDatosGeneral(INDYCOM obj)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO INDYCOM(");
                sql.AppendLine("legajo");
                sql.AppendLine(", nro_bad");
                sql.AppendLine(", nro_contrib");
                sql.AppendLine(", des_com");
                sql.AppendLine(", nom_fantasia");
                sql.AppendLine(", dado_baja");
                sql.AppendLine(", fecha_baja");
                sql.AppendLine(", exento");
                sql.AppendLine(", nro_cuit");
                sql.AppendLine(", transporte");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", nom_calle");
                sql.AppendLine(", cod_calle");
                sql.AppendLine(", nro_dom");
                sql.AppendLine(", nro_local");
                sql.AppendLine(", piso_dpto");
                sql.AppendLine(", nom_barrio");
                sql.AppendLine(", cod_barrio");
                sql.AppendLine(", ciudad");
                sql.AppendLine(", provincia");
                sql.AppendLine(", pais");
                sql.AppendLine(", cod_postal");
                sql.AppendLine(", emite_cedulon");
                sql.AppendLine(", cod_situacion_judicial");
                sql.AppendLine(", telefono");
                sql.AppendLine(", celular");
                sql.AppendLine(", ocupacion_vereda");
                sql.AppendLine(", emite_cedulon");
                //sql.AppendLine(", clave_pago");
                //sql.AppendLine(", clave_gestion");
                sql.AppendLine(", vto_inscripcion");
                //sql.AppendLine(", Telefono1");
                //sql.AppendLine(", Telefono2");
                //sql.AppendLine(", Celular1");
                //sql.AppendLine(", Celular2");
                //sql.AppendLine(", Con_sucursal");
                //sql.AppendLine(", Nro_sucursal");
                //sql.AppendLine(", es_transferido");
                //sql.AppendLine(", Con_DDJJ_anual");
                //sql.AppendLine(", cod_zona_liquidacion");
                //sql.AppendLine(", debito_automatico");
                //sql.AppendLine(", fecha_DDJJ_Anual");
                //sql.AppendLine(", email_envio_cedulon");
                //sql.AppendLine(", Reempadronamiento");
                //sql.AppendLine(", Empadronado");
                //sql.AppendLine(", Fecha_empadronado");
                //sql.AppendLine(", Es_agencia");
                //sql.AppendLine(", Cedulon_digital");
                sql.AppendLine(", cod_cond_ante_iva");
                sql.AppendLine(", cod_caracter");
                sql.AppendLine(", categoria_iva");
                sql.AppendLine(", otra_entidad");
                sql.AppendLine(", convenio_uni");
                sql.AppendLine(", cod_nueva_zona");
                //sql.AppendLine(", FECHA_VECINO_DIGITAL");
                //sql.AppendLine(", CUIT_VECINO_DIGITAL");

                //sql.AppendLine(")");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @nro_bad");
                sql.AppendLine(", @nro_contrib");
                sql.AppendLine(", @des_com");
                sql.AppendLine(", @nom_fantasia");
                sql.AppendLine(", @dado_baja");
                sql.AppendLine(", @fecha_baja");
                sql.AppendLine(", @exento");
                sql.AppendLine(", @nro_cuit");
                sql.AppendLine(", @transporte");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @nom_calle");
                sql.AppendLine(", @cod_calle");
                sql.AppendLine(", @nro_dom");
                sql.AppendLine(", @nro_local");
                sql.AppendLine(", @piso_dpto");
                sql.AppendLine(", @nom_barrio");
                sql.AppendLine(", @cod_barrio");
                sql.AppendLine(", @ciudad");
                sql.AppendLine(", @provincia");
                sql.AppendLine(", @pais");
                sql.AppendLine(", @cod_postal");
                sql.AppendLine(", @emite_cedulon");
                sql.AppendLine(", @cod_situacion_judicial");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @celular");
                sql.AppendLine(", @ocupacion_vereda");
                //sql.AppendLine(", @clave_pago");
                //sql.AppendLine(", @clave_gestion");
                sql.AppendLine(", @emite_cedulon");
                sql.AppendLine(", @vto_inscripcion");
                sql.AppendLine(", @cod_cond_ante_iva");
                sql.AppendLine(", @cod_caracter");
                sql.AppendLine(", @categoria_iva");
                sql.AppendLine(", @otra_entidad");
                sql.AppendLine(", @convenio_uni");
                sql.AppendLine(", @cod_nueva_zona");
                sql.AppendLine(")");
                //sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@nro_contrib", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@des_com", obj.des_com);
                    cmd.Parameters.AddWithValue("@nom_fantasia", obj.nom_fantasia);
                    cmd.Parameters.AddWithValue("@dado_baja", obj.dado_baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@exento", obj.exento);
                    cmd.Parameters.AddWithValue("@nro_cuit", obj.nro_cuit);
                    cmd.Parameters.AddWithValue("@transporte", obj.transporte);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@nom_calle", obj.nom_calle);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@Nro_local", obj.nro_local);
                    cmd.Parameters.AddWithValue("@Piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@nom_barrio", obj.nom_barrio);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@emite_cedulon", obj.emite_cedulon);
                    cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@ocupacion_vereda", obj.Ocupacion_vereda);
                    //cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                    //cmd.Parameters.AddWithValue("@clave_gestion", obj.clave_gestion);
                    cmd.Parameters.AddWithValue("@vto_inscripcion", Convert.ToDateTime(obj.vto_inscripcion, culturaFecArgentina).AddDays(90));
                    //
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@cod_caracter", obj.cod_caracter);
                    cmd.Parameters.AddWithValue("@categoria_iva", obj.categoria_iva);
                    cmd.Parameters.AddWithValue("@otra_entidad", obj.otra_entidad);
                    cmd.Parameters.AddWithValue("@convenio_uni", obj.convenio_uni);
                    cmd.Parameters.AddWithValue("@cod_nueva_zona", obj.cod_nueva_zona);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Delete(int legajo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  INDYCOM ");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateDatosGenerales(INDYCOM obj)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INDYCOM SET");
                sql.AppendLine(", nro_bad=@nro_bad");
                sql.AppendLine(", des_com=@des_com");
                sql.AppendLine(", nom_fantasia=@nom_fansasia");
                //sql.AppendLine(", dado_baja");
                //sql.AppendLine(", fecha_baja");
                sql.AppendLine(", exento=@exento");
                sql.AppendLine(", nro_cuit=@nro_cuit");
                sql.AppendLine(", transporte=@trasnporte");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", nom_calle=@nom_calle");
                sql.AppendLine(", cod_calle=@cod_calle");
                sql.AppendLine(", nro_dom=@nro_dom");
                sql.AppendLine(", nro_local=@nro_local");
                sql.AppendLine(", piso_dpto=@piso_dpto");
                sql.AppendLine(", nom_barrio=@nom_barrio");
                sql.AppendLine(", cod_barrio=@cod_barrio");
                sql.AppendLine(", ciudad=@ciudad");
                sql.AppendLine(", provincia=@provincia");
                sql.AppendLine(", pais=@pais");
                sql.AppendLine(", cod_postal=@cod_postal");
                sql.AppendLine(", emite_cedulon=@emite_cedulon");
                sql.AppendLine(", cod_situacion_judicial=@cod_situacion_judicial");
                sql.AppendLine(", telefono=@teleono");
                sql.AppendLine(", celular=@celular");
                sql.AppendLine(", transporte=@transporte");
                sql.AppendLine(", ocupacion_vereda=@ocupacion_vereda");
                sql.AppendLine(", emite_cedulon=@emite_cedulon");
                //sql.AppendLine(", clave_pago=@clave_pago");
                //sql.AppendLine(", clave_gestion=@clave_gestion");
                //
                sql.AppendLine(", cod_cond_ante_iva");
                sql.AppendLine(", cod_caracter");
                sql.AppendLine(", categoria_iva");
                sql.AppendLine(", otra_entidad");
                sql.AppendLine(", convenio_uni");
                sql.AppendLine(", cod_nueva_zona");
                //sql.AppendLine(", vto_inscripcion=@vto_inscripcion");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@nro_contrib", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@des_com", obj.des_com);
                    cmd.Parameters.AddWithValue("@nom_fantasia", obj.nom_fantasia);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@dado_baja", obj.dado_baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@exento", obj.exento);
                    cmd.Parameters.AddWithValue("@nro_cuit", obj.nro_cuit);
                    cmd.Parameters.AddWithValue("@transporte", obj.transporte);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@nom_calle", obj.nom_calle);
                    cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@nro_local", obj.nro_local);
                    cmd.Parameters.AddWithValue("@piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@nom_barrio", obj.nom_barrio);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@emite_cedulon", obj.emite_cedulon);
                    cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@transporte", obj.transporte);
                    cmd.Parameters.AddWithValue("@ocupacion_vereda", obj.Ocupacion_vereda);
                    //cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                    //cmd.Parameters.AddWithValue("@clave_gestion", obj.clave_gestion);
                    //
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@cod_caracter", obj.cod_caracter);
                    cmd.Parameters.AddWithValue("@categoria_iva", obj.categoria_iva);
                    cmd.Parameters.AddWithValue("@otra_entidad", obj.otra_entidad);
                    cmd.Parameters.AddWithValue("@convenio_uni", obj.convenio_uni);
                    cmd.Parameters.AddWithValue("@cod_nueva_zona", obj.cod_nueva_zona);
                    //cmd.Parameters.AddWithValue("@vto_inscripcion", obj.Vto_inscripcion.AddDays(90));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateDatosDomPostal(INDYCOM obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INDYCOM SET");
                sql.AppendLine(", cod_calle_dom_esp=@cod_calle_dom_esp");
                sql.AppendLine(", nom_calle_dom_esp=@nom_calle_dom_esp");
                sql.AppendLine(", nro_dom_esp=@nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp=@piso_dpto_esp");
                sql.AppendLine(", local_esp=@local_esp");
                sql.AppendLine(", cod_barrio_dom_esp=@cod_barrio_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp=@nom_barrio_dom_esp");
                sql.AppendLine(", ciudad_dom_esp=@ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp=@provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp=@pais_dom_esp");
                sql.AppendLine(", cod_postal_dom_esp=@cod_postal_dom_esp");
                sql.AppendLine(", fecha_cambio_domicilio=@fecha_cambio_domicilio");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_calle_dom_esp", obj.cod_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@local_esp", obj.local_esp);
                    cmd.Parameters.AddWithValue("@cod_barrio_dom_esp", obj.cod_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@cod_postal_dom_esp", obj.cod_postal_dom_esp);
                    cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio);
                    cmd.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveDatosAfip(INDYCOM obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INDYCOM SET");
                sql.AppendLine(", cod_cond_ante_iva=@cod_cond_ante_iva");
                sql.AppendLine(", categoria_iva=@categoria_iva");
                sql.AppendLine(", nro_ing_bruto=@nro_ing_bruto");
                sql.AppendLine(", convenio_uni=@convenio_uni");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_cond_ante_iva", obj.cod_cond_ante_iva);
                    cmd.Parameters.AddWithValue("@categoria_iva", obj.categoria_iva.ToUpper());
                    cmd.Parameters.AddWithValue("@nro_ing_bruto", obj.nro_ing_bruto);
                    cmd.Parameters.AddWithValue("@convenio_uni", obj.convenio_uni);
                    cmd.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveDatosLiquidacion(INDYCOM obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INDYCOM SET");
                sql.AppendLine(", tipo_liquidacion=@tipo_liquidacion");
                sql.AppendLine(", pri_periodo=@pri_periodo");
                sql.AppendLine(", per_ult=@per_ult");
                sql.AppendLine(", cod_zona=@cod_zona");
                sql.AppendLine(", cod_zona_liquidacion=@cod_zona_liquidacion");
                sql.AppendLine(", cod_nueva_zona=@cod_nueva_zona");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@tipo_liquidacion", obj.tipo_liquidacion);
                    cmd.Parameters.AddWithValue("@pri_periodo", obj.pri_periodo);
                    cmd.Parameters.AddWithValue("@per_ult", obj.per_ult);
                    cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);
                    cmd.Parameters.AddWithValue("@cod_zona_liquidacion", obj.cod_zona_liquidacion);
                    cmd.Parameters.AddWithValue("@cod_nueva_zona", obj.cod_nueva_zona);
                    cmd.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Count()
        {
            try
            {
                int count = 0;
                string sql = @"SELECT count(*) 
                               FROM Indycom (nolock)";
                //Where Baja=@baja";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    //cmd.Parameters.AddWithValue("@baja", baja);
                    cmd.Connection.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<INDYCOM> GetIndycomPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta)
        {
            bool busquedaSi = false;
            try
            {
                List<INDYCOM> lst = new List<INDYCOM>();
                string sql = @" SELECT *
                                FROM (
                                    SELECT ROW_NUMBER() OVER (ORDER BY legajo) AS RowNum, *
                                    FROM INDYCOM (nolock)
                                ) AS tabla_numerada";
                //WHERE
                //RowNum BETWEEN @desde AND @hasta
                //ORDER By Dominio
                string sqlWhere = "";
                if (!string.IsNullOrEmpty(buscarPor))
                {
                    switch (buscarPor)
                    {
                        case "legajo":
                            sqlWhere = @" WHERE
                                legajo=Convert(int,@parametro) AND
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By legajo";
                            break;
                        case "cuit":
                            sqlWhere = @" WHERE
                                nro_cuit=Convert(varchar(11),@parametro) AND
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By legajo";
                            break;
                        case "titular":
                            if (strParametro != string.Empty)
                            {
                                sqlWhere = @" WHERE
                                nro_bad in (SELECT nro_bad
					                        FROM badec	
					                        WHERE badec.nombre like @parametro + '%')  AND 
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By legajo";
                            }
                            break;
                        case "nom_fantasia":
                            sqlWhere = @" WHERE
                                nom_fantasia like @parametro + '%' AND
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By legajo";
                            break;
                        default:
                            break;
                    }
                }
                if (sqlWhere.Length > 0)
                {
                    busquedaSi = true;
                    sql += sqlWhere;
                }
                else
                {
                    busquedaSi = false;
                    sql += " WHERE RowNum BETWEEN @desde AND @hasta ORDER By legajo";
                }
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@desde", registro_desde);
                    cmd.Parameters.AddWithValue("@hasta", registro_hasta);
                    if (busquedaSi)
                        cmd.Parameters.AddWithValue("@parametro", strParametro);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region (Combos y Busquedas)
        public static List<TIPOS_LIQ_IYC> Tipos_liq_iyc()
        {
            try
            {
                List<TIPOS_LIQ_IYC> lst = new List<TIPOS_LIQ_IYC>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TIPOS_LIQ_IYC";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    TIPOS_LIQ_IYC obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new TIPOS_LIQ_IYC();
                            if (!dr.IsDBNull(0)) { obj.cod_tipo_liq = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.descripcion_tipo_liq = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TIPOS_PER_IYC> Tipos_per_iyc()
        {
            try
            {
                List<TIPOS_PER_IYC> lst = new List<TIPOS_PER_IYC>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TIPOS_PER_IYC";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    TIPOS_PER_IYC obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new TIPOS_PER_IYC();
                            if (!dr.IsDBNull(0)) { obj.cod_tipo_per = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.des_tipo_per = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.cuotas = dr.GetInt16(2); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<TIPOS_DE_IVA> Tipos_iva()
        {
            try
            {
                List<TIPOS_DE_IVA> lst = new List<TIPOS_DE_IVA>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TIPOS_DE_IVA";
                    cmd.Connection.Open();
                    TIPOS_DE_IVA obj;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new TIPOS_DE_IVA();
                            if (!dr.IsDBNull(0)) { obj.cod_cond_ante_iva = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.des_cond_ante_iva = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.alicuota = dr.GetDecimal(2); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Combo> Tipos_entidad()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CARACTER_ENTIDADES";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Combo? obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = dr.GetString(1); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Zonasiyc()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM ZONAS_IYC";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetString(0)); }
                            //if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Situacion_judicial()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " Select cod_situacion_judicial, descripcion From SITUACION_JUDICIAL";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Buscador> GetConvenios(string nom_convenio)
        {
            try
            {
                string strSQL = @"SELECT  
                                  Codigo=cod_convenio,
                                  Nombre=CONVERT(VARCHAR(40),nom_convenio)
                                  FROM CONVENIOS_IYC
                                  WHERE  nom_convenio LIKE @nombre_aproximado
                                  ORDER BY cod_convenio";
                List<Buscador> lst = new List<Buscador>();
                Buscador obj;
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nombre_aproximado", nom_convenio + "%");
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Buscador();
                            if (!dr.IsDBNull(0)) { obj.codigo = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Buscador> GetMinimos_indycom(string minimo)
        {
            try
            {
                string strSQL = @"SELECT  
                                    Codigo=cod_minimo,
                                    Descripción=CONVERT(VARCHAR(40),des_minimo)
                                    FROM MINIMOS_INDYCOM
                                    WHERE  des_minimo LIKE @nombre_aproximado
                                    ORDER BY cod_minimo";
                List<Buscador> lst = new List<Buscador>();
                Buscador obj;
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nombre_aproximado", minimo + "%");
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Buscador();
                            if (!dr.IsDBNull(0)) { obj.codigo = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        public static void BajaComercial(int legajo, string fecha_baja)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE INDYCOM SET");
                sql.AppendLine(", dado_baja=1");
                sql.AppendLine(", fecha_baja=@fecha_baja");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    //cmd.Parameters.AddWithValue("@dado_baja", 1);
                    cmd.Parameters.AddWithValue("@fecha_baja", Convert.ToDateTime(fecha_baja, culturaFecArgentina).ToString());
                    cmd.Connection.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void BajaSucursal(int legajo, int nro_sucursal, string fecha_baja)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Sucursales_Indycom SET");
                sql.AppendLine(", dado_baja=1");
                sql.AppendLine(", fecha_baja=@fecha_baja");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo AND");
                sql.AppendLine("nro_sucursal=@nro_sucursal");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@nro_sucursal", nro_sucursal);
                    cmd.Parameters.AddWithValue("@fecha_baja", Convert.ToDateTime(fecha_baja, culturaFecArgentina).ToString());
                    cmd.Connection.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //SELECT des_com FROM sucursales_indycom  WHERE legajo= :legajo  and nro_sucursal= :nro_sucursal and dado_baja=0 




    }
}

