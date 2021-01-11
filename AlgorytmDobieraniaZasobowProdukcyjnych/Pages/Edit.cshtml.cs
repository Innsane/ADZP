using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Data;
using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRepository repository;

        public EditModel(IWalek walek, IRepository repository)
        {
            Walek = walek;
            this.repository = repository;
        }

        public IWalek Walek { get; }


        [BindProperty]
        public string Material { get; set; }
        [BindProperty]
        public Feature[] NowyWalek { get; set; }
        [TempData]
        public string Message { get; set; }

        public int Stopnie { get; set; }
        public List<SelectListItem> MaterialOptions { get; set; }

        public void OnGet()
        {
            NowyWalek = new Feature[20];
            Material = "";
            for (int i = 0; i < NowyWalek.Length; i++)
            {
                NowyWalek[i] = new Feature();
            }
            var materials = Walek.GetWalkiMaterial();
            MaterialOptions = new List<SelectListItem>();
            foreach (var material in materials)
            {
                MaterialOptions.Add(new SelectListItem { Value = material.Idmat, Text = material.MatPn });
            }
        }

        public PartialViewResult OnGetStopnie(string iloscStopni)
        {
            Stopnie = Convert.ToInt32(iloscStopni);

            return new PartialViewResult
            {
                ViewName = "_AddWalek",
                ViewData = new ViewDataDictionary<EditModel>(ViewData, this)
            };
        }

        public IActionResult OnPost()
        {
            if(Material == "0")
            {
                TempData["Message"] = "Wybierz materiał dla wałka!";
                return RedirectToAction("OnGet");
            }
            else if (!ModelState.IsValid )
            {
                TempData["Message"] = "Wystąpił błąd!";
                return RedirectToAction("OnGet");
            }
            else
            {
                var material = Material;
                SetFeature(out List<Feature> ListWalek, out int numberOfPart);
                Part part = SetPart(numberOfPart, material);

                foreach (var feature in ListWalek)
                {
                    repository.Add(feature);
                    repository.Add(part);
                }
                TempData["Message"] = "Dodano nowy wałek!";
            }
            repository.Commit();
            return RedirectToPage("./Algorithm");
        }

        private static Part SetPart(int numberOfPart, string material)
        {
            return new Part
            {
                Idpart = "Part00" + numberOfPart,
                PartName = "Wałek " + numberOfPart,
                Idmat = material,
            };
        }

        private void SetFeature(out List<Feature> ListWalek, out int numberOfPart)
        {
            ListWalek = new List<Feature>();
            for (int i = 0; i < NowyWalek.Length; i++)
            {
                if (!(NowyWalek[i] is null))
                {
                    ListWalek.Add(NowyWalek[i]);
                }
                else break;
            }
            numberOfPart = 0;
            for (int i = 0; i < ListWalek.Count; i++)
            {
                numberOfPart = repository.CountParts() + 1;
                if (i < 9)
                {
                    ListWalek[i].Idftr = "P00" + numberOfPart + "F00" + i + 1;
                }
                else
                {
                    ListWalek[i].Idftr = "P00" + numberOfPart + "F0" + i + 1;
                }
                ListWalek[i].Idpart = "Part00" + numberOfPart;
                ListWalek[i].FtrNo = "#" + i + 1;
                ListWalek[i].FtrType = "POCL";
                ListWalek[i].Radius = 0;
                ListWalek[i].Depth = 0;
                ListWalek[i].Width = 0;
                ListWalek[i].Angle = 0;
            }
        }
    }
}