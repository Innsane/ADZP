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
    public class TreeViewModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMfgResources resources;

        public TreeViewModel(IConfiguration config, IMfgResources resources)
        {
            this.config = config;
            this.resources = resources;
        }

        public IEnumerable<TreeOfCuttingTool> CuttingTools { get; set; }
        public PropertyInfo[] Infos { get; set; }

        public void OnGet()
        {
            CuttingTools = resources.GetAllCuttingTools();

            List<TreeOfCuttingTool> cuttingToolsList = CuttingTools.ToList();
            Type type = cuttingToolsList[0].GetType();
            Infos = type.GetProperties();

            var TreeModelList = new List<JsTreeModel>();
            foreach (var item in cuttingToolsList)
            {
                TreeModelList.Add(new JsTreeModel(item));
            }
            ViewData["json"] = JsonSerializer.Serialize(TreeModelList);
        }
    }
}