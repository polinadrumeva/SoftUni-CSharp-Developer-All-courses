namespace Formula1.Models.Cars
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    
    using System;


    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        public string Model
        {
            get 
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                this.model = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                this.horsePower = value;
            }

        }

        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;
            }
            private set
            {
                if (value < 1.60 || value > 2.00)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                this.engineDisplacement = value;
            }
        }

        public FormulaOneCar(string model, int power, double displacement)
        {
            this.Model = model;
            this.Horsepower = power;
            this.EngineDisplacement = displacement;

        }
        public double RaceScoreCalculator(int laps)
        {
            double score = this.EngineDisplacement / this.Horsepower * laps;
            return score;
        }
    }
}
