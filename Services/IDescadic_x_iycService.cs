using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_IyC.Entities;

namespace Web_Api_IyC.Services
{
    public interface IDescadic_x_iycService
    {
        public List<Descadic_x_iyc> read(int legajo);
        public Descadic_x_iyc getByPk(int legajo, int cod_concepto_iyc);
        public int insert(Descadic_x_iyc obj);
        public void update(Descadic_x_iyc obj);
        public void delete(int legajo, int cod_concepto_iyc, string usuario);
        public List<Descadic_x_iyc> getConceptos_x_iyc(int legajo);
    }
}

