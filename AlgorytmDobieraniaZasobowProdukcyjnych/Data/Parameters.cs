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
        public List<Parameter> ParametersRG = new List<Parameter>();
        public List<Parameter> ParametersMT = new List<Parameter>();
        public List<Parameter> ParametersFN = new List<Parameter>();
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
                ParametersRG.Add(parameter);
            }

            while (!(IsTool()))
            {
                if (IsTool()) SortOfPower();
                else Recalculate();
            }
            SortOfPower();
        }

        private bool IsTool()
        {
            var goodTools = new List<Parameter>();
            foreach (var para in ParametersRG)
            {
                int count = 0;
                for (int i = 0; i < Walek.Stopnie; i++)
                {
                    if (para.PE[i] > para.PC[i])
                    {
                        count++;
                    }
                }
                if (count == Walek.Stopnie) goodTools.Add(para);
            }

            if(goodTools.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Recalculate()
        {
            foreach (var para in ParametersRG)
            {
                for (int i = 0; i < Walek.Stopnie; i++)
                {
                    if (para.PE[i] < para.PC[i])
                    {
                        para.VC[i] -= para.VC[i] * 0.1;
                    }
                }
                para.Calculate();
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
            for (int i = 0; i < ParametersRG.Count; i++)
            {
                for (int j = 0; j < Walek.Stopnie; j++)
                {
                    if (ParametersRG[i].PE[j] < ParametersRG[i].PC[j])
                    {
                        ParametersRG.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }

        public List<Parameter> GetParametersList()
        {
            var bestParameter = new Parameter();
            var bestIndex = 0;
            var bestQ = 0.0;
            for (int i = 0; i < ParametersRG.Count; i++)
            {
                ParametersRG[i].Q.Max();
                if(ParametersRG[i].Q.Max() > bestQ)
                {
                    bestQ = ParametersRG[i].Q.Max();
                    bestIndex = i;
                }
                bestParameter = ParametersRG[bestIndex];
            }
            ParametersRG.Clear();
            ParametersRG.Add(bestParameter);
            return ParametersRG;
        }
    }
}
