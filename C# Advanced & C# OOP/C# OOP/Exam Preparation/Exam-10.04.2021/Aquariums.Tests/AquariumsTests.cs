namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [TestCase("", 19)]
        [TestCase(null, 10)]
        public void NameShouldThrowExceptionaIfNameIsNullOrEmprty(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() =>
           {
               Aquarium aquarium = new Aquarium(name, capacity);

           }, "Invalid aquarium name!");
        }

        [TestCase("Polina", 19)]
        [TestCase("Maria", 10)]
        public void NameShouldReturnCorrectData(string name, int capacity)
        {
           Aquarium aquarium = new Aquarium(name, capacity);
            string actualName = aquarium.Name;
            string expectedName = name;
            Assert.AreEqual(expectedName, actualName);

        }

        [TestCase("Polina", -19)]
        public void CapacityShouldThrowExceptionaIfValueIsNegativeNumber(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, capacity);

            }, "Invalid aquarium capacity!");
        }

        [TestCase("Polina", 19)]
        public void CapacityShouldReturnCorrectData(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);
            int actualCapacity = aquarium.Capacity;
            int expectedCapacity = capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);

        }

        [Test]
        public void AddShouldThrowExceptionIfAquariumIsFull()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 1);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(second);

            }, "Aquarium is full!");

        }

        [Test]
        public void AddShouldAddedFishSuccessfully()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);

            int actualData = aquarium.Count;
            int expectedData = 2;

            Assert.AreEqual(expectedData, actualData);  
        }

        [Test]
        public void RemoveShouldRemovedFishSuccessfully()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);
            aquarium.RemoveFish("Polina");
            int actualData = aquarium.Count;
            int expectedData = 1;

            Assert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfFishNotExist()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Ivan");

            }, $"Fish with the name Ivan doesn't exist!");
        }

        [Test]
        public void SellFishShouldThrowExceptionIfFishNotExist()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Ivan");

            }, $"Fish with the name Ivan doesn't exist!");
        }

        [Test]
        public void SellFishShouldChangeAvailableStatusCorrectly()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);
            aquarium.SellFish("Polina");

            bool actualIsAvailable = first.Available;
            bool expectedIsAvailable = false;

            Assert.AreEqual(expectedIsAvailable, actualIsAvailable);

        }

        [Test]
        public void SellFishShouldReturnCorrectData()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);
            Fish actualfishToSell = aquarium.SellFish("Polina");

            Assert.AreEqual(first, actualfishToSell);

        }

        [Test]
        public void ReportShouldReturnCorrectData()
        {
            Aquarium aquarium = new Aquarium("RiverWorld", 3);
            Fish first = new Fish("Polina");
            Fish second = new Fish("Maria");
            aquarium.Add(first);
            aquarium.Add(second);

            string actualReport = aquarium.Report();
            string expectedReport = $"Fish available at RiverWorld: Polina, Maria";

            Assert.AreEqual(expectedReport, actualReport);

        }
    }
}
