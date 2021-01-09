using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Material
    {
        public Material()
        {
            Parts = new HashSet<Part>();
        }

        public string Idmat { get; set; }
        public string MatEn { get; set; }
        public string Rodzaj { get; set; }
        public string Stan { get; set; }
        public string MatPn { get; set; }
        public string MatDin { get; set; }
        public string MatIso { get; set; }
        public string MatWnr { get; set; }
        public string Cmc { get; set; }
        public string Smc { get; set; }
        public double? C { get; set; }
        public short Hb { get; set; }
        public short Rm { get; set; }
        public short? Kc04 { get; set; }
        public short? Kc11 { get; set; }
        public double? Mc { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
