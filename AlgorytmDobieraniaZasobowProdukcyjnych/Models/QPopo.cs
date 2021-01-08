using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class QPopo
    {
        public string Idftr { get; set; }
        public string Idpart { get; set; }
        public string FtrNo { get; set; }
        public string FtrType { get; set; }
        public string Nazwa { get; set; }
        public double? Diameter { get; set; }
        public double? Depth { get; set; }
        public double? Radius { get; set; }
        public byte? It { get; set; }
        public double? Ra { get; set; }
    }
}
