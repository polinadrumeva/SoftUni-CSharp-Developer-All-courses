namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SpaceMissiles : Weapon
    {
        private const double priceWeapon = 8.75;

        public SpaceMissiles(int destructionLevel)
            : base(priceWeapon, destructionLevel)
        {
        }
    }
}
