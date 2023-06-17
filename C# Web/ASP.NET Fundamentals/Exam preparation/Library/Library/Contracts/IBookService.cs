using Library.ViewModels;

namespace Library.Contracts
{
	public interface IBookService
	{
		Task AddBookToCollectionAsync(string userId, BookViewModel model);

		Task<IEnumerable<AllBookViewModel>> GetNewAddBookModelAsync();
		Task<BookViewModel?> GetBookByIdAsync(int id);
		Task<IEnumerable<MyBookViewModel>> GetMyBooksAsync(string id);

		Task RemoveBookFromCollectionAsync(string userId, BookViewModel model);

		Task<AddBookViewModel> GetBooksModelAsync();

		Task AddBookAsync(AddBookViewModel model);
	}
}
