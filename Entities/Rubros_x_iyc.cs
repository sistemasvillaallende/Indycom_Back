using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_IyC.Entities;

public class Rubros_x_iyc : DALBase
{
    public int legajo { get; set; }
    public int cod_rubro { get; set; }
    public int Nro_sucursal { get; set; }
    public int cod_minimo { get; set; }
    public int cod_convenio { get; set; }
    public Single cantidad { get; set; }
    public bool exento { get; set; }
    public bool descuento { get; set; }
    public decimal valor { get; set; }
    public Rubros_x_iyc()
    {
        legajo = 0;
        cod_rubro = 0;
        Nro_sucursal = 0;
        cod_minimo = 0;
        cod_convenio = 0;
        cantidad = 0;
        exento = false;
        descuento = false;
        valor = 0;
    }
    private static List<Rubros_x_iyc> mapeo(SqlDataReader dr)
    {
        List<Rubros_x_iyc> lst = new List<Rubros_x_iyc>();
        Rubros_x_iyc obj;
        if (dr.HasRows)
        {
            int legajo = dr.GetOrdinal("legajo");
            int cod_rubro = dr.GetOrdinal("cod_rubro");
            int Nro_sucursal = dr.GetOrdinal("Nro_sucursal");
            int cod_minimo = dr.GetOrdinal("cod_minimo");
            int cod_convenio = dr.GetOrdinal("cod_convenio");
            int cantidad = dr.GetOrdinal("cantidad");
            int exento = dr.GetOrdinal("Exento");
            int descuento = dr.GetOrdinal("Descuento");
            int valor = dr.GetOrdinal("Valor");
            while (dr.Read())
            {
                obj = new Rubros_x_iyc();
                if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                if (!dr.IsDBNull(Nro_sucursal)) { obj.Nro_sucursal = dr.GetInt32(Nro_sucursal); }
                if (!dr.IsDBNull(cod_minimo)) { obj.cod_minimo = dr.GetInt32(cod_minimo); }
                if (!dr.IsDBNull(cod_convenio)) { obj.cod_convenio = dr.GetInt32(cod_convenio); }
                if (!dr.IsDBNull(cantidad)) { obj.cantidad = dr.GetFloat(cantidad); }
                if (!dr.IsDBNull(exento)) { obj.exento = dr.GetBoolean(exento); }
                if (!dr.IsDBNull(descuento)) { obj.descuento = dr.GetBoolean(descuento); }
                if (!dr.IsDBNull(valor)) { obj.valor = dr.GetDecimal(valor); }
                lst.Add(obj);
            }
        }
        return lst;
    }
    public static List<Rubros_x_iyc> read()
    {
        try
        {
            List<Rubros_x_iyc> lst = new List<Rubros_x_iyc>();
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Rubros_x_iyc";
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
    public static Rubros_x_iyc getByPk(int legajo, int cod_rubro, int Nro_sucursal)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM RUBROS_X_IYC WHERE");
            sql.AppendLine("legajo = @legajo");
            sql.AppendLine("AND cod_rubro = @cod_rubro");
            sql.AppendLine("AND Nro_sucursal = @Nro_sucursal");
            Rubros_x_iyc? obj = null;
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                cmd.Parameters.AddWithValue("@Nro_sucursal", Nro_sucursal);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Rubros_x_iyc> lst = mapeo(dr);
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
    public static List<Rubros_x_iyc> GetRubros_x_iyc(int legajo)
    {
        try
        {
            string sql = @"SELECT * 
                           FROM RUBROS_X_IYC 
                           WHERE legajo = @legajo
                           ORDER BY  nro_sucursal";
            List<Rubros_x_iyc> lst = new List<Rubros_x_iyc>();
            using (SqlConnection con = GetConnectionSIIMVA())
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
        catch (Exception)
        {

            throw;
        }
    }
    public static int insert(Rubros_x_iyc obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Rubros_x_iyc(");
            sql.AppendLine("legajo");
            sql.AppendLine(", cod_rubro");
            sql.AppendLine(", Nro_sucursal");
            sql.AppendLine(", cod_minimo");
            sql.AppendLine(", cod_convenio");
            sql.AppendLine(", cantidad");
            sql.AppendLine(", Exento");
            sql.AppendLine(", Descuento");
            sql.AppendLine(", Valor");
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");
            sql.AppendLine("@legajo");
            sql.AppendLine(", @cod_rubro");
            sql.AppendLine(", @Nro_sucursal");
            sql.AppendLine(", @cod_minimo");
            sql.AppendLine(", @cod_convenio");
            sql.AppendLine(", @cantidad");
            sql.AppendLine(", @Exento");
            sql.AppendLine(", @Descuento");
            sql.AppendLine(", @Valor");
            sql.AppendLine(")");
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                cmd.Parameters.AddWithValue("@cod_minimo", obj.cod_minimo);
                cmd.Parameters.AddWithValue("@cod_convenio", obj.cod_convenio);
                cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                cmd.Parameters.AddWithValue("@Exento", obj.exento);
                cmd.Parameters.AddWithValue("@Descuento", obj.descuento);
                cmd.Parameters.AddWithValue("@Valor", obj.valor);
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void update(Rubros_x_iyc obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE  Rubros_x_iyc SET");
            sql.AppendLine("cod_minimo=@cod_minimo");
            sql.AppendLine(", cod_convenio=@cod_convenio");
            sql.AppendLine(", cantidad=@cantidad");
            sql.AppendLine(", Exento=@Exento");
            sql.AppendLine(", Descuento=@Descuento");
            sql.AppendLine(", Valor=@Valor");
            sql.AppendLine("WHERE");
            sql.AppendLine("legajo=@legajo");
            sql.AppendLine("AND cod_rubro=@cod_rubro");
            sql.AppendLine("AND Nro_sucursal=@Nro_sucursal");
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                cmd.Parameters.AddWithValue("@cod_minimo", obj.cod_minimo);
                cmd.Parameters.AddWithValue("@cod_convenio", obj.cod_convenio);
                cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                cmd.Parameters.AddWithValue("@Exento", obj.exento);
                cmd.Parameters.AddWithValue("@Descuento", obj.descuento);
                cmd.Parameters.AddWithValue("@Valor", obj.valor);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void delete(Rubros_x_iyc obj)
    {
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE  Rubros_x_iyc ");
            sql.AppendLine("WHERE");
            sql.AppendLine("legajo=@legajo");
            sql.AppendLine("AND cod_rubro=@cod_rubro");
            sql.AppendLine("AND Nro_sucursal=@Nro_sucursal");
            using (SqlConnection con = GetConnectionSIIMVA())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                cmd.Parameters.AddWithValue("@Nro_sucursal", obj.Nro_sucursal);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    
}

