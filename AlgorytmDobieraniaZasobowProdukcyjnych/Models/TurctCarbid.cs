using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TurctCarbid
    {
        public string Id { get; set; }
        public string Geometry { get; set; }
        public int Material { get; set; }
        public decimal? ApMin { get; set; }
        public decimal? ApMax { get; set; }
        public decimal? FnMin { get; set; }
        public decimal? FnMax { get; set; }
        public int? VcMin { get; set; }
        public int? VcMax { get; set; }
        public decimal? ApZ { get; set; }
        public decimal? FnZ { get; set; }
        public int? VcZ { get; set; }
    }
}
