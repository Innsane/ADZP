using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class DataTablePartialModel
    {
        public PropertyInfo[] Infos { get; set; }
        public List<TableData> Datas { get; set; }
    }
}
