using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Integral(Sin,1,3));
            Console.WriteLine(Integral(TwoTimesCos, 1, 3));
            Console.WriteLine(Integral(Power, 1, 3));
            Console.WriteLine(Integral(Cubed, 1, 3));
            Console.WriteLine(Integral(Smth, 1, 3));
            Console.ReadLine();
        }
        public delegate double F(double x);
        public static double Integral(F fce, double a, double b) {
            double d = (b - a)/1000;
            double area = 0;
            for (double x = a; x <= b; x+=d)
            {
                area += Math.Abs(fce(x+d/2))*d;
            }
            return area;
        }
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }
        public static double TwoTimesCos(double x)
        {
            return 2*Math.Cos(x);
        }
        public static double Power(double x)
        {
            return Math.Pow(x,2);
        }
        public static double Cubed(double x)
        {
            return Math.Pow(x, 3);
        }
        public static double Smth(double x)
        {
            return 3/(x+1);
        }
    }
}
