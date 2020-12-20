using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class ParVcVal
    {
        public string Id { get; set; }
        public string Cmc { get; set; }
        public string Mc { get; set; }
        public short? Grade { get; set; }
        public float? F1 { get; set; }
        public float? F2 { get; set; }
        public short? Vc1 { get; set; }
        public short? Vc2 { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
