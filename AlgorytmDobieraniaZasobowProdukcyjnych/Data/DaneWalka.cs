using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class DaneWalka
    {
        //wpisane
        public string Image { get; set; }
        public double Dlugosc { get; set; }
        public double Srednica { get; set; }
        public string MaterialId { get; set; }
        public string MaterialPn { get; set; }
        public double GestoscMaterialu = 7.85;
        public int IloscPrzejsc { get; set; }

        public int Stopnie { get; set; }

        public List<double> DlugoscStopnia { get; set; }
        public List<double> SrednicaStopnia { get; set; }
        public List<int> KlasaTolerancji { get; set; }
        public List<double> ChropowatoscRa { get; set; }
        public List<double> ChropowatoscRt { get; set; }
        public List<QTurningTool> ToolsRG { get; set; }
        public List<QTurningTool> ToolsMT { get; set; }
        public List<QTurningTool> ToolsFN { get; set; }

        //obliczone
        public double S { get; set; } //smuklosc
        public double VPO { get; set; } //objetosc walu
        public double VPF { get; set; } //objetosc polfabrykatu
        public double O { get; set; } //zmiana objetosci
        public double MPO { get; set; } //masa PO
        public double MPF { get; set; } //masa PF
        public double MW { get; set; } //masa wiorow
        public double TPF { get; set; } //tolerancja polfabrykatu
        public double DSR { get; set; } //srednia srednica
        public double SRPF { get; set; } //srednica calkowita polfabrykatu
        public double DLPF { get; set; } //dlugosc calkowita polfabrykatu


        public List<double> TPO { get; set; } //tolerancje stopni
        public List<double> KO { get; set; }  //wskaznik wzrostu dokaldnosci stopni
        public List<int> IZ { get; set; }  //liczba operacji (1 - tylko zgrubna 2 - zgrubna ksztaltujaca 3 - zgruba ksztaltujaca wykanczajaca)
        public List<double> DFN { get; set; } //srednica przed wykonwcza
        public List<double> DMT { get; set; } //srednica przed ksztaltujaca
        public List<double> DRG { get; set; } //srednica przed zgrubna
        public List<double> APMAX { get; set; } //ilosc materialu do zebrania
        public List<double> APRGREAL { get; set; } //glebokosci skrawania dla zgrubnej

        //z tabeli w SQL SERVER
        public double QFN { get; set; }
        public double QMT { get; set; }
        public double QRG { get; set; }
        public double QFND { get; set; }
        public double QMTD { get; set; }
        public double QRGD { get; set; }
        public double QLMT { get; set; }
        public double QLRG { get; set; }
        public double SRC { get; set; }
        public double DLC { get; set; }
    }
}
