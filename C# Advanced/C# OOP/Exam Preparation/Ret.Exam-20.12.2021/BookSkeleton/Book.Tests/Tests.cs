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
    }
}