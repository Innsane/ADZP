using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class QTurningTool: TableData
    {
        public string OpA { get; set; }
        public string OpB { get; set; }
        public string Holder { get; set; }
        public string Geometry { get; set; }
        public int Material { get; set; }
        public double? His { get; set; }
        public string Ht { get; set; }
        public double? B { get; set; }
        public double? H { get; set; }
        public double? Kr { get; set; }
        public int InIs { get; set; }
        public decimal? Re { get; set; }
        public decimal? S { get; set; }
        public int? L { get; set; }
        public decimal? La { get; set; }
        public decimal? FnMin { get; set; }
        public decimal? FnMax { get; set; }
        public decimal? ApMin { get; set; }
        public decimal? ApMax { get; set; }
        public int? VcMin { get; set; }
        public int? VcMax { get; set; }
        public decimal? ApZ { get; set; }
        public decimal? FnZ { get; set; }
        public int? VcZ { get; set; }
        public double? MaxAp { get; set; }
    }
}
