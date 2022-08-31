using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private double flourModifier;
        private double bakingModifier;

        public string FlourType 
        {
            get
            { 
                return this.flourType;
            }
            set
            {
                if (String.IsNullOrEmpty(value) || (value.ToLower() != "white" && value.ToLower() != "wholegrain"))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTehnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (String.IsNullOrEmpty(value) || (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade"))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }
        }

        public double FlourModifier
        {
            get
            {
                return this.flourModifier;
            }
            set
            {
                if (this.FlourType.ToLower() == "white")
                {
                    this.flourModifier = 1.5;
                }
                else if (this.FlourType.ToLower() == "wholegrain")
                {
                    this.flourModifier = 1.0;
                }
            }
        }

        public double BakingModifier
        {
            get
            {
                return this.bakingModifier;
            }
            set
            {
                if (this.BakingTehnique.ToLower() == "crispy")
                {
                    this.bakingModifier = 0.9;
                }
                else if (this.BakingTehnique.ToLower() == "chewy")
                {
                    this.bakingModifier = 1.1;
                }
                else if (this.BakingTehnique.ToLower() == "homemade")
                {
                    this.bakingModifier = 1.0;
                }
            }
        }
    
        public Dough(string flourType, string tehnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTehnique = tehnique;
            this.Grams = grams;
            this.FlourModifier = flourModifier;
            this.BakingModifier = bakingModifier;
        }

        public double CalculateCalories()
         => (2 * this.Grams) * this.FlourModifier * this.BakingModifier;
        
    }
}
