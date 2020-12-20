using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Walek
    {
        private readonly MfgResourcesContext db;

        public Walek(MfgResourcesContext db)
        {
            this.db = db;

        }
        //wpisane
        public double Dlugosc { get; set; }
        public double Srednica { get; set; }
        public string Matrial { get; set; }
        public double GestoscMaterialu = 7.85;

        public int Stopnie { get; set; }

        public List<double> DlugoscStopnia { get; set; }
        public List<double> SrednicaStopnia { get; set; }
        public List<int> KlasaTolerancji { get; set; }

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
        public List<double> QSR { get; set; } //naddatki srednica
        public List<double> QDL { get; set; } //naddatki dlugosc
        public List<double> DFN { get; set; } //srednica przed wykonwcza
        public List<double> DMT { get; set; } //srednica przed ksztaltujaca
        public List<double> DRG { get; set; } //srednica przed zgrubna
        public List<double> APMAX { get; set; } //maksymalna dlugosc skrawania

        //z tabeli w SQL SERVER
        public double QFN { get; set; }
        public double QMT { get; set; }
        public double QRG { get; set; }
        public double QLMT { get; set; }
        public double QLRG { get; set; }
        public double SRC { get; set; }
        public double DLC { get; set; }

        //smuklosc
        public void Smuklosc()
        {
            this.S = Dlugosc / Srednica;
        }

        //zmiana objetosci walu
        public void ObjetoscWalu()
        {
            var suma = 0.000000;
            for (int i = 0; i < Stopnie; i++)
            {
                var x = (3.14 * DlugoscStopnia[i] * SrednicaStopnia[i] * SrednicaStopnia[i]);
                suma += (x / 4);
            }
            VPO = suma;
        }

        public void ObjetoscPolfabrykatu()
        {
            VPF = (3.14 * Dlugosc * Srednica*Srednica)/4;
        }

        public void ZmianaObjetosci()
        {
            var x = (VPF - VPO) / VPF;
            x *= 100;
            O = x;
        }

        public void MasaWalu()
        {
            MPO = GestoscMaterialu* VPO;
        }

        public void MasaPolfabrykatu()
        {
            MPF = GestoscMaterialu * VPF;
        }

        public void MasaWiorow()
        {
            MW = MPF - MPO;
        }
        
        public void TolerancjaPolfabrykatu()
        {
            var tolerance = from l in db.RolledBarsTols
                        where l.Dmax <= Srednica && l.Dmin >= Srednica
                        select l.TolA1;
            var x = tolerance.ToList();

            TPF =  (float)x[0] * 2 * 1000;
        }

        public void TolerancjaStopni()
        {
            var index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                var query = from l in db.Tolerances
                            where l.Dmax <= srednica && l.Dmin > srednica && l.Itc == KlasaTolerancji[index]
                            select l.Tol;

                TPO.Add((float)query.ToList()[0]);
                index++;
            }
        }

        public void WzrostDokladnosci()
        {
            foreach (var tolerance in TPO)
            {
                KO.Add(TPF / tolerance);
            }
        }

        public void Operacje()
        {
            foreach (var wskaznik in KO)
            {
                if(wskaznik <= 10)
                {
                    IZ.Add(1);
                }
                else if(wskaznik > 10 && wskaznik <=50)
                            {
                    IZ.Add(2);
                }
                else
                {
                    IZ.Add(3);
                }
            }
        }

        public void SredniaSrednica()
        {
            var suma = 0.0;
            for(int i = 0; i<Stopnie;i++)
            {
                suma += DlugoscStopnia[i] * SrednicaStopnia[i];
            }
            DSR = suma / Dlugosc;
        }

        public void NaddatkiSrednica()
        {
            var RG = from l in db.TurnAllowCentrRgs
                          where l.Lmax <= Dlugosc && l.Lmin > Dlugosc &&
                                l.Dmax <= DSR && l.Dmin > DSR
                          select l.Qnom;

            var MT = from l in db.TurnAllowCentrMts
                          where l.Lmax <= Dlugosc && l.Lmin > Dlugosc &&
                                l.Dmax <= DSR && l.Dmin > DSR
                          select l.Qnom;

            var FN = from l in db.TurnAllowCentrFns
                          where l.Lmax <= Dlugosc && l.Lmin > Dlugosc &&
                                l.Dmax <= DSR && l.Dmin > DSR
                          select l.Qnom;

            QFN = (double)FN.ToList()[0];
            QMT = (double)MT.ToList()[0];
            QRG = (double)RG.ToList()[0];
        }

        public void NaddatkiDlugosc()
        {
            var RG = from l in db.TurnAllowChuckRgs
                     where l.Lmax <= Dlugosc && l.Lmin > Dlugosc &&
                           l.Dmax <= DSR && l.Dmin > DSR
                     select l.Qnom;

            var MT = from l in db.TurnAllowChuckMts
                     where l.Lmax <= Dlugosc && l.Lmin > Dlugosc &&
                           l.Dmax <= DSR && l.Dmin > DSR
                     select l.Qnom;
            QLMT = (double)MT.ToList()[0];
            QLRG = (double)RG.ToList()[0];
        }

        public void SrednicaPolfabrykatu()
        {
            var Q = QSR[0] + QSR[1] + QSR[2];
            SRPF = Srednica + Q;
        }

        public void DlugoscPolfabrykatu()
        {
            var Q = QDL[0] + QDL[1];
            DLPF = Dlugosc + (Q * 2);
            DLC = DLPF;
        }

        public void SrednicePrzedObrobka()
        {
            var index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                if (IZ[index] <= 2)
                {
                    DFN[index] = srednica;
                }
                else
                {
                    DFN[index] = SrednicaStopnia[index] + QFN;
                }
                index++;
            }

            index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                if (IZ[index] == 1)
                {
                    DMT[index] = srednica;
                }
                else
                {
                    DMT[index] = DFN[index] + QMT;
                }
                index++;
            }

            index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                DRG[index] = DMT[index] + QRG;
                index++;
            }
        }

        public void WymiaryPolfabrykatu()
        {
            var srednica = from l in db.RolledBarsDiams
                           where l.D > SRPF
                           orderby l.D ascending
                           select l.D;
            SRC = srednica.ToList()[0];
        }

        public void MaxSkrawanie()
        {
            var index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                APMAX[index] = SRC - srednica / 2;
                index++;
            }
        }
    }
}
