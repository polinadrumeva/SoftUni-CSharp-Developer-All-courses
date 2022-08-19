using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = this.cars.GetByName(carModel);
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            IDriver driver = this.drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid type!");
            }

            ICar carToFind = this.cars.GetByName(model);
            if (carToFind != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }

            this.cars.Add(car);
            return String.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driverToCreate = new Driver(driverName);
            this.drivers.Add(driverToCreate);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.races.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            IRace raceToCreate = new Race(name, laps);
            this.races.Add(raceToCreate);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (var driver in race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)))
            {
                if (count == 0)
                {
                    sb.AppendLine(String.Format(OutputMessages.DriverFirstPosition, driver.Name, raceName));
                    driver.WinRace();
                }
                else if (count == 1)
                {
                    sb.AppendLine(String.Format(OutputMessages.DriverSecondPosition, driver.Name, raceName));
                }
                else if (count == 2)
                {
                    sb.AppendLine(String.Format(OutputMessages.DriverThirdPosition, driver.Name, raceName));
                }
                else if (count == 3)
                {
                    break;
                }

                count++;
            }

            this.races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }

}
