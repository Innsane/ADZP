using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
        [BindProperty]
        public string TableName { get; set; }
        public string TableNameNow { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
        public DataTablePartialModel DataTablePartial { get; set; }
        public ImagePath ImagePath { get; set; }


        public void OnGet()
        {
            DataTablePartial = new DataTablePartialModel();
            TableName = "WiertlaTabs";
            TableName = TableName.ToLower();
            Picked = "CT";
            TreeDataToJson(viewModel.TreeOfCuttingTools);
            DataToTable(FindDataToTable());
            Resources = resources.GetAllResources();
        }

        
        public IActionResult OnPost()
        {
            Picked = Picked.Trim();
            if (Picked == "CT")
            {
                TreeDataToJson(viewModel.TreeOfCuttingTools);
                DataToTable(dataTable.wiertlatabs);
            }
            if (Picked == "EQ")
            {
                TreeDataToJson(viewModel.TreeOfEquipments);
                DataToTable(dataTable.opsklos);
            }
            if (Picked == "MT")
            {
                TreeDataToJson(viewModel.TreeOfMachineTools);
                DataToTable(dataTable.lathes);
            }
            Resources = resources.GetAllResources();
            return Page();
        }

        public PartialViewResult OnGetDataTable(string tableName)
        {
            TableName = tableName + "s";
            TableName = TableName.ToLower();
            DataToTable(FindDataToTable());
            return new PartialViewResult
            {
                ViewName = "_DataTable",
                ViewData = new ViewDataDictionary<DataTablePartialModel>(ViewData, DataTablePartial)
            };
        }

        public PartialViewResult OnGetModalImage(string path)
        {
            if (path == "" || path == null)
            {
                ImagePath = new ImagePath
                {
                    Path = "",
                    Path2D = ""
                };
                return Partial("_ModalImage", ImagePath);
            }

            var pathList = new List<string>();
            var listOfFiles = Directory.GetFiles("C:/Users/Kuba/source/CSharp/AlgorytmDobieraniaZasobowProdukcyjnych/AlgorytmDobieraniaZasobowProdukcyjnych/wwwroot/images",
                                                                "*", SearchOption.AllDirectories).ToList();
            path = path.Remove(path.Length - 4, 4);
            foreach (string file in listOfFiles)
            {
                if (file.Contains(path))
                {
                    pathList.Add(file);
                }
            }

            if(pathList[0].Length > pathList[1].Length)
            {
                pathList.Reverse();
            }
            var pathToImage = "/images/" + Path.GetFileName(pathList[0]);
            var pathToImage2D = "/images/" + Path.GetFileName(pathList[1]);

            ImagePath = new ImagePath
            {
                Path = pathToImage,
                Path2D = pathToImage2D
            };
            return Partial("_ModalImage", ImagePath);
        }

        public void DataToTable(IEnumerable<TableData> tools)
        {
            DataTablePartial = new DataTablePartialModel();
            var list = tools.ToList();
            DataTablePartial.Datas = new List<TableData>();
            DataTablePartial.Datas = list;
            Type type = list[0].GetType();
            DataTablePartial.Infos = type.GetProperties();
        }

        public IEnumerable<TableData> FindDataToTable()
        {
            
            if (TableName.Length > 0)
            {
                return DataTableViewModel.GetPropValue(dataTable, TableName);
            }
            else return DataTableViewModel.GetPropValue(dataTable, TableNameNow);
        }

        private void TreeDataToJson<T>(IEnumerable<T> tree) where T: TreeOf 
        {
            var TreeModelList = new List<JsTreeModel>();
            foreach (var item in tree)
            {
                TreeModelList.Add(new JsTreeModel(item));
            }

            ViewData["json"] = System.Text.Json.JsonSerializer.Serialize(TreeModelList);
        }
    }
}