namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
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

        public bool CanBreath => Oxygen >= 10.00;

        public IBag Bag { get; private set; }

        public Astronaut(string name, double oxygen)
        {
           this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }
        public virtual void Breath()
        {
            if (this.Oxygen - decreaseOxygen <= 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= decreaseOxygen;
            }
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.Name}");
            stringBuilder.AppendLine($"Oxygen: {this.Oxygen}");
            if (this.Bag.Items.Count == 0)
            {
                stringBuilder.AppendLine($"Bag items: none");
            }
            else
            {
                stringBuilder.AppendLine($"Bag items: {string.Join(", ", this.Bag.Items)}");
            }
            
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
