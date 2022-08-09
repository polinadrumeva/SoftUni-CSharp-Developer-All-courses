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
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("Maria");
            Assert.Throws<InvalidOperationException>(() =>
           {
               gym.AddAthlete(athlete1);
           }, "The gym is full.");

        }

        [Test]
        public void RemoveAthletesShouldReturnCorrectData()
        {
            Gym gym = new Gym("SportGym", 10);
            Athlete athlete = new Athlete("Polina");
            Athlete athlete1 = new Athlete("Maria");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.RemoveAthlete("Maria");
            int actualData = gym.Count;
            int expectedData = 1;
            Assert.AreEqual(expectedData, actualData);
        }

        [TestCase("Maria")]
        public void RemoveAthletesShouldThrowEceptionIfAtletesNotExist(string name)
        {
            Gym gym = new Gym("SportGym", 2);
            Athlete athlete = new Athlete("Polina");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete(name);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(name);
            }, $"The athlete {name} doesn't exist.");

        }

        [Test]
        public void InjureAthletesShouldReturnCorrectData()
        {
            Gym gym = new Gym("SportGym", 10);
            Athlete athlete = new Athlete("Polina");
            Athlete athlete1 = new Athlete("Maria");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.InjureAthlete("Maria");
            bool actualInjureData = athlete1.IsInjured;
            bool expectedInjureData = true;
            Assert.AreEqual(expectedInjureData, actualInjureData);
        }

        [TestCase("Maria")]
        public void InjureAthletesShouldThrowExceptionIfAtletesNotExist(string name)
        {
            Gym gym = new Gym("SportGym", 2);
            Athlete athlete = new Athlete("Polina");
            Athlete athlete1 = new Athlete(name);
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(name);
            }, $"The athlete {name} doesn't exist.");

        }

        [TestCase("Polina")]
        [TestCase("Maria")]
        public void ReportShouldReturnCorrectData(string name)
        {
            Gym gym = new Gym("SportGym", 10);
            Athlete athlete = new Athlete(name);
            gym.AddAthlete(athlete);
           
            string actualReport = gym.Report();
            string expectedReport = $"Active athletes at SportGym: {name}";
            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
