using Priklad3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priklad3
{
    internal class Person
    {
        readonly IBirthDateValidator birthDateValidator;
        readonly INameValidator nameValidator;
        readonly ISSNValidator ssnValidator;

        public Person(IBirthDateValidator birthDateValidator, INameValidator nameValidator, ISSNValidator ssnValidator)
        {
            this.birthDateValidator = birthDateValidator;
            this.nameValidator = nameValidator;
            this.ssnValidator = ssnValidator;
        }
    }
}
