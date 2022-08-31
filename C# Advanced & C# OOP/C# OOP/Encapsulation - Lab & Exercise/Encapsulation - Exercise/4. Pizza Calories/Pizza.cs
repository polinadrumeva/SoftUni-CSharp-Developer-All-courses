using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<ToppingClass> topping;

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }
       
        public List<ToppingClass> Topping { get; set; }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Topping = new List<ToppingClass>();
        }

        public void Add(ToppingClass topping)
        { 
            if (this.Topping.Count + 1 > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.Topping.Add(topping);
            }
        }

        public double CalculateCalories()
         => Topping.Sum(x => x.CalculateCalories()) + this.Dough.CalculateCalories();
    }
}
