using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Tolerance
    {
        public int Identyfikator { get; set; }
        public short? Dmin { get; set; }
        public short? Dmax { get; set; }
        public short? Itc { get; set; }
        public float? Tol { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
