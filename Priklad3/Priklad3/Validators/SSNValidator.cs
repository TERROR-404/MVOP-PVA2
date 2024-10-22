using Priklad3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priklad3.Validators
{
    internal class SSNValidator : ISSNValidator
    {
        public bool IsValid(string issn, string birthDate)
        {
            bool a = true;
            if (Convert.ToInt32(birthDate.Split('-')[0]) < 1954)
            {
                if (issn[6]!='/' ||issn.Split('/')[0].Length != 6 || issn.Split('/')[1].Length != 3|| issn.Split('/')[0].GetType() == typeof(int) || issn.Split('/')[1].GetType() == typeof(int))
                {
                    a = false;
                }
            }
            else if (Convert.ToInt32(birthDate.Split('-')[0]) > 1954)
            {
                if (issn[6] != '/' ||issn.Split('/')[0].Length != 6 || issn.Split('/')[1].Length != 3 || issn.Split('/')[0].GetType() == typeof(int) || issn.Split('/')[1].GetType() == typeof(int))
                {
                    a = false;
                }
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}
