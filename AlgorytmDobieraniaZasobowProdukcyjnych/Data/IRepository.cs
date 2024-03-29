﻿using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public interface IRepository
    {
        public IEnumerable<Lathe> GetObrabiarki();
        public IEnumerable<Lathe> GetObrabiarki(string name);
        public IEnumerable<TurnToolTab> GetTools(Lathe lathe, string zabieg);
        public List<List<QTurningTool>> GetTurningTools(IEnumerable<TurnToolTab> tools, Lathe lathe, DaneWalka walek, List<string> grades, int stopien, int stopien1);
        public string GetCmcMaterial(DaneWalka walek);
        public List<string> GetGrades(string cmc);
        public void Add(QPocl qpocl);
        public void Add(Feature feature);
        public void Add(Part part);
        public int Commit();
        int CountParts();
        
    }
}
