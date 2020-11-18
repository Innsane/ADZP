using System;
using System.Collections.Generic;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data.Models
{
    public partial class WiertlaTab
    {
        public string Oznaczenie { get; set; }
        public string Producent { get; set; }
        public string OznPn { get; set; }
        public string Typ { get; set; }
        public string Technologia { get; set; }
        public string NormaPn { get; set; }
        public string NormaEn { get; set; }
        public string Material { get; set; }
        public double? KatR { get; set; }
        public string Opis { get; set; }
        public string Kod { get; set; }
        public string Obraz { get; set; }
        public string Rys2D { get; set; }
        public string Mod3D { get; set; }
    }
}
