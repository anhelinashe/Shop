namespace shop
{
    internal class Program
    {

        class Customer
        {

            public int Card;
            public int Money;
            public int Products;
            public int Money1;
            public Customer(Random rnd)
            {
                this.Card = rnd.Next(1, 1000);
                this.Money = rnd.Next(1000, 10000);
                this.Money1 = Money;
                this.Products = 0;

            }

        }

        class Product
        {
            public string Name;
            public int Price;
            public int Quantity;


            public Product(string name, int price, int quantity)
            {
                this.Name = name;
                this.Price = price;
                this.Quantity = quantity;

            }
        }
        static void Buy(Product product, Customer customer, int Profit)
        {
            if (customer.Money >= product.Price && product.Quantity > 0)
            {
                customer.Money -= product.Price;
                customer.Products += 1;
                product.Quantity -= 1;
                Profit += product.Price;

            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello User! Enter the number of buyer:");
            int userCount = int.Parse(Console.ReadLine());
            Customer[] customers = new Customer[userCount];
            Random rnd = new Random();
            for (int i = 0; i < userCount; i++)
            {
                customers[i] = new Customer(rnd);
                Console.WriteLine($"Customer № {i + 1}:Money {customers[i].Money}, Card {customers[i].Card}");
            }
            int Profit = 0;
            Product[] product = new Product[]
            {
            new Product ("Eggs", 55, 20),
            new Product ("Apples", 38, 75),
            new Product ("Milk", 95, 20),
            new Product ("Butter", 65, 20),
            new Product ("Bread", 27, 10),
            };


            for (int i = 0; i < customers.Length; i++)
            {
                for (int k = 0; k < product.Length; k++)
                {
                    while (customers[k].Money >= product[k].Price && product[k].Quantity > 0)
                    {
                        Buy(product[k], customers[k], Profit);
                    }
                }
            }

            Customer maxProductCustomer = customers[0];
            Customer maxSpendCustomer = customers[0];
            int maxProducts = customers[0].Products;
            int maxSpent = customers[0].Money1 - customers[0].Money;

            foreach (var customer in customers)
            {

                if (customer.Products > maxProducts)
                {
                    maxProducts = customer.Products;
                    maxProductCustomer = customer;
                }


                int spentMoney = customer.Money1 - customer.Money;
                if (spentMoney > maxSpent)
                {
                    maxSpent = spentMoney;
                    maxSpendCustomer = customer;
                }
            }


            Console.WriteLine($"Shop's final profit: {Profit}");
            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine($"Customer № {i + 1}: Card {customers[i].Card}, Money {customers[i].Money}, Items bought: {customers[i].Products}");
            }
            Console.WriteLine($"Customer who bought the most items: ID Card {maxProductCustomer.Card}, Items: {maxProductCustomer.Products}");
            Console.WriteLine($"Customer who spent the most money: ID Card {maxSpendCustomer.Card}, Money Spent: {maxSpent}");
        }
    }
}
