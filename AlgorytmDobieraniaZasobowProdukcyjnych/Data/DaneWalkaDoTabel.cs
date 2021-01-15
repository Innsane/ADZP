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

        public int StopienDoPokazania { get; set; }

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
        //parametry wybranych narzedzi
        public List<List<List<object>>> Tools = new List<List<List<object>>>();
        public List<string> ToolsNames = new List<string>();
        //parametry tokarki
        public List<object> Lathe = new List<object>();
        public List<string> LatheName = new List<string>();

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
            SetTools(listOfParameters);
            SetLathe(listOfParameters);
            SetParametrListRG(listOfParameters[0], ListaStopni);
            SetParametrListMT(listOfParameters[1], ListaStopni);
            SetParametrListFN(listOfParameters[2], ListaStopni);
        }

        private void SetParametrListRG(List<Parameter> listOfParameters, List<int> listaStopni)
        {
            var numer = 0;
            var tablesParameters = new List<List<List<object>>>();
            foreach (var parameter in listOfParameters)
            {
                var singleTable = new List<List<object>>();
                numer += 1;
                for (int i = 0; i < listOfParameters.First().Walek.Stopnie; i++)
                {
                    singleTable.Add(new List<object> {
                        numer,
                        listaStopni[i],
                        parameter.Tool.Holder,
                        parameter.Tool.Geometry,
                        parameter.Tool.Material,
                        parameter.Przejsc[i],
                        parameter.AP[i],
                        parameter.F[i],
                        parameter.VC[i],
                        parameter.N[i],
                        parameter.Q[i],
                        parameter.TG[i],
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
                        "Nr",        
                        "Stopień",
                        "Oprawka",
                        "Płytka",
                        "Materiał",
                        "Przejść",
                        "ap [mm]",
                        "f [mm]/obr]",
                        "vc [m/min]",
                        "n [obr/min]",
                        "Q [cm3/min]",
                        "tg [min]",
                        "Fc [N]",
                        "kc [N/mm2]",
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
            var numer = 0;
            foreach (var parameter in listOfParameters)
            {
                var singleTable = new List<List<object>>();
                numer += 1;
                for (int i = 0; i < listOfParameters.First().Walek.Stopnie; i++)
                {
                    singleTable.Add(new List<object> {
                        numer,
                        listaStopni[i],
                        parameter.Tool.Holder,
                        parameter.Tool.Geometry,
                        parameter.Tool.Material,
                        parameter.Ra[i],
                        parameter.AP[i],
                        parameter.F[i],
                        parameter.VC[i],
                        parameter.N[i],
                        parameter.Q[i],
                        parameter.TG[i],
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
                        "Nr",
                        "Stopień",
                        "Oprawka",
                        "Płytka",
                        "Materiał",
                        "Ra",
                        "ap [mm]",
                        "f [mm]/obr]",
                        "vc [m/min]",
                        "n [obr/min]",
                        "Q [cm3/min]",
                        "tg [min]",
                        "Fc [N]",
                        "kc [N/mm2]",
                        "hm [mm]",
                        "Pc [kW]",
                        "Pe [kW]"
                    };

            ParametersNamesMT = nameList;
            ParametersMT = tablesParameters;
        }
        private void SetParametrListFN(List<Parameter> listOfParameters, List<int> listaStopni)
        {
            var tablesParameters = new List<List<List<object>>>();
            var numer = 0;
            foreach (var parameter in listOfParameters)
            {
                numer += 1;
                var singleTable = new List<List<object>>();
                for (int i = 0; i < listOfParameters.First().Walek.Stopnie; i++)
                {
                    singleTable.Add(new List<object> {
                        numer,
                        listaStopni[i],
                        parameter.Tool.Holder,
                        parameter.Tool.Geometry,
                        parameter.Tool.Material,
                        parameter.Ra[i],
                        parameter.AP[i],
                        parameter.F[i],
                        parameter.VC[i],
                        parameter.N[i],
                        parameter.Q[i],
                        parameter.TG[i],
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
                        "Nr",
                        "Stopień",
                        "Oprawka",
                        "Płytka",
                        "Materiał",
                        "Chropowatość",
                        "ap [mm]",
                        "f [mm]/obr]",
                        "vc [m/min]",
                        "n [obr/min]",
                        "Q [cm3/min]",
                        "tg [min]",
                        "Fc [N]",
                        "kc [N/mm2]",
                        "hm [mm]",
                        "Pc [kW]",
                        "Pe [kW]"
                    };

            ParametersNamesFN = nameList;
            ParametersFN = tablesParameters;
        }

        internal void SetImages(Lathe lathe, List<List<Parameter>> lists, DaneWalka walek)
        {
            SetWalekImage(walek);
            SetLatheImage(lathe);
            SetParameterImage(lists);
        }
        internal void SetWalekImage(DaneWalka walek)
        {
            ImageWalek = "/images/" + walek.Image;
        }
        internal void SetLatheImage(Lathe lathe)
        {
            ImageLathe = "/images/" + lathe.Obraz;
        }
        internal void SetParameterImage(List<List<Parameter>> lists)
        {
            ImageToolRG = "/images/" + lists[0][0].Tool.Obraz;
            ImageToolMT = "/images/" + lists[1][0].Tool.Obraz;
            ImageToolFN = "/images/" + lists[2][0].Tool.Obraz;
        }

        internal void SetTools(List<List<Parameter>> data)
        {
            var index = 0;
            var tablesParameters = new List<List<List<object>>>();
            foreach (var list in data)
            {
                index = 0;
                var singleTable = new List<List<object>>();
                foreach (var parameter in list)
                {
                    index += 1;
                    singleTable.Add(new List<object>
                    {
                        index,
                        parameter.Tool.Holder,
                        parameter.Tool.Geometry,
                        parameter.Tool.Material,
                        parameter.Tool.Kr,
                        parameter.Tool.Re,
                        parameter.Tool.FnMax,
                        parameter.Tool.VcMax,
                        parameter.Tool.MaxAp,
                    });
                }
                tablesParameters.Add(singleTable);
            }

            var nameList = new List<string>
                    {
                        "Nr",
                        "Oprawka",
                        "Płytka",
                        "Materiał",
                        "Kr",
                        "Re",
                        "MaxF",
                        "MaxVc",
                        "MaxAp",
                    };
            Tools = tablesParameters;
            ToolsNames = nameList;
        }
        private void SetLathe(List<List<Parameter>> listOfParameters)
        {
            var list = new List<object>
            {
                listOfParameters[0][0].Lathe.Oznaczenie,
                listOfParameters[0][0].Lathe.Kod,
                listOfParameters[0][0].Lathe.Gniazdo,
                listOfParameters[0][0].Lathe.NMax,
                listOfParameters[0][0].Lathe.NMin,
                listOfParameters[0][0].Lathe.P,
            };

            var listNames = new List<string>
            {
                "Oznaczenie",
                "Kod",
                "Gnizado",
                "n max [obr/min]",
                "n min [obr/min]",
                "Pe [kW]"
            };
            Lathe = list;
            LatheName = listNames;
        }
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
