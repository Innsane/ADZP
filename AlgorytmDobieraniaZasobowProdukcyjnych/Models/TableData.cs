using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public abstract class TableData
    {
        public string Kod { get; set; }
        public string Obraz { get; set; }
        public string Rys2D { get; set; }
        public string Mod3D { get; set; }
    }
}
