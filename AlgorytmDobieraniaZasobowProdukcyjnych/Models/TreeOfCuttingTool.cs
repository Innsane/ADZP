using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class TreeOfCuttingTool
    {
        public string NodeId { get; set; }
        public string KeyId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public int? IconId { get; set; }
        public string TableId { get; set; }
        public string PictureId { get; set; }
        public string Stepncname { get; set; }
    }
}
