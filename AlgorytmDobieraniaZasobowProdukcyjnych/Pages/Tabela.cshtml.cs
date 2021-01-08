using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class TabelaModel : PageModel
    {
        private IWalek Walek;

        public TabelaModel(IWalek walek, DaneWalkaDoTabel dane)
        {
            Walek = walek;
            Dane = dane;
        }

        public DaneWalkaDoTabel Data { get; set; }
        public DaneWalkaDoTabel Dane { get; }
        public string Image { get; set; }
        public string Path { get; set; }
        public int Index = 0;

        public void OnGet()
        {
            Data = Dane;
            if(Data is null)
            {
                RedirectToPage("Algorithm");
            }
        }
    }
}