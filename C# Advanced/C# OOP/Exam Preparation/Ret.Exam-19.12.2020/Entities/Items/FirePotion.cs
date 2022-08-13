using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int weightFire = 5;
        private const int decreaseHealth = 20;

        public FirePotion()
            : base(weightFire)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health -= decreaseHealth;
                if (character.Health <= 0)
                {
                    character.IsAlive = false;
                }
            }
        }
    }
}
