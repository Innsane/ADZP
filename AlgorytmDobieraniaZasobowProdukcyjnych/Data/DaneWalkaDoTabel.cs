using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class DaneWalkaDoTabel
    {

        public DaneWalkaDoTabel()
        {

        }

        public void SetDataToTable(DaneWalkaDoTabel dane)
        {
            AtributeValue = dane.AtributeValue;
            ListValue = dane.ListValue;
            AtributeName = dane.AtributeName;
            ListName = dane.ListName;
            Image = dane.Image;
        }

        internal void SetParameterToTable(List<Parameter> listOfParameters)
        {
            ParameterList = listOfParameters;

            ParameterListInfo = listOfParameters.First().GetType().GetProperties().ToList();

            var list = new List<List<object>>();
            foreach (var parameter in listOfParameters)
            {
                list.Add(new List<object>());
                list.Last().Add(parameter.Tool.Geometry);
                list.Last().Add(parameter.Tool.Holder);
                list.Last().Add(parameter.Tool.Material);
                list.Last().Add(parameter.AP);
                list.Last().Add(parameter.F);
                list.Last().Add(parameter.VC);
                list.Last().Add(parameter.N);
                list.Last().Add(parameter.Q);
                list.Last().Add(parameter.TG);
                list.Last().Add(parameter.T);
                list.Last().Add(parameter.FC);
                list.Last().Add(parameter.KC);
                list.Last().Add(parameter.HM);
                list.Last().Add(parameter.PC);
                list.Last().Add(parameter.PE);
            }

            var nameList = new List<string>
            {
                "Geometry",
                "Holder",
                "Material",
                "AP",
                "F",
                "VC",
                "N",
                "Q",
                "TG",
                "T",
                "FC",
                "KC",
                "HM",
                "PC",
                "PE"
            };

            ParametersNames = nameList;
            Parameters = list;
        }



        public List<object> AtributeValue { get; set; }
        public List<string> AtributeName { get; set; }

        public List<object[]> ListValue { get; set; }
        public List<string> ListName { get; set; }
        public List<Parameter> ParameterList = new List<Parameter>();
        public List<PropertyInfo> ParameterListInfo = new List<PropertyInfo>();
        public List<List<object>> Parameters = new List<List<object>>();
        public List<string> ParametersNames = new List<string>();

        public string Image { get; set; }


    }
}
