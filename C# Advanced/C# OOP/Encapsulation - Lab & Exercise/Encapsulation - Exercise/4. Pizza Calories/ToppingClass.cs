using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class ToppingClass
    {
        private string toppingType;
        private double grams;
        private double toppingModifier;

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            set
            {
                if (String.IsNullOrEmpty(value) || (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce"))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }
        
        public double Grams
        {
            get
            {
                return this.grams;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double ToppingModifier
        {
            get
            {
                return this.toppingModifier;
            }
            set
            {
                if (this.toppingType.ToLower() == "meat")
                {
                    this.toppingModifier = 1.2;
                }
                else if (this.toppingType.ToLower() == "veggies")
                {
                    this.toppingModifier = 0.8;
                }
                else if (this.toppingType.ToLower() == "cheese")
                {
                    this.toppingModifier = 1.1;
                }
                else if (this.toppingType.ToLower() == "sauce")
                {
                    this.toppingModifier = 0.9;
                }
            }
        }

        public ToppingClass(string toppingType, double grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
            this.ToppingModifier = toppingModifier;
         
        }

        public double CalculateCalories()
         =>  (this.Grams * this.ToppingModifier) * 2;

    }
}
