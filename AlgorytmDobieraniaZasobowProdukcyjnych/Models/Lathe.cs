using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class Lathe
    {
        [Key]
        public string Oznaczenie { get; set; }

        public string Rodzaj { get; set; }
        public string Typ { get; set; }
        public string Kod { get; set; }
        public string Opis { get; set; }
        public string Producent { get; set; }
        public int? L { get; set; }
        public int? B { get; set; }
        public int? H { get; set; }
        public int? M { get; set; }
        public double? P { get; set; }
        public int? NMin { get; set; }
        public int? NMax { get; set; }
        public string Gniazdo { get; set; }
        public string Wrzeciono { get; set; }
        public string Obraz { get; set; }
        public string Rys2D { get; set; }
        public string Mod3D { get; set; }
    }
}
