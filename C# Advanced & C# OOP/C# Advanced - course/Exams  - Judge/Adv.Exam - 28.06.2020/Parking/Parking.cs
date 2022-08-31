using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        //  Field data – collection that holds added cars
        private List<Car> data;

        public List<Car> Data { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        //	Getter Count – returns the number of cars.
        public int Count { get { return Data.Count; } }


        public Parking(string type, int capacity)
        {
            this.Data = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }


        //	Method Add(Car car) – adds an entity to the data if there is an empty cell for the car.
        public void Add(Car car)
        {
            if (!Data.Contains(car) && Data.Count + 1 <= Capacity)
            {
                Data.Add(car);
            }
        }

        //	Method Remove(string manufacturer, string model) – removes the car by given manufacturer and model, if such exists, and returns bool.
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove != null)
            {
                Data.Remove(carToRemove);
                return true;
            }

            return false;
        }

        //	Method GetLatestCar() – returns the latest car (by year) or null if have no cars.
        public Car GetLatestCar()
        {
            int max = Data.Max(x => x.Year);
            Car latestCar = Data.First(x => x.Year == max);

            if (Data.Count == 0)
            {
                return null;
            }

            return latestCar;
        }

        //	Method GetCar(string manufacturer, string model) – returns the car with the given manufacturer and model or null if there is no such car.
        public Car GetCar(string manufacturer, string model)
        {
            Car carToReturn = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToReturn != null)
            {
                return carToReturn;
            }

            return null;
        }

        //	GetStatistics() – returns a string in the following format:
        public string GetStatistics()
        {
            StringBuilder parking = new StringBuilder();
            parking.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in Data)
            {

                parking.AppendLine(car.ToString());

            }

            return parking.ToString();
        }

    }
}
