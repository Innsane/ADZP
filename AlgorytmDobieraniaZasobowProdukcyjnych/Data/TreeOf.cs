using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public abstract class TreeOf
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
