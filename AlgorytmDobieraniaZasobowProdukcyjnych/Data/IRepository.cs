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
        public List<QTurningTool> GetTurningTools(IEnumerable<TurnToolTab> tools, Lathe lathe);
    }
}
