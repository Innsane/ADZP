using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class AlgorithmModel : PageModel
    {
        private readonly IConfiguration config;

        public AlgorithmModel(IConfiguration config, IWalek walek)
        {
            this.config = config;
            Walek = walek;
        }

        public IWalek Walek { get; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var stopnie = Convert.ToInt32(Request.Form["N"]);
            var dane = new DaneWalka()
            {
                Srednica = Convert.ToDouble(Request.Form["srC"]),
                Dlugosc = Convert.ToDouble(Request.Form["dlC"]),
                Stopnie = Convert.ToInt32(Request.Form["N"]),
                DlugoscStopnia = new List<double>(),
                SrednicaStopnia = new List<double>(),
                KlasaTolerancji = new List<int>()
            };
            for (int i = 0; i < stopnie; i++)
            {
                var index = i.ToString();
                dane.DlugoscStopnia.Add(Convert.ToDouble(Request.Form["stopienDl" + index]));
                dane.SrednicaStopnia.Add(Convert.ToDouble(Request.Form["stopienSr" + index]));
                dane.KlasaTolerancji.Add(Convert.ToInt32(Request.Form["stopienT" + index]));
            }

            Walek.SetWalek(dane);
            Walek.Calculate();

            return RedirectToPage("Tabela", Walek);
        }
    }
}