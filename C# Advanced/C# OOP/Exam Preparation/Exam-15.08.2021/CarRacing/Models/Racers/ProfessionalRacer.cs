namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class ProfessionalRacer : Racer
    {
        private const int drivingExperienceProfRacer = 30;
        private const string racingBehaviourProfRacer = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, racingBehaviourProfRacer, drivingExperienceProfRacer, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
