namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Astronaut : IAstronaut
    {
        private const double decreaseOxygen = 10;
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidAstronautName));

                }

                this.name = value;  
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen));

                }

                this.oxygen = value;
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag { get; private set; }

        public Astronaut(string name, double oxygen)
        {
           this.Name = name;
            this.Oxygen = oxygen;
        }
        public virtual void Breath()
        {
            this.Oxygen -= decreaseOxygen;
        }
    }
}
