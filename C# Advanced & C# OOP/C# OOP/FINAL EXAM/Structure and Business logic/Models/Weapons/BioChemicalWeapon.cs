namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class BioChemicalWeapon : Weapon
    {
        private const double priceWeapon = 3.2;
        public BioChemicalWeapon(int destructionLevel) 
            : base(priceWeapon, destructionLevel)
        {
        }

    }
}
