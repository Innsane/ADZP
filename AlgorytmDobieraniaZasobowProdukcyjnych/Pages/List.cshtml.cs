﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMfgResources resources;

        public ListModel(IConfiguration config, IMfgResources resources)
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

            CreateGenecicList(lathesList);
        }

        public void CreateGenecicList<T>(List<T> list)
        {
            Type d1 = typeof(List<>);
            Type[] typeArgs = { typeof(T) };
            Type makeme = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(makeme);
            List<T> itsMe = o as List<T>;
            itsMe.Add(list[1]);
            
        }
    }
}