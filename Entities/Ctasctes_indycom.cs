using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC.Entities
{
    public class Ctasctes_indycom : DALBase
    {
        public int tipo_transaccion { get; set; }
        public int nro_transaccion { get; set; }
        public int nro_pago_parcial { get; set; }
        public int legajo { get; set; }
        public DateTime? fecha_transaccion { get; set; }
        public string periodo { get; set; }
        public decimal monto_original { get; set; }
        public int nro_plan { get; set; }
        public bool pagado { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public int nro_procuracion { get; set; }
        public bool pago_parcial { get; set; }
        public DateTime? vencimiento { get; set; }
        public int nro_cedulon { get; set; }
        public bool declaracion_jurada { get; set; }
        public bool liquidacion_especial { get; set; }
        public int cod_cate_deuda { get; set; }
        public decimal monto_pagado { get; set; }
        public decimal recargo { get; set; }
        public decimal honorarios { get; set; }
        public decimal iva_hons { get; set; }
        public Int16 tipo_deuda { get; set; }
        public string decreto { get; set; }
        public string observaciones { get; set; }
        public Int64 nro_cedulon_paypertic { get; set; }
        //
        //Las propiedades de abajo son
        //
        public string des_movimiento { get; set; }
        public string des_categoria { get; set; }
        public decimal deuda { get; set; }
        public int sel { get; set; }
        public decimal costo_financiero { get; set; }
        public string des_rubro { get; set; }
        public int cod_tipo_per { get; set; }
        public decimal sub_total { get; set; }
        public int deuda_activa { get; set; }

        public Ctasctes_indycom()
        {
            tipo_transaccion = 0;
            nro_transaccion = 0;
            nro_pago_parcial = 0;
            legajo = 0;
            fecha_transaccion = DateTime.Now;
            periodo = string.Empty;
            monto_original = 0;
            nro_plan = 0;
            pagado = false;
            debe = 0;
            haber = 0;
            nro_procuracion = 0;
            pago_parcial = false;
            vencimiento = DateTime.Now;
            nro_cedulon = 0;
            declaracion_jurada = false;
            liquidacion_especial = false;
            cod_cate_deuda = 0;
            monto_pagado = 0;
            recargo = 0;
            honorarios = 0;
            iva_hons = 0;
            tipo_deuda = 0;
            decreto = string.Empty;
            observaciones = string.Empty;
            nro_cedulon_paypertic = 0;
            //
            des_movimiento = string.Empty;
            des_categoria = string.Empty;
            deuda = 0;
            sel = 0;
            costo_financiero = 0;
            des_rubro = string.Empty;
            cod_tipo_per = 0;
            deuda_activa = 0;
        }

        private static List<Ctasctes_indycom> mapeo(SqlDataReader dr)
        {
            List<Ctasctes_indycom> lst = new List<Ctasctes_indycom>();
            Ctasctes_indycom obj;
            if (dr.HasRows)
            {
                int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int nro_pago_parcial = dr.GetOrdinal("nro_pago_parcial");
                int legajo = dr.GetOrdinal("legajo");
                int fecha_transaccion = dr.GetOrdinal("fecha_transaccion");
                int periodo = dr.GetOrdinal("periodo");
                int monto_original = dr.GetOrdinal("monto_original");
                int nro_plan = dr.GetOrdinal("nro_plan");
                int pagado = dr.GetOrdinal("pagado");
                int debe = dr.GetOrdinal("debe");
                int haber = dr.GetOrdinal("haber");
                int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                int pago_parcial = dr.GetOrdinal("pago_parcial");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                int declaracion_jurada = dr.GetOrdinal("declaracion_jurada");
                int liquidacion_especial = dr.GetOrdinal("liquidacion_especial");
                int cod_cate_deuda = dr.GetOrdinal("cod_cate_deuda");
                int monto_pagado = dr.GetOrdinal("monto_pagado");
                int recargo = dr.GetOrdinal("recargo");
                int honorarios = dr.GetOrdinal("honorarios");
                int iva_hons = dr.GetOrdinal("iva_hons");
                int tipo_deuda = dr.GetOrdinal("tipo_deuda");
                int decreto = dr.GetOrdinal("decreto");
                int observaciones = dr.GetOrdinal("observaciones");
                int nro_cedulon_paypertic = dr.GetOrdinal("nro_cedulon_paypertic");
                int deuda_activa = dr.GetOrdinal("deuda_activa");
                while (dr.Read())
                {
                    obj = new Ctasctes_indycom();
                    if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(nro_pago_parcial)) { obj.nro_pago_parcial = dr.GetInt32(nro_pago_parcial); }
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(fecha_transaccion)) { obj.fecha_transaccion = dr.GetDateTime(fecha_transaccion); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                    if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                    if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                    if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                    if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                    if (!dr.IsDBNull(pago_parcial)) { obj.pago_parcial = dr.GetBoolean(pago_parcial); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                    if (!dr.IsDBNull(declaracion_jurada)) { obj.declaracion_jurada = dr.GetBoolean(declaracion_jurada); }
                    if (!dr.IsDBNull(liquidacion_especial)) { obj.liquidacion_especial = dr.GetBoolean(liquidacion_especial); }
                    if (!dr.IsDBNull(cod_cate_deuda)) { obj.cod_cate_deuda = dr.GetInt32(cod_cate_deuda); }
                    if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                    if (!dr.IsDBNull(recargo)) { obj.recargo = dr.GetDecimal(recargo); }
                    if (!dr.IsDBNull(honorarios)) { obj.honorarios = dr.GetDecimal(honorarios); }
                    if (!dr.IsDBNull(iva_hons)) { obj.iva_hons = dr.GetDecimal(iva_hons); }
                    if (!dr.IsDBNull(tipo_deuda)) { obj.tipo_deuda = dr.GetInt16(tipo_deuda); }
                    if (!dr.IsDBNull(decreto)) { obj.decreto = dr.GetString(decreto); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(nro_cedulon_paypertic)) { obj.nro_cedulon_paypertic = dr.GetInt64(nro_cedulon_paypertic); }
                    if (!dr.IsDBNull(deuda_activa)) { obj.deuda_activa = dr.GetInt32(deuda_activa); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ctasctes_indycom> read()
        {
            try
            {
                List<Ctasctes_indycom> lst = new List<Ctasctes_indycom>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Ctasctes_indycom";
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

        public static Ctasctes_indycom getByPk(int tipo_transaccion, int nro_transaccion, int nro_pago_parcial)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ctasctes_indycom WHERE");
                sql.AppendLine("tipo_transaccion = @tipo_transaccion");
                sql.AppendLine("AND nro_transaccion = @nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial = @nro_pago_parcial");
                Ctasctes_indycom obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", nro_pago_parcial);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ctasctes_indycom> lst = mapeo(dr);
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

        public static int insert(Ctasctes_indycom obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ctasctes_indycom(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", legajo");
                sql.AppendLine(", fecha_transaccion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", monto_original");
                sql.AppendLine(", nro_plan");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                sql.AppendLine(", nro_procuracion");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_cedulon");
                sql.AppendLine(", declaracion_jurada");
                sql.AppendLine(", liquidacion_especial");
                sql.AppendLine(", cod_cate_deuda");
                sql.AppendLine(", monto_pagado");
                sql.AppendLine(", recargo");
                sql.AppendLine(", honorarios");
                sql.AppendLine(", iva_hons");
                sql.AppendLine(", tipo_deuda");
                sql.AppendLine(", decreto");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", nro_cedulon_paypertic");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @fecha_transaccion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @monto_original");
                sql.AppendLine(", @nro_plan");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                sql.AppendLine(", @nro_procuracion");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_cedulon");
                sql.AppendLine(", @declaracion_jurada");
                sql.AppendLine(", @liquidacion_especial");
                sql.AppendLine(", @cod_cate_deuda");
                sql.AppendLine(", @monto_pagado");
                sql.AppendLine(", @recargo");
                sql.AppendLine(", @honorarios");
                sql.AppendLine(", @iva_hons");
                sql.AppendLine(", @tipo_deuda");
                sql.AppendLine(", @decreto");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @nro_cedulon_paypertic");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@fecha_transaccion", obj.fecha_transaccion);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@nro_plan", obj.nro_plan);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
                    cmd.Parameters.AddWithValue("@haber", obj.haber);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Parameters.AddWithValue("@pago_parcial", obj.pago_parcial);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@declaracion_jurada", obj.declaracion_jurada);
                    cmd.Parameters.AddWithValue("@liquidacion_especial", obj.liquidacion_especial);
                    cmd.Parameters.AddWithValue("@cod_cate_deuda", obj.cod_cate_deuda);
                    cmd.Parameters.AddWithValue("@monto_pagado", obj.monto_pagado);
                    cmd.Parameters.AddWithValue("@recargo", obj.recargo);
                    cmd.Parameters.AddWithValue("@honorarios", obj.honorarios);
                    cmd.Parameters.AddWithValue("@iva_hons", obj.iva_hons);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Parameters.AddWithValue("@decreto", obj.decreto);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", obj.nro_cedulon_paypertic);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void update(Ctasctes_indycom obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ctasctes_indycom SET");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine(", fecha_transaccion=@fecha_transaccion");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", monto_original=@monto_original");
                sql.AppendLine(", nro_plan=@nro_plan");
                sql.AppendLine(", pagado=@pagado");
                sql.AppendLine(", debe=@debe");
                sql.AppendLine(", haber=@haber");
                sql.AppendLine(", nro_procuracion=@nro_procuracion");
                sql.AppendLine(", pago_parcial=@pago_parcial");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", nro_cedulon=@nro_cedulon");
                sql.AppendLine(", declaracion_jurada=@declaracion_jurada");
                sql.AppendLine(", liquidacion_especial=@liquidacion_especial");
                sql.AppendLine(", cod_cate_deuda=@cod_cate_deuda");
                sql.AppendLine(", monto_pagado=@monto_pagado");
                sql.AppendLine(", recargo=@recargo");
                sql.AppendLine(", honorarios=@honorarios");
                sql.AppendLine(", iva_hons=@iva_hons");
                sql.AppendLine(", tipo_deuda=@tipo_deuda");
                sql.AppendLine(", decreto=@decreto");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", nro_cedulon_paypertic=@nro_cedulon_paypertic");
                sql.AppendLine("WHERE");
                sql.AppendLine("tipo_transaccion=@tipo_transaccion");
                sql.AppendLine("AND nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial=@nro_pago_parcial");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@fecha_transaccion", obj.fecha_transaccion);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@nro_plan", obj.nro_plan);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
                    cmd.Parameters.AddWithValue("@haber", obj.haber);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Parameters.AddWithValue("@pago_parcial", obj.pago_parcial);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@declaracion_jurada", obj.declaracion_jurada);
                    cmd.Parameters.AddWithValue("@liquidacion_especial", obj.liquidacion_especial);
                    cmd.Parameters.AddWithValue("@cod_cate_deuda", obj.cod_cate_deuda);
                    cmd.Parameters.AddWithValue("@monto_pagado", obj.monto_pagado);
                    cmd.Parameters.AddWithValue("@recargo", obj.recargo);
                    cmd.Parameters.AddWithValue("@honorarios", obj.honorarios);
                    cmd.Parameters.AddWithValue("@iva_hons", obj.iva_hons);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Parameters.AddWithValue("@decreto", obj.decreto);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", obj.nro_cedulon_paypertic);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ctasctes_indycom obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ctasctes_indycom ");
                sql.AppendLine("WHERE");
                sql.AppendLine("tipo_transaccion=@tipo_transaccion");
                sql.AppendLine("AND nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial=@nro_pago_parcial");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Periodos> IniciarCtacte(int legajo)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                string sql = string.Empty;
                sql = @"SELECT periodo, vencimiento_1 as vencimiento, 0 as sel
                        FROM Vencimientos_IyC V (NOLOCK)
                        WHERE
                        v.cod_tipo_per<>4 AND
                        v.periodo>='2021/00' AND
                        NOT EXISTS (SELECT * 
                            FROM CTASCTES_INDYCOM C
                            WHERE C.tipo_transaccion=1 
                                AND C.legajo=@legajo
                                AND C.periodo=V.periodo)
                        ORDER BY V.periodo";
                List<Periodos> lst = new();
                Periodos? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int periodo = dr.GetOrdinal("periodo");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(vencimiento))
                            {
                                obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina).ToString();
                            }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Confirma_iniciar_ctacte(int legajo, List<Ctasctes_indycom> lst,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                int nro_transaccion = 0;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ctasctes_indycom(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", legajo");
                sql.AppendLine(", fecha_transaccion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", monto_original");
                //sql.AppendLine(", nro_plan");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                //sql.AppendLine(", nro_procuracion");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_cedulon");
                sql.AppendLine(", declaracion_jurada");
                sql.AppendLine(", liquidacion_especial");
                sql.AppendLine(", cod_cate_deuda");
                //sql.AppendLine(", monto_pagado");
                //sql.AppendLine(", recargo");
                //sql.AppendLine(", honorarios");
                //sql.AppendLine(", iva_hons");
                sql.AppendLine(", tipo_deuda");
                //sql.AppendLine(", decreto");
                //sql.AppendLine(", observaciones");
                //sql.AppendLine(", nro_cedulon_paypertic");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @fecha_transaccion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @monto_original");
                //sql.AppendLine(", @nro_plan");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                //sql.AppendLine(", @nro_procuracion");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_cedulon");
                sql.AppendLine(", @declaracion_jurada");
                sql.AppendLine(", @liquidacion_especial");
                sql.AppendLine(", @cod_cate_deuda");
                //sql.AppendLine(", @monto_pagado");
                //sql.AppendLine(", @recargo");
                //sql.AppendLine(", @honorarios");
                //sql.AppendLine(", @iva_hons");
                sql.AppendLine(", @tipo_deuda");
                //sql.AppendLine(", @decreto");
                //sql.AppendLine(", @observaciones");
                //sql.AppendLine(", @nro_cedulon_paypertic");
                sql.AppendLine(")");

                nro_transaccion = GetNroTransaccion(3, con, trx);
                UpdateNroTransaccion(3, (nro_transaccion + lst.Count), con, trx);
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@tipo_transaccion", 1);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                cmd.Parameters.AddWithValue("@nro_pago_parcial", 0);
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@fecha_transaccion", DateTime.Now);
                cmd.Parameters.AddWithValue("@periodo", string.Empty);
                cmd.Parameters.AddWithValue("@monto_original", 0);
                //cmd.Parameters.AddWithValue("@nro_plan", null);
                cmd.Parameters.AddWithValue("@pagado", 0);
                cmd.Parameters.AddWithValue("@debe", 0);
                cmd.Parameters.AddWithValue("@haber", 0);
                //cmd.Parameters.AddWithValue("@nro_procuracion", null);
                cmd.Parameters.AddWithValue("@pago_parcial", 0);
                cmd.Parameters.AddWithValue("@vencimiento", null);
                cmd.Parameters.AddWithValue("@nro_cedulon", 0);
                cmd.Parameters.AddWithValue("@declaracion_jurada", 1);
                cmd.Parameters.AddWithValue("@liquidacion_especial", 0);
                cmd.Parameters.AddWithValue("@cod_cate_deuda", 1);
                //cmd.Parameters.AddWithValue("@honorarios", 0);
                //cmd.Parameters.AddWithValue("@iva_hons", 0);
                cmd.Parameters.AddWithValue("@tipo_deuda", 1);
                //cmd.Parameters.AddWithValue("@decreto", 0);
                //cmd.Parameters.AddWithValue("@observaciones", string.Empty);
                //cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", 0);
                //cmd.Connection.Open();
                foreach (var item in lst)
                {
                    nro_transaccion += 1;
                    cmd.Parameters["@tipo_transaccion"].Value = 1;
                    cmd.Parameters["@periodo"].Value = item.periodo;
                    cmd.Parameters["@nro_transaccion"].Value = nro_transaccion;
                    cmd.Parameters["@nro_pago_parcial"].Value = 0;
                    cmd.Parameters["@legajo"].Value = legajo;
                    cmd.Parameters["@vencimiento"].Value = item.vencimiento;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static List<Ctasctes_indycom> PeriodosRecalculo(int legajo)
        //{
        //    try
        //    {
        //        string sql = string.Empty;
        //        sql = @"SELECT a.nro_transaccion, a.periodo, a.monto_original,
        //                        a.debe, a.vencimiento, v.cod_tipo_per as tipo_per
        //                    FROM CTASCTES_INDYCOM a WITH (NOLOCK)
        //                    join VENCIMIENTOS_PERIODOS2 v on
        //                    v.subsistema=3 and
        //                    v.periodo=a.periodo
        //                    WHERE
        //                        a.legajo=@lgejao AND
        //                        a.tipo_transaccion=1 AND pagado=0 AND
        //                        a.pago_parcial=0 AND nro_plan IS null AND
        //                        a.nro_procuracion IS NULL AND
        //                        a.cod_cate_deuda = 1                            
        //                    ORDER by A.periodo";
        //        List<Ctasctes_indycom> lst = new();
        //        using (SqlConnection con = GetConnectionSIIMVA())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@legajo", legajo);
        //            cmd.Connection.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            Ctasctes_indycom? obj;
        //            if (dr.HasRows)
        //            {
        //                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
        //                int periodo = dr.GetOrdinal("periodo");
        //                int monto_original = dr.GetOrdinal("monto_original");
        //                int debe = dr.GetOrdinal("debe");
        //                int vencimiento = dr.GetOrdinal("vencimiento");
        //                int tipo_per = dr.GetOrdinal("tipo_per");
        //                while (dr.Read())
        //                {
        //                    obj = new Ctasctes_indycom();

        //                    if (!dr.IsDBNull(nro_transaccion))
        //                    { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
        //                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
        //                    if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
        //                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
        //                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
        //                    if (!dr.IsDBNull(tipo_per)) { obj.tipo_deuda = dr.GetInt16(tipo_per); }
        //                    lst.Add(obj);
        //                }
        //            }
        //        }
        //        return lst;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public static List<Combo> ListarCategoriasIyC()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CATE_DEUDA_INDYCOM";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Combo? obj;
                    obj = new Combo();
                    obj.text = "TODAS LAS DEUDAS";
                    obj.value = "0";
                    lst.Add(obj);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = dr.GetString(1); }
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
        //////////////
        public static List<TARJETAS_DEBITOS> ListarTarjetas()
        {
            try
            {
                string sql = @"SELECT cod_tarjeta,des_tarjeta 
                               FROM TARJETAS_DEBITOS 
                               WHERE cod_paypertic IS NOT null and activa=1";
                List<TARJETAS_DEBITOS> lst = new List<TARJETAS_DEBITOS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    TARJETAS_DEBITOS? obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(0)) { obj.cod_tarjeta = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.des_tarjeta = dr.GetString(1); }
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
        public static List<Planes_cobro> ListarPlanesdeTarjetas(int cod_tarjeta, int subsistema)
        {
            try
            {
                List<Planes_cobro> lst = new List<Planes_cobro>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT pc.cod_plan,pc.descripcion,TD.debito,TD.des_tarjeta,
                                            pc.Con_dto_interes,pc.ali_dto_interes,pc.Con_costo_financiero,
                                            pc.ali_costo_financiero,pc.suma_descadic 
                                        FROM Planes_cobro pc 
                                        LEFT JOIN TARJETAS_DEBITOS td ON 
                                            td.cod_tarjeta = pc.cod_tarjeta 
                                        WHERE pc.subsistema=@subistema AND 
                                            pc.activo_windows=1 AND 
                                            pc.cod_tarjeta=@cod_tarjeta";
                    cmd.Parameters.AddWithValue("@cod_tarjeta", cod_tarjeta);
                    cmd.Parameters.AddWithValue("@subsistema", subsistema);//5
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Planes_cobro? obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Planes_cobro();
                            if (!dr.IsDBNull(0)) { obj.cod_plan = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.debito = dr.GetInt16(2); }
                            if (!dr.IsDBNull(3)) { obj.des_tarjeta = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.con_dto_interes = dr.GetInt16(4); }
                            if (!dr.IsDBNull(5)) { obj.ali_dto_interes = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.con_costo_financiero = dr.GetInt16(6); }
                            if (!dr.IsDBNull(7)) { obj.ali_costo_financiero = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.suma_descadic = dr.GetBoolean(8); }
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
        public static List<Ctasctes_indycom> ListarCtacte(int legajo, int tipo_consulta, int cate_deuda_desde, int cate_deuda_hasta)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder strSql = new StringBuilder();
                strSql.AppendLine(@"SELECT 
                                      movimiento=
                                        (SELECT t.Descripcion 
                                        FROM TIPOS_TRANSACCIONES t 
                                        WHERE t.tipo_transaccion=a.Tipo_transaccion), 
                                    a.tipo_transaccion, 
                                    a.nro_transaccion, 
                                    a.periodo, 
                                    a.fecha_transaccion, 
                                    a.monto_original, 
                                    a.debe, 
                                    a.haber, 
                                    a.nro_plan, 
                                    a.nro_procuracion,
                                    categoria = 
                                        (SELECT c.des_categoria 
                                        FROM CATE_DEUDA_INDYCOM c 
                                        WHERE c.cod_categoria = a.cod_cate_deuda),
                                    a.pagado,
                                    a.nro_cedulon
                                    FROM CTASCTES_INDYCOM A WITH (NOLOCK) 
                                    WHERE  
                                      A.legajo=@legajo AND");
                if (tipo_consulta == 1)// toda la cuenta corriente
                {
                    if (cate_deuda_desde == cate_deuda_hasta)
                    {
                        strSql.AppendLine(@"A.cod_cate_deuda = @categoria_desde");
                    }
                    else
                    {
                        strSql.AppendLine(@"A.cod_cate_deuda between @categoria_desde and @categoria_hasta");
                    }
                    strSql.AppendLine(@"ORDER BY PERIODO, NRO_TRANSACCION, TIPO_TRANSACCION");
                }
                else  // solo deudas
                {
                    if (cate_deuda_desde == cate_deuda_hasta)
                    {
                        strSql.AppendLine(@"A.cod_cate_deuda = @categoria_desde AND");
                    }
                    else
                    {
                        strSql.AppendLine(@"A.cod_cate_deuda between @categoria_desde and @categoria_hasta AND");
                    }
                    strSql.AppendLine(@"((A.tipo_transaccion=1 AND A.pagado=0) OR (A.tipo_transaccion <> 1 AND NOT EXISTS 
                        (SELECT * FROM CTASCTES_INDYCOM B WHERE B.tipo_transaccion = 1 AND B.nro_transaccion = A.nro_transaccion AND pagado = 1)))");
                    strSql.AppendLine(@"ORDER BY PERIODO, NRO_TRANSACCION, TIPO_TRANSACCION");
                }
                List<Ctasctes_indycom> lst = new List<Ctasctes_indycom>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@categoria_desde", cate_deuda_desde);
                    cmd.Parameters.AddWithValue("@categoria_hasta", cate_deuda_hasta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Ctasctes_indycom? obj;
                    if (dr.HasRows)
                    {
                        int movimiento = dr.GetOrdinal("movimiento");
                        int periodo = dr.GetOrdinal("periodo");
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int fecha_transaccion = dr.GetOrdinal("fecha_transaccion");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int haber = dr.GetOrdinal("haber");
                        int nro_plan = dr.GetOrdinal("nro_plan");
                        int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                        int categoria = dr.GetOrdinal("categoria");
                        int pagado = dr.GetOrdinal("pagado");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(movimiento)) { obj.des_movimiento = dr.GetString(movimiento); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(fecha_transaccion)) { obj.fecha_transaccion = Convert.ToDateTime(dr.GetDateTime(fecha_transaccion), culturaFecArgentina); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                            if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                            if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                            if (!dr.IsDBNull(categoria)) { obj.des_categoria = dr.GetString(categoria); }
                            if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            lst.Add(obj);
                        }
                    }

                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (i == 0)
                            lst[i].sub_total = -lst[i].debe + lst[i].haber;
                        else
                            lst[i].sub_total = lst[i - 1].sub_total - lst[i].debe + lst[i].haber;
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            try
            {
                string strSQL = @"SELECT A.*, B.des_categoria,
                                    des_movimiento=(SELECT t.Descripcion 
                                                FROM TIPOS_TRANSACCIONES t 
                                                WHERE t.tipo_transaccion=a.Tipo_transaccion)
                                    FROM CTASCTES_INDYCOM A
                                    JOIN CATE_DEUDA_INDYCOM B on
                                      A.cod_cate_deuda=B.cod_categoria
                                    WHERE
                                      A.tipo_transaccion=@tipo_transaccion AND
                                      A.nro_transaccion=@nro_transaccion";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder strRetorno = new StringBuilder();
                List<Ctasctes_indycom> lst = new List<Ctasctes_indycom>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Ctasctes_indycom? obj;
                    obj = new();
                    if (dr.HasRows)
                    {
                        int des_movimiento = dr.GetOrdinal("des_movimiento");
                        int periodo = dr.GetOrdinal("periodo");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int fecha_transaccion = dr.GetOrdinal("fecha_transaccion");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int haber = dr.GetOrdinal("haber");
                        int nro_plan = dr.GetOrdinal("nro_plan");
                        int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                        int categoria = dr.GetOrdinal("des_categoria");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        while (dr.Read())
                        {
                            //obj = new();
                            obj.tipo_transaccion = tipo_transaccion;
                            obj.nro_transaccion = nro_transaccion;
                            if (!dr.IsDBNull(des_movimiento)) { obj.des_movimiento = dr.GetString(des_movimiento); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina); }
                            if (!dr.IsDBNull(fecha_transaccion)) { obj.fecha_transaccion = Convert.ToDateTime(dr.GetDateTime(fecha_transaccion), culturaFecArgentina); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                            if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                            if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                            if (!dr.IsDBNull(categoria)) { obj.des_categoria = dr.GetString(categoria); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            lst.Add(obj);
                        }
                        if (lst.Count > 0)
                            obj = lst[0];
                        strRetorno.AppendLine("Fecha Transacci�n: " + Convert.ToString(obj.fecha_transaccion, culturaFecArgentina));
                        strRetorno.AppendLine("Vencimiento: " + Convert.ToString(obj.vencimiento, culturaFecArgentina));
                        switch (obj.tipo_transaccion)
                        {
                            case 1:
                                strRetorno.AppendLine("Mov.Deuda");
                                strRetorno.AppendLine("Per�odo: " + obj.periodo);
                                strRetorno.AppendLine(obj.des_categoria.ToString());
                                if (obj.pago_parcial)
                                    strRetorno.AppendLine("Deuda con Pago Parcial");
                                strRetorno.AppendLine("Nro Transacci�n: " + obj.nro_transaccion.ToString());
                                break;
                            case 2:
                                if (obj.nro_cedulon != 0)
                                    strRetorno.AppendLine("Mov.Pago con N� Cedulon:" + obj.nro_cedulon.ToString());
                                else
                                    strRetorno.AppendLine("Mov.Pago");
                                strRetorno.AppendLine("Per�odo:" + obj.periodo.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                if (obj.pago_parcial)
                                    strRetorno.AppendLine("Pago Parcial");
                                strRetorno.AppendLine("Nro Transacci�n: " + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine("Monto Pagado:" + obj.monto_pagado.ToString());
                                break;
                            case 3:
                                strRetorno.AppendLine("Mov.Fin de Plan de Pago");
                                strRetorno.AppendLine("Plan de Pago N�:" + obj.nro_plan.ToString());
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 4:
                                strRetorno.AppendLine("Mov.Bonificaci�n por pago anticipado");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 5:
                                strRetorno.AppendLine("Mov.Ajuste Positivo");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 6:
                                strRetorno.AppendLine("Mov.Ajuste Negativo");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 7:
                                strRetorno.AppendLine("Mov.Cancelaci�n Operativa");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 8:
                                strRetorno.AppendLine("Mov.Decreto o Resoluci�n");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 9:
                                strRetorno.AppendLine("Mov.Baja de Plan de Pagos");
                                strRetorno.AppendLine("Plan de Pago N�:" + obj.nro_plan.ToString());
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            default:
                                break;
                        }
                    }
                    if (obj.nro_cedulon > 0)
                    { strRetorno.AppendLine(Tipos_pago(obj.nro_cedulon)); }
                    string texto = strRetorno.ToString();
                    string[] lineas = texto.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    string ret = "<div>";
                    foreach (string linea in lineas)
                    {
                        ret += string.Format("<p>{0}</p>", linea);
                    }
                    ret += "</div>";
                    return ret;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string Tipos_pago(int nro_cedulon)
        {
            try
            {
                string strSQL = @"
                                SELECT c.nro_movimiento, Tipo_pago=t.Descripcion,forma_pago=e.descripcion, 
                                CASE 
                                   WHEN c.efectivo>0 THEN 'EFECTIVO'
                                   ELSE   ''
                                   END AS EFECTIVO,
                                CASE   
                                   WHEN C.debitos>0 THEN 'DEBITO'
                                   ELSE   ''
                                   END AS DEBITO,
                                CASE   
                                   WHEN C.creditos>0 THEN 'CREDITO'
                                   ELSE   ''
                                   END AS CREDITO,
                                CASE   
                                   WHEN C.cheques>0 THEN 'CHEQUE'
                                   ELSE   ''
                                   END AS CHEQUE,
                                CASE   
                                   WHEN C.documentos>0 THEN 'DOCUMENTO'
                                   ELSE   ''
                                   END AS DOCUMENTOS,   
                                CASE   
                                   WHEN C.canje>0 THEN 'CANJE'
                                   ELSE   ''
                                   END AS CANJE,
   
                                CASE   
                                   WHEN C.bonos>0 THEN 'BONOS'
                                   ELSE   ''
                                   END AS BONOS ,     
                                CASE   
                                   WHEN C.acreditacion_bcos>0 THEN 'ACRED. BANCOS'
                                   ELSE   ''
                                   END AS BANCOS      
     
                                FROM ENTIDAD_RECAUDADORA e 
                                LEFT JOIN MOVIM_CAJA_V2 c ON e.Id_entidad=c.cod_forma_pago
                                LEFT JOIN COMPR_X_MOVIM_CAJA_V2 d ON d.nro_movimiento = c.nro_movimiento
                                LEFT JOIN TIPOS_INGRESO_PAGO t ON t.id_tipo_ingreso_pago=e.id_tipo_ingreso_pago
                                WHERE d.nro_cedulon=@nro_cedulon";
                StringBuilder strRetorno = new StringBuilder();
                List<Tipo_pago> lst = new List<Tipo_pago>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nro_cedulon", nro_cedulon);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Tipo_pago? obj;
                    obj = new();
                    if (dr.HasRows)
                    {
                        int tipo_pago = dr.GetOrdinal("tipo_pago");
                        int efectivo = dr.GetOrdinal("efectivo");
                        int debito = dr.GetOrdinal("debito");
                        int credito = dr.GetOrdinal("credito");
                        int cheque = dr.GetOrdinal("cheque");
                        int documentos = dr.GetOrdinal("documentos");
                        int canje = dr.GetOrdinal("canje");
                        int bonos = dr.GetOrdinal("bonos");
                        int bancos = dr.GetOrdinal("bancos");
                        while (dr.Read())
                        {
                            //obj = new();
                            if (!dr.IsDBNull(tipo_pago)) { obj.tipo_pago = dr.GetString(tipo_pago); }
                            if (!dr.IsDBNull(efectivo)) { obj.efectivo = dr.GetString(efectivo); }
                            if (!dr.IsDBNull(debito)) { obj.debito = dr.GetString(debito); }
                            if (!dr.IsDBNull(credito)) { obj.credito = dr.GetString(credito); }
                            if (!dr.IsDBNull(cheque)) { obj.cheque = dr.GetString(cheque); }
                            if (!dr.IsDBNull(documentos)) { obj.documentos = dr.GetString(documentos); }
                            if (!dr.IsDBNull(canje)) { obj.canje = dr.GetString(canje); }
                            if (!dr.IsDBNull(bonos)) { obj.bonos = dr.GetString(bonos); }
                            if (!dr.IsDBNull(bancos)) { obj.bancos = dr.GetString(bancos); }
                            lst.Add(obj);
                        }
                        if (lst.Count > 0)
                            obj = lst[0];
                        strRetorno.AppendLine("TIPO PAGO: " + obj.tipo_pago);
                        strRetorno.AppendLine("FORMA PAGO: " + obj.forma_pago);
                        strRetorno.AppendLine(obj.efectivo + '-' + obj.credito + '-' + obj.debito + '-' + obj.bancos + '-' +
                            obj.cheque + '-' + obj.documentos + '-' + obj.canje + '-' + obj.bonos);
                    }
                    return strRetorno.ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Ctasctes_indycom> Listar_periodos_a_cancelar(int legajo)
        {
            try
            {
                string sql = string.Empty;
                sql = @"SELECT
                          C.tipo_transaccion,
                          C.nro_transaccion,
                          C.legajo,
                          C.periodo, 
                          C.monto_original,
                          C.debe,
                          C.vencimiento,
                          C.cod_cate_deuda,
                          C.pagado,
                          C.pago_parcial,
                          deuda=C.debe -
                            (SELECT SUM(C2.haber)
                             FROM CTASCTES_INDYCOM C2
                             WHERE C2.nro_transaccion=C.nro_transaccion) 
                        FROM CTASCTES_INDYCOM C 
                        WHERE
                          C.legajo=@legajo AND
                          pagado=0 AND
                          tipo_transaccion=1 AND
                          nro_plan IS NULL AND
                          nro_procuracion IS NULL
                        ORDER BY periodo";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Ctasctes_indycom> lst = new();
                Ctasctes_indycom? obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int cod_cate_deuda = dr.GetOrdinal("cod_cate_deuda");
                        int pagado = dr.GetOrdinal("pagado");
                        int pago_parcial = dr.GetOrdinal("pago_parcial");
                        int deuda = dr.GetOrdinal("deuda");
                        while (dr.Read())
                        {
                            obj = new();
                            obj.legajo = legajo;
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina); }
                            if (!dr.IsDBNull(cod_cate_deuda)) { obj.cod_cate_deuda = dr.GetInt32(cod_cate_deuda); }
                            if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                            if (!dr.IsDBNull(pago_parcial)) { obj.pago_parcial = dr.GetBoolean(pago_parcial); }
                            if (!dr.IsDBNull(deuda)) { obj.deuda = dr.GetDecimal(deuda); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void InsertCancelacioMasiva(int tipo_transaccion, int legajo, List<Ctasctes_indycom> lst,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ctasctes_indycom(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", legajo");
                sql.AppendLine(", fecha_transaccion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", monto_original");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", cod_cate_deuda");
                sql.AppendLine(", monto_pagado");
                sql.AppendLine(", declaracion_jurada");
                sql.AppendLine(", liquidacion_especial");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @fecha_transaccion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @monto_original");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @cod_cate_deuda");
                sql.AppendLine(", @monto_pagado");
                sql.AppendLine(", @declaracion_jurada");
                sql.AppendLine(", @liquidacion_especial");
                sql.AppendLine(")");
                //
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                cmd.Parameters.AddWithValue("@nro_pago_parcial", 0);
                cmd.Parameters.AddWithValue("@legajo", string.Empty);
                cmd.Parameters.AddWithValue("@fecha_transaccion", DateTime.Now);
                cmd.Parameters.AddWithValue("@periodo", string.Empty);
                cmd.Parameters.AddWithValue("@monto_original", 0);
                cmd.Parameters.AddWithValue("@pagado", 1);
                cmd.Parameters.AddWithValue("@debe", 0);
                cmd.Parameters.AddWithValue("@haber", 0);
                cmd.Parameters.AddWithValue("@pago_parcial", 0);
                cmd.Parameters.AddWithValue("@vencimiento", string.Empty);
                cmd.Parameters.AddWithValue("@cod_cate_deuda", 0);
                cmd.Parameters.AddWithValue("@monto_pagado", 0);
                cmd.Parameters.AddWithValue("@declaracion_jurada", 0);
                cmd.Parameters.AddWithValue("@liquidacion_especial", 0);
                //cmd.Connection.Open();
                foreach (var item in lst)
                {
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.Parameters["@tipo_transaccion"].Value = tipo_transaccion;
                    cmd.Parameters["@nro_pago_parcial"].Value = item.nro_pago_parcial;
                    cmd.Parameters["@legajo"].Value = legajo;
                    cmd.Parameters["@fecha_transaccion"].Value = DateTime.Now;
                    cmd.Parameters["@periodo"].Value = item.periodo;
                    cmd.Parameters["@haber"].Value = item.debe;
                    cmd.Parameters["@pago_parcial"].Value = item.pago_parcial;
                    cmd.Parameters["@vencimiento"].Value = item.vencimiento;
                    cmd.Parameters["@cod_cate_deuda"].Value = item.cod_cate_deuda;
                    cmd.Parameters["@declaracion_jurada"].Value = item.declaracion_jurada;
                    cmd.Parameters["@liquidacion_especial"].Value = item.liquidacion_especial;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Insertar la Cancelacion en la CtaCte del Legajo " + legajo, ex);
            }
        }
        public static List<Ctasctes_indycom> Listar_Periodos_cancelados(int legajo)
        {
            try
            {
                string sql = string.Empty;
                sql = @"SELECT tipo_transaccion, periodo, debe ,nro_transaccion 
                        FROM CTASCTES_INDYCOM (NOLOCK)
                        WHERE
                          legajo=@legajo AND 
                          (tipo_transaccion=7 or tipo_transaccion=8)
                        ORDER BY periodo";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Ctasctes_indycom> lst = new();
                Ctasctes_indycom? obj;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int debe = dr.GetOrdinal("debe");
                        while (dr.Read())
                        {
                            obj = new();
                            obj.legajo = legajo;
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Confirma_elimina_cancelacion(int legajo, List<Ctasctes_indycom> lst,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"DELETE CTASCTES_INDYCOM
                                  WHERE
                                      (tipo_transaccion=7 or tipo_transaccion=8) AND
                                      legajo=@legajo AND
                                      nro_transaccion=@nro_transaccion and
                                      legajo=@legajo";
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                //cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                foreach (var item in lst)
                {
                    cmd.Parameters["@legajo"].Value = legajo;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Ctasctes_indycom> Listar_periodos_a_reliquidar(int legajo)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL = @"SELECT a.nro_transaccion, a.periodo, a.monto_original,
                              a.debe, a.vencimiento, v.cod_tipo_per
                            FROM CTASCTES_INDYCOM a WITH (NOLOCK)
                            join VENCIMIENTOS_IYC v 
                            v.periodo=a.periodo
                            WHERE
                              a.legajo=@legajo AND
                              a.tipo_transaccion=1 AND pagado=0 AND
                              a.pago_parcial=0 AND nro_plan IS null AND
                              a.nro_procuracion IS NULL AND
                              a.cod_cate_deuda = 1";

                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Ctasctes_indycom> lst = new();
                Ctasctes_indycom? obj;

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int cod_tipo_per = dr.GetOrdinal("cod_tipo_per");

                        while (dr.Read())
                        {
                            obj = new();
                            obj.legajo = legajo;
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(vencimiento))
                            {
                                obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina);
                            }
                            if (!dr.IsDBNull(cod_tipo_per)) { obj.cod_tipo_per = dr.GetInt32(cod_tipo_per); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Ctasctes_indycom> Reliquidar_periodos(int legajo, List<Ctasctes_indycom> lst,
            SqlConnection con, SqlTransaction trx)
        {
            //Parametros que vienen como item en la la lst
            //string periodo, int nro_transaccion, int tipo_per
            try
            {
                int anio = 0;
                double auxmonto_original = 0;
                double auxdebe = 0;
                foreach (var item in lst)
                {
                    anio = Convert.ToInt32(item.periodo.Substring(0, 4));
                    if (anio >= 2020)
                    {
                        auxmonto_original = sp_RECALCULO_INDYCOM(item.legajo, item.periodo, item.cod_tipo_per, con, trx);
                        auxdebe = auxmonto_original + Calcula_Interes(auxmonto_original, item.vencimiento, con, trx);
                        item.monto_original = Convert.ToDecimal(auxmonto_original);
                        item.debe = Convert.ToDecimal(auxdebe);

                    }
                }
                return lst;
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}", "{1}", "Error en el Proceso de Reliquidar la Deuda del Legajo ", legajo), ex);
            }
        }
        public static void Confirma_reliquidacion(int legajo, int tipo_liquidacion, List<Ctasctes_indycom> lst,
           SqlConnection con, SqlTransaction trx)
        {
            try
            {
                int anio = 0;
                foreach (var item in lst)
                {
                    anio = Convert.ToInt32(item.periodo.Substring(0, 4));
                    if (anio >= 2020)
                    {
                        SqlUpdate_Ctasctes(legajo, item.monto_original, item.debe, item.nro_transaccion, item.periodo, con, trx);
                        if (tipo_liquidacion == 1)
                            sqlDelete_Detalle_Mensual(item.nro_transaccion, con, trx);
                        else
                            sqlDelete_Detalle_MensualConDJJ(item.nro_transaccion, con, trx);
                        sqlInsert_Detalle_Mensual(item.nro_transaccion, con, trx);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void MarcopagadalaCtacte(int legajo, List<Ctasctes_indycom> lst,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Ctasctes_indycom");
                sql.AppendLine("set pagado=1");
                sql.AppendLine("WHERE legajo=@legajo AND ");
                sql.AppendLine("   tipo_transaccion=1 AND ");
                sql.AppendLine("   nro_transaccion=@nro_transaccion");
                //
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", 0);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                //cmd.Connection.Open();
                foreach (var item in lst)
                {
                    cmd.Parameters["@legajo"].Value = legajo;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.ExecuteNonQuery();
                }
                //
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en la marca de la CtaCte del Legajo " + legajo);
            }
        }
        public static void MarconopagadalaCtacte(int legajo, List<Ctasctes_indycom> lst,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Ctasctes_indycom");
                sql.AppendLine("set pagado=0");
                sql.AppendLine("WHERE legajo=@legajo AND ");
                sql.AppendLine("      tipo_transaccion=1 AND ");
                sql.AppendLine("      nro_transaccion=@nro_transaccion");
                //
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", 0);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                //cmd.Connection.Open();
                foreach (var item in lst)
                {
                    cmd.Parameters["@legajo"].Value = legajo;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.ExecuteNonQuery();
                }
                //
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en la marca de la CtaCte del Legajo " + legajo);
            }
        }
        ////////////////////
        //public static List<Ctasctes_indycom> Reliquidar_periodos(int legajo, List<Ctasctes_indycom> lst, SqlConnection con, SqlTransaction trx)
        //{
        //    //Parametros que vienen como item en la la lst
        //    //string periodo, int nro_transaccion, int tipo_per
        //    try
        //    {
        //        int anio = 0;
        //        double auxmonto_original = 0;
        //        double auxdebe = 0;
        //        foreach (var item in lst)
        //        {
        //            anio = Convert.ToInt32(item.periodo.Substring(0, 4));
        //            if (anio >= 2020)
        //            {
        //                if (item.cod_tipo_per == 1) //Periodo Mensual
        //                {
        //                    auxmonto_original = sp_RECALCULO_INDYCOM(item.legajo, item.periodo, item.cod_tipo_per, con, trx);
        //                    auxdebe = auxmonto_original + Calcula_Interes(auxmonto_original, item.vencimiento, con, trx);
        //                    item.monto_original = Convert.ToDecimal(auxmonto_original);
        //                    item.debe = Convert.ToDecimal(auxdebe);
        //                }
        //            }
        //        }
        //        return lst;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        private static double Calcula_Interes(double auxmonto_original, DateTime? vencimiento,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                double interes = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Calculo_Interes_4";
                //cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@monto_original", auxmonto_original);
                cmd.Parameters.AddWithValue("@vencimiento", Convert.ToDateTime(vencimiento, culturaFecArgentina));
                interes = Convert.ToDouble(cmd.ExecuteScalarAsync());
                return interes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SqlActualiza_Ctasctes_Indycom(int legajo, int nro_transaccion, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"UPDATE CTASCTES_INDYCOM
                                    set monto_original=0, debe=0
                                  WHERE
                                    tipo_transaccion=1 AND
                                    nro_pago_parcial=0 AND
                                    nro_transaccion=@nro_transaccion AND
                                    legajo=@legajo";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void SqlUpdate_Ctasctes(int legajo, decimal monto_original, decimal debe, int nro_transaccion,
            string periodo, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"UPDATE Ctasctes_indycom
                                    SET monto_original=@monto_1, debe=@monto_2
                                    WHERE nro_transaccion=@nro_transaccion
                                    AND tipo_transaccion=1
                                    AND legajo=@legajo
                                    AND periodo=@periodo";
                //
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                cmd.Parameters.AddWithValue("@monto_1", monto_original);
                cmd.Parameters.AddWithValue("@monto_2", debe);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void sqlDelete_Detalle_Mensual(int nro_transaccion, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"DELETE
                                  FROM DETALLE_DEUDA_IYC
                                  WHERE nro_transaccion =@nro_transaccion";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void sqlDelete_Detalle_MensualConDJJ(int nro_transaccion, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"DELETE
                                  FROM DETALLE_DEUDA_IYC
                                  WHERE 
                                    cod_concepto_iyc<>1 and
                                    nro_transaccion =@nro_transaccion";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void sqlInsert_Detalle_Mensual(int nro_transaccion, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"INSERT into DETALLE_DEUDA_AUTO
                                  SELECT *
                                  FROM AUX_DETALLE_DEUDA_AUTO_RECALCULO
                                  WHERE nro_transaccion=@nro_transaccion";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static double sp_RECALCULO_INDYCOM(int legajo, string periodo, int tipo_per,
            SqlConnection con, SqlTransaction trx)
        {
            try
            {
                double total = 0;

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_RECALCULO_IYC_2020";
                //cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@cod_tipo_liquidacion", tipo_per);
                cmd.ExecuteNonQuery();
                total = Convert.ToDouble(cmd.ExecuteScalar());
                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}

