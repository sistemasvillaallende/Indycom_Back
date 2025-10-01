using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
namespace Web_Api_IyC.Services
{
    public class Resolucion_habilitacionService : IResolucion_habilitacionService
    {

        public void Insert(Resolucion_habilitacion_DTO obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            if (obj.Nro_sucursal is not 0) // Si no es 0 es que es una sucursal
                            {
                                Sucursales_indycom.updateResolucion(obj.Legajo, obj.Nro_sucursal, obj.Fecha_hab, obj.Nro_res, con, trx);
                            }
                            // Aca falta la parte en donde se hacer el insert en resolucion_habilitacion
                            int nro_item = Resolucion_habilitacion.ObtenerUltimoNroItem(obj.Legajo, con, trx);
                            Resolucion_habilitacion.insert(obj.Legajo, obj.Nro_sucursal, nro_item + 1, obj.Nro_res,
                            obj.Fecha_inspeccion, obj.Fecha_hab, obj.Transporte, obj.Usuario, DateTime.Now, con, trx);

                            trx.Commit();

                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Resolucion_habilitacion> GetByLegajo(int legajo)
        {
            {
                try
                {
                    return Resolucion_habilitacion.getByLegajo(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public Resolucion_habilitacion_imprimir GetResolucion(int legajo)
        {
            {
                try
                {
                    return Resolucion_habilitacion.GetResolucion(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

                public List<Resolucion_habilitacion_imprimir> GetAllResolucion(int legajo)
        {
            {
                try
                {
                    return Resolucion_habilitacion.GetAllResolucion(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}

