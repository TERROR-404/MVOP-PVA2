using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databáze_kuchyňských_receptů
{
    public class RecipesClass
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }
        public string Author { get; set; }
        public bool Vegetarian { get; set; }
        public DateTime Time { get; set; }
    }
}
