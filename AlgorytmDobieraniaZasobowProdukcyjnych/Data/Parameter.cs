using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class Parameter: IParameter
    {
        private readonly MfgResourcesContext db;

        public Parameter(MfgResourcesContext db)
        {
            this.db = db;
        }

        internal void SetParameter(DaneWalka walek, Lathe lathe, QTurningTool tool, string cmc)
        {
            Walek = walek;
            Lathe = lathe;
            Tool = tool;
            Obrobka = "RG";
            CmcMaterial = cmc;
        }

        public Parameter Calculate(DaneWalka walek, Lathe lathe, QTurningTool tool, string cmc)
        {
            Walek = walek;
            Lathe = lathe;
            Tool = tool;
            Obrobka = "RG";
            CmcMaterial = cmc;

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

            return this;
        }

        public DaneWalka Walek { get; set; }
        public Lathe Lathe { get; set; }
        public QTurningTool Tool { get; set; }
        public string Obrobka { get; set; }
        public string CmcMaterial { get; private set; } //wartosc cmc materialu PO

        public double AP { get; set; } //glebokosc skrawania [mm]
        public double F { get; set; } //posuw [mm/obr]
        public double VC { get; set; } //predkosc skrawania [m/min]
        public double N { get; set; } //predkosc obrotowa napedu obrabiarki [obr/min]
        public double Q { get; set; } //wydajnosc objetosciowa [cm3/min]
        public double TG { get; set; } //czas maszynowy obrobki [min]
        public double T { get; set; } //okres trwalosci [min]
        public double FC { get; private set; } //glowna sila skrawania [N]
        public double KC { get; private set; } //opor wlasciwy skrawania
        public double HM { get; private set; } //grubosc wiora
        public double PC { get; private set; } //moc skrawania netto [kW]
        public double PE { get; private set; } //dostepna moc [kW]

        

        public void GlebokoscSkrawania()
        {
            var toolAp = Convert.ToDouble(Tool.ApMax);
            var walekAp = Walek.APMAX.Max();
            while (!(walekAp <= toolAp))
            {
                walekAp /= 2;
            }
            AP = walekAp;
        }

        public void Posuw()
        {
            F = Convert.ToDouble(Tool.FnZ);
        }

        public void PredkoscSkrawania()
        {
            var f1 = Tool.FnMin;
            var vc1 = Tool.VcMin;
            var f2 = Tool.FnMax;
            var vc2 = Tool.VcMax;

            var a = (vc2 - vc1) / (f2 - f1);
            var b = vc1 - ((vc2 - vc1) * f1) / (f2 - f1);
            VC = Convert.ToDouble(a) * Convert.ToDouble(F) + Convert.ToDouble(b);
        }

        public void PredkoscObrotowa()
        {
            N = (1000 * VC) / (3.14 * Walek.SrednicaStopnia.Max());
            if(N>Lathe.NMax)
            {
                VC = (3.14 * Convert.ToDouble(Lathe.NMax) * Walek.SRC) / 1000;
                N = Convert.ToDouble(Lathe.NMax);
            }
        }

        public void WydajnoscObjetosciowa()
        {
            Q = VC * AP * F;
        }

        public void GruboscWiora()
        {
            var kr = Convert.ToDouble(Tool.Kr);
            var sin = (kr * 3.14) / 180;
            HM = F * (Math.Sin(sin));
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
            KC = kc1 * (Math.Pow(HM, minusmc)) * (1 - (gamma / 100));
        }

        public void GlownaSilaSkrawania()
        {
            FC = KC * AP * F;
        }

        public void DostepnaMoc()
        {
            PE = Convert.ToDouble(Lathe.P) * 0.75;
        }

        public void PotrzebnaMoc()
        {
            PC = FC * VC / 60000;
            if(PC>PE)
            {

            }
        }

        public void CzasMaszynowy()
        {
            var l = Walek.DlugoscStopnia.Last();
            TG = l / (N * F);
        }
    }
}
