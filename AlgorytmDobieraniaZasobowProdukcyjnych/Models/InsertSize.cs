using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class InsertSize
    {
        public string Idis { get; set; }
        public string Shape { get; set; }
        public byte Size { get; set; }
        public double? IC { get; set; }
        public byte Th { get; set; }
        public double S { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
