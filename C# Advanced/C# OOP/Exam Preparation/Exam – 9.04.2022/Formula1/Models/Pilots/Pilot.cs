namespace Formula1.Models.Pilots
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return this.car;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarForPilot));

                }

                this.car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace
        { 
            get
            { 
                return canRace;
            }
            private set
            { 
                this.canRace = value;
            }
        }

        
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public void AddCar(IFormulaOneCar car)
        {
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.InvalidCarForPilot));
            }
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
