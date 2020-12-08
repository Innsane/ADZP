using System;
using System.Collections.Generic;
using System.IO;
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
            Picked = "CT";
            DataToJson(viewModel.TreeOfCuttingTools);
            DataToTable(FindDataToTable());
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

        public PartialViewResult OnGetDataTablePartial(string tableName)
        {
            TableName = "WiertlaTabs";
            DataToTable(FindDataToTable());
            return new PartialViewResult
            {
                ViewName = "_DataTable",
                ViewData = new ViewDataDictionary<DataTablePartialModel>(ViewData, DataTablePartial)
            };
        }

        public PartialViewResult OnGetModalImage(string path)
        {
            var pathList = new List<string>();
            var listOfFiles = Directory.GetFiles("C:/Users/Kuba/source/CSharp/AlgorytmDobieraniaZasobowProdukcyjnych/AlgorytmDobieraniaZasobowProdukcyjnych/wwwroot/images",
                                                                "*", SearchOption.AllDirectories).ToList();
            path = path.Remove(path.Length - 4, 4);
            foreach (string file in listOfFiles)
            {
                if(file.Contains(path))
                {
                    pathList.Add(file);
                }
            }

            if(pathList[0].Length > pathList[1].Length)
            {
                pathList.Reverse();
            }
            var pathToImage = "/images/" + path + ".jpg";
            var pathToImage2D = "/images/" + Path.GetFileName(pathList[1]);
            
            ImagePath = new ImagePath
            {
                Path = pathToImage,
                Path2D = pathToImage2D
            };
            return Partial("_ModalImage", ImagePath);
        }

        public JsonResult OnGetWriteToConsole(string text)
        {
            var data = text;
            return new JsonResult(data);
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