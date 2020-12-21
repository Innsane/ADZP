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

        public void Dane(DaneWalkaDoTabel dane)
        {
            AtributeValue = dane.AtributeValue;
            ListValue = dane.ListValue;
            AtributeName = dane.AtributeName;
            ListName = dane.ListName;
        }

        public List<object> AtributeValue { get; set; }
        public List<string> AtributeName { get; set; }

        public List<object[]> ListValue { get; set; }
        public List<string> ListName { get; set; }
    }
}
