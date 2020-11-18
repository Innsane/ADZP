using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data.Models
{
    public partial class WiertlaDat
    {
        public string Oznaczenie { get; set; }
        public string Fk { get; set; }
        public string Idc { get; set; }
        public double? D { get; set; }
        public double? L1 { get; set; }
        public double? L2 { get; set; }
        public string Chwyt { get; set; }
        public string Kod { get; set; }
        public decimal? Cena { get; set; }
        public string Obraz { get; set; }
        public string Rys2D { get; set; }
        public string Mod3D { get; set; }
    }
}
