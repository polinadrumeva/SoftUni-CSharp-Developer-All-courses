namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    public class GymsTests
    {
        
        [TestCase("", 2)]
        [TestCase(null, 2)]
        public void NamePropShouldThrowExceptionWithNullOrEmptyName(string name, int size)
        { 
            Assert.Throws<ArgumentNullException> (() =>
            {
                Gym newGym = new Gym(name, size);
            }, 
            "Invalid gym name.");
        }

        [Test]
        public void NamePropShouldReturnCorrectData()
        {
            Gym gym = new Gym("SportGym", 10);
            string actualName = gym.Name;
            string expectedName = "SportGym";
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase("SportGym", -10)]
        [TestCase("SportGym", -1)]
        public void CapacityPropShouldThrowExceptionWithNegativeNumber(string name, int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym newGym = new Gym(name, size);
            },
            "Invalid gym capacity.");
        }

        [Test]
        public void CapacityPropShouldReturnCorrectData()
        {
            Gym gym = new Gym("SportGym", 10);
            int actualCapacity = gym.Capacity;
            int expectedCapacity = 10;
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void AddathletesShouldReturnCorrectData()
        {
            Gym gym = new Gym("SportGym", 10);
            Athlete athlete = new Athlete("Polina");
            gym.AddAthlete(athlete);
            int actualData = gym.Count;
            int expectedData= 1;
            Assert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void AddathletesShouldThrowEceptionIsFullCapacity()
        {
            Gym gym = new Gym("SportGym", 1);
            Athlete athlete = new Athlete("Polina");
            Assert.Throws<InvalidOperationException>(() =>
           {
               gym.AddAthlete(athlete);
           }, "The gym is full.");

        }
    }
}
