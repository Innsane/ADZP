﻿using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class NozeJednolite: TableData
    {
        public string Id { get; set; }
        public string Iso { get; set; }
        public string Pn { get; set; }
        public double? Din { get; set; }
        public string Oznaczanie { get; set; }
        public string Nazwa { get; set; }
        public string Typ { get; set; }
        public string Hand { get; set; }
        public int? B { get; set; }
        public int? H { get; set; }
        public int? L { get; set; }
        public double? Re { get; set; }
        public double? X1 { get; set; }
        public double? X2 { get; set; }
        public double? Dmin { get; set; }
        public int? Kat { get; set; }
        public double? Waga { get; set; }
        public string Material { get; set; }
        public decimal? Cena { get; set; }
    }
}
