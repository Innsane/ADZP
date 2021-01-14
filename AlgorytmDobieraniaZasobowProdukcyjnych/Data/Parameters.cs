using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        //public List<Parameter> ParametersCalculated = new List<Parameter>();
        //public List<Parameter> ParametersMT = new List<Parameter>();
        //public List<Parameter> ParametersFN = new List<Parameter>();
        public List<List<Parameter>> ParameterList = new List<List<Parameter>>();
        public List<List<QTurningTool>> Turnings = new List<List<QTurningTool>>();

        public Lathe Lathe { get; set; }
        public string Cmc { get; private set; }
        public DaneWalka Walek { get; set; }

        public void Calculate()
        {
            for (int i = 0; i < Turnings.Count; i++)
            {
                var parametersCalculated = new List<Parameter>();
                foreach (var turning in Turnings[i])
                {
                    var parameter = new Parameter(db);
                    parameter.Calculate(Walek, Lathe, turning, Cmc);
                    parametersCalculated.Add(parameter);
                }
                ParameterList.Add(parametersCalculated);
            }

            //while (!(IsTool()))
            //{
            //    if (IsTool()) SortOfPower();
            //    else Recalculate();
            //}
            //SortOfPower();
        }

        public List<List<Parameter>> GetParametersList(int ilosc)
        {
            for (int i = 0; i < ParameterList.Count; i++)
            {
                ParameterList[i].Sort(CompareByQ);
                ParameterList[i].Reverse();
                var list = ParameterList[i].GroupBy(elem => elem.Tool.Material).Select(group => group.Take(ilosc).ToList()).ToList();
                ParameterList[i].Clear();
                foreach (var listOfParametrs in list)
                {
                    for (int ii = 0; ii < listOfParametrs.Count; ii++)
                    {
                        ParameterList[i].Add(listOfParametrs[ii]);
                    }
                }
                //ParameterList[i] = ParameterList[i].GroupBy(elem=>elem.Tool.Material).Select(group=>group.First()).ToList();
                //ParameterList[i] = ParameterList[i].ToList();
            }
            return ParameterList;
        }

        private static int CompareByQ(Parameter x, Parameter y)
        {
            if (x.Q.Max() > y.Q.Max()) return 1;
            else if (x.Q.Max() == y.Q.Max()) return 0;
            else return -1;
        }

        public void SetParameterList(DaneWalka walek, Lathe lathe, string cmc, List<List<QTurningTool>> turnings)
        {
            Walek = walek;
            Lathe = lathe;
            Cmc = cmc;
            Turnings = turnings;
        }

        //internal void SortOfPower()
        //{
        //    for (int i = 0; i < ParameterList[0].Count; i++)
        //    {
        //        for (int j = 0; j < Walek.Stopnie; j++)
        //        {
        //            if (ParameterList[0][i].PE[j] < ParameterList[0][i].PC[j])
        //            {
        //                ParameterList[0].RemoveAt(i);
        //                i--;
        //                break;
        //            }
        //        }
        //    }
        //}

        //private bool IsTool()
        //{
        //    var goodTools = new List<Parameter>();
        //    foreach (var para in ParametersCalculated)
        //    {
        //        int count = 0;
        //        for (int i = 0; i < Walek.Stopnie; i++)
        //        {
        //            if (para.PE[i] > para.PC[i])
        //            {
        //                count++;
        //            }
        //        }
        //        if (count == Walek.Stopnie) goodTools.Add(para);
        //    }

        //    if (goodTools.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private void Recalculate()
        //{
        //    foreach (var para in ParametersCalculated)
        //    {
        //        for (int i = 0; i < Walek.Stopnie; i++)
        //        {
        //            if (para.PE[i] < para.PC[i])
        //            {
        //                para.VC[i] -= para.VC[i] * 0.1;
        //            }
        //        }
        //        para.Calculate();
        //    }
        //}



        //public List<List<Parameter>> GetParametersList()
        //{
        //    var bestParameter = new Parameter();
        //    var bestIndex = 0;
        //    var bestQ = 0.0;
        //    foreach (var list in ParameterList)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            list[i].Q.Max();
        //            if (list[i].Q.Max() > bestQ)
        //            {
        //                bestQ = list[i].Q.Max();
        //                bestIndex = i;
        //            }
        //            bestParameter = list[bestIndex];
        //        }
        //        list.Clear();
        //        list.Add(bestParameter);
        //    }

        //    return ParameterList;
        //}


    }
}
