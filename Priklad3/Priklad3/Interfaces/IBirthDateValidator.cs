using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priklad3.Interfaces
{
    interface IBirthDateValidator
    {
        bool IsValid(string birthDate, out DateTime retVal);
    }
}
