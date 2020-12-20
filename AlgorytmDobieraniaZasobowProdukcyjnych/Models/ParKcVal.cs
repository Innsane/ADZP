using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class ParKcVal
    {
        public string Id { get; set; }
        public string Material { get; set; }
        public string Cmc { get; set; }
        public short? RmMin { get; set; }
        public short? RmMax { get; set; }
        public float? F1 { get; set; }
        public float? F2 { get; set; }
        public short? Kc1 { get; set; }
        public short? Kc2 { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
