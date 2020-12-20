#nullable disable

using AlgorytmDobieraniaZasobowProdukcyjnych;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class Accuracy
    {
        public string Ida { get; set; }
        public string AccName { get; set; }
        public string AccDescr { get; set; }
        public short? Itmin { get; set; }
        public short? Itmax { get; set; }
        public double? RaMin { get; set; }
        public double? RaMax { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
