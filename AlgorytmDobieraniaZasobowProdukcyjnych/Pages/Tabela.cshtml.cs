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
        public Walek walek { set; get; }
        public void OnGet(Walek walek)
        {
        }
    }
}