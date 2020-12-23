using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Parameter
    {
        public Parameter(DaneWalka walek, Lathe lathe, QTurningTool tool)
        {
            Walek = walek;
            Lathe = lathe;
            Tool = tool;
        }

        public DaneWalka Walek { get; set; }
        public Lathe Lathe { get; set; }
        public QTurningTool Tool { get; set; }
        public string Obrobka { get; set; }
        public double AP { get; set; } //glebokosc skrawania [mm]
        public double F { get; set; } //posuw [mm/obr]
        public double VC { get; set; } //predkosc skrawania [m/min]
        public double N { get; set; } //predkosc obrotowa napedu obrabiarki [obr/min]
        public double Q { get; set; } //wydajnosc objetosciowa [cm3/min]
        public double P { get; set; } //moc potrzebna do obrobki [kW]
        public double TG { get; set; } //czas maszynowy obrobki [min]
        public double T { get; set; } //okres trwalosci [min]
    }
}
