using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Cars.Count; }}

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.Capacity = capacity;
        }

        public string AddCar(Car addedCAr)
        {
            bool canAddCar = true;
            foreach (var car in Cars)
            {
                if (car.RegistrationNumber == addedCAr.RegistrationNumber)
                {
                    canAddCar = false;
                    return $"Car with that registration number, already exists!";
                }
            }

            if (Cars.Count + 1 > this.Capacity)
            {
                canAddCar = false;
                return "Parking is full!";
            }

            if (canAddCar)
            {
                Cars.Add(addedCAr);
                return $"Successfully added new car {addedCAr.Make} {addedCAr.RegistrationNumber}";

            }
            return "";
        }

        public string RemoveCar(string registrationNumber) 
        {
            bool isAvailable = false;
            foreach (var car in Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    isAvailable = true;
                }
            }

            if (!isAvailable)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = Cars.First(car => car.RegistrationNumber == registrationNumber);
                Cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.First(car => car.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationsNumbers) 
        {
            foreach (var registrationNumber in registrationsNumbers)
            { 
                RemoveCar(registrationNumber);
            }
        }
    }
}
