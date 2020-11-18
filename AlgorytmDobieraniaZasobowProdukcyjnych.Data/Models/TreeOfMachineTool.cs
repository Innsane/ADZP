using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data.Models
{
    public partial class TreeOfMachineTool
    {
        public string NodeId { get; set; }
        public string KeyId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public int? IconId { get; set; }
        public string TableId { get; set; }
        public string PictureId { get; set; }
    }
}
