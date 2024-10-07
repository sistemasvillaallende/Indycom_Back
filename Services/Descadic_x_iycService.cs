using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;

namespace Web_Api_IyC.Services
{
    public class Descadic_x_iycService : IDescadic_x_iycService
    {
        public Descadic_x_iyc getByPk(int legajo, int cod_concepto_iyc)
        {
            try
            {
                return Descadic_x_iyc.getByPk(legajo, cod_concepto_iyc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Descadic_x_iyc> getConceptos_x_iyc(int legajo)
        {
            try
            {
                return Descadic_x_iyc.getConceptos_x_iyc(legajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Descadic_x_iyc> read(int legajo)
        {
            try
            {
                return Descadic_x_iyc.read(legajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Descadic_x_iyc obj)
        {
                if (obj.objAuditoria == null)
                {
                    Auditoria audit = new Auditoria();
                    obj.objAuditoria = audit;
                }
                int id = 0;
                obj.objAuditoria.identificacion = obj.legajo.ToString();
                obj.objAuditoria.proceso = "MODIFICACION DE CONCEPTO";
                obj.objAuditoria.detalle = JsonConvert.SerializeObject(INDYCOM.GetByPk(obj.legajo));
                obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                id = Descadic_x_iyc.insert(obj);
                AuditoriaD.InsertAuditoria(obj.objAuditoria);

                return id;

        }
        public void update(Descadic_x_iyc obj)
        {
            try
            {
                if (obj.objAuditoria == null)
                {
                    Auditoria audit = new Auditoria();
                    obj.objAuditoria = audit;
                }
                    obj.objAuditoria.identificacion = obj.legajo.ToString();
                    obj.objAuditoria.proceso = "MODIFICACION DE CONCEPTO";
                    obj.objAuditoria.detalle = JsonConvert.SerializeObject(INDYCOM.GetByPk(obj.legajo));
                    obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Descadic_x_iyc.update(obj);
                    AuditoriaD.InsertAuditoria(obj.objAuditoria);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int legajo, int cod_concepto_iyc, string usuario)
        {
            try
            {

                    Auditoria objAuditoria = new Entities.AUDITORIA.Auditoria();
                    objAuditoria.identificacion = legajo.ToString();
                    objAuditoria.proceso = "BAJA DE CONCEPTO";
                    objAuditoria.detalle = JsonConvert.SerializeObject(INDYCOM.GetByPk(legajo));
                    objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Descadic_x_iyc.delete(legajo, cod_concepto_iyc);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

