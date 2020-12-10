using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Threading.Tasks;
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
                DataToTable(dataTable.wiertlatabs);
            }
            if (Picked == "EQ")
            {
                DataToJson(viewModel.TreeOfEquipments);
                DataToTable(dataTable.opsklos);
            }
            if (Picked == "MT")
            {
                DataToJson(viewModel.TreeOfMachineTools);
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

        public JsonResult OnGetWriteToConsole(string text)
        {
            var data = text;
            return new JsonResult(data);
        }

        public JsonResult OnGetDataToTable(string name)
        {
            TableName = "lathes";
            DataToTable(FindDataToTable());

            var infosList = DataTablePartial.Infos;
            var data = DataTablePartial.Datas;

            var columns = new List<Column>();
            foreach (var property in infosList)
            {
                string camelCaseName;
                if (property.Name.Length > 1)
                {
                    camelCaseName = char.ToLower(property.Name[0]) + property.Name.Substring(1);
                }
                else
                {
                    camelCaseName = property.Name.ToLower();
                }
                columns.Add(new Column { title = property.Name, data = camelCaseName });
            }

            var jsonToTable = new JsonToDataTable<Lathe> { data = dataTable.lathes.ToList(), columns = columns };
            return new JsonResult(jsonToTable);
        }

        //public JsonResult OnGetDataToTableGeneric(string name)
        //{
        //    TableName = (name + "s").ToLower();
        //    DataToTable(FindDataToTable());

        //    var infosList = DataTablePartial.Infos;
        //    var data = DataTablePartial.Datas;

        //    var columns = new List<Column>();
        //    foreach (var property in infosList)
        //    {
        //        string camelCaseName;
        //        if (property.Name.Length > 1)
        //        {
        //            camelCaseName = char.ToLower(property.Name[0]) + property.Name.Substring(1);
        //        }
        //        else
        //        {
        //            camelCaseName = property.Name.ToLower();
        //        }
        //        columns.Add(new Column { title = property.Name, data = camelCaseName });
        //    }

        //    dataTable.GetDataByName(name);

        //    var jsonToTable = new JsonToDataTable<ITableData> { data = data.Add(dataTable.lathes), columns = columns };
        //    return new JsonResult(jsonToTable);
        //}
            //switch (name)
            //{
            //    case "wiertlatab":
            //        list1 = DataTablePartial.Datas;
            //        break;
            //    case "lathes":
            //        jsonResult = new JsonResult(dataTable.lathes.ToList());
            //        break;
            //    case "wiertladat":
            //        jsonResult = new JsonResult(dataTable.wiertladats.ToList());
            //        break;
            //    case "opskl":
            //        jsonResult = new JsonResult(dataTable.opsklos.ToList());
            //        break;
            //    case "opsklo":
            //        jsonResult = new JsonResult(dataTable.opsklss.ToList());
            //        break;
            //}

            //var list = new List<TableData>();
            //JsonResult jsonResult = new JsonResult(dataTable.wiertlatabs.ToList());
            //switch (name)
            //{
            //    case "wiertlatab":
            //        jsonResult = new JsonResult(dataTable.wiertlatabs.ToList());
            //        break;
            //    case "lathes":
            //        jsonResult = new JsonResult(dataTable.lathes.ToList());
            //        break;
            //    case "wiertladat":
            //        jsonResult = new JsonResult(dataTable.wiertladats.ToList());
            //        break;
            //    case "opskl":
            //        jsonResult = new JsonResult(dataTable.opsklos.ToList());
            //        break;
            //    case "opsklo":
            //        jsonResult = new JsonResult(dataTable.opsklss.ToList());
            //        break;
            //}

            //making data for DataTable columns property
            //Type type = dataTable.lathes.ToList()[0].GetType();
            //var infosList = type.GetProperties();

            //var list = new List<Column>();
            //foreach (var property in infosList)
            //{
            //    string camelCaseName;
            //    if (property.Name.Length > 1)
            //    {
            //        camelCaseName = char.ToLower(property.Name[0]) + property.Name.Substring(1);
            //    }
            //    else
            //    {
            //        camelCaseName = property.Name.ToLower();
            //    }
            //    list.Add(new Column { title = property.Name, data = camelCaseName });
            //}

            //switch (name)
            //{
            //    case "wiertladat":
            //        jsonToTable = new JsonToDataTable<WiertlaDat> { data = dataTable.wiertladats.ToList(), columns = list };
            //        break;
            //    case "lathes":
            //        jsonResult = new JsonResult(dataTable.lathes.ToList());
            //        break;
            //    case "wiertladat":
            //        jsonResult = new JsonResult(dataTable.wiertladats.ToList());
            //        break;
            //    case "opskl":
            //        jsonResult = new JsonResult(dataTable.opsklos.ToList());
            //        break;
            //    case "opsklo":
            //        jsonResult = new JsonResult(dataTable.opsklss.ToList());
            //        break;
            //}


            //w zakladkach firefox create list of variable type

        //}

        public JsonResult ColumnNames(string name)
        {
            Type type = dataTable.lathes.ToList()[0].GetType();
            var infosList = type.GetProperties();

            var list = new List<Column>();
            foreach (var property in infosList)
            {
                list.Add(new Column { title = property.Name, data = property.Name });
            }
            

            return new JsonResult(list);
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

            ViewData["json"] = System.Text.Json.JsonSerializer.Serialize(TreeModelList);
        }
    }
}