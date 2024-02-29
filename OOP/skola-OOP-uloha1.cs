using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human("Jakub","Dvořák");
            Human h2 = new Human("kuba","");

        }
    }
    class Human
    {
        private string name;

        private string surname;
        public string Name { 
            get{return name; } 
            set { if (value == "") { throw new Exception("Jméno nemůže být prázdný string!"); } this.name = value; } }
        public string Surname {
            get { return surname; }
            set { if (value == "") { throw new Exception("Příjmení nemůže být prázdný string!"); } this.surname = value; }
        }

        public Human(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
