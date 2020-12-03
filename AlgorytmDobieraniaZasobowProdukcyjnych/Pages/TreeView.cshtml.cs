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
        private readonly TreeViewViewModel viewModel;
        public readonly DataTableViewModel dataTable;

        public TreeViewModel(IConfiguration config, IMfgResources resources, TreeViewViewModel viewModel, DataTableViewModel dataTable)
        {
            this.config = config;
            this.resources = resources;
            this.viewModel = viewModel;
            this.dataTable = dataTable;
        }

        [BindProperty]
        public string Picked { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
        public PropertyInfo[] Infos { get; set; }
        public List<TableData> Datas { get; set; }


        public void OnGet()
        {
            DataToJson(viewModel.TreeOfMachineTools);
            DataToTable(dataTable.Lathes);
            Resources = resources.GetAllResources();
        }

        

        public IActionResult OnPost()
        {
            Picked = Picked.Trim();
            if (Picked == "CT")
            {
                DataToJson(viewModel.TreeOfCuttingTools);
                DataToTable(dataTable.WiertlaTabs);
            }
            if (Picked == "EQ")
            {
                DataToJson(viewModel.TreeOfEquipments);
                DataToTable(dataTable.Opsklos);
            }
            if (Picked == "MT")
            {
                DataToJson(viewModel.TreeOfMachineTools);
                DataToTable(dataTable.Lathes);
            }
            
            Resources = resources.GetAllResources();
            return Page();
        }

        public void DataToTable(IEnumerable<TableData> tools)
        {
            var list = tools.ToList();
            Datas = new List<TableData>();
            Datas = list;
            Type type = list[0].GetType();
            Infos = type.GetProperties();
        }

        private void DataToJson<T>(IEnumerable<T> tree) where T: TreeOf 
        {
            var TreeModelList = new List<JsTreeModel>();
            foreach (var item in tree)
            {
                TreeModelList.Add(new JsTreeModel(item));
            }

            ViewData["json"] = JsonSerializer.Serialize(TreeModelList);
        }
    }
}