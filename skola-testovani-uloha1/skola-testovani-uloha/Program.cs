using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skola_testovani_uloha
{
    public class Quadratic
    {
        static void Main(string[] args)
        {
        }
        public double Discriminant(int a, int b, int c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }
        public double[] Result(int a, int b, int c)
        {
            double[] result = new double[2];
            double d = Discriminant(a, b, c);
            result[0] = (-b + Math.Sqrt(d)) / 2 * a;
            result[1] = (-b - Math.Sqrt(d)) / 2 * a;
            return result;
        }
    }


}
