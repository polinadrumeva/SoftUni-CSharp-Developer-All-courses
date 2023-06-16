using Library.Contracts;
using Library.Data;
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

		public Task AddBookToCollectionAsync(string userId, int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
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

		public Task GetBookByIdAsync(int id)
		{
			throw new NotImplementedException();
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
	}
}
