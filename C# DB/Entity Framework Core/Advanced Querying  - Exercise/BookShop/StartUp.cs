namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Castle.DynamicProxy.Generators;
    using Data;
    using Initializer;
    using System.Diagnostics;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //02.Age Restriction
            //var command = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, command);
            //Console.WriteLine(result);

            //03. Golden Books
            //var result = GetGoldenBooks(db);
            //Console.WriteLine(result);

            //04. Books by Price
            //var result = GetBooksByPrice(db);
            //Console.WriteLine(result);
            //Console.WriteLine(result.Length);

            //05. Not Released In
            //var year = int.Parse(Console.ReadLine());
            //var result = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(result);

            //06. Book Titles by Category
            //var input = Console.ReadLine();
            //var result = GetBooksByCategory(db, input);
            //Console.WriteLine(result);

            //07. Released Before Date
            //var input = Console.ReadLine();
            //var result = GetBooksReleasedBefore(db, input);
            //Console.WriteLine(result);
            //Console.WriteLine(result.Length);

            //08.Author Search
            //var input = Console.ReadLine();
            //var result = GetAuthorNamesEndingIn(db, input);
            //Console.WriteLine(result);
            //Console.WriteLine(result.Length);

            //09. Book Search
            //var input = Console.ReadLine();
            //var result = GetBookTitlesContaining(db, input);
            //Console.WriteLine(result);

            //10. Book Search by Author
            //var input = Console.ReadLine();
            //var result = GetBooksByAuthor(db, input);
            //Console.WriteLine(result);


            //11. Count Books
            //var input = int.Parse(Console.ReadLine());
            //var result = CountBooks(db, input);
            //Console.WriteLine(result);

            //12. Total Book Copies
            //var result = CountCopiesByAuthor(db);
            //Console.WriteLine(result);

            //13. Profit by Category
            //var result = GetTotalProfitByCategory(db);
            //Console.WriteLine(result);

            //14. Most Recent Books
            //var result = GetMostRecentBooks(db);
            //Console.WriteLine(result);

            //15.Increase Prices
            //ncreasePrices(db);

            //16. Remove Books
            var result = RemoveBooks(db);
            Console.WriteLine(result);

        }

        //02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object ageObj);
            AgeRestriction ageRestriction;
            if (hasParsed)
            {
                ageRestriction = (AgeRestriction)ageObj;
                var books = context.Books.Where(b => b.AgeRestriction == ageRestriction)
                                     .Select(b => b.Title).ToArray();

                foreach (var book in books.OrderBy(b => b))
                {
                    sb.AppendLine(book);
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }

        //03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var goldenBooks = context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                                        .OrderBy(b => b.BookId)
                                        .Select(b => b.Title)
                                        .ToArray();
            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //04. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books.Where(b => b.Price >= 40)
                                        .OrderByDescending(b => b.Price)
                                        .Select(b => new { b.Title, b.Price })
                                        .ToArray();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        //05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var books = context.Books.Where(b => b.ReleaseDate.Value.Year != year)
                                        .OrderBy(b => b.BookId)
                                        .Select(b => b.Title)
                                        .ToArray();
            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToArray();

            var sb = new StringBuilder();

            var books = context.Books.Where(b => b.BookCategories.Any(bc => array.Contains(bc.Category.Name.ToLower()))).ToArray();

            foreach (var book in books.OrderBy(book => book.Title))
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateInFormat = DateTime.Parse(date);

            var sb = new StringBuilder();

            var books = context.Books.Where(b => b.ReleaseDate < dateInFormat)
                            .OrderByDescending(b => b.ReleaseDate)
                            .Select(b => new { b.Title, b.EditionType, b.Price})
                            .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        //08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors.Where(a => a.FirstName.EndsWith(input))
                            .Select(a => new { a.FirstName, a.LastName})
                            .ToArray();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        //09. Book Search

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        { 
            var sb = new StringBuilder();

            var authors = context.Authors.Where(a => a.LastName.StartsWith(input.ToLower()))
                                .Select(a => new {a.FirstName, a.LastName, a.Books })
                                .ToArray();

            foreach (var a in authors)
            {
                foreach (var b in a.Books.OrderBy(b => b.BookId))
                {
                    sb.AppendLine($"{b.Title} ({a.FirstName} {a.LastName})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.Where(b => b.Title.Length > lengthCheck).Count();

            return books;
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authors = context.Authors.Select(a => new { a.FirstName, a.LastName, a.Books }).ToArray();

            foreach (var a in authors.OrderByDescending(a => a.Books.Sum(b => b.Copies)))
            {
                var books = a.Books.Sum(b => b.Copies);

                sb.AppendLine($"{a.FirstName} {a.LastName} - {books}");
                
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context.Categories
                                .Select(c => new
                                 {
                                      CategoryName = c.Name,
                                      Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)

                                 })
                                .OrderByDescending(c => c.Profit)
                                .ThenBy(c => c.CategoryName)
                                .ToArray();

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.CategoryName} ${c.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var recentBooks = context.Categories
                                 .Select(c => new
                                  {
                                    CategoryName = c.Name,
                                    MostRecentBooks = c.CategoryBooks.OrderByDescending(c => c.Book.ReleaseDate).Select(cb => new
                                      {
                                        BookName = cb.Book.Title,
                                        YearPublished = cb.Book.ReleaseDate.Value.Year
                                  }).Take(3)
                                 })
                                .OrderBy(c => c.CategoryName)
                                .ToArray();

            foreach (var category in recentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookName} ({book.YearPublished})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToArray();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();
            var count = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return count;
        }
    }
}



