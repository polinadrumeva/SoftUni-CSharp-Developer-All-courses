using System;
using Heroes.Models.Contracts;


namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {

        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;

        public string Name 
        {
            get
            { 
                return this.name;
            }
           private  set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }
        public int Armour
        {
            get
            {
                return this.armour;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }
        public bool IsAlive 
        {
            get
            {
                return this.isAlive;
            }
            private set
            {
                if (this.health < 0)
                {
                    this.isAlive = false;
                }
                else
                {
                    this.isAlive = true;
                }
            }
        }
        public IWeapon Weapon { get { return this.weapon; } private set { AddWeapon(value); } }

        public Hero(string name, int health, int armour)
        {
            this.Name = name; 
            this.Health = health;
            this.Armour = armour;
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException("Weapon cannot be null.");
            }
            if (this.Weapon == null)
            {
                this.Weapon = weapon;
            }
           
        }

        public void TakeDamage(int points)
        {
            if (this.Armour >= 0)
            {
                this.Armour -= points;
            }

            if (this.Armour <= 0)
            {
                this.Health -= this.Armour;
                this.Armour = 0;
            }

            if (this.Health <= 0)
            {
                this.isAlive = false;
            }

        }
    }
}
