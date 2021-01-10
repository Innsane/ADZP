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
        public QPocl[] NowyWalek { get; set; }

        public int Stopnie { get; set; }
        public List<QPocl> Part { get; set; }
        public List<SelectListItem> MaterialOptions { get; set; }

        public void OnGet()
        {
            NowyWalek = new QPocl[20];
            for (int i = 0; i < NowyWalek.Length; i++)
            {
                NowyWalek[i] = new QPocl();
            }
            var materials = Walek.GetWalkiMaterial();
            MaterialOptions = new List<SelectListItem>();
            foreach (var material in materials)
            {
                MaterialOptions.Add(new SelectListItem { Value = material, Text = material });
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                SetQpocl(out List<QPocl> ListWalek, out int numberOfPart);
                Part part = SetPart(numberOfPart);

                foreach (var qpocl in ListWalek)
                {
                    repository.Add(qpocl);
                    repository.Add(part);
                }
                TempData["Message"] = "Dodano nowy wałek!";
            }
            repository.Commit();
            return RedirectToPage("./Algorithm");
        }

        private static Part SetPart(int numberOfPart)
        {
            return new Part
            {
                Idpart = "Part00" + numberOfPart,
                PartName = "Wałek " + numberOfPart,
                Idmat = "Wałek " + numberOfPart,
            };
        }

        private void SetQpocl(out List<QPocl> ListWalek, out int numberOfPart)
        {
            ListWalek = new List<QPocl>();
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
                ListWalek[i].FtrNo = "#" + i + 1;
                ListWalek[i].FtrType = "POCL";
                ListWalek[i].Nazwa = "Powierzchnia Cylindryczna";
                ListWalek[i].Radius = 0;
                if (i < 9)
                {
                    ListWalek[i].Idftr = "P00" + numberOfPart + "F00" + i + 1;
                }
                else
                {
                    ListWalek[i].Idftr = "P00" + numberOfPart + "F0" + i + 1;
                }
                ListWalek[i].Idpart = "Part00" + numberOfPart;
            }
        }
    }
}