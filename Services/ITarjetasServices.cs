using  Web_Api_IyC.Entities.TARJETAS;

namespace Web_Api_IyC
{
    public interface ITarjetasServices
    {
        public List<Tarjetas> getTarjetasWeb();
        public List<Tarjetas> getTarjetasDesktop();
        public Tarjetas getTarjetasByPk(int pk);
        public Tarjetas getTarjetasByCodPayPerTic(int pk);

        public List<PLANES_COBRO> readPlanes();
        public List<PLANES_COBRO> getBySubsistema(int subsistema, decimal deuda, int cod_tarjeta);
        public PLANES_COBRO getPlanByPk(int cod_plan);
    }
}
