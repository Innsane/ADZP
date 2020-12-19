using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TurnToolTab
    {
        public string Idtt { get; set; }
        public string Tooling { get; set; }
        public string ShankCode { get; set; }
        public string CatPage { get; set; }
        public string Method { get; set; }
        public string Accuracy { get; set; }
        public double? Kappa { get; set; }
        public double? Alfa { get; set; }
        public double? Gamma { get; set; }
        public double? Lambda { get; set; }
        public string Kod { get; set; }
        public string Obraz { get; set; }
        public string Rys2D { get; set; }
        public string Mod3D { get; set; }
    }
}
