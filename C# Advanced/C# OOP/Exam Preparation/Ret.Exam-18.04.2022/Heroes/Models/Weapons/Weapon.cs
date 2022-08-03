using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public string Name 
        {
            get
            { 
                return this.name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public int Durability 
        {
            get
            {
                return this.durability;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }

                this.durability = value;

            }
        }

        public Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public abstract int DoDamage();
       
    }
}
