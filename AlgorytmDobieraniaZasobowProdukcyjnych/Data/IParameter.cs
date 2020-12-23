using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public interface IParameter
    {
        public Parameter Calculate(DaneWalka walek, Lathe lathe, QTurningTool tool,string cmc);
    }
}
