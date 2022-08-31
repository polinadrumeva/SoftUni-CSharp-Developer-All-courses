namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerName));
                }

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get
            {
                return this.racingBehavior;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerBehavior));
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get
            {
                return this.drivingExperience;
            }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerDrivingExperience));
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get
            {
                return this.car;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerCar));
                }

                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable > this.Car.FuelConsumptionPerRace)
            {
                return true;
            }

            return false;
        }

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
           this.Username = username;    
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience= drivingExperience;
            this.Car = car;
        }
        public virtual void Race()
        {
            this.Car.Drive();       
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Username}" + Environment.NewLine + $"--Driving behavior: {this.RacingBehavior}" + Environment.NewLine + $"--Driving experience: {this.DrivingExperience}" + Environment.NewLine + $"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})";
        }
    }
}
