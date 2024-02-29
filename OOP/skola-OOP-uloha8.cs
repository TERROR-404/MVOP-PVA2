using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PorizeniBytu byt1 = new PorizeniBytu(50000,10000000,5000000,20000,10000);
            NakupAkcii akcie1 = new NakupAkcii(300000,40000,60000,36895,2000,10000);
            Console.WriteLine(byt1.CompareTo(akcie1));
            Console.ReadLine();
        }
    }

    abstract class Investice
    {
        public abstract decimal Vynosy();
        public abstract decimal Naklady();
        public decimal Navratnost()
        {
            decimal roi = Math.Round(100* Vynosy() / Naklady());
            return roi;
        }
    }
    class PorizeniBytu : Investice,IComparable<NakupAkcii>
    {
        public PorizeniBytu(decimal mesicniNajem, decimal zhodnoceniBytu, decimal porizovaciCena, decimal opravy, decimal pojisteni)
        {
            MesicniNajem = mesicniNajem;
            ZhodnoceniBytu = zhodnoceniBytu;
            PorizovaciCena = porizovaciCena;
            Opravy = opravy;
            Pojisteni = pojisteni;
        }

        private decimal MesicniNajem { get; set; }
        private decimal ZhodnoceniBytu { get; set; }
        private decimal PorizovaciCena { get; set; }
        private decimal Opravy { get; set; }
        private decimal Pojisteni { get; set; }
        public override decimal Vynosy()
        {
            return 12 * MesicniNajem + ZhodnoceniBytu /100;
        }
        public override decimal Naklady()
        {
            return PorizovaciCena + Opravy + Pojisteni;
        }

        public int CompareTo(NakupAkcii obj)
        {
            return this.Navratnost().CompareTo(obj.Navratnost());
        }
    }
    class NakupAkcii : Investice, IComparable<PorizeniBytu>
    {
        public NakupAkcii(decimal prodejniCena, decimal porizovaciCena, decimal dividenda, decimal pocetAkcii, decimal cenaAkcie, decimal poplatky)
        {
            ProdejniCena = prodejniCena;
            PorizovaciCena = porizovaciCena;
            Dividenda = dividenda;
            PocetAkcii = pocetAkcii;
            CenaAkcie = cenaAkcie;
            Poplatky = poplatky;
        }

        private decimal ProdejniCena { get; set; }
        private decimal PorizovaciCena { get; set; }
        private decimal Dividenda { get; set; }
        private decimal PocetAkcii { get; set; }
        private decimal CenaAkcie { get; set; }
        private decimal Poplatky { get; set; }
        public override decimal Vynosy()
        {
            return ProdejniCena - PorizovaciCena + Dividenda;
        }
        public override  decimal Naklady()
        {
            return PocetAkcii * CenaAkcie * Poplatky;
        }

        public int CompareTo(PorizeniBytu obj)
        {
            return this.Navratnost().CompareTo(obj.Navratnost());
        }
    }
}
