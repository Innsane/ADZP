using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class RaRtTable
    {
        public List<double> Ra { get; set; }
        public List<double> Rt { get; set; }

        public RaRtTable()
        {
            Ra = new List<double>{
                0.1,
                0.2,
                0.3,
                0.35,
                0.4,
                0.44,
                0.49,
                0.53,
                0.58,
                0.63,
                0.71,
                0.8,
                0.9,
                0.99,
                1.2,
                1.4,
                1.6,
                1.8,
                2.0,
                3.2,
                4.4,
                5.8,
                6.3,
                7.4,
                8.8,
                10.7,
                12.5,
                14.0,
                40.0,
                80.0,
            };
            Rt = new List<double>{
                0.5,
                1,
                1.6,
                1.8,
                2,
                2.2,
                2.4,
                2.6,
                2.8,
                3.0,
                3.5,
                4.0,
                4.5,
                5.0,
                6.0,
                7.0,
                8.0,
                9.0,
                10.0,
                15.0,
                20.0,
                25.0,
                27.0,
                30.0,
                35.0,
                40.0,
                45.0,
                50.0,
                136.0,
                270.0,
            };
        }
    }
}
