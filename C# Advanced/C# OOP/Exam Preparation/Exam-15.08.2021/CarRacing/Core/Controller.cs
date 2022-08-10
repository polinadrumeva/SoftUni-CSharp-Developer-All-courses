namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
           
            ICar car = this.cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarCannotBeFound));
            }

            IRacer racer;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username,car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            this.racers.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = this.racers.FindBy(racerOneUsername);
            IRacer secondRacer = this.racers.FindBy(racerTwoUsername);
            if (firstRacer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if(secondRacer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

           return this.map.StartRace(firstRacer, secondRacer).ToString();

        }

        public string Report()
        {
            List<IRacer> sortedRacer = this.racers.Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (IRacer racer in sortedRacer)
            {
                stringBuilder.AppendLine(racer.ToString());
            }
                
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
