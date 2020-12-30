using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class DaneWalkaDoTabel
    {
        public List<object> AtributeValue { get; set; }
        public List<string> AtributeName { get; set; }

        public List<object[]> ListValue { get; set; }
        public List<string> ListName { get; set; }

        public List<List<object>> NaddatkiValues { get; internal set; }
        public List<string> NaddatkiNames { get; internal set; }


        //public List<Parameter> ParameterList = new List<Parameter>();
        //public List<PropertyInfo> ParameterListInfo = new List<PropertyInfo>();
        //narzedzia do obrobki zgrubnej
        public List<List<List<object>>> ParametersRG = new List<List<List<object>>>();
        public List<string> ParametersNamesRG = new List<string>();
        //narzedzia do obrobki ksztlatujacej
        public List<List<List<object>>> ParametersMT = new List<List<List<object>>>();
        public List<string> ParametersNamesMT = new List<string>();
        //narzedzia do obrobki wykanczajacej
        public List<List<List<object>>> ParametersFN = new List<List<List<object>>>();
        public List<string> ParametersNamesFN = new List<string>();

        public string ImageLathe { get; set; }
        public string ImageToolRG { get; set; }
        public string ImageToolMT { get; set; }
        public string ImageToolFN { get; set; }
        public string ImageWalek { get; set; }
        

        public DaneWalkaDoTabel()
        {

        }

        public void SetDataToTable(DaneWalkaDoTabel dane)
        {
            AtributeValue = dane.AtributeValue;
            ListValue = dane.ListValue;
            AtributeName = dane.AtributeName;
            ListName = dane.ListName;
            NaddatkiValues = dane.NaddatkiValues;
            NaddatkiNames = dane.NaddatkiNames;
            ImageLathe = dane.ImageLathe;
        }

        internal void SetParameterToTable(List<List<Parameter>> listOfParameters)
        {
            //ParameterList = listOfParameters;
            //ParameterListInfo = listOfParameters.First().GetType().GetProperties().ToList();

            var ListaStopni = new List<int>();
            for (int i = 0; i < listOfParameters[0].First().VC.Count; i++)
            {
                ListaStopni.Add(i + 1);
            }

            SetParametrListRG(listOfParameters[0], ListaStopni);
            SetParametrListMT(listOfParameters[1], ListaStopni);
            SetParametrListFN(listOfParameters[2], ListaStopni);
        }

        private void SetParametrListRG(List<Parameter> listOfParameters, List<int> listaStopni)
        {
            var tablesParameters = new List<List<List<object>>>();
            foreach (var parameter in listOfParameters)
            {
                var singleTable = new List<List<object>>();
                for (int i = 0; i < listOfParameters.First().Walek.Stopnie; i++)
                {
                    singleTable.Add(new List<object> {
                        listaStopni[i],
                        parameter.Tool.Geometry,
                        parameter.Tool.Holder,
                        parameter.Tool.Material,
                        parameter.Przejsc[i],
                        parameter.AP[i],
                        parameter.F[i],
                        parameter.VC[i],
                        parameter.N[i],
                        parameter.Q[i],
                        parameter.TG[i],
                        0,//parameter.T[i],
                        parameter.FC[i],
                        parameter.KC[i],
                        parameter.HM[i],
                        parameter.PC[i],
                        parameter.PE[i],
                    });
                }
                tablesParameters.Add(singleTable);
            }

            var nameList = new List<string>
                    {
                        "Stopień",
                        "Geometry",
                        "Holder",
                        "Material",
                        "Przejsc",
                        "ap",
                        "f",
                        "vc",
                        "n",
                        "Q",
                        "tg",
                        "T",
                        "Fc",
                        "kc",
                        "hm [mm]",
                        "Pc [kW]",
                        "Pe [kW]"
                    };

            ParametersNamesRG = nameList;
            ParametersRG = tablesParameters;
        }
        private void SetParametrListMT(List<Parameter> listOfParameters, List<int> listaStopni)
        {
            var tablesParameters = new List<List<List<object>>>();
            foreach (var parameter in listOfParameters)
            {
                var singleTable = new List<List<object>>();
                for (int i = 0; i < listOfParameters.First().Walek.Stopnie; i++)
                {
                    singleTable.Add(new List<object> {
                        listaStopni[i],
                        parameter.Tool.Geometry,
                        parameter.Tool.Holder,
                        parameter.Tool.Material,
                        parameter.AP[i],
                        parameter.F[i],
                        parameter.VC[i],
                        parameter.N[i],
                        parameter.Q[i],
                        parameter.TG[i],
                        0,//parameter.T[i],
                        parameter.FC[i],
                        parameter.KC[i],
                        parameter.HM[i],
                        parameter.PC[i],
                        parameter.PE[i],
                    });
                }
                tablesParameters.Add(singleTable);
            }

            var nameList = new List<string>
                    {
                        "Stopień",
                        "Geometry",
                        "Holder",
                        "Material",
                        "ap",
                        "f",
                        "vc",
                        "n",
                        "Q",
                        "tg",
                        "T",
                        "Fc",
                        "kc",
                        "hm [mm]",
                        "Pc [kW]",
                        "Pe [kW]"
                    };

            ParametersNamesMT = nameList;
            ParametersMT = tablesParameters;
        }

        internal void SetImages(Lathe lathe, List<List<Parameter>> lists, DaneWalka walek)
        {
            ImageLathe = "/images/" + lathe.Obraz;
            ImageWalek = "/images/" + walek.Image.Trim() + ".jpg";
            ImageToolRG = "/images/" + lists[0][0].Tool.Obraz;
            ImageToolMT = "/images/" + lists[1][0].Tool.Obraz;
            ImageToolFN = "/images/" + lists[2][0].Tool.Obraz;
        }

        private void SetParametrListFN(List<Parameter> listOfParameters, List<int> listaStopni)
        {
            var tablesParameters = new List<List<List<object>>>();
            foreach (var parameter in listOfParameters)
            {
                var singleTable = new List<List<object>>();
                for (int i = 0; i < listOfParameters.First().Walek.Stopnie; i++)
                {
                    singleTable.Add(new List<object> {
                        listaStopni[i],
                        parameter.Tool.Geometry,
                        parameter.Tool.Holder,
                        parameter.Tool.Material,
                        parameter.AP[i],
                        parameter.F[i],
                        parameter.VC[i],
                        parameter.N[i],
                        parameter.Q[i],
                        parameter.TG[i],
                        0,//parameter.T[i],
                        parameter.FC[i],
                        parameter.KC[i],
                        parameter.HM[i],
                        parameter.PC[i],
                        parameter.PE[i],
                    });
                }
                tablesParameters.Add(singleTable);
            }

            var nameList = new List<string>
                    {
                        "Stopień",
                        "Geometry",
                        "Holder",
                        "Material",
                        "ap",
                        "f",
                        "vc",
                        "n",
                        "Q",
                        "tg",
                        "T",
                        "Fc",
                        "kc",
                        "hm [mm]",
                        "Pc [kW]",
                        "Pe [kW]"
                    };

            ParametersNamesFN = nameList;
            ParametersFN = tablesParameters;
        }

        //    internal void SetParameterToTable(List<Parameter> listOfParameters)
        //    {
        //        ParameterList = listOfParameters;

        //        ParameterListInfo = listOfParameters.First().GetType().GetProperties().ToList();

        //        var list = new List<List<object>>();
        //        foreach (var parameter in listOfParameters)
        //        {
        //            list.Add(new List<object>());
        //            list.Last().Add(parameter.Tool.Geometry);
        //            list.Last().Add(parameter.Tool.Holder);
        //            list.Last().Add(parameter.Tool.Material);
        //            list.Last().Add(parameter.AP);
        //            list.Last().Add(parameter.F);
        //            list.Last().Add(parameter.VC);
        //            list.Last().Add(parameter.N);
        //            list.Last().Add(parameter.Q);
        //            list.Last().Add(parameter.TG);
        //            list.Last().Add(parameter.T);
        //            list.Last().Add(parameter.FC);
        //            list.Last().Add(parameter.KC);
        //            list.Last().Add(parameter.HM);
        //            list.Last().Add(parameter.PC);
        //            list.Last().Add(parameter.PE);
        //        }

        //        var nameList = new List<string>
        //        {
        //            "Geometry",
        //            "Holder",
        //            "Material",
        //            "AP",
        //            "F",
        //            "VC",
        //            "N",
        //            "Q",
        //            "TG",
        //            "T",
        //            "FC",
        //            "KC",
        //            "HM",
        //            "PC",
        //            "PE"
        //        };

        //        ParametersNames = nameList;
        //        Parameters = list;
        //    }

        //}
    }
}
