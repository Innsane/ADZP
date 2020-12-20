using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public interface IWalek
    {
        public void SetWalek(DaneWalka dane);
        public void Calculate();
    }
}
