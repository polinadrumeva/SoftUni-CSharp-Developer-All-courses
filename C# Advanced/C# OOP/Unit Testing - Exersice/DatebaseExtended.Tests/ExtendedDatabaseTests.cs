namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
       
        [Test]
        public void ShouldHaveExactlyLength()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                Person firstPerson = new Person(i, $"{i}");
                database.Add(firstPerson);
            }

            Person newPerson = new Person(84392, "Poli");
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(newPerson);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //[Test]
        //public void ShouldAddRangeSuccessful()
        //{
        //    Database data = new Database();
        //    Person[] people = new Person[16];
        //    for (int i = 0; i < 16; i++)
        //    {
        //        Person firstPerson = new Person(i, $"{i}");
        //        people[i] = firstPerson;
        //    }
        //    data.AddRange(people);
        //    Assert.That(data.Count, Is.EqualTo(people.Length));
        //}

        [Test]
        public void ShouldThrowExceptionIfAddBiggerThen16Range()
        {
            Database data = new Database();
            Person[] people = new Person[19];
            for (int i = 0; i < 19; i++)
            {
                Person firstPerson = new Person(i, $"{i}");
                people[i] = firstPerson;
            }

            Assert.Throws<ArgumentException>(() =>
            {
                new Database(people);
            }, "Provided data length should be in range [0..16]!");
            
        }

        [Test]
        public void CheckAddingInArray()
        {
            Database data = new Database();
            Person firstPerson = new Person(123456, "Polina");
            data.Add(firstPerson);
            Assert.That(data.Count, Is.EqualTo(1));
        }


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

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername("");
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
        public void ShouldThrowExceptionIfLowerCase()
        {
            Database database = new Database();
            Person firstPerson = new Person(123456, "Polina");
            Assert.That(() => database.FindByUsername("polina"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldReturnPersonWithThatUsernameSuccessful()
        {
            Database db = new Database();
            Person person = new Person(12345, "Polina");
            db.Add(person);
            Person result = db.FindByUsername("Polina");

            Assert.AreEqual((result.UserName, result.Id), (person.UserName, person.Id));
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

        [Test]
        public void ShouldReturnPersonWithThatIdSuccess()
        {
            Database db = new Database(new Person(123456, "Polina"));
            Person result = db.FindById(123456);
            Person expected = new Person(123456, "Polina");
            Assert.AreEqual((result.Id, result.UserName),
                (expected.Id, expected.UserName));
        }
    }
}