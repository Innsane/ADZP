using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class AlgorithmModel : PageModel
    {
        private readonly IRepository repository;
        private readonly IParameters parameters;

        public AlgorithmModel(IWalek walek, IParameter parameter, IRepository repository, DaneWalkaDoTabel dane, DaneWalka daneWalka, IParameters parameters)
        {
            Walek = walek;
            Parameter = parameter;
            this.repository = repository;
            DataToTable = dane;
            DaneWalka = daneWalka;
            this.parameters = parameters;
        }

        public IWalek Walek { get; }
        public IParameter Parameter { get; }
        public DaneWalkaDoTabel DataToTable { get; }
        public DaneWalka DaneWalka { get; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Material { get; set; }
        [BindProperty]
        public string Lathe { get; set; }
        public List<string> Names { get; set; }
        public List<SelectListItem> NamesOptions { get; set; }
        public List<SelectListItem> MaterialOptions { get; set; }
        public List<SelectListItem> LathesOptions { get; set; }

        public void OnGet()
        {
            Names = Walek.GetWalkiName();
            NamesOptions = new List<SelectListItem>();
            foreach (var name in Names)
            {
                NamesOptions.Add(new SelectListItem { Value = name, Text = name });
            }

            var materials = Walek.GetWalkiMaterial();
            MaterialOptions = new List<SelectListItem>();
            foreach (var material in materials)
            {
                MaterialOptions.Add(new SelectListItem { Value = material, Text = material });
            }

            var lathes = repository.GetObrabiarki().ToList();
            LathesOptions = new List<SelectListItem>();
            foreach (var lathe in lathes)
            {
                LathesOptions.Add(new SelectListItem { Value = lathe.Oznaczenie, Text = lathe.Oznaczenie });
            }
        }

        public IActionResult OnPost()
        {
            DaneWalka dane = DataFromRequest();

            Walek.SetWalek(dane);
            Walek.Calculate();
            DataToTable.SetDataToTable(Walek.GetDataToTable());

            return RedirectToPage("Tabela");
        }

        private DaneWalka DataFromRequest()
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

            return dane;
        }

        public IActionResult OnPostWalekSql()
        {
            Walek.GetWalekByName(Name);
            Walek.Calculate();

            var walek = Walek.GetData();
            var lathe = repository.GetObrabiarki(Lathe).First();
            var tools = repository.GetTools(lathe, "RG");
            var cmc = repository.GetCmcMaterial(walek);
            var grades = repository.GetGrades(cmc);
            var turnings = repository.GetTurningTools(tools, lathe, walek, grades);

            parameters.SetParameterList(walek, lathe, cmc, turnings);
            parameters.Calculate();
            //var listOfParameters = new List<Parameter>();
            //for (int i = 0; i < turnings.Count; i++)
            //{
            //    var calculated = new Parameter();
            //    calculated.Calculate(walek, lathe, turnings[i], cmc);
            //    listOfParameters.Add(calculated);
            //}
            //foreach (var turn in turnings)
            //{
            //    listOfParameters.Add(Parameter.Calculate(walek, lathe, turn, cmc));
            //}
            //notes when comeback:
            //add display of parameters to site
            //check needed power if it extends power of lathe remove from list
            //display only tools that can be used to this process
            //SortListOfParameter(listOfParameters);
            DataToTable.SetDataToTable(Walek.GetDataToTable());
            DataToTable.SetParameterToTable(parameters.GetParametersList());
            DataToTable.SetImages(lathe, parameters.GetParametersList(), walek);

            return RedirectToPage("Tabela");
        }

        //private void SortListOfParameter(List<Parameter> listOfParameters)
        //{
        //    for (int i = 0; i < listOfParameters.Count; i++)
        //    {
        //        if(listOfParameters[i].PE <= listOfParameters[i].PC)
        //        {
        //            listOfParameters.RemoveAt(i);
        //        }
        //    }
        //}
    }
}