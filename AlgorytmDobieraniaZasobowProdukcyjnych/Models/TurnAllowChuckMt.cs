using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TurnAllowChuckMt
    {
        public int Ida { get; set; }
        public double? Lmin { get; set; }
        public double? Lmax { get; set; }
        public double? Dmin { get; set; }
        public double? Dmax { get; set; }
        public double? Qnom { get; set; }
        public byte? It { get; set; }
        public double? Ra { get; set; }
        public double? F { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
