namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Egg : IEgg
    {
        private string name;
        private int energyRequered;
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
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidEggName));
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyRequered;
            }
            protected set
            {
                if (value < 0)
                {
                    this.energyRequered = 0;
                }
                this.energyRequered = value;
            }
        }

        public Egg(string name, int energyRequered)
        {
            this.Name = name;
            this.EnergyRequired = energyRequered;
        }
        public void GetColored()
        {
            if (this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }

            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }

            return false;
        }
    }
}
