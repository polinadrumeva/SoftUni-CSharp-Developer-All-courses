namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class StreetRacer : Racer
    {
        private const int drivingExperienceStreetRacer = 10;
        private const string racingBehaviourStreetRacer = "aggressive";
        public StreetRacer(string username,ICar car) : base(username, racingBehaviourStreetRacer, drivingExperienceStreetRacer, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
