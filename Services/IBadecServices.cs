using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_IyC.Services
{
    public interface IBadecServices
    {
        public int insert(Entities.BADEC obj);
        public void update(Entities.BADEC obj);
        public void update2(Entities.BADEC obj);
        public void delete(int nro_bad);
        public List<Entities.BADEC> read();
        public List<Entities.BADEC> read2();
        public Entities.BADEC getByPk(int nro_bad);
        public Entities.BADEC getByPk2(int nro_bad);        
    }
}
