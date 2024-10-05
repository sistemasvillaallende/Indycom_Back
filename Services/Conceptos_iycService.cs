using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
using Web_Api_IyC.Entities;
namespace Web_Api_IyC.Services
{
    public class Conceptos_iycService : IConceptos_iycService
    {
        public Conceptos_iyc getByPk(int cod_concepto_iyc)
        {
            try
            {
                return Conceptos_iyc.getByPk(cod_concepto_iyc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Conceptos_iyc> read()
        {
            try
            {
                return Conceptos_iyc.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Conceptos_iyc obj)
        {
            try
            {
                return Conceptos_iyc.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Conceptos_iyc obj)
        {
            try
            {
                Conceptos_iyc.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Conceptos_iyc obj)
        {
            try
            {
                Conceptos_iyc.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     }
}

