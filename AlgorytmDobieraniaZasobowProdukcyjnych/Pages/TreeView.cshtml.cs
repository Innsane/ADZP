using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class TreeViewModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMfgResources resources;

        public TreeViewModel(IConfiguration config, IMfgResources resources, TreeViewViewModel viewModel)
        {
            this.config = config;
            this.resources = resources;
            ViewModel = viewModel;
        }

        [BindProperty]
        public string Picked { get; set; }
        public TreeViewViewModel ViewModel { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
        public PropertyInfo[] Infos { get; set; }

        public void OnGet()
        {
            DataToJson(ViewModel.TreeOfCuttingTools);
            Resources = resources.GetAllResources();
        }

        public IActionResult OnPost()
        {
            Picked = Picked.Trim();
            if(Picked == "CT") DataToJson(ViewModel.TreeOfCuttingTools);
            if (Picked == "EQ") DataToJson(ViewModel.TreeOfEquipments);
            if (Picked == "MT") DataToJson(ViewModel.TreeOfMachineTools);
            Resources = resources.GetAllResources();
            return Page();
        }

        private void DataToJson<T>(IEnumerable<T> tree) where T: TreeOf 
        {
            List<T> list = tree.ToList();

            Type type = list[0].GetType();
            Infos = type.GetProperties();

            var TreeModelList = new List<JsTreeModel>();
            foreach (var item in list)
            {
                TreeModelList.Add(new JsTreeModel(item));
            }

            ViewData["json"] = JsonSerializer.Serialize(TreeModelList);
        }
    }
}