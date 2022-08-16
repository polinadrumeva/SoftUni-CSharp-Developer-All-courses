using System;
using System.Text;
using Heroes.Models.Contracts;


namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {

        private string name;
        private int health;
        private int armour;
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
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }
        public bool IsAlive => this.Health > 0;
        public IWeapon Weapon 
        { 
            get
            { 
                return this.weapon; 
            } 
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            } 
        }

        public Hero(string name, int health, int armour)
        {
            this.Name = name; 
            this.Health = health;
            this.Armour = armour;
        }

        public void AddWeapon(IWeapon weapon)
        {
            
                this.Weapon = weapon;
            
        }

        public void TakeDamage(int points)
        {
            if (this.Armour >= points)
            {
                this.Armour -= points;
            }
            else
            {
                int leftPoints = points - this.Armour;
                int pointsForArmour = points - leftPoints;
                this.Armour -= pointsForArmour;
                this.Armour = 0;
                this.Health -= leftPoints;
                if (this.Health <= 0)
                {
                    this.Health = 0;
                }

            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Name} ");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armour: {this.Armour}");

            if (this.Weapon == null)
            {
                sb.AppendLine($"--Weapon: Unarmed");
            }
            else
            {
                sb.AppendLine($"--Weapon: {this.Weapon.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
