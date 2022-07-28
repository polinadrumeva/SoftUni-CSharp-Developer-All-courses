namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ShouldConstructorReturnCorrectData()
        {
            Car newCar = new Car("Fiat", "Punto", 1.0, 30);
            string dataName = newCar.Make;
            string expectedName = "Fiat";

            string dataModel = newCar.Model;
            string expectedModel = "Punto";

            double dataComsumption = newCar.FuelConsumption;
            double expectedComsumption = 1.0;

            double dataCapacity = newCar.FuelCapacity;
            double expectedCapacity = 30;

            double dataAmount = newCar.FuelAmount;
            double expectedAmount = 0;

            Assert.That(dataAmount, Is.EqualTo(expectedAmount));
            Assert.That(dataName, Is.EqualTo(expectedName));
            Assert.That(dataModel, Is.EqualTo(expectedModel));
            Assert.That(dataComsumption, Is.EqualTo(expectedComsumption));
            Assert.That(dataCapacity, Is.EqualTo(expectedCapacity));

        }

        [TestCase("", "Punto", 1.0, 30)]
        [TestCase(null, "Punto", 1.0, 30)]
        public void ShouldPropretyExceptionWithNullOrEmptyMake(string make, string model, double comsumption, double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Car car = new Car(make, model, comsumption, capacity);
           }, "Make cannot be null or empty!");
        }

        [TestCase("Fiat", "Punto", 1.0, 30)]
        public void ShouldPropretyMakeReturnCorrectData(string make, string model, double comsumption, double capacity)
        {
            Car car = new Car(make, model, comsumption, capacity);
            string dataMake = car.Make;
            string expectedMake = "Fiat";

            Assert.AreEqual(expectedMake, dataMake);
        }

        [TestCase("Fiat", "", 1.0, 30)]
        [TestCase("Fiat", null, 1.0, 30)]
        public void ShouldPropretyExceptionWithNullOrEmptyModel(string make, string model, double comsumption, double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, comsumption, capacity);
            }, "Model cannot be null or empty!");
        }

        [TestCase("Fiat", "Punto", 1.0, 30)]
        public void ShouldPropretyModelReturnCorrectData(string make, string model, double comsumption, double capacity)
        {
            Car car = new Car(make, model, comsumption, capacity);
            string dataModel = car.Model;
            string expectedModel = "Punto";

            Assert.AreEqual(expectedModel, dataModel);
        }

        [TestCase("Fiat", "Punto", 0, 30)]
        [TestCase("Fiat", "Punto", -10, 30)]
        public void ShouldPropretyComsumptionExceptionWithNegativeNumber(string make, string model, double comsumption, double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, comsumption, capacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase("Fiat", "Punto", 1.0, 30)]
        public void ShouldPropretyComsumptionReturnCorrectData(string make, string model, double comsumption, double capacity)
        {
            Car car = new Car(make, model, comsumption, capacity);
            double dataComsumption = car.FuelConsumption;
            double expectedComsumption = 1.0;

            Assert.AreEqual(expectedComsumption, dataComsumption);
        }

        [TestCase("Fiat", "Punto", 1.0, -30)]
        [TestCase("Fiat", "Punto", 1.0, 0)]
        public void ShouldPropretyCapacityExceptionWithNegativeNumber(string make, string model, double comsumption, double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, comsumption, capacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase("Fiat", "Punto", 1.0, 30)]
        public void ShouldPropretyCapacityReturnCorrectData(string make, string model, double comsumption, double capacity)
        {
            Car car = new Car(make, model, comsumption, capacity);
            double dataCapacity = car.FuelCapacity;
            double expectedCapacity = 30;

            Assert.AreEqual(expectedCapacity, dataCapacity);
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void ShouldThorwExceptionIfRefuelIsNegativeOrZero(double fuel)
        {
            Car newCar = new Car("Fiat", "Punto", 1.0, 30);

            Assert.Throws<ArgumentException>(() =>
           {
               newCar.Refuel(fuel);
           }, "Fuel amount cannot be zero or negative!");
            
        }

        [TestCase(10)]
        public void ShouldRefuelReturnCorrectData(double fuel)
        {
            Car newCar = new Car("Fiat", "Punto", 1.0, 30);
            newCar.Refuel(fuel);

            double dataAmount = newCar.FuelAmount;
            double expectedAmount = 10;
           
            Assert.AreEqual(expectedAmount, dataAmount);

        }

        [TestCase(30)]
        [TestCase(40)]
        public void ShouldIfTryToRefuelWithMoreThanCapacityReturnCapacity(double fuel)
        {
            Car newCar = new Car("Fiat", "Punto", 1.0, 30);
            newCar.Refuel(fuel);

            double dataAmount = newCar.FuelAmount;
            double expectedAmount = 30;

            Assert.AreEqual(expectedAmount, dataAmount);

        }

        [TestCase(10)]
      
        public void ShouldDriveThrowExceptionIfNotHaveEnoughFuel(double distance)
        {
            Car newCar = new Car("Fiat", "Punto", 1.0, 30);
            
            double fuelNeeded = (distance / 100) * newCar.FuelConsumption;
            Assert.Throws<InvalidOperationException>(() =>
           {
               newCar.Drive(distance);
           }, "You don't have enough fuel to drive!");
        }

        [TestCase(10)]

        public void ShouldDriveReturnCorrectData(double distance)
        {
            Car newCar = new Car("Fiat", "Punto", 1.0, 30);
            newCar.Refuel(20);
            double fuelNeeded = (distance / 100) * newCar.FuelConsumption;
            newCar.Drive(distance);

            double dataAmount = newCar.FuelAmount;
            double expectedAmount = 19.90;

            Assert.AreEqual(expectedAmount, dataAmount);
        }

    }
}