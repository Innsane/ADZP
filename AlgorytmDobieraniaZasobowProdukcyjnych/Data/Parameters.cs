using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Parameters
    {
        public List<Parameter> ParaList { get; set; }
        public List<QTurningTool> Turnings { get; set; }
        public Lathe Lathe { get; set; }
        public DaneWalka Walek { get; set; }

        public void CalculateParameters()
        {
 
        }
    }
}
