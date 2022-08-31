using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void ConstructorShouldReturnCorrectData()
            {
                Garage garage = new Garage("Manoa", 3);
                string actualName = garage.Name;
                string expectedName = "Manoa";

                int actualMechanics = garage.MechanicsAvailable;
                int expectedMechanics = 3;

                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedMechanics, actualMechanics);
            }

            [TestCase(null)]
            [TestCase("")]
            public void NameShouldThrowExceptionIfIsNullOrEmtpy(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 3);
                }, "Invalid garage name.");
            }

            [TestCase(0)]
            [TestCase(-2)]
            public void MechanicsShouldThrowExceptionIfIsNegativeOrZero(int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Manoa", mechanics);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CarsCountShouldReturnCorrectData()
            {
                Garage garage = new Garage("Manoa", 3);
                Car car = new Car("Fiat", 4);
                garage.AddCar(car);
                
                int actualCount = garage.CarsInGarage;
                int expectedCount = 1;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void AddCarShouldThrowExceptionIfCapacityIsFull()
            {
                Garage garage = new Garage("Manoa", 1);
                Car car = new Car("Fiat", 4);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car);
                }, "No mechanic available.");
            }

            [Test]
            public void FixCarShouldThrowExceptionIfNotExist()
            {
                Garage garage = new Garage("Manoa", 3);
                Car car = new Car("Fiat", 4);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Opel");
                }, $"The car Opel doesn't exist.");
            }

            [Test]
            public void FixCarShouldReturnCorrectData()
            {
                Garage garage = new Garage("Manoa", 3);
                Car car = new Car("Fiat", 4);
                garage.AddCar(car);
                garage.FixCar("Fiat");

                int actualIssues = car.NumberOfIssues;
                int expectedIssues = 0;

                Assert.AreEqual(expectedIssues, actualIssues);
            
            }


            [Test]
            public void RemoveFixCarShouldReturnCorrectData()
            {
                Garage garage = new Garage("Manoa", 3);
                Car car = new Car("Fiat", 4);
                garage.AddCar(car);
                garage.FixCar("Fiat");
                garage.RemoveFixedCar();

                int actualCount = garage.CarsInGarage;
                int expectedCount = 0;

                Assert.AreEqual(expectedCount, actualCount);

            }


            [Test]
            public void RemoveFixCarShouldThrorwExceptionIfDontHaveAnyCars()
            {
                Garage garage = new Garage("Manoa", 3);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");

            }

            [Test]
            public void ReportShouldReturnCorrectData()
            {
                Garage garage = new Garage("Manoa", 3);
                Car car = new Car("Fiat", 4);
                garage.AddCar(car);

                string actualReport = garage.Report();
                string expectedReport = "There are 1 which are not fixed: Fiat.";


                Assert.AreEqual(expectedReport, actualReport);

            }
        }
    }
}