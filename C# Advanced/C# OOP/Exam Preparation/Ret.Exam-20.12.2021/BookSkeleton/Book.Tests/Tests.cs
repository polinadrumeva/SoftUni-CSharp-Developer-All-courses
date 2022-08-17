namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void ConstructorReturnCorrectData()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            string actualName = book.BookName;
            string expectedName = "Ana Karenina";

            string actualAuthor = book.Author;
            string expectedAuthor = "Tolstoi";

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAuthor, actualAuthor);

        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowExceptionIfIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "Tolstoi");
            }, $"Invalid {nameof(name)}!");

        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorShouldThrowExceptionIfIsNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Ana Karenina", author);
            }, $"Invalid {nameof(author)}!");

        }

        [Test]
        public void AddFootnoteShouldThrowExceptionIfAlreadyExist()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            book.AddFootnote(1, "Very good start to the book");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Beautiful heroine");
            }, "Footnote already exists!");

        }

        [Test]
        public void AddFootnoteShouldReturnCorrectData()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            book.AddFootnote(1, "Very good start to the book");
            book.AddFootnote(2, "Beautiful heroine");

            int actualCount = book.FootnoteCount;
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void FindFootnoteShouldThrowExceptionIfNotExist()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            book.AddFootnote(1, "Very good start to the book");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(3);
            }, "Footnote doesn't exists!");

        }

        [Test]
        public void FindFootnoteShouldReturnCorrectData()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            book.AddFootnote(1, "Very good start to the book");
            string actualData = book.FindFootnote(1);
            string expectedData = "Footnote #1: Very good start to the book";

            Assert.AreEqual(expectedData, actualData);

        }

        [Test]
        public void AlterFootnoteShouldThrowExceptionIfNotExist()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            book.AddFootnote(1, "Very good start to the book");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(3, "Heroine is very intersting personage.");
            }, "Footnote doesn't exists!");

        }

        [Test]
        public void AlterFootnoteShouldReturnCorrectData()
        {
            Book book = new Book("Ana Karenina", "Tolstoi");
            book.AddFootnote(1, "Very good start to the book");
            book.AlterFootnote(1, "Heroine is very intersting personage.");

            string actualData = book.FindFootnote(1);
            string expectedData = "Footnote #1: Heroine is very intersting personage.";

            Assert.AreEqual(expectedData, actualData);

        }
    }
}