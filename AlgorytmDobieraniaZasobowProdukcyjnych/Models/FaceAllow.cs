using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class FaceAllow
    {
        public int Ida { get; set; }
        public short? Lmin { get; set; }
        public short? Lmax { get; set; }
        public short? Dmin { get; set; }
        public short? Dmax { get; set; }
        public string Range { get; set; }
        public double? Ra { get; set; }
        public double? Tol { get; set; }
        public double? Qnom { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
