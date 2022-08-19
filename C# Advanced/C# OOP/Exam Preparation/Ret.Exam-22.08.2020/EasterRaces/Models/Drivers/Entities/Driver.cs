using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name; 
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;

        public Driver(string name)
        {
            this.Name = name;
        }
        
        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.CarInvalid));
            }

            this.Car = car;
            
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
