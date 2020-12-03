using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Opskl: TableData
    {
        public double Idp { get; set; }
        public string Norma { get; set; }
        public int? Iso { get; set; }
        public int? Ksm { get; set; }
        public double? L { get; set; }
        public double? D { get; set; }
        public double? E { get; set; }
        public double? S { get; set; }
        public string Nakretka { get; set; }
        public string Opis { get; set; }
    }
}
