﻿using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Parameter : IParameter
    {
        private readonly MfgResourcesContext db;

        public Parameter(MfgResourcesContext db)
        {
            this.db = db;
        }

        public Parameter()
        {
        }

        public DaneWalka Walek { get; set; }
        public Lathe Lathe { get; set; }
        public QTurningTool Tool { get; set; }
        public string Obrobka { get; set; }
        public string CmcMaterial { get; private set; } //wartosc cmc materialu PO
        private int Stopien { get; set; }
        

        public List<double> AP = new List<double>();
        public List<int> Przejsc = new List<int>();
        public List<double> F = new List<double>();
        public List<double> VC = new List<double>();
        public List<double> N = new List<double>();
        public List<double> Q = new List<double>();
        public List<double> TG = new List<double>();
        public List<double> T = new List<double>();
        public List<double> FC = new List<double>();
        public List<double> KC = new List<double>();
        public List<double> HM = new List<double>();
        public List<double> PC = new List<double>();
        public List<double> PE = new List<double>();

        //public double AP { get; set; } //glebokosc skrawania [mm]
        //public double F { get; set; } //posuw [mm/obr]
        //public double VC { get; set; } //predkosc skrawania [m/min]
        //public double N { get; set; } //predkosc obrotowa napedu obrabiarki [obr/min]
        //public double Q { get; set; } //wydajnosc objetosciowa [cm3/min]
        //public double TG { get; set; } //czas maszynowy obrobki [min]
        //public double T { get; set; } //okres trwalosci [min]
        //public double FC { get; private set; } //glowna sila skrawania [N]
        //public double KC { get; private set; } //opor wlasciwy skrawania
        //public double HM { get; private set; } //grubosc wiora
        //public double PC { get; private set; } //moc skrawania netto [kW]
        //public double PE { get; private set; } //dostepna moc [kW]

        internal void SetParameter(DaneWalka walek, Lathe lathe, QTurningTool tool, string cmc)
        {
            Walek = walek;
            Lathe = lathe;
            Tool = tool;
            Obrobka = "RG";
            CmcMaterial = cmc;
        }

        public void Calculate(DaneWalka walek, Lathe lathe, QTurningTool tool, string cmc)
        {
            Walek = walek;
            Lathe = lathe;
            Tool = tool;
            Obrobka = "RG";
            CmcMaterial = cmc;
            Stopien = 0;

            for (int i = 0; i < Walek.Stopnie; i++)
            {
                RodzajObrobki();
                GlebokoscSkrawania();
                Posuw();
                PredkoscSkrawania();
                PredkoscObrotowa();
                WydajnoscObjetosciowa();
                GruboscWiora();
                OporWlasciwy();
                GlownaSilaSkrawania();
                DostepnaMoc();
                PotrzebnaMoc();
                CzasMaszynowy();
                Stopien++;
            }
        }

        public void Calculate()
        {
            Stopien = 0;
            for (int i = 0; i < Walek.Stopnie; i++)
            {
                GlebokoscSkrawania();
                Posuw();
                PredkoscObrotowa();
                WydajnoscObjetosciowa();
                GruboscWiora();
                OporWlasciwy();
                GlownaSilaSkrawania();
                DostepnaMoc();
                PotrzebnaMoc();
                CzasMaszynowy();
                Stopien++;
            }
            AP.RemoveRange(0, Walek.Stopnie);
            F.RemoveRange(0, Walek.Stopnie);
            N.RemoveRange(0, Walek.Stopnie);
            Q.RemoveRange(0, Walek.Stopnie);
            TG.RemoveRange(0, Walek.Stopnie);
            //T.RemoveRange(0, Walek.Stopnie);
            FC.RemoveRange(0, Walek.Stopnie);
            KC.RemoveRange(0, Walek.Stopnie);
            HM.RemoveRange(0, Walek.Stopnie);
            PC.RemoveRange(0, Walek.Stopnie);
            PE.RemoveRange(0, Walek.Stopnie);
        }

        public void RodzajObrobki()
        {
            Obrobka = Tool.Geometry.Substring(Tool.Geometry.Length - 2, 2);
        }

        public void GlebokoscSkrawania()
        {
            var toolAp = Convert.ToDouble(Tool.MaxAp);
            var walekAp = Walek.APMAX[Stopien];
            var index = 1;

            if (Obrobka == "PF")
            {
                AP.Add((Walek.DFN[Stopien] - Walek.SrednicaStopnia[Stopien]) / 2);
                Przejsc.Add(1);
            }
            else if (Obrobka == "PM")
            {
                AP.Add((Walek.DMT[Stopien] - Walek.DFN[Stopien]) / 2);
                Przejsc.Add(1);
            }
            else if (Obrobka == "PR")
            {
                if (Walek.DMT[Stopien] == Walek.DMT.Max())
                {
                    if ((Walek.SRC - Walek.DMT[Stopien]) / 2 < Tool.MaxAp)
                    {
                        AP.Add((Walek.SRC - Walek.DMT[Stopien]) / 2);
                        Przejsc.Add(index);
                    }
                    else
                    {
                        index = 1;
                        do
                        {
                            index++;
                        } while ((Walek.SRC - Walek.DMT[Stopien]) / 2 / index < Tool.MaxAp);
                        AP.Add((Walek.SRC - Walek.DMT[Stopien]) / 2 / index);
                        Przejsc.Add(index);
                    }
                }
                else
                {
                    var srP = Walek.DMT.FindAll(t => t > Walek.DMT[Stopien]).Min();
                    if ((srP - Walek.DMT[Stopien]) / 2 < Tool.MaxAp)
                    {
                        AP.Add((srP - Walek.DMT[Stopien]) / 2);
                        Przejsc.Add(index);
                    }
                    else
                    {
                        index = 1;
                        do
                        {
                            index++;
                        } while (((srP - Walek.DMT[Stopien]) / 2) / index < Tool.MaxAp);
                        AP.Add(((srP - Walek.DMT[Stopien]) / 2) / index);
                        Przejsc.Add(index);
                    }
                }

            }
            else AP.Add(0);
        }

        public void Posuw()
        {
            F.Add(Convert.ToDouble(Tool.FnZ));
        }

        public void PredkoscSkrawania()
        {
            var f1 = Tool.FnMin;
            var vc1 = Tool.VcMin;
            var f2 = Tool.FnMax;
            var vc2 = Tool.VcMax;

            var a = (vc2 - vc1) / (f2 - f1);
            var b = vc1 - ((vc2 - vc1) * f1) / (f2 - f1);
            VC.Add(Convert.ToDouble(a) * Convert.ToDouble(F[Stopien]) + Convert.ToDouble(b));
        }

        public void PredkoscObrotowa()
        {
            N.Add((1000 * VC[Stopien]) / (3.14 * Walek.SrednicaStopnia[Stopien]));
            if (N[Stopien] > Lathe.NMax)
            {
                VC.Add((3.14 * Convert.ToDouble(Lathe.NMax) * Walek.SRC) / 1000);
                N.Add(Convert.ToDouble(Lathe.NMax));
            }
        }

        public void WydajnoscObjetosciowa()
        {
            Q.Add(VC[Stopien] * AP[Stopien] * F[Stopien]);
        }

        public void GruboscWiora()
        {
            var kr = Convert.ToDouble(Tool.Kr);
            var sin = (kr * 3.14) / 180;
            HM.Add(F[Stopien] * (Math.Sin(sin)));
        }

        public void OporWlasciwy()
        {
            var query = from m in db.Materials
                        where m.Cmc == CmcMaterial
                        select m;

            var query1 = from t in db.TurnToolTabs
                         where t.ShankCode.StartsWith(Tool.Holder.Substring(0, 4))
                         select t.Gamma;

            var kc1 = Convert.ToDouble(query.ToList().First().Kc11);
            var mc = Convert.ToDouble(query.ToList().First().Mc);
            var gamma = Convert.ToDouble(query1.ToList().First());

            var minusmc = 0 - mc;
            KC.Add(kc1 * (Math.Pow(HM[Stopien], minusmc)) * (1 - (gamma / 100)));
        }

        public void GlownaSilaSkrawania()
        {
            FC.Add(KC[Stopien] * AP[Stopien] * F[Stopien]);
        }

        public void DostepnaMoc()
        {
            PE.Add(Convert.ToDouble(Lathe.P) * 1);
        }

        public void PotrzebnaMoc()
        {
            PC.Add(FC[Stopien] * VC[Stopien] / 60000);
        }

        public void CzasMaszynowy()
        {
            var l = Walek.DlugoscStopnia[Stopien];
            TG.Add(l / (N[Stopien] * F[Stopien]));
        }
    }
}
