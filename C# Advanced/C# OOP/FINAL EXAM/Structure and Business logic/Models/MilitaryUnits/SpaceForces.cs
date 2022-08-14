namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SpaceForces : MilitaryUnit
    {
        private const double costMilitaryUnit = 11;
        public SpaceForces() 
            : base(costMilitaryUnit)
        {
        }
    }
}
