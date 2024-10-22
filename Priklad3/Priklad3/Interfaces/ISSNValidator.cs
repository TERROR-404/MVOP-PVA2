using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priklad3.Interfaces
{
    interface ISSNValidator
    {
        bool IsValid(string issn, string birthDate);
    }
}
