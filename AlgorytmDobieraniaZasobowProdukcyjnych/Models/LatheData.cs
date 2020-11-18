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

        public IEnumerable<Lathe> GetAll()
        {
            var query = from l in db.Lathes
                        where l.Rodzaj.StartsWith("Tokarka")
                        orderby l.Oznaczenie
                        select l;
            return query;
        }
    }
}
