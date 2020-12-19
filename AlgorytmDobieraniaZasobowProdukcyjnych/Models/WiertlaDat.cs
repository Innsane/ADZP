using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class WiertlaDat: TableData
    {
        public string Oznaczenie { get; set; }
        public string Fk { get; set; }
        public string Idc { get; set; }
        public double? D { get; set; }
        public double? L1 { get; set; }
        public double? L2 { get; set; }
        public string Chwyt { get; set; }
        public decimal? Cena { get; set; }
    }
}
