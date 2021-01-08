using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Part
    {
        public Part()
        {
            Blanks = new HashSet<Blank>();
        }

        public string Idpart { get; set; }
        public string PartName { get; set; }
        public string Idmat { get; set; }
        public double? Mass { get; set; }
        public string Drawing { get; set; }
        public string Model { get; set; }
        public string Picture { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual ICollection<Blank> Blanks { get; set; }
    }
}
