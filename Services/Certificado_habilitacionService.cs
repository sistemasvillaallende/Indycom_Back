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
    public class Certificado_habilitacionService : ICertificado_habilitacionService
    {

        public List<Certificado_habilitacion> read()
        {
            try
            {
                return Certificado_habilitacion.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Certificado_habilitacion GetByLegajo(int legajo)
        {
            {
                try
                {
                    return Certificado_habilitacion.getByLegajo(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Certificado_habilitacionDTO> GetPrincipalByLegajo(int legajo)
        {
            {
                try
                {
                    return Certificado_habilitacion.GetPrincipalByLegajo(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public List<Certificado_habilitacionDTO> GetSucursalByLegajo(int legajo)
        {
            {
                try
                {
                    return Certificado_habilitacion.GetSucursalByLegajo(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public void Insert(Certificado_habilitacion_Con_Auditoria obj)
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
                            string detalle =
                                            $"rubro: {obj.cod_rubro}  " +
                                            $"legajo: {obj.legajo}  " +
                                            $"titular: {obj.titular}  " +
                                            $"domicilio: {obj.domicilio}  " +
                                            $"vencimiento: {obj.vecimiento}";


                            obj.auditoria.identificacion = obj.legajo.ToString();
                            obj.auditoria.proceso = "'IMPRIMIR HABILITACION COMERCIO";
                            obj.auditoria.detalle = detalle;
                            obj.auditoria.observaciones += string.Format(" Fecha impresion habilitacion : {0} ", DateTime.Now);

                            int maxNroCertificado = Certificado_habilitacion.ObtenerUltimoNroCertificado(con, trx);
                            DateTime fechaEmision = DateTime.Now;
                            string certificado = CertificadoHelper.GenerarCodigoCertificado(maxNroCertificado + 1, fechaEmision.Year, 0);
                            string qr = CertificadoHelper.GenerarCodigoQR(maxNroCertificado + 1, fechaEmision.Year, 0);
                            Certificado_habilitacion.insert(obj.legajo, maxNroCertificado + 1, fechaEmision.Year, obj.nro_sucursal, obj.cod_rubro, certificado, fechaEmision, obj.vecimiento, qr, con, trx);

                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
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



        public List<Certificado_habilitacionImp> GetCertificadoPrincipal(int legajo)
        {
            {
                try
                {
                    return Certificado_habilitacion.GetCertificadoPrincipal(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public List<Certificado_habilitacionImp> GetCertificadoSucursal(int legajo)
        {
            {
                try
                {
                    return Certificado_habilitacion.GetCertificadoSucursal(legajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}

