using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMfgResources resources;

        public ListModel(IConfiguration config, IMfgResources resources)
        {
            this.config = config;
            this.resources = resources;
        }

        public IEnumerable<Lathe> Lathes { get; set; }


        public void OnGet()
        {
            Lathes = resources.GetAll();
        }
    }
}