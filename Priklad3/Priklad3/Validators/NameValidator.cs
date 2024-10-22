using Priklad3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priklad3.Validators
{
    class NameValidator : INameValidator
    {
        public bool IsValid(string s)
        {
            return s.Length > 1 && char.IsUpper(s[0]); 
        }
    }
}
