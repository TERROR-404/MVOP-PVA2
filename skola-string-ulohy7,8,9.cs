using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //uloha 7
            /*
            Regex r = new Regex(@"((?<predvolba>(\+\d{3}\s|\(\d{3}\)))?(?<cislo>\d{3}(\s\d{3}){2}))|((?<predvolba>\+\d{3})?(?<cislo>\d{9}))");
            string a = "+420 000 111 222\n(420) 000 111 222\n000 111 222\n000111222\n+420000111222\n000111\n+(420) 000 111 222";
            string[] s = a.Split('\n');
            foreach (var item in s)
            {
                if (r.IsMatch(item))
                {
                    var match = r.Match(item);
                    Console.WriteLine(item);
                    Console.WriteLine(match.Groups["predvolba"]);
                    Console.WriteLine(match.Groups["cislo"]);
                }
                else
                {
                    Console.WriteLine($"string \"{item}\" se neshoduje");
                }
            }
            */
            //uloha9
            /*
            Console.WriteLine("Zadejte jmeno: ");
            string name = Console.ReadLine();
            Console.WriteLine("Zadejte PIN: ");
            string pin = Console.ReadLine();
            Regex rName = new Regex(@"^\w+$");
            Regex rPin = new Regex(@"^\d{4}$");
            if (rName.IsMatch(name)&&rPin.IsMatch(pin))
            {
                Console.WriteLine("Správně");
            }
            else
            {
                Console.WriteLine("Špatně");
            }
            */
            //uloha 8
            /*
            Console.WriteLine(IsMail("jan.novak@seznam.cz"));
            Console.WriteLine(IsMail("jannovak@mail.cz"));
            Console.WriteLine(IsMail("jan_novak111@centrum.cz"));
            Console.WriteLine(IsMail("jan.no.v.ak@seznam.cz"));
            Console.WriteLine(IsMail("jan.novak@sezn.am.cz"));
            */
        }
        /*
        public static bool IsMail(string s)
        {
            Console.WriteLine(s);
            Regex r = new Regex(@"^\w+(\.\w+)*\@[a-z]+\.[a-z]{2}$");
            if (r.IsMatch(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
    }
}
