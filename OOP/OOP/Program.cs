namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Elektronika elektronika = new Elektronika(
                id: 1,
                name: "Laptop",
                price: 20000,
                description: "High-performance laptop",
                quantity: 5,
                warranty: DateTime.Now.AddYears(2)
            );

            Console.WriteLine("Elektronika Details:");
            Console.WriteLine(elektronika.ZobrazitDetaily());
            elektronika.AplikovatSlevu(10);
            Console.WriteLine("Price after discount: " + elektronika.VypocitejCenuPoSleve());

            Obleceni obleceni = new Obleceni(
                id: 2,
                name: "T-Shirt",
                price: 500,
                description: "Cotton T-Shirt",
                quantity: 20,
                size: "L"
            );

            Console.WriteLine("\nObleceni Details:");
            Console.WriteLine(obleceni.ZobrazitDetaily());
            obleceni.AplikovatSlevu(15);
            Console.WriteLine("Price after discount: " + obleceni.VypocitejCenuPoSleve());
        }
    }

    interface IStorovnatelny
    {
        bool LzeStornovat();
        void Stornovat();
    }

    interface ISlevaSchopny
    {
        void AplikovatSlevu(double procentoSlevy);
        double VypocitejCenuPoSleve();
    }

    abstract class Product
    {
        private int id;
        public int ID
        {
            get { return id; }
        }
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value >= 0 ? value : price; }
        }
        private string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value >= 0 ? value : quantity; }
        }
        public abstract string ZobrazitDetaily();

        public Product(int id, string name, int price, string description, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
    }

    class Elektronika : Product, ISlevaSchopny
    {
        private DateTime warranty;
        public DateTime Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        public Elektronika(
            int id,
            string name,
            int price,
            string description,
            int quantity,
            DateTime warranty
        )
            : base(id, name, price, description, quantity)
        {
            this.warranty = warranty;
        }

        public override string ZobrazitDetaily()
        {
            return "ID: "
                + ID
                + "\n"
                + "Název: "
                + Name
                + "\n"
                + "Cena: "
                + Price
                + "\n"
                + "Popis: "
                + Description
                + "\n"
                + "Množství: "
                + Quantity
                + "\n"
                + "Záruka: "
                + Warranty.ToString("dd/MM/yyyy");
        }

        public void AplikovatSlevu(double procentoSlevy)
        {
            Price = (int)(Price * (1 - procentoSlevy / 100));
        }

        public double VypocitejCenuPoSleve()
        {
            return Price;
        }
    }

    class Obleceni : Product, ISlevaSchopny
    {
        private string size = "";
        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public Obleceni(
            int id,
            string name,
            int price,
            string description,
            int quantity,
            string size
        )
            : base(id, name, price, description, quantity)
        {
            this.size = size;
        }

        public override string ZobrazitDetaily()
        {
            return "ID: "
                + ID
                + "\n"
                + "Název: "
                + Name
                + "\n"
                + "Cena: "
                + Price
                + "\n"
                + "Popis: "
                + Description
                + "\n"
                + "Množství: "
                + Quantity
                + "\n"
                + "Velikost: "
                + Size;
        }

        public void AplikovatSlevu(double procentoSlevy)
        {
            Price = (int)(Price * (1 - procentoSlevy / 100));
        }

        public double VypocitejCenuPoSleve()
        {
            return Price;
        }
    }

    class User
    {
        private int id;
        public int ID
        {
            get { return id; }
        }
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email = "";
        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains("@") && value.Contains("."))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email format.");
                }
            }
        }
        private int budeget;
        public int Budeget
        {
            get { return budeget; }
            set { budeget = value >= 0 ? value : budeget; }
        }
    }

    class Objednavka : IStorovnatelny
    {
        public bool LzeStornovat()
        {
            return true;
        }

        public void Stornovat()
        {
            Console.WriteLine("Objednávka byla stornována.");
        }

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        private List<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public enum StavObjednavky
        {
            Vytvorena,
            Zaplacena,
            Odeslana,
            Stornovana,
        }

        private StavObjednavky stav;
        public StavObjednavky Stav
        {
            get { return stav; }
            set { stav = value; }
        }
    }
}
