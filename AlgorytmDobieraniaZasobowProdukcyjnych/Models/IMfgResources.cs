using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public interface IMfgResources
    {
        IEnumerable<Lathe> GetAll();
    }
}
