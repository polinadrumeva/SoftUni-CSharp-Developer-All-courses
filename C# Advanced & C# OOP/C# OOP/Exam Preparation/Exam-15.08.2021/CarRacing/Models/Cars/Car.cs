namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumption;
        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarMake));
                }

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarModel));
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get
            {
                return this.vin;
            }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarVIN));
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarHorsePower));
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get
            {
                return this.fuelAvailable;
            }
            protected set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }

                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get
            {
                return this.fuelConsumption;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarFuelConsumption));
                }

                this.fuelConsumption = value;
            }
        }

        public Car(string make, string model, string vin, int horsePower, double fuelAvailabe, double fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailabe;
            this.FuelConsumptionPerRace = fuelConsumption;

        }
        public abstract void Drive();
    }
}
