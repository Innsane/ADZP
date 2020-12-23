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

        public IEnumerable<Lathe> GetObrabiarki(string name)
        {
            var query = from l in db.Lathes
                        where l.Oznaczenie.StartsWith(name)
                        select l;
            return query;
        }

        public IEnumerable<TurnToolTab> GetTools(Lathe lathe, string zabieg)
        {

            var query = from t in db.TurnToolTabs
                        where t.Accuracy.Contains(zabieg) && t.Kappa >= 55
                        select t;
            return query;
        }

        public List<QTurningTool> GetTurningTools(IEnumerable<TurnToolTab> tools, Lathe lathe)
        {
            var dlugosc = Convert.ToDouble(lathe.Gniazdo.Substring(0, 2));
            var szerokosc = Convert.ToDouble(lathe.Gniazdo.Substring(3, 2));
            var turnings = new List<QTurningTool>();

            var query = from l in db.QTurningTools
                        where l.B == dlugosc && l.H == szerokosc && l.Ht == "L" && l.Kr < 90
                        select l;
            var list = query.ToList();
            return turnings = query.ToList() ;
        }
    }
}
