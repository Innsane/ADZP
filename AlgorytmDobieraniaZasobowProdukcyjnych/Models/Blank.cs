using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Blank
    {
        public string Idbl { get; set; }
        public string Idp { get; set; }
        public string Material { get; set; }
        public double? Dmax { get; set; }
        public short? Dpf { get; set; }
        public double? Tdpf { get; set; }
        public byte? Itpf { get; set; }
        public double? Rapf { get; set; }
        public short? Lpf { get; set; }
        public double? Tlpf { get; set; }
        public short? Np { get; set; }
        public double? Weight { get; set; }
        public decimal? Price { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Part IdpNavigation { get; set; }
    }
}
