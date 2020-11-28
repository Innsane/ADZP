using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class DataTableModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMfgResources resources;

        public DataTableModel(IConfiguration config, IMfgResources resources)
        {
            this.config = config;
            this.resources = resources;
        }

        public IEnumerable<Lathe> Lathes { get; set; }
        public PropertyInfo[] Infos { get; set; }


        public void OnGet()
        {
            Lathes = resources.GetAllLathes();

            List<Lathe> lathesList = Lathes.ToList();
            Type type = lathesList[0].GetType();
            Infos = type.GetProperties();
        }
    }
}