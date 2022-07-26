using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void ShouldLoosesHealthIfIsAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            
            //Act
            dummy.TakeAttack(2);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(8));
        }

        [Test]
        public void ThrowExceptionIfIsDeadButIsAttacked()
        { 
            //Arrenge
            Dummy dummy = new Dummy(0, 10);
            
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void ShouldCanGiveXPIfIsDead()
        {
            //Arrenge
            Dummy dummy = new Dummy(0, 10);

            //Act & Assert
            Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
            
        }

        [Test]
        public void ShouldCantGiveXPIfIsAlive()
        {
            //Arrenge
            Dummy dummy = new Dummy(10, 10);
            
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

        }
        
    }
}