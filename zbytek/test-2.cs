using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto1 = new Auto("Citroen", "1FTFX1E57JKE37092", 5000);
            Auto auto2 = new Auto("Citroen", "1FTFX1E57JKE37092", 3000);
            Auto auto3 = new Auto("Citroen", "1FTFX1E57JKE37092", 4000);
            Auto auto4 = new Auto("Citroen", "1FTFX1E57JKE37092", 2000);
            Auto auto5 = new Auto("Citroen", "1FTFX1E57JKE37092", 0);
            Auto auto6 = new Auto("Citroen", "1FTFX1E57JKE37092", 20000);
            Auto auto7 = new Auto("Citroen", "1FTFX1E57JKE37092", 1000);
            Auto[] auta = new Auto[] {auto1,auto2,auto3,auto4,auto5,auto6,auto7 };
            for (int i = 0; i < auta.Length - 1; i++)
            {
                for (int j = 0; j < auta.Length - 1 - i; j++)
                {
                    if (auta[j].CompareTo(auta[j + 1]) > 0)
                    {
                        (auta[j], auta[j+1]) = (auta[j + 1], auta[j]);
                    }
                }
            }
            foreach (var item in auta)
            {
                Console.WriteLine(item.Displacement);
            }
            Console.ReadLine();
        }
    }
    public interface IGeo
    {
        double[] zemSirkaADelka { get; set; }
        string misto { get; set; }
    }
    public class Auto: IGeo, IComparable<Auto>
    {
        double[] IGeo.zemSirkaADelka { get; set; }
        string IGeo.misto { get; set; }
        public string Znacka { get; set; }
        public string VIN { get; set; }
        public int Displacement { get; set; }
        public Auto(string znacka, string vIN, int displacement)
        {
            Znacka = znacka;
            if (vIN.Length!=17)
            {
                Exception e = new Exception("Znacka nema 17 znaku!");
                throw e;
            }
            VIN = vIN;
            Displacement = displacement;
        }

        public int CompareTo(Auto a)
        {
            return this.Displacement.CompareTo(a.Displacement);
        }
    }
}
