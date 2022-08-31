namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void CapacityShouldThrowExceptionIfValueIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               RobotManager manager = new RobotManager(capacity);
           }, "Invalid capacity!");
        }

        [Test]
        public void CapacityShouldReturnCorrectData()
        {
            RobotManager manager = new RobotManager(60);
            int actualCapacity = manager.Capacity;
            int expectedCapacity = 60;
            Assert.AreEqual(actualCapacity, expectedCapacity);
        }

        [Test]
        public void CountShouldReturnCorrectData()
        {
            RobotManager manager = new RobotManager(5);
            Robot firstRobot = new Robot("Polina", 100);
            Robot secondRobot = new Robot("Maria", 1000);
            manager.Add(firstRobot);
            manager.Add(secondRobot);
            int actualCount = manager.Count;
            int expectedCount= 2;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionIfTryToAddExistRobot()
        {
            RobotManager manager = new RobotManager(5);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);

            Assert.Throws<InvalidOperationException>(() =>
           {
               manager.Add(firstRobot);
           }, $"There is already a robot with name {firstRobot.Name}!");
        }

        [Test]
        public void AddShouldThrowExceptionIfManagerIsFull()
        {
            RobotManager manager = new RobotManager(1);
            Robot firstRobot = new Robot("Polina", 100);
            Robot secondRobot = new Robot("Maria", 1000);
            manager.Add(firstRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(secondRobot);
            }, "Not enough capacity!");
        }

        [Test]
        public void RemoveShouldThrowExceptionIfRobotNotExist()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("Maria");
            }, $"Robot with the name Maria doesn't exist!");
        }

        [Test]
        public void RemoveShouldReturnCorrectData()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            Robot secondRobot = new Robot("Maria", 1000);
            manager.Add(firstRobot);
            manager.Add(secondRobot);
            manager.Remove("Polina");
            int actualCount = manager.Count;
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void WorkShouldThrowExceptionIfRobotNotExist()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Maria", "Shopper", 10);
            }, $"Robot with the name Maria doesn't exist!");
        }

        [Test]
        public void WorkShouldThrowExceptionIfBatteryIsLowerThenUsage()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Polina", "Lawyer", 200);
            }, $"{firstRobot.Name} doesn't have enough battery!");
        }

        [Test]
        public void WorkShouldReturnCorrectData()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);
            manager.Work("Polina", "Lawyer", 50);
            int actualBattery = firstRobot.Battery;
            int expectedBattery = 50;

            Assert.AreEqual(expectedBattery, actualBattery);

        }

        [Test]
        public void ChargeShouldThrowExceptionIfRobotNotExist()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("Maria");
            }, $"Robot with the name Maria doesn't exist!");
        }

        [Test]
        public void ChargeShouldReturnCorrectData()
        {
            RobotManager manager = new RobotManager(10);
            Robot firstRobot = new Robot("Polina", 100);
            manager.Add(firstRobot);
          
            manager.Work("Polina", "Lawyer", 50);
            manager.Charge("Polina");
            int actualBattery = firstRobot.Battery;
            int expectedBattery = 100;

            Assert.AreEqual(expectedBattery, actualBattery);

        }
    }
}
