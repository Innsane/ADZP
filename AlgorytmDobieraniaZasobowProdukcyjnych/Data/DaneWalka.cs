using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class DaneWalka
    {
        //wpisane
        public double Dlugosc { get; set; }
        public double Srednica { get; set; }
        public string Material { get; set; }
        public double GestoscMaterialu = 7.85;

        public int Stopnie { get; set; }

        public List<double> DlugoscStopnia { get; set; }
        public List<double> SrednicaStopnia { get; set; }
        public List<int> KlasaTolerancji { get; set; }
    }
}
