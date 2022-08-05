using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(-10)]
        [TestCase(-1)]
        public void CapacityShouldThrowExceptionWithNEagtiveValue(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [TestCase(10)]
        [TestCase(0)]
        public void CapacityShouldReturnCorrectData(int capacity)
        {
            Shop shop = new Shop(capacity);
            Assert.AreEqual(capacity, shop.Capacity);
        }

       
        [Test]
        public void CountShouldReturnCorrectData()
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Smartphone samsung = new Smartphone("Samsung", 100);
            Shop shop = new Shop(5);
            shop.Add(nokia);
            shop.Add(samsung);
            int actualCount = shop.Count;
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionIfPhoneAleradyExist()
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Shop shop = new Shop(5);
            shop.Add(nokia);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(nokia);
            }, $"The phone model {nokia.ModelName} already exist.");

        }

        [Test]
        public void AddShouldThrowExceptionIfShopIsFull()
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Smartphone samsung = new Smartphone("Samsung", 200);
            Shop shop = new Shop(1);
            shop.Add(nokia);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(samsung);
            }, "The shop is full.");

        }

        [TestCase("Nokia", 300)]
        public void AddShouldReturnCorrectData(string name, int batteryCharge)
        {
            Smartphone nokia = new Smartphone(name, batteryCharge);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            string actualName = nokia.ModelName;
            int actualBattery = nokia.MaximumBatteryCharge;
            string expectedName = name;
            int expectedBattery = batteryCharge;

            int actualCount = shop.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedBattery, actualBattery);
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestCase("Samsung")]
        public void RemoveShouldThrowExceptionIfPhoneNotExist(string modelName)
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Smartphone samsung = new Smartphone("Samsung", 200);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(modelName);
            }, $"The phone model {modelName} doesn't exist.");

        }

        [Test]
        public void RemoveShouldReturnCorrectData()
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Shop shop = new Shop(2);
            shop.Add(nokia);
            shop.Remove(nokia.ModelName);

            int actualCount = shop.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount);
            
        }

        [TestCase("Samsung", 200)]
        [TestCase("Apple", 300)]
        public void TestPhoneShouldThrowExceptionIfPhoneNotExist(string modelName, int battery)
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Smartphone anotherPhone = new Smartphone(modelName, battery);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, battery);
            }, $"The phone model {modelName} doesn't exist.");

        }

        [TestCase(400)]
        public void TestPhoneShouldThrowExceptionIfBatteryIsLower(int usageBattery)
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(nokia.ModelName, usageBattery);
            }, $"The phone model {nokia.ModelName} is low on batery.");

        }

        [TestCase(200)]
        public void TestPhoneShouldReturnCorrectData(int usageBattery)
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            shop.TestPhone(nokia.ModelName, usageBattery);
            int actualBattery = nokia.CurrentBateryCharge;
            int expectedBattery = 100;

            Assert.AreEqual(expectedBattery, actualBattery);

        }

        [TestCase("Samsung")]
        [TestCase("Apple")]
        public void ChargePhoneShouldThrowExceptionIfPhoneNotExist(string modelName)
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(modelName);
            }, $"The phone model {modelName} doesn't exist.");

        }

        [TestCase(200)]
        public void ChargePhoneShouldReturnCorrectData(int usageBattery)
        {
            Smartphone nokia = new Smartphone("Nokia", 300);
            Shop shop = new Shop(2);
            shop.Add(nokia);

            shop.TestPhone(nokia.ModelName, usageBattery);
            shop.ChargePhone(nokia.ModelName);

            int actualBattery = nokia.CurrentBateryCharge;
            int expectedBattery = 300;

            Assert.AreEqual(expectedBattery, actualBattery);

        }
    }
}