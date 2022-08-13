using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth; 
        private double health; 
        private double baseArmor; 
        private double armor; 
        private double abilityPoints;
        private Bag bag;
        private bool isAlive;
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
                    throw new ArgumentException(String.Format(ExceptionMessages.CharacterNameInvalid));
                }

                this.name = value;
            }
        }
        public double BaseHealth { get; set; }
        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                else if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }

                this.health = value;
            }
        }
        public double BaseArmor { get; set; }
        public double Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }

                this.armor = value;
            }
        }


        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; } = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

        }
		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            if (this.isAlive)
            {
                double leftPoints;
                if (this.Armor < hitPoints)
                {
                    leftPoints = hitPoints - this.Armor;
                    this.Armor = 0;
                    this.Health -= leftPoints;
                    if (this.Health <= 0)
                    {
                        this.IsAlive = false;
                    }
                }
                else
                {
                    this.Armor -= hitPoints;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.isAlive)
            {
                item.AffectCharacter(this);
            }
        }

    }
}