using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class LatheData : IMfgResources
    {
        private readonly MfgResourcesContext db;

        public LatheData(MfgResourcesContext db)
        {
            this.db = db;
        }

        public IEnumerable<Lathe> GetAllLathes()
        {
            var query = from l in db.Lathes
                        select l;
            return query;
        }

        public IEnumerable<WiertlaDat> GetAllWiertla()
        {
            var query = from l in db.WiertlaDats
                        orderby l.Oznaczenie
                        select l;
            return query;
        }

        public IEnumerable<TreeOfCuttingTool> GetAllCuttingTools()
        {
            var query = from t in db.TreeOfCuttingTools
                        select t;
            return query;
        }

    }
}
