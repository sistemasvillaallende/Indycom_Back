using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_IyC.Entities;

namespace Web_Api_IyC.Services
{
    public class BadecServices : IBadecServices
    {
        public void delete(int nro_bad)
        {
            try
            {
                Entities.BADEC.delete(nro_bad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BADEC getByPk(int nro_bad)
        {
            try
            {
                return Entities.BADEC.getByPk(nro_bad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BADEC getByPk2(int nro_bad)
        {
            try
            {
                return Entities.BADEC.getByPk2(nro_bad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BADEC> GetByNombre(string nombre)
        {
            try
            {
                return Entities.BADEC.GetByNombre(nombre);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insert(BADEC obj)
        {
            try
            {
                return Entities.BADEC.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BADEC> read()
        {
            try
            {
                return Entities.BADEC.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BADEC> read2()
        {
            try
            {
                return Entities.BADEC.read2();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(BADEC obj)
        {
            try
            {
                Entities.BADEC.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update2(BADEC obj)
        {
            try
            {
                Entities.BADEC.update2(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
