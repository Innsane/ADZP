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
                              where m.Idmat == walek.MaterialId
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
        public List<List<QTurningTool>> GetTurningTools(IEnumerable<TurnToolTab> tools, Lathe lathe, DaneWalka walek, List<string> grades)
        {
            var dlugosc = Convert.ToDouble(lathe.Gniazdo.Substring(0, 2));
            var szerokosc = Convert.ToDouble(lathe.Gniazdo.Substring(3, 2));
            var ap = Convert.ToDecimal(walek.APMAX.Max());
            var turnings = new List<List<QTurningTool>>();

            var TurnRG = from l in db.QTurningTools
                         where l.B == dlugosc && l.H == szerokosc && l.MaxAp > walek.APRGREAL.Max() &&
                               l.Kr < 90 &&
                               l.Re <= (decimal)2.4 &&
                               l.Re >= (decimal)1.6 &&
                               l.Ht == "L" &&
                               l.OpA == "LT" &&
                               l.Geometry.Contains("PR")
                         select l;
            turnings.Add(TurnRG.ToList());

            var TurnMT = from l in db.QTurningTools
                         where l.B == dlugosc && l.H == szerokosc && l.MaxAp > walek.QMT &&
                               l.Kr > 90 &&
                               l.Re <= (decimal)1.2 &&
                               l.Ht == "L" &&
                               l.OpA == "LT" &&
                               l.Geometry.Contains("PM")
                         select l;
            turnings.Add(TurnMT.ToList());

            var TurnFN = from l in db.QTurningTools
                         where l.B == dlugosc && l.H == szerokosc && l.MaxAp > walek.QFN &&
                               l.Kr > 90 &&
                               l.Re <= (decimal)0.4 &&
                               l.Ht == "L" &&
                               l.OpA == "LT" &&
                               l.Geometry.Contains("PF")
                         select l;
            turnings.Add(TurnFN.ToList());


            turnings = SortByGrade(grades, turnings);
            SortByMaxAp(turnings);
            return turnings;
        }

        private static void SortByMaxAp(List<List<QTurningTool>> turnings)
        {
            decimal apmax = 1000;
            foreach (var list in turnings)
            {
                foreach (var turning in list)
                {
                    if (turning.ApMax < apmax)
                    {
                        apmax = (decimal)turning.ApMax;
                    }
                }
                list.RemoveAll(t => t.ApMax != apmax);
            }

        }

        private static List<List<QTurningTool>> SortByGrade(List<string> grades, List<List<QTurningTool>> turnings)
        {
            var newTurnings = new List<List<QTurningTool>>();
            

            foreach (var list in turnings)
            {
                var newList = new List<QTurningTool>();
                foreach (var grade in grades)
                {
                    foreach (var turn in list)
                    {
                        if (turn.Material == Convert.ToInt32(grade))
                        {
                            newList.Add(turn);
                        }
                    }
                }
                newTurnings.Add(newList);
            }

            return newTurnings;
        }

        public void Add(QPocl qpocl)
        {
            db.Add(qpocl);
        }

        public void Add(Feature feature)
        {
            db.Add(feature);
        }

        public void Add(Part part)
        {
            db.Add(part);
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public int CountParts()
        {
            var query = from p in db.Parts
                        select p;
            return query.ToList().Count;
        }

        
    }
}
