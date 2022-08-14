namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;
        public double Price { get; private set; }

        public int DestructionLevel 
        {
            get 
            { 
                return this.destructionLevel;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooLowDestructionLevel));
                }
                else if (value > 10)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooHighDestructionLevel));
                }

                this.destructionLevel = value;
            }
        }
      

        public Weapon(double price, int destructionLevel)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }
    }
}
