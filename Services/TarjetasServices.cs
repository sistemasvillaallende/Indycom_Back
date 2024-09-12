using System.Reflection.PortableExecutable;
using  Web_Api_IyC.Entities.TARJETAS;

namespace Web_Api_IyC
{
    public class TarjetasServices : ITarjetasServices
    {
        public PLANES_COBRO getByPk(int cod_plan)
        {
            try
            {
                return PLANES_COBRO.getByPk(cod_plan);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<PLANES_COBRO> getBySubsistema(int subsistema, decimal deuda, int cod_tarjeta)
        {
            try
            {
                return PLANES_COBRO.getBySubsistema(subsistema, deuda, cod_tarjeta);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PLANES_COBRO getPlanByPk(int cod_plan)
        {
            try
            {
                return PLANES_COBRO.getByPk(cod_plan);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Tarjetas getTarjetasByCodPayPerTic(int pk)
        {
            try
            {
                return Tarjetas.getTarjetasByCodPayPerTic(pk);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Tarjetas getTarjetasByPk(int pk)
        {
            try
            {
                return Tarjetas.getTarjetasByPk(pk);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Tarjetas> getTarjetasDesktop()
        {
            try
            {
                return Tarjetas.getTarjetasDesktop();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Tarjetas> getTarjetasWeb()
        {
            try
            {
                return Tarjetas.getTarjetasWeb();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<PLANES_COBRO> readPlanes()
        {
            try
            {
                return PLANES_COBRO.read();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
