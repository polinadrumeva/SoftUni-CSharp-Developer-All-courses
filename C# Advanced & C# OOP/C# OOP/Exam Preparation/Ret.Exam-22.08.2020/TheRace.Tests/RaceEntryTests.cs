using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [Test]
        public void NameDriverShouldThrowExceptionIfValueIsNull()
        {
            UnitCar car = new UnitCar("Fiat", 100, 200);
           
            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver driver = new UnitDriver(null, car);
            }, "Name cannot be null!");
        }


        [Test]
        public void AddDriverShouldThrowExceptionIfDriverIsNull()
        {
            UnitDriver driver = null;
            RaceEntry entry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.AddDriver(driver);
            }, "Driver cannot be null.");
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriverAlreadyExist()
        {
            UnitCar car = new UnitCar("Fiat", 100, 200);
            UnitDriver driver = new UnitDriver("Polina", car);
            RaceEntry entry = new RaceEntry();
            entry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.AddDriver(driver);
            }, "Driver Polina is already added.");
        }

        [Test]
        public void AddDriverShouldReturnCorrectData()
        {
            UnitCar car = new UnitCar("Fiat", 100, 200);
            UnitDriver driver = new UnitDriver("Polina", car);
            RaceEntry entry = new RaceEntry();
            string actual = entry.AddDriver(driver);
            string expected = "Driver Polina added in race.";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateShouldThrowExceptionIfNotHaveMinPartip()
        {
            UnitCar car = new UnitCar("Fiat", 100, 200);
            UnitDriver driver = new UnitDriver("Polina", car);
            RaceEntry entry = new RaceEntry();
            entry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.CalculateAverageHorsePower();
            }, "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateShouldReturnCorrectData()
        {
            UnitCar car = new UnitCar("Fiat", 50, 200);
            UnitCar car1 = new UnitCar("Opel", 200, 200);
            UnitCar car2 = new UnitCar("Moskvich", 50, 200);
            UnitDriver driver = new UnitDriver("Polina", car);
            UnitDriver driver1 = new UnitDriver("Maria", car1);
            UnitDriver driver2 = new UnitDriver("Emo", car2);
            RaceEntry entry = new RaceEntry();
            entry.AddDriver(driver);
            entry.AddDriver(driver1);
            entry.AddDriver(driver2);

            double actualAverage = entry.CalculateAverageHorsePower();
            double expectedAverage = 100;

            Assert.AreEqual(expectedAverage, actualAverage);
        }
    }
}