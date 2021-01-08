using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Feature
    {
        public string Idftr { get; set; }
        public string Idpart { get; set; }
        public string FtrNo { get; set; }
        public string FtrType { get; set; }
        public string ParFtr { get; set; }
        public double? Diameter { get; set; }
        public double? Length { get; set; }
        public double? Depth { get; set; }
        public double? Width { get; set; }
        public double? Radius { get; set; }
        public double? Angle { get; set; }
        public string Thread { get; set; }
        public string Fit { get; set; }
        public byte? It { get; set; }
        public double? Ra { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
