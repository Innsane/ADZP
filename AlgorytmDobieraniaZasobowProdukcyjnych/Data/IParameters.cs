using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public interface IParameters
    {
        public void SetParameterList(DaneWalka walek, Lathe lathe, string cmc, List<QTurningTool> turnings);
        public void Calculate();
        List<Parameter> GetParametersList();
    }
}
