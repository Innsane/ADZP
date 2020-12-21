using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Walki
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Material { get; set; }
        public int N { get; set; }
        public double Di { get; set; }
        public double Li { get; set; }
        public int Ti { get; set; }
    }
}
