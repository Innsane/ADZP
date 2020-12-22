using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
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
        public void SetWalek(List<Walki> dane);
        public void Calculate();
        public DaneWalkaDoTabel GetData();
        public void GetWalekByName(string name);
        public List<string> GetWalkiName();
        public List<string> GetWalkiMaterial();
    }
}
