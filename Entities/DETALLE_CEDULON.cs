using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_IyC.Entities
{
    public class DETALLE_CEDULON : DALBase
    {
        public int nroTran { get; set; }
        public string periodo { get; set; }
        public decimal monto { get; set; }

        public DETALLE_CEDULON()
        {
            nroTran = 0;
            monto = 0;
            periodo = string.Empty;

        }

        public static List<DETALLE_CEDULON> read(int nroCedulon)
        {
            try
            {
                List<DETALLE_CEDULON> lst = new List<DETALLE_CEDULON>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.nro_transaccion, B.PERIODO, A.monto_pagado");
                sql.AppendLine("FROM DEUDAS_X_CEDULON3 A");
                sql.AppendLine("INNER JOIN CTASCTES_AUTOMOTORES B ON A.nro_transaccion=B.NRO_TRANSACCION");
                sql.AppendLine("AND B.TIPO_TRANSACCION=2");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon");
                DETALLE_CEDULON? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);


                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int nroTran = dr.GetOrdinal("nro_transaccion");
                        int monto = dr.GetOrdinal("monto_pagado");
                        int periodo = dr.GetOrdinal("PERIODO");

                        while (dr.Read())
                        {
                            obj = new DETALLE_CEDULON();
                            if (!dr.IsDBNull(nroTran)) { obj.nroTran = dr.GetInt32(nroTran); }
                            if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DETALLE_CEDULON> readTasa(int nroCedulon)
        {
            try
            {
                List<DETALLE_CEDULON> lst = new List<DETALLE_CEDULON>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.nro_transaccion, B.PERIODO, A.monto_pagado");
                sql.AppendLine("FROM DEUDAS_X_CEDULON3 A");
                sql.AppendLine("INNER JOIN CTASCTES_INMUEBLES B ON A.nro_transaccion=B.NRO_TRANSACCION");
                sql.AppendLine("AND B.TIPO_TRANSACCION=2");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon");
                DETALLE_CEDULON? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);


                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int nroTran = dr.GetOrdinal("nro_transaccion");
                        int monto = dr.GetOrdinal("monto_pagado");
                        int periodo = dr.GetOrdinal("PERIODO");

                        while (dr.Read())
                        {
                            obj = new DETALLE_CEDULON();
                            if (!dr.IsDBNull(nroTran)) { obj.nroTran = dr.GetInt32(nroTran); }
                            if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
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
        public static List<DETALLE_CEDULON> ReadIndyCom(int nroCedulon)
        {
            try
            {
                List<DETALLE_CEDULON> lst = new List<DETALLE_CEDULON>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.nro_transaccion, B.PERIODO, A.monto_pagado");
                sql.AppendLine("FROM DEUDAS_X_CEDULON3 A");
                sql.AppendLine("INNER JOIN CTASCTES_INDYCOM B ON A.nro_transaccion=B.NRO_TRANSACCION");
                sql.AppendLine("AND B.TIPO_TRANSACCION=2");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon");
                DETALLE_CEDULON obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);


                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int nroTran = dr.GetOrdinal("nro_transaccion");
                        int monto = dr.GetOrdinal("monto_pagado");
                        int periodo = dr.GetOrdinal("PERIODO");

                        while (dr.Read())
                        {
                            obj = new DETALLE_CEDULON();
                            if (!dr.IsDBNull(nroTran)) { obj.nroTran = dr.GetInt32(nroTran); }
                            if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
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
        public static List<DETALLE_CEDULON> readIndyCom(int nroCedulon)
        {
            try
            {
                List<DETALLE_CEDULON> lst = new List<DETALLE_CEDULON>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.nro_transaccion, B.PERIODO, A.monto_pagado");
                sql.AppendLine("FROM DEUDAS_X_CEDULON3 A");
                sql.AppendLine("INNER JOIN CTASCTES_CEMENTERIO B ON A.nro_transaccion=B.NRO_TRANSACCION");
                sql.AppendLine("AND B.TIPO_TRANSACCION=2");
                sql.AppendLine("WHERE A.nro_cedulon=@nro_cedulon");
                DETALLE_CEDULON? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nro_cedulon", nroCedulon);


                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int nroTran = dr.GetOrdinal("nro_transaccion");
                        int monto = dr.GetOrdinal("monto_pagado");
                        int periodo = dr.GetOrdinal("PERIODO");

                        while (dr.Read())
                        {
                            obj = new DETALLE_CEDULON();
                            if (!dr.IsDBNull(nroTran)) { obj.nroTran = dr.GetInt32(nroTran); }
                            if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
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
