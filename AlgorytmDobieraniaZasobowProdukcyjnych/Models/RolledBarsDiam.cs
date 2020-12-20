using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class RolledBarsDiam
    {
        public short D { get; set; }
        public float? TolA1 { get; set; }
        public float? TolA2 { get; set; }
        public float? TolA3 { get; set; }
        public float? Masa { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
