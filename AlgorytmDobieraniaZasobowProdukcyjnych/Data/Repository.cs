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

        public string GetCmcMaterial(DaneWalka walek)
        {
            var cmcMaterial = from m in db.Materials
                              where m.MatPn == walek.Material
                              select m.Cmc;
            return cmcMaterial.ToList().First();
        }

        public List<string> GetGrades(string cmc)
        {
            var grades = from g in db.ParVcVals
                        where g.Cmc == cmc
                        select g.Grade;
            var list = new List<string>();
            foreach (var grade in grades)
            {
                list.Add(grade.ToString());
            }

            return list.Distinct().ToList();
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
        //getting turnings base on data
        //LT = longitudal turning
        //FC = facing
        //PR = profiling
        //CH = 
        public List<QTurningTool> GetTurningTools(IEnumerable<TurnToolTab> tools, Lathe lathe, DaneWalka walek, List<string> grades)
        {
            var dlugosc = Convert.ToDouble(lathe.Gniazdo.Substring(0, 2));
            var szerokosc = Convert.ToDouble(lathe.Gniazdo.Substring(3, 2));
            var ap = Convert.ToDecimal(walek.APMAX.Max());
            var turnings = new List<QTurningTool>();

            while(turnings.Count == 0)
            {
                var query = from l in db.QTurningTools
                            where l.B == dlugosc && l.H == szerokosc && l.ApMax >= ap &&
                                  l.Ht == "L" &&  
                                  l.OpA == "LT" && l.Geometry.Contains("PR")
                            select l;
                ap /= 2;
                turnings = query.ToList();
            }

            var newTurnings = new List<QTurningTool>();
            foreach (var grade in grades)
            {
                foreach (var turn in turnings)
                {
                    if(turn.Material == Convert.ToInt32(grade))
                    {
                        newTurnings.Add(turn);
                    }
                }
            }
            turnings = newTurnings;
            decimal apmax = 1000;
            foreach (var turning in turnings)
            {
                if(turning.ApMax < apmax)
                {
                    apmax = (decimal)turning.ApMax;
                }
            }
            turnings.RemoveAll(t => t.ApMax != apmax);
            return turnings;
        }
    }
}
