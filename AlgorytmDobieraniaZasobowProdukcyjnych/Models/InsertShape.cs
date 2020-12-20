using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class InsertShape
    {
        public string Shape { get; set; }
        public string Name { get; set; }
        public byte? An { get; set; }
        public byte Nce { get; set; }
        public double Elf { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
