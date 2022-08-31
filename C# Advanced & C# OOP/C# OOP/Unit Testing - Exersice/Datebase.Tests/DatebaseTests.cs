namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void ShouldHaveExactlyLength()
        {
            Database database;
            Assert.Throws<InvalidOperationException>(() => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }


        [Test]
        public void CheckAddingInArray()
        { 
            Database database = new Database();
            database.Add(1);
            Assert.That(database.Count, Is.EqualTo(1));
        }


        [Test]
        public void ShouldCanNotAdd17Element()
        {
            Database database = new Database();
            int length = 16;
            for (int i = 0; i < length; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void ShouldCanNotRemoveFromEmptyArray()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void ShouldRemoveLastIndex()
        { 
            Database database = new Database(1, 2, 3, 4);
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(3));

        }

        [Test]
        public void ShouldFetchReturnAnArray()
        { 
            int[] numbers = new int[] { 1, 2, 3};
            Database database = new Database(numbers);
            int[] arrays = database.Fetch();
            Assert.AreEqual(numbers, arrays);
        }
    }
}
