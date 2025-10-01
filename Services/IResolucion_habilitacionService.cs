
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.HELPERS;

namespace Web_Api_IyC
{
    public interface IResolucion_habilitacionService
    {
        public void Insert(Resolucion_habilitacion_DTO obj);
        public List<Resolucion_habilitacion> GetByLegajo(int legajo);
        public Resolucion_habilitacion_imprimir GetResolucion(int legajo);
        public  List<Resolucion_habilitacion_imprimir> GetAllResolucion(int legajo);
    }
}
