namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class NuclearWeapon : Weapon
    {
        private const double priceWeapon = 15;

        public NuclearWeapon(int destructionLevel)
            : base(priceWeapon, destructionLevel)
        {
        }
    }
}
