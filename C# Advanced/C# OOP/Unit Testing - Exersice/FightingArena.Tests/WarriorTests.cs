namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ShouldCtorReturnCorrectData()
        {
            Warrior warrior = new Warrior("Polina", 10, 50);
            string dataName = warrior.Name;
            string expectedName = "Polina";

            int dataDamage = warrior.Damage;
            int expectedDamage = 10;

            int dataXP = warrior.HP;
            int expectedXP = 50;

            Assert.AreEqual(expectedName, dataName);
            Assert.AreEqual(expectedDamage, dataDamage);
            Assert.AreEqual(expectedXP, dataXP);
        }

        [TestCase("", 10, 50)]
        [TestCase(null, 10, 50)]
        public void ShouldPropNameThrowErrorForNullOrEmpty(string name, int damage, int xp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, xp);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase("Polina", 10, 50)]
        public void ShouldPropNameReturnCorrectData(string name, int damage, int xp)
        {
            Warrior warrior = new Warrior(name, damage, xp);
            string dataName = warrior.Name;
            string expectedName = "Polina";

            Assert.AreEqual(expectedName, dataName);
        }

        [TestCase("Polina", -10, 50)]
        [TestCase("Polina", 0, 50)]
        public void ShouldPropDamageThrowErrorForNegativeOrZeroNumber(string name, int damage, int xp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, xp);
            }, "Damage value should be positive!");
        }

        [TestCase("Polina", 10, 50)]
        public void ShouldPropDamageReturnCorrectData(string name, int damage, int xp)
        {
            Warrior warrior = new Warrior(name, damage, xp);
            int dataDamage = warrior.Damage;
            int expectedDamage = 10;

            Assert.AreEqual(expectedDamage, dataDamage);
        }

        [TestCase("Polina", 10, -50)]
        public void ShouldPropXPThrowErrorForNegativeNumber(string name, int damage, int xp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, xp);
            }, "HP should not be negative!");
        }

        [TestCase("Polina", 10, 50)]
        public void ShouldPropXPReturnCorrectData(string name, int damage, int xp)
        {
            Warrior warrior = new Warrior(name, damage, xp);
            int dataXP = warrior.HP;
            int expectedXP = 50;

            Assert.AreEqual(expectedXP, dataXP);
        }

        [TestCase("Maria", 20, 30)]
        [TestCase("Maria", 30, 10)]

        public void AttackShouldThrowExrrorIfITryDownXPUnder30(string name, int damage, int xp)
        {
            Warrior firstWarrior = new Warrior("Polina", 10, 50);
            Warrior secondWarrior = new Warrior(name, damage, xp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                secondWarrior.Attack(firstWarrior);
            }, "Your HP is too low in order to attack other warriors!");
            
        }

        [TestCase("Maria", 20, 30)]
        [TestCase("Maria", 30, 10)]

        public void AttackShouldThrowExrrorIfTryDownXPUnder30(string name, int damage, int xp)
        {
            Warrior firstWarrior = new Warrior("Polina", 10, 50);
            Warrior secondWarrior = new Warrior(name, damage, xp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                firstWarrior.Attack(secondWarrior);
            }, $"Enemy HP must be greater than 30 in order to attack him!");

        }

        [TestCase("Maria", 20, 50)]

        public void AttackShouldThrowExrrorIfDamageIsBiggerThanXP(string name, int damage, int xp)
        {
            Warrior firstWarrior = new Warrior("Polina", 60, 50);
            Warrior secondWarrior = new Warrior(name, damage, xp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                secondWarrior.Attack(firstWarrior);
            }, "You are trying to attack too strong enemy");

        }

        [Test]
        public void AttackShouldReturnCorrectDataWhenWasAttack()
        {
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 20, 50);
            secondWarrior.Attack(firstWarrior);

            int dataXP = firstWarrior.HP;
            int expectedXP = 40;

            Assert.AreEqual(expectedXP, dataXP);

        }

        [Test]
        public void AttackShouldReturnZeroIfAttackIsBigger()
        {
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 70, 50);
            secondWarrior.Attack(firstWarrior);

            int dataXP = firstWarrior.HP;
            int expectedXP = 0;

            Assert.AreEqual(expectedXP, dataXP);
        }

        [Test]
        public void AttackShouldReturnCorrectDataWhenAttack()
        {
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 10, 50);
            secondWarrior.Attack(firstWarrior);

            int dataXP = firstWarrior.HP;
            int expectedXP = 50;

            Assert.AreEqual(expectedXP, dataXP);
        }
    }
}