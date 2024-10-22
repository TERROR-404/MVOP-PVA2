using Priklad3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priklad3.Validators
{
    internal class BirthDateValidator : IBirthDateValidator
    {
        public bool IsValid(string birthDate, out DateTime retVal)
        {
            DateTime date1 = new DateTime(1900, 1, 1);
            return (DateTime.TryParse(birthDate, out retVal)&&retVal < DateTime.Now && retVal > date1);
        }
    }
}
