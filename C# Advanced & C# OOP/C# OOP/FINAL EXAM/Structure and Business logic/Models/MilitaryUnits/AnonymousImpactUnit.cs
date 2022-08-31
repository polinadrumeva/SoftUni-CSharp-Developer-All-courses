namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double costMilitaryUnit = 30;
        public AnonymousImpactUnit() 
            : base(costMilitaryUnit)
        {
        }
    }
}
