using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class QCechy
    {
        public string Idftr { get; set; }
        public string Idpart { get; set; }
        public double? Cecha { get; set; }
        public string Type { get; set; }
    }
}
