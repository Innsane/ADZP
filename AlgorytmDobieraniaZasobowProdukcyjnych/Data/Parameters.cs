using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Parameters : IParameters
    {
        private readonly MfgResourcesContext db;

        public Parameters(MfgResourcesContext db)
        {
            this.db = db;
        }
        public List<Parameter> ParaList = new List<Parameter>();
        public List<QTurningTool> Turnings = new List<QTurningTool>();
        public Lathe Lathe { get; set; }
        public string Cmc { get; private set; }
        public DaneWalka Walek { get; set; }

        public void Calculate()
        {
            foreach (var turning in Turnings)
            {
                var parameter = new Parameter(db);
                parameter.Calculate(Walek, Lathe, turning, Cmc);
                ParaList.Add(parameter);
                if (IsTool()) SortOfPower();
                else Recalculate();
            }
        }

        private void Recalculate()
        {
            foreach (var para in ParaList)
            {
                para.VC -= para.VC * 0.1;
                para.Calculate();
            }
        }

        private bool IsTool()
        {
            var goodTools = new List<Parameter>();
            foreach (var para in ParaList)
            {
                if(para.PE > para.PC)
                {
                    goodTools.Add(para);
                }
            }

            if(goodTools.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetParameterList(DaneWalka walek, Lathe lathe, string cmc, List<QTurningTool> turnings)
        {
            Walek = walek;
            Lathe = lathe;
            Cmc = cmc;
            Turnings = turnings;
        }

        internal void SortOfPower()
        {
            for (int i = 0; i < ParaList.Count; i++)
            {
                if (ParaList[i].PE < ParaList[i].PC)
                {
                    ParaList.RemoveAt(i);
                }
            }
        }

        public List<Parameter> GetParametersList()
        {
            return ParaList;
        }
    }
}
