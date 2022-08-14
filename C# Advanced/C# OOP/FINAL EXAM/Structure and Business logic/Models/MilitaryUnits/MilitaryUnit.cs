namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1; 
        public double Cost { get; private set; }

        public int EnduranceLevel { get { return this.enduranceLevel; } protected set { this.enduranceLevel = value; } }

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }
        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (this.EnduranceLevel == 20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(String.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
        }
    }
}
