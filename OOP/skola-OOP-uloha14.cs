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
            Console.WriteLine(ReadString(ValidacePrijmeni));
            Console.ReadLine();
        }
        public delegate bool Validace(string s);
        public static string ReadString(Validace v)
        {
            while (true)
            {
                string prijmeni = Console.ReadLine();
                if (v(prijmeni))
                {
                    return prijmeni;
                }
            }
        }
        public static bool ValidacePrijmeni(string s)
        {
            if (s.Length>2||s.Length<1)
            {
                return false;
            }
            else
            {
                int i;
                bool isInt = int.TryParse(s, out i);
                return isInt;
            }
        }

    }
}
