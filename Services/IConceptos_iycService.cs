using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_IyC.Entities;
namespace Web_Api_IyC.Services
{
    public interface IConceptos_iycService
    {
        public List<Conceptos_iyc> read();
        public Conceptos_iyc getByPk(int cod_concepto_iyc);
        public int insert(Conceptos_iyc obj);
        public void update(Conceptos_iyc obj);
        public void delete(Conceptos_iyc obj);
    }
}

