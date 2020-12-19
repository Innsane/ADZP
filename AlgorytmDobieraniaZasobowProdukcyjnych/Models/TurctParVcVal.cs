using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TurctParVcVal
    {
        public string Id { get; set; }
        public string Cmc { get; set; }
        public string Mc { get; set; }
        public int Grade { get; set; }
        public decimal? F1 { get; set; }
        public decimal? F2 { get; set; }
        public int? Vc1 { get; set; }
        public int? Vc2 { get; set; }
    }
}
