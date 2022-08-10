namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class StreetRacer : Racer
    {
        public StreetRacer(string username, string racingBehavior, int drivingExperience, ICar car) : base(username, racingBehavior, drivingExperience, car)
        {
        }
    }
}
