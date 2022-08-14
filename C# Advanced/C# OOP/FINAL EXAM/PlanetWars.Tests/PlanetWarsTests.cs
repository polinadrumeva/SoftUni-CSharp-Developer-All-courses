using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [TestCase(-100)]
            public void PriceShouldThrowExceptionIfValueIsNegative(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Makarov", price, 100);
                }, "Price cannot be negative.");
            }

            [Test]
            public void PriceShouldReturnCorrectData()
            {
                Weapon weapon = new Weapon("Makarov", 200, 100);
                double actualPrice = weapon.Price;
                double expectedPrice = 200;

                Assert.AreEqual(expectedPrice, actualPrice);
            }

            [TestCase(null)]
           [TestCase("")]
            public void NameShouldThrowExceptionIfValueIsNullOrEmtty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 100);
                }, "Invalid planet Name");
            }

            [Test]
            public void NameShouldReturnCorrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                string actualName = planet.Name;
                string expectedName = "Pluton";

                Assert.AreEqual(expectedName, actualName);
            }

            [TestCase(-10)]
            public void BudgetShouldThrowExceptionIfValueIsNegative(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Pluton", budget);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void BudgetShouldReturnCorrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                double actualBudget = planet.Budget;
                double expectedBudget = 200;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void ProfitShouldReturnCorrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                planet.Profit(100);
                double actualProfit = planet.Budget;
                double expectedProfit = 300;

                Assert.AreEqual(expectedProfit, actualProfit);
            }

            [Test]
            public void SpendFundsShouldThrowExceptionIfAmountIsBiggerThenBudget()
            {
                Planet planet = new Planet("Pluton", 200);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(300);
                }, $"Not enough funds to finalize the deal.");
            }

            [Test]
            public void SpendFundsShouldReturnCOrrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                planet.SpendFunds(100);

                double actualBudget = planet.Budget;
                double expectedBudget = 100;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void AddWeaponShouldThrowExceptionIfWeaponAlreadyExist()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                }, $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            public void AddWeaponShouldReturnCOrrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                planet.AddWeapon(weapon);

                double actualCount = planet.Weapons.Count;
                double expectedCount = 1;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void RemoveWeaponShouldReturnCOrrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Makarov");

                double actualCount = planet.Weapons.Count;
                double expectedCount = 0;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void UpgradeShouldThrowExceptionIfWeaponNotExist()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Glog");
                }, $"Glog does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void UpgradeWeaponShouldReturnCorrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Makarov");

                double actualLevel = weapon.DestructionLevel;
                double expectedLevel = 101;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [Test]
            public void MilitaryRatioShouldReturnCorrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                Weapon weapon1 = new Weapon("Glog", 200, 50);
                Weapon weapon2 = new Weapon("Kalasnikov", 2500, 200);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                double actualRatio = planet.MilitaryPowerRatio;
                double expectedRatio = 350;

                Assert.AreEqual(expectedRatio, actualRatio);
            }


            [Test]
            public void DistructShouldThrowExceptionIFOpponentDistructIsGreater()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                Weapon weapon1 = new Weapon("Glog", 200, 50);
                Weapon weapon2 = new Weapon("Kalasnikov", 2500, 200);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);


                Planet opponenPlanet = new Planet("Mars", 2000);
                Weapon opponentweapon1 = new Weapon("Makarov", 2000, 1000);
                Weapon opponentweapon2 = new Weapon("Glog", 200, 50);
                Weapon opponentweapon3 = new Weapon("Kalasnikov", 2500, 200);
                opponenPlanet.AddWeapon(opponentweapon1);
                opponenPlanet.AddWeapon(opponentweapon2);
                opponenPlanet.AddWeapon(opponentweapon3);

               Assert.Throws<InvalidOperationException> (() =>
               {
                   planet.DestructOpponent(opponenPlanet);
               }, $"{opponenPlanet.Name} is too strong to declare war to!");
            }

            [Test]
            public void DistructShouldReturnCorrectData()
            {
                Planet planet = new Planet("Pluton", 200);
                Weapon weapon = new Weapon("Makarov", 2000, 100);
                Weapon weapon1 = new Weapon("Glog", 200, 50);
                Weapon weapon2 = new Weapon("Kalasnikov", 2500, 200);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);


                Planet opponenPlanet = new Planet("Mars", 2000);
                Weapon opponentweapon1 = new Weapon("Makarov", 2000, 10);
                Weapon opponentweapon2 = new Weapon("Glog", 200, 50);
                Weapon opponentweapon3 = new Weapon("Kalasnikov", 2500, 20);
                opponenPlanet.AddWeapon(opponentweapon1);
                opponenPlanet.AddWeapon(opponentweapon2);
                opponenPlanet.AddWeapon(opponentweapon3);

                string actualReturn = planet.DestructOpponent(opponenPlanet);
                string expectedReturn = "Mars is destructed!";

                Assert.AreEqual(expectedReturn, actualReturn);
            }


        }

        
    }
}
