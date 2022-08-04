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
    }
}