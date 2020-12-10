using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class JsonToDataTable<T>
    {
        public List<Column> columns { set; get; }
        public List<T> data { set; get; }
    }
}
