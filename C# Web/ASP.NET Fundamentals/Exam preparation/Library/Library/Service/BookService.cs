using Library.Contracts;
using Library.Data;
using Library.Database.Models;
using Library.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
	public class BookService : IBookService
	{
		private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



		public async Task AddBookToCollectionAsync(string userId, BookViewModel model)
		{
			var alreadyAdded = await dbContext.IdentityUserBooks.AnyAsync(x => x.CollectorId == userId && x.BookId == model.Id);

			if (!alreadyAdded)
			{
				var newUserBook = new IdentityUserBook
				{
					CollectorId = userId,
					BookId = model.Id
				};

				await dbContext.IdentityUserBooks.AddAsync(newUserBook);
				await dbContext.SaveChangesAsync();
			}

		}

		public async Task<IEnumerable<AllBookViewModel>> GetNewAddBookModelAsync()
		{
			return await dbContext.Books
				.Select(x => new AllBookViewModel
				{
					Id = x.Id,
					Title = x.Title,
					Author = x.Author,
					ImageUrl = x.ImageUrl,
					Rating = x.Rating,
					Category = x.Category.Name
				})
				.ToListAsync();
		}

		public async Task<BookViewModel?> GetBookByIdAsync(int id)
		{
			return await dbContext.Books.Where(x => x.Id == id)
				.Select(x => new BookViewModel
				{
					Id = x.Id,
					Title = x.Title,
					Author = x.Author,
					ImageUrl = x.ImageUrl,
					Rating = x.Rating,
					CategoryId = x.CategoryId,
					Description = x.Description
				}).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<MyBookViewModel>> GetMyBooksAsync(string id)
		{
			return await dbContext.IdentityUserBooks.Where(x => x.CollectorId == id)
				.Select(x => new MyBookViewModel
				{
					Id = x.Book.Id,
					Title = x.Book.Title,
					Author = x.Book.Author,
					ImageUrl = x.Book.ImageUrl,
					Description = x.Book.Description,
					Category = x.Book.Category.Name
				})
				.ToListAsync();
		}

		public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel model)
		{
			var userBook = await dbContext.IdentityUserBooks.FirstOrDefaultAsync(x => x.CollectorId == userId && x.BookId == model.Id);

			if (userBook != null)
			{
				dbContext.IdentityUserBooks.Remove(userBook);
				await dbContext.SaveChangesAsync();
			}
		}

		public async Task<AddBookViewModel> GetBooksModelAsync()
		{
			var catgories = await dbContext.Categories
				.Select(x => new CategoryViewModel
				{
					Id = x.Id,
					Name = x.Name
				})
				.ToListAsync();

			var model = new AddBookViewModel
			{
				Categories = catgories
			};

			return model;
		}

		public async Task AddBookAsync(AddBookViewModel model)
		{
			 var book = new Book
			 { 
				Title = model.Title,
				Author = model.Author,
				Description = model.Description,
				ImageUrl = model.Url,
				Rating = (decimal)model.Rating,
				CategoryId = model.CategoryId
			 };

			await dbContext.Books.AddAsync(book);
			await dbContext.SaveChangesAsync();
			 
 		}
	}
}
