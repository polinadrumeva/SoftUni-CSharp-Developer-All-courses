using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int weightHealth = 5;
        private const int increaseHealth = 20;

        public HealthPotion() 
            : base(weightHealth)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += increaseHealth;
            }
        }
    }
}
