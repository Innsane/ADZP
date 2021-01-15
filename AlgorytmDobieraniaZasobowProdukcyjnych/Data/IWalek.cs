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
        public void SetWalek(List<QPocl> dane, int iloscPrzejsc);
        public void Calculate(int iloscPrzejsc);
        public DaneWalkaDoTabel GetDataToTable();
        public DaneWalka GetData();
        public void GetWalekByName(string name, int iloscPrzejsc);
        public List<string> GetWalkiName();
        public List<Material> GetWalkiMaterial();
    }
}
