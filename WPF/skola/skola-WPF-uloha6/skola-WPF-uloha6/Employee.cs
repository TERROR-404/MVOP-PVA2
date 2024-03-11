using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skola_WPF_uloha6
{
    internal class Employee : Person
    {
        public string Education { get; set; }
        public string WorkPosition { get; set; }
        public string GrossSalary { get; set; }
        public Employee(string education, string workPosition, string grossSalary, string name, string surname, int yearOfBirth) : base(name, surname, yearOfBirth)
        {
            Education = education;
            WorkPosition = workPosition;
            GrossSalary = grossSalary;
        }
    }
}
