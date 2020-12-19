using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Opsklo: TableData
    {
        public double Idp { get; set; }
        public string Norma { get; set; }
        public string Iso { get; set; }
        public string Typ { get; set; }
        public double? Ksm { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public double? D { get; set; }
        public double? E { get; set; }
        public double? F { get; set; }
        public double? G { get; set; }
        public double? K { get; set; }
        public double? J { get; set; }
        public double? L { get; set; }
        public double? Bicie { get; set; }
        public double? Mwpo { get; set; }
        public double? Mn { get; set; }
        public string Opis { get; set; }
    }
}
