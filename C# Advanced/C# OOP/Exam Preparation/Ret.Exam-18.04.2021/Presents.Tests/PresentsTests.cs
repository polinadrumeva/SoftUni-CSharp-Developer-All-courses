namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [TestCase("Polina", 10.4)]
        [TestCase("Maria", 10)]
        public void CreateShouldReturnCorrectData(string name, double magic)
        { 
            Present present = new Present(name, magic);
            Bag bag = new Bag();
            bag.Create(present);
            string actualData = present.Name;
            double actualMagic = present.Magic;
            string expectedName = name; 
            double expectedMagic = magic;

            Assert.AreEqual(expectedName, actualData);
            Assert.AreEqual(expectedMagic, actualMagic);
        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentIsNull()
        {
            Present present = null;
            Bag bag = new Bag();


            Assert.Throws<ArgumentNullException>(() =>
           {
               bag.Create(present);
           }, "Present is null");
        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentAlreadyExist()
        {
            Present present = new Present("Polina", 10);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");
        }

        [TestCase("Polina", 10.4)]
        [TestCase("Maria", 10)]
        public void RemoveShouldReturnCorrectData(string name, double magic)
        {
            Present present = new Present(name, magic);
            Bag bag = new Bag();
            bag.Create(present);
            bool actual = bag.Remove(present);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLeastPresentShouldReturnCorrectData()
        {
            Present present = new Present("Polina", 10.4);
            Present present1 = new Present("Maria", 10);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);

            Present actual = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(actual, present1);
        }

        [Test]
        public void GetPresentShouldReturnCorrectData()
        {
            Present present = new Present("Polina", 10.4);
            Bag bag = new Bag();
            bag.Create(present);

            Present actual = bag.GetPresent("Polina");

            Assert.AreEqual(actual, present);
        }
    }
}
