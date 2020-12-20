using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TurnAllowCentrRg
    {
        public int Ida { get; set; }
        public short? Lmin { get; set; }
        public short? Lmax { get; set; }
        public double? Dmin { get; set; }
        public double? Dmax { get; set; }
        public double? Qnom { get; set; }
        public byte? It { get; set; }
        public double? Ra { get; set; }
        public double? F { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
