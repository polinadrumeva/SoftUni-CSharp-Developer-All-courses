namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CountShouldReturnCorrectData()
        {
            Arena arena = new Arena();
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 20, 50);
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            int dataCount = arena.Count;
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, dataCount);
        }

        [Test]
        public void ShouldThrowErrorIfTryEnrollSamePerson()
        {
            Arena arena = new Arena();
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            arena.Enroll(firstWarrior);
            Warrior secondWarrior = new Warrior("Polina", 20, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(secondWarrior);
            }, "Warrior is already enrolled for the fights!");

        }

        [Test]
        public void EnrollReturnCorrectAdding()
        {
            Arena arena = new Arena();
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 10, 60);
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            int dataCount = arena.Count;
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, dataCount);
        }


        [TestCase("Polina", "Maria")]
        public void FightShouldAttackSuccessful(string attacker, string defender)
        {
            Arena arena = new Arena();
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 10, 60);
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            Warrior attackerWarrior = arena.Warriors.FirstOrDefault(x => x.Name == attacker);
            Warrior defenderWarrior = arena.Warriors.FirstOrDefault(x => x.Name == defender);
            attackerWarrior.Attack(defenderWarrior);

            string dataAttWarior = attackerWarrior.Name;
            string expectedAttWarior = "Polina";

            string dataDefendedWarr = defenderWarrior.Name;
            string expectedDefendedWarior = "Maria";

            Assert.AreEqual(expectedAttWarior, dataAttWarior);
            Assert.AreEqual(expectedDefendedWarior, dataDefendedWarr);

        }

        [TestCase("Poli", "Maria")]
        public void FightShouldAThrowExceptionIfCantFindAttacker(string attacker, string defender)
        {
            Arena arena = new Arena();
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 10, 60);
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);


            Assert.That(() => arena.Fight(attacker, defender), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attacker} enrolled for the fights!"));


        }

        [TestCase("Polina", "Mari")]
        public void FightShouldAThrowExceptionIfCantFindDefender(string attacker, string defender)
        {
            Arena arena = new Arena();
            Warrior firstWarrior = new Warrior("Polina", 10, 60);
            Warrior secondWarrior = new Warrior("Maria", 10, 60);
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);


            Assert.That(() => arena.Fight(attacker, defender), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defender} enrolled for the fights!"));


        }
    }
}
