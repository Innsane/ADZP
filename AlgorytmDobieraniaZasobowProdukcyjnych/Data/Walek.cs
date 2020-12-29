using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Walek : DaneWalka, IWalek
    {
        private readonly MfgResourcesContext db;


        public Walek(MfgResourcesContext db)
        {
            this.db = db;
        }

        public DaneWalkaDoTabel GetDataToTable()
        {
            var list = new List<object>
            {
                Srednica,
                SRC,
                Dlugosc,
                DLC,
                Material,
                GestoscMaterialu,
                Stopnie,
                S,
                O,
                MPO,
                MPF,
                MW,
                DSR,
                SRPF,
                DLPF,
                QRG,
                QMT,
                QFN,
                QLRG,
                QLMT
            };

            var atname = new List<string>
            {
                nameof(Srednica),
                nameof(SRC),
                nameof(Dlugosc),
                nameof(DLC),
                nameof(Material),
                nameof(GestoscMaterialu),
                nameof(Stopnie),
                nameof(S),
                nameof(O),
                nameof(MPO),
                nameof(MPF),
                nameof(MW),
                nameof(DSR),
                nameof(SRPF),
                nameof(DLPF),
                nameof(QRG),
                nameof(QMT),
                nameof(QFN),
                nameof(QLRG),
                nameof(QLMT)
            };

            var stopienWalu = new List<int>();
            for (int i = 0; i < Stopnie; i++)
            {
                stopienWalu.Add(i + 1);
            }
            var listList = new List<object[]>
            {
                stopienWalu.Cast<object>().ToArray(),
                DlugoscStopnia.Cast<object>().ToArray(),
                SrednicaStopnia.Cast<object>().ToArray(),
                KlasaTolerancji.Cast<object>().ToArray(),
                TPO.Cast<object>().ToArray(),
                KO.Cast<object>().ToArray(),
                IZ.Cast<object>().ToArray(),
                DFN.Cast<object>().ToArray(),
                DMT.Cast<object>().ToArray(),
                DRG.Cast<object>().ToArray(),
                APMAX.Cast<object>().ToArray()
            };

            var listname = new List<string>
            {
                "Stopien walu",
                nameof(DlugoscStopnia),
                nameof(SrednicaStopnia),
                nameof(KlasaTolerancji),
                nameof(TPO),
                nameof(KO),
                nameof(IZ),
                nameof(DFN),
                nameof(DMT),
                nameof(DRG),
                nameof(APMAX)
            };

            var naddatki = new List<List<object>>
            {
                new List<object>
                {
                    "Wykańczający",
                    "Kształtujący",
                    "Zgrubny"
                },
                new List<object>
                {
                    QFND,
                    QMTD,
                    QRGD
                },
                new List<object>
                {
                    QFN,
                    QMT,
                    QRG
                }
            };

            var naddatkiNames = new List<string>
            {
                "Rodzaj naddatku",
                "Naddatki dobrane",
                "Naddatki do obliczeń"
            };

            return new DaneWalkaDoTabel
            {
                AtributeValue = list,
                ListValue = listList,
                AtributeName = atname,
                ListName = listname,
                NaddatkiValues = naddatki,
                NaddatkiNames = naddatkiNames,
                Image = this.Image
            };
        }

        public void SetWalek(DaneWalka dane)
        {
            Srednica = dane.Srednica;
            Dlugosc = dane.Dlugosc;
            Material = dane.Material;
            Stopnie = dane.Stopnie;
            DlugoscStopnia = dane.DlugoscStopnia;
            SrednicaStopnia = dane.SrednicaStopnia;
            KlasaTolerancji = dane.KlasaTolerancji;
            TPO = new List<double>();
            KO = new List<double>();
            IZ = new List<int>();
            DFN = new List<double>();
            DMT = new List<double>();
            DRG = new List<double>();
            APMAX = new List<double>();
        }

        public DaneWalka GetData()
        {
            return new DaneWalka
            {
                Srednica = this.Srednica,
                Dlugosc = this.Dlugosc,
                Material = this.Material,
                Stopnie = this.Stopnie,
                DlugoscStopnia = this.DlugoscStopnia,
                SrednicaStopnia = this.SrednicaStopnia,
                KlasaTolerancji = this.KlasaTolerancji,
                TPO = this.TPO,
                KO = this.KO,
                IZ = this.IZ,
                DFN = this.DFN,
                DMT = this.DMT,
                DRG = this.DRG,
                APMAX = this.APMAX,
                APRGREAL = this.APRGREAL,
                QLMT = this.QLMT,
                SRPF = this.SRPF,
                SRC = this.SRC
            };
        }

        public void GetWalekByName(string name)
        {
            var query = from l in db.Walkis
                        where l.Nazwa == name
                        orderby l.N ascending
                        select l;

            var list = query.ToList();
            SetWalek(list);
        }

        public void SetWalek(List<Walki> dane)
        {
            Image = dane.First().Nazwa;
            Material = dane.First().Material;
            DlugoscStopnia = new List<double>();
            SrednicaStopnia = new List<double>();
            KlasaTolerancji = new List<int>();
            foreach (var stopien in dane)
            {
                if (stopien.Di > Srednica)
                {
                    Srednica = stopien.Di;
                }
                Dlugosc += stopien.Li;
                DlugoscStopnia.Add(stopien.Li);
                SrednicaStopnia.Add(stopien.Di);
                KlasaTolerancji.Add(stopien.Ti);
            }
            Stopnie = dane.Count;
            TPO = new List<double>();
            KO = new List<double>();
            IZ = new List<int>();
            DFN = new List<double>();
            DMT = new List<double>();
            DRG = new List<double>();
            APMAX = new List<double>();
        }

        public List<string> GetWalkiName()
        {
            var query = from l in db.Walkis
                        select l.Nazwa;
            var list = query.Distinct().ToList();
            return list;
        }

        public List<string> GetWalkiMaterial()
        {
            var query = from l in db.Materials
                        select l.MatPn;
            var list = query.ToList();
            return list;
        }

        public void Calculate()
        {
            Smuklosc();
            ObjetoscWalu();
            ObjetoscPolfabrykatu();
            ZmianaObjetosci();
            MasaWalu();
            MasaPolfabrykatu();
            MasaWiorow();
            TolerancjaPolfabrykatu();
            TolerancjaStopni();
            WzrostDokladnosci();
            Operacje();
            SredniaSrednica();
            NaddatkiSrednica();
            NaddatkiDlugosc();
            SrednicaPolfabrykatu();
            DlugoscPolfabrykatu();
            SrednicePrzedObrobka();
            WymiaryPolfabrykatu();
            MaxSkrawanie();
            PrawdziwaGlebokoscSkrawania();
        }

        ////obliczone
        //public double S { get; set; } //smuklosc
        //public double VPO { get; set; } //objetosc walu
        //public double VPF { get; set; } //objetosc polfabrykatu
        //public double O { get; set; } //zmiana objetosci
        //public double MPO { get; set; } //masa PO
        //public double MPF { get; set; } //masa PF
        //public double MW { get; set; } //masa wiorow
        //public double TPF { get; set; } //tolerancja polfabrykatu
        //public double DSR { get; set; } //srednia srednica
        //public double SRPF { get; set; } //srednica calkowita polfabrykatu
        //public double DLPF { get; set; } //dlugosc calkowita polfabrykatu


        //public List<double> TPO { get; set; } //tolerancje stopni
        //public List<double> KO { get; set; }  //wskaznik wzrostu dokaldnosci stopni
        //public List<int> IZ { get; set; }  //liczba operacji (1 - tylko zgrubna 2 - zgrubna ksztaltujaca 3 - zgruba ksztaltujaca wykanczajaca)
        //public List<double> DFN { get; set; } //srednica przed wykonwcza
        //public List<double> DMT { get; set; } //srednica przed ksztaltujaca
        //public List<double> DRG { get; set; } //srednica przed zgrubna
        //public List<double> APMAX { get; set; } //maksymalna dlugosc skrawania

        ////z tabeli w SQL SERVER
        //public double QFN { get; set; }
        //public double QMT { get; set; }
        //public double QRG { get; set; }
        //public double QLMT { get; set; }
        //public double QLRG { get; set; }
        //public double SRC { get; set; }
        //public double DLC { get; set; }

        //smuklosc
        private void Smuklosc()
        {
            S = Dlugosc / Srednica;
        }

        //zmiana objetosci walu
        private void ObjetoscWalu()
        {
            var suma = 0.000000;
            for (int i = 0; i < Stopnie; i++)
            {
                var x = (3.14 * DlugoscStopnia[i] / 100 * SrednicaStopnia[i] / 100 * SrednicaStopnia[i] / 100);
                suma += (x / 4);
            }
            VPO = suma;
        }

        private void ObjetoscPolfabrykatu()
        {
            VPF = (3.14 * (Dlugosc / 100) * (Srednica / 100) * (Srednica / 100)) / 4;
        }

        private void ZmianaObjetosci()
        {
            var x = (VPF - VPO) / VPF;
            x *= 100;
            O = x;
        }

        private void MasaWalu()
        {
            MPO = GestoscMaterialu * VPO;
        }

        private void MasaPolfabrykatu()
        {
            MPF = GestoscMaterialu * VPF;
        }

        private void MasaWiorow()
        {
            MW = MPF - MPO;
        }

        private void TolerancjaPolfabrykatu()
        {
            var tolerance = from l in db.RolledBarsTols
                            where l.Dmax > Srednica && l.Dmin <= Srednica
                            select l.TolA1;
            var x = tolerance.ToList();

            TPF = (float)x[0] * 1000;
        }

        private void TolerancjaStopni()
        {

            var index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                var query = from l in db.Tolerances
                            where l.Dmax >= srednica && l.Dmin < srednica && l.Itc == KlasaTolerancji[index]
                            select l.Tol;

                TPO.Add((float)query.ToList()[0] * 1000);
                index++;
            }
        }

        private void WzrostDokladnosci()
        {
            foreach (var tolerance in TPO)
            {
                KO.Add(TPF / tolerance);
            }
        }

        private void Operacje()
        {
            foreach (var wskaznik in KO)
            {
                if (wskaznik < 10)
                {
                    IZ.Add(1);
                }
                else if (wskaznik >= 10 && wskaznik <= 50)
                {
                    IZ.Add(2);
                }
                else
                {
                    IZ.Add(3);
                }
            }
        }

        private void SredniaSrednica()
        {
            var suma = 0.0;
            for (int i = 0; i < Stopnie; i++)
            {
                suma += DlugoscStopnia[i] * SrednicaStopnia[i];
            }
            DSR = suma / Dlugosc;
        }

        private void NaddatkiSrednica()
        {
            var RG = from l in db.TurnAllowCentrRgs
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR
                     select l.Qnom;

            var MT = from l in db.TurnAllowCentrMts
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR
                     select l.Qnom;

            var FN = from l in db.TurnAllowCentrFns
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR
                     select l.Qnom;

            var oldDlugosc = Dlugosc;
            Dlugosc /= 2;
            var any = FN.Any();
            if (!(FN.Any() || MT.Any() || RG.Any()))
            {
                RG = from l in db.TurnAllowCentrRgs
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR
                     select l.Qnom;

                MT = from l in db.TurnAllowCentrMts
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR
                     select l.Qnom;

                FN = from l in db.TurnAllowCentrFns
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR
                     select l.Qnom;
            }
            Dlugosc = oldDlugosc;
            QFN = Math.Round((double)FN.ToList().First(), 1);
            QMT = Math.Round((double)MT.ToList().First(), 1);
            QRG = Math.Round((double)RG.ToList().First(), 1);

            QFND = (double)FN.ToList().First();
            QMTD = (double)MT.ToList().First();
            QRGD = (double)RG.ToList().First();
        }

        private void NaddatkiDlugosc()
        {
            var RG = from l in db.FaceAllows
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR && l.Range == "RG"
                     select l.Qnom;

            var MT = from l in db.FaceAllows
                     where l.Lmax > Dlugosc && l.Lmin <= Dlugosc &&
                           l.Dmax > DSR && l.Dmin <= DSR && l.Range == "MT"
                     select l.Qnom;

            if (MT.ToList().Count == 0)
            {
                QLMT = 1;
                QLRG = 1;
            }
            else
            {
                QLMT = (double)MT.ToList().First();
                QLRG = (double)RG.ToList().First();
            }

        }

        private void SrednicaPolfabrykatu()
        {
            var Q = QFN + QMT + QRG;
            SRPF = Srednica + Q;
        }

        private void DlugoscPolfabrykatu()
        {
            var Q = QLMT + QLRG;
            DLPF = Dlugosc + (Q * 2);
            DLC = DLPF;
        }

        private void SrednicePrzedObrobka()
        {
            var index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                if (IZ[index] <= 2)
                {
                    DFN.Add(srednica);
                }
                else
                {
                    DFN.Add(SrednicaStopnia[index] + QFN);
                }
                index++;
            }

            index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                if (IZ[index] == 1)
                {
                    DMT.Add(srednica);
                }
                else
                {
                    DMT.Add(DFN[index] + QMT);
                }
                index++;
            }

            index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                DRG.Add(DMT[index] + QRG);
                index++;
            }
        }

        private void WymiaryPolfabrykatu()
        {
            var srednica = from l in db.RolledBarsDiams
                           where l.D > SRPF
                           orderby l.D ascending
                           select l.D;
            SRC = srednica.ToList()[0];
        }

        private void MaxSkrawanie()
        {
            var index = 0;
            foreach (var srednica in SrednicaStopnia)
            {
                APMAX.Add((SRC - srednica) / 2);
                index++;
            }
        }

        private void PrawdziwaGlebokoscSkrawania()
        {
            var aps = new List<double>();
            var dmt = new List<double>(DMT);
            dmt = dmt.OrderByDescending(d => d).ToList();
            for (int i = 0; i < dmt.Count-1; i++)
            {
                aps.Add((dmt[i] - dmt[i + 1])/2);
            }
            while(aps.Max() > 10.29)

            {
                for (int i = 0; i < aps.Count; i++)
                {
                    aps[i] = aps[i] / 2;
                }
            }
            APRGREAL = aps;
        }
    }
}
