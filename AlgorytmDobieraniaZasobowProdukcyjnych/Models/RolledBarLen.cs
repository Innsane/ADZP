using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class RolledBarLen
    {
        public int Identyfikator { get; set; }
        public int? Dmin { get; set; }
        public int? Dmax { get; set; }
        public int? Lmin { get; set; }
        public int? Lmax { get; set; }
    }
}
