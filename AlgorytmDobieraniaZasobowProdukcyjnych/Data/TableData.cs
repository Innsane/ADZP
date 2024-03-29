﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public abstract class TableData : ITableData
    {
        public string Kod { get; set; }
        public string Obraz { get; set; }
        public string Rys2D { get; set; }
        public string Mod3D { get; set; }

        public string GetImageName()
        {
            return Obraz;
        }
    }
}
