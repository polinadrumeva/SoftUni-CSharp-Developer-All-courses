using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 2; i < 4; i++)
            {
                string[] data = Console.ReadLine().Split(";");
                if (i % 2 == 0)
                {
                    for (int j = 0; j < data.Length; j++)
                    {
                        if (data[j] == "" || data[j] == " ")
                        {
                            continue;
                        }
                        else
                        {
                            string[] personInfo = data[j].Split("=");
                            try
                            {
                                Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                                persons.Add(person);

                            }
                            catch (ArgumentException ex)
                            {

                                Console.WriteLine(ex.Message);
                                return;
                            }
                        }
                        
                    }

                }
                else
                {
                    for (int k = 0; k < data.Length; k++)
                    {
                        if (data[k] == "" || data[k] == " ")
                        {
                            continue;
                        }
                        else
                        {
                            string[] personInfo = data[k].Split("=");

                            Product product = new Product(personInfo[0], decimal.Parse(personInfo[1]));
                            products.Add(product);
                        }
                       

                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] infos = command.Split(" ");
                string name = infos[0];
                string productName = infos[1];
                Person personWhoBuy = persons.First(x => x.Name == name);
                Product productForBuy = products.First(x => x.Name == productName);
                personWhoBuy.BuyProduct(productForBuy);
            }

            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {

                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(x => x.Name).ToArray())}");
                }
                
            }
        }
    }
}
