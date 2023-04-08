namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
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

            //05. Not Released In
            //var year = int.Parse(Console.ReadLine());
            //var result = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(result);

            //06. Book Titles by Category
            var input = Console.ReadLine();
            var result = GetBooksByCategory(db, input);
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

            var books = context.Books.Where(b => b.Price > 40)
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
            string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c=> c.ToLower()).ToArray();
            
            var sb = new StringBuilder();

            var books = context.Books.Where(b => b.BookCategories.Any(bc => array.Contains(bc.Category.Name.ToLower()))).ToArray();
            
            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
    }
}


