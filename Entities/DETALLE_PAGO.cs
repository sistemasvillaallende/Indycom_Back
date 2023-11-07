using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_IyC.Entities
{
    public class DETALLE_PAGO:DALBase
    {
        public string fecha_movimiento { get; set; }
        public int nro_transaccion { get; set; }
        public int nro_cedulon { get; set; }
        public decimal monto_pagado { get; set; }
        public string descripcion { get; set; }
        public string periodo { get; set; }
        public string des_tarjeta { get; set; }
        public int cant_cuotas { get; set; }
        public List<DETALLE_CEDULON> lstDet { get; set; }
        public DETALLE_PAGO()
        {
            fecha_movimiento = string.Empty;
            nro_transaccion = 0;
            nro_cedulon = 0;
            monto_pagado = 0;
            descripcion = string.Empty;
            periodo = string.Empty;
            des_tarjeta = string.Empty;
            cant_cuotas = 0;
            lstDet = new List<DETALLE_CEDULON>();   
        }

        public static DETALLE_PAGO read(int nroCedulon, int nroTransaccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT B.fecha_movimiento, E.NRO_TRANSACCION, A.nro_cedulon, E.monto_pagado,");
                sql.AppendLine("c.descripcion, E.periodo, G.des_tarjeta, F.CANT_CUOTAS");
                sql.AppendLine("FROM COMPR_X_MOVIM_CAJA_V2 A");
                sql.AppendLine("FULL JOIN MOVIM_CAJA_V2 B ON A.nro_movimiento=B.nro_movimiento");
                sql.AppendLine("FULL JOIN ENTIDAD_RECAUDADORA C ON B.cod_forma_pago=C.Id_entidad");
                sql.AppendLine("FULL JOIN CEDULONES2 D ON A.nro_cedulon=D.nro_cedulon");
                sql.AppendLine("FULL JOIN CTASCTES_INDYCOM E ON A.nro_cedulon=E.nro_cedulon AND E.TIPO_TRANSACCION=2");
                sql.AppendLine("FULL JOIN PAGOS_PAYPERTIC F ON A.nro_cedulon=F.NRO_CEDULON");
                sql.AppendLine("FULL JOIN TARJETAS_DEBITOS G ON F.COD_TARJETA_INTERNO=G.cod_tarjeta");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon AND E.NRO_TRANSACCION=@nro_transaccion");

                DETALLE_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nroTransaccion);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int fecha_movimiento = dr.GetOrdinal("fecha_movimiento");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        int descripcion = dr.GetOrdinal("descripcion");
                        int periodo = dr.GetOrdinal("periodo");
                        int des_tarjeta = dr.GetOrdinal("des_tarjeta");
                        int cant_cuotas = dr.GetOrdinal("cant_cuotas");
                        while (dr.Read())
                        {
                            obj = new DETALLE_PAGO();
                            if (!dr.IsDBNull(fecha_movimiento)) { obj.fecha_movimiento = dr.GetDateTime(fecha_movimiento).ToShortDateString(); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(des_tarjeta)) { obj.des_tarjeta = dr.GetString(des_tarjeta); }
                            if (!dr.IsDBNull(cant_cuotas)) { obj.cant_cuotas = dr.GetInt32(cant_cuotas); }
                            obj.lstDet = DETALLE_CEDULON.read(obj.nro_cedulon);
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DETALLE_PAGO read(int nroCedulon)
        {
            try
            {
                DETALLE_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = @"
                        SELECT DISTINCT
                        B.fecha_movimiento, c.descripcion, G.des_tarjeta, F.CANT_CUOTAS, I.des_tarjeta
                        FROM COMPR_X_MOVIM_CAJA_V2 A
                        FULL JOIN MOVIM_CAJA_V2 B ON A.nro_movimiento=B.nro_movimiento
                        FULL JOIN ENTIDAD_RECAUDADORA C ON B.cod_forma_pago=C.Id_entidad
                        FULL JOIN CEDULONES2 D ON A.nro_cedulon=D.nro_cedulon
                        FULL JOIN CTASCTES_AUTOMOTORES E ON A.nro_cedulon=E.nro_cedulon AND E.TIPO_TRANSACCION=2
                        FULL JOIN PAGOS_PAYPERTIC F ON A.nro_cedulon=F.NRO_CEDULON
                        FULL JOIN TARJETAS_DEBITOS G ON F.COD_TARJETA_INTERNO=G.cod_tarjeta
                        FULL JOIN DEBITOS_PAYPERTIC H ON H.NRO_CEDULON=A.nro_cedulon
                        FULL JOIN TARJETAS_DEBITOS I ON I.cod_paypertic=H.COD_TARJETA_PAYPERTIC
                        WHERE A.nro_cedulon=@nro_cedulon";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new DETALLE_PAGO();
                            if (!dr.IsDBNull(0)) { obj.fecha_movimiento = dr.GetDateTime(0).ToShortDateString(); }
                            if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.des_tarjeta = dr.GetString(2); }
                            if (!dr.IsDBNull(3)) { obj.cant_cuotas = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.des_tarjeta = dr.GetString(4); }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DETALLE_PAGO readTasa(int nroCedulon, int nroTransaccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT B.fecha_movimiento, E.NRO_TRANSACCION, A.nro_cedulon, E.monto_pagado,");
                sql.AppendLine("c.descripcion, E.periodo, G.des_tarjeta, F.CANT_CUOTAS");
                sql.AppendLine("FROM COMPR_X_MOVIM_CAJA_V2 A");
                sql.AppendLine("INNER JOIN MOVIM_CAJA_V2 B ON A.nro_movimiento=B.nro_movimiento");
                sql.AppendLine("INNER JOIN ENTIDAD_RECAUDADORA C ON B.cod_forma_pago=C.Id_entidad");
                sql.AppendLine("INNER JOIN CEDULONES2 D ON A.nro_cedulon=D.nro_cedulon");
                sql.AppendLine("INNER JOIN CTASCTES_INMUEBLES E ON A.nro_cedulon=E.nro_cedulon AND E.TIPO_TRANSACCION=2");
                sql.AppendLine("FULL JOIN PAGOS_PAYPERTIC F ON A.nro_cedulon=F.NRO_CEDULON");
                sql.AppendLine("FULL JOIN TARJETAS_DEBITOS G ON F.COD_TARJETA_INTERNO=G.cod_tarjeta");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon AND E.NRO_TRANSACCION=@nro_transaccion");

                DETALLE_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nroTransaccion);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int fecha_movimiento = dr.GetOrdinal("fecha_movimiento");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        int descripcion = dr.GetOrdinal("descripcion");
                        int periodo = dr.GetOrdinal("periodo");
                        int des_tarjeta = dr.GetOrdinal("des_tarjeta");
                        int cant_cuotas = dr.GetOrdinal("cant_cuotas");
                        while (dr.Read())
                        {
                            obj = new DETALLE_PAGO();
                            if (!dr.IsDBNull(fecha_movimiento)) { obj.fecha_movimiento = dr.GetDateTime(fecha_movimiento).ToShortDateString(); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(des_tarjeta)) { obj.des_tarjeta = dr.GetString(des_tarjeta); }
                            if (!dr.IsDBNull(cant_cuotas)) { obj.cant_cuotas = dr.GetInt32(cant_cuotas); }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DETALLE_PAGO readIndycom(int nroCedulon, int nroTransaccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT B.fecha_movimiento, E.NRO_TRANSACCION, A.nro_cedulon, E.monto_pagado,");
                sql.AppendLine("c.descripcion, E.periodo, G.des_tarjeta, F.CANT_CUOTAS");
                sql.AppendLine("FROM COMPR_X_MOVIM_CAJA_V2 A");
                sql.AppendLine("INNER JOIN MOVIM_CAJA_V2 B ON A.nro_movimiento=B.nro_movimiento");
                sql.AppendLine("INNER JOIN ENTIDAD_RECAUDADORA C ON B.cod_forma_pago=C.Id_entidad");
                sql.AppendLine("INNER JOIN CEDULONES2 D ON A.nro_cedulon=D.nro_cedulon");
                sql.AppendLine("INNER JOIN CTASCTES_INDYCOM E ON A.nro_cedulon=E.nro_cedulon AND E.TIPO_TRANSACCION=2");
                sql.AppendLine("FULL JOIN PAGOS_PAYPERTIC F ON A.nro_cedulon=F.NRO_CEDULON");
                sql.AppendLine("FULL JOIN TARJETAS_DEBITOS G ON F.COD_TARJETA_INTERNO=G.cod_tarjeta");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon AND E.NRO_TRANSACCION=@nro_transaccion");

                DETALLE_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nroTransaccion);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int fecha_movimiento = dr.GetOrdinal("fecha_movimiento");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        int descripcion = dr.GetOrdinal("descripcion");
                        int periodo = dr.GetOrdinal("periodo");
                        int des_tarjeta = dr.GetOrdinal("des_tarjeta");
                        int cant_cuotas = dr.GetOrdinal("cant_cuotas");
                        while (dr.Read())
                        {
                            obj = new DETALLE_PAGO();
                            if (!dr.IsDBNull(fecha_movimiento)) { obj.fecha_movimiento = dr.GetDateTime(fecha_movimiento).ToShortDateString(); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(des_tarjeta)) { obj.des_tarjeta = dr.GetString(des_tarjeta); }
                            if (!dr.IsDBNull(cant_cuotas)) { obj.cant_cuotas = dr.GetInt32(cant_cuotas); }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static DETALLE_PAGO readIndyCem(int nroCedulon, int nroTransaccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT B.fecha_movimiento, E.NRO_TRANSACCION, A.nro_cedulon, E.monto_pagado,");
                sql.AppendLine("c.descripcion, E.periodo, G.des_tarjeta, F.CANT_CUOTAS");
                sql.AppendLine("FROM COMPR_X_MOVIM_CAJA_V2 A");
                sql.AppendLine("INNER JOIN MOVIM_CAJA_V2 B ON A.nro_movimiento=B.nro_movimiento");
                sql.AppendLine("INNER JOIN ENTIDAD_RECAUDADORA C ON B.cod_forma_pago=C.Id_entidad");
                sql.AppendLine("INNER JOIN CEDULONES2 D ON A.nro_cedulon=D.nro_cedulon");
                sql.AppendLine("INNER JOIN CTASCTES_CEMENTERIO E ON A.nro_cedulon=E.nro_cedulon AND E.TIPO_TRANSACCION=2");
                sql.AppendLine("FULL JOIN PAGOS_PAYPERTIC F ON A.nro_cedulon=F.NRO_CEDULON");
                sql.AppendLine("FULL JOIN TARJETAS_DEBITOS G ON F.COD_TARJETA_INTERNO=G.cod_tarjeta");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon AND E.NRO_TRANSACCION=@nro_transaccion");

                DETALLE_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nroTransaccion);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int fecha_movimiento = dr.GetOrdinal("fecha_movimiento");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        int descripcion = dr.GetOrdinal("descripcion");
                        int periodo = dr.GetOrdinal("periodo");
                        int des_tarjeta = dr.GetOrdinal("des_tarjeta");
                        int cant_cuotas = dr.GetOrdinal("cant_cuotas");
                        while (dr.Read())
                        {
                            obj = new DETALLE_PAGO();
                            if (!dr.IsDBNull(fecha_movimiento)) { obj.fecha_movimiento = dr.GetDateTime(fecha_movimiento).ToShortDateString(); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(des_tarjeta)) { obj.des_tarjeta = dr.GetString(des_tarjeta); }
                            if (!dr.IsDBNull(cant_cuotas)) { obj.cant_cuotas = dr.GetInt32(cant_cuotas); }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
