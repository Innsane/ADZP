using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TurctInsert
    {
        public string Id { get; set; }
        public string Geometry { get; set; }
        public string Shape { get; set; }
        public decimal? Re { get; set; }
        public decimal? S { get; set; }
        public int Is { get; set; }
        public int? L { get; set; }
        public decimal? IC { get; set; }
        public decimal? Kw { get; set; }
        public decimal? La { get; set; }
        public int? K { get; set; }
    }
}
