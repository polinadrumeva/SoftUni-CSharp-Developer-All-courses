namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Start()
        { 
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");
            Person secondPerson = new Person(345678, "Maria");
        }
        [Test]
        public void ShouldHaveExactlyLength()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");
            for (int i = 0; i < 16; i++)
            {
                database.Add(firstPerson);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(firstPerson);
            }, "Array's capacity must be exactly 16 integers!");
        }


        //[Test]
        //public void CheckAddingInArray()
        //{
        //    Database database = new Database();
        //    database.Add(1);
        //    Assert.That(database.Count, Is.EqualTo(1));
        //}


        //[Test]
        //public void ShouldCanNotAdd17Element()
        //{
        //    Database database = new Database();
        //    int length = 16;
        //    for (int i = 0; i < length; i++)
        //    {
        //        database.Add(i);
        //    }

        //    Assert.Throws<InvalidOperationException>(() => database.Add(17));
        //}


        //[Test]
        //public void ShouldFetchReturnAnArray()
        //{
        //    int[] numbers = new int[] { 1, 2, 3 };
        //    Database database = new Database(numbers);
        //    int[] arrays = database.Fetch();
        //    Assert.AreEqual(numbers, arrays);
        //}

        [Test]
        public void ShouldThrowExceptionIfUserExist()
        {
            Database data = new Database();
            Person firstPerson = new Person(123456, "Polina");
            Person secondPerson = new Person(233244, "Polina");
            for (int i = 0; i < 1; i++)
            {
                data.Add(firstPerson);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(secondPerson);
            }, "There is already user with this username!");
        }


        [Test]
        public void ShouldThrowExceptionIfIdIsSame()
        {
            Database data = new Database();
            Person firstPerson = new Person(123456, "Polina");
            Person secondPerson = new Person(123456, "Maria");
            for (int i = 0; i < 1; i++)
            {
                data.Add(firstPerson);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(secondPerson);
            }, "There is already user with this Id!");
        }

        [Test]
        public void ShouldCanNotRemoveFromEmptyArray()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void ShouldRemoveLastPerson()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");
            database.Add(firstPerson);
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(0));

        }

        [Test]
        public void ShouldThrowInvalidExceptionIfUserNotExist()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Maria");
            }, "No user is present by this username!");
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfUserValueIsNull()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            }, "Username parameter is null!");
        }

        [Test]
        public void ShouldThrowInvalidExceptionIfIDNotExist()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(23453);
            }, "No user is present by this ID!");
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfIDIsNegative()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-123456);
            }, "Id should be a positive number!");
        }
    }
}