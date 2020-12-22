using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Repository : IRepository
    {
        private readonly MfgResourcesContext db;

        public Repository(MfgResourcesContext db)
        {
            this.db = db;
        }

        public IEnumerable<Lathe> GetObrabiarki()
        {
            var query = from l in db.Lathes
                        select l;
            return query;
        }
    }
}
