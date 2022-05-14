using System;
using System.Collections.Generic;
using System.Linq;


namespace ME05._Shopping_Spree
{
    class Person
    {
        public string Name { get; set; }

        public double Money { get; set; }

        public List<string> Bag { get; set; }

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<string>();  
        }
        
    }

    class Product
    {
        public string Name { get; set; }

        public double Cost { get; set; }

        public Product(string productName, double cost)
        {
            this.Name = productName;
            this.Cost = cost;
        }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> productes = new List<Product>();

            List<string> persons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < persons.Count; i++)
            {
                string[] personInfo = persons[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                double money = double.Parse(personInfo[1]);
                Person person = new Person(name, money);
                people.Add(person);
            }

            List<string> products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < products.Count; i++)
            {
                string[] productInfo = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = productInfo[0];
                double cost = double.Parse(productInfo[1]);
                Product product = new Product(productName, cost);
                productes.Add(product); 
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProduct = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string customerName = personProduct[0];
                string productNames = personProduct[1];

                foreach (Person person in people)
                {
                    foreach (Product product in productes)
                    {
                        if (person.Name == customerName && product.Name == productNames && person.Money >= product.Cost)
                        {
                            person.Money -= product.Cost;
                            person.Bag.Add(productNames);
                            Console.WriteLine($"{person.Name} bought {product.Name}");
                        }
                        else if (person.Name == customerName && product.Name == productNames && person.Money < product.Cost)
                        {
                            Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        }
                    }
                    
                }
            }

            foreach (Person person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
            }
        }
    }
}

