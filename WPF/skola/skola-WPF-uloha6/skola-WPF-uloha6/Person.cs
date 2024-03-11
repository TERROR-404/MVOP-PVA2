using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skola_WPF_uloha6
{
    internal class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int YearOfBirth { get; set; }
        public Person(string name, string surname, int yearOfBirth)
        {
            Name = name;
            Surname = surname;
            YearOfBirth = yearOfBirth;
        }
    }
}
