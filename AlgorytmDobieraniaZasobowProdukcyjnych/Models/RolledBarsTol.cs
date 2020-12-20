using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class RolledBarsTol
    {
        public int Identyfikator { get; set; }
        public short? Dmin { get; set; }
        public short? Dmax { get; set; }
        public float? TolA1 { get; set; }
        public float? TolA2 { get; set; }
        public float? TolA3 { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
