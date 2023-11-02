using System;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input1 = "jan.novak@seznam.cz";
            string input2 = "jannovak@mail.cz";
            string input3 = "jan_novak111@centrum.cz";
            string input4 = "Pepa.@Prase..";
            Console.WriteLine(IsMail(input1));
            Console.WriteLine(IsMail(input2));
            Console.WriteLine(IsMail(input3));
            Console.WriteLine(IsMail(input4));
        }
        public static bool IsMail(string s)
        {
            Regex r = new Regex(@"^\w+(\.\w+)*@(\w+\.)+\w{2,4}$");
            return r.IsMatch(s);
        }
    }
}
