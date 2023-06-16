using Library.ViewModels;

namespace Library.Contracts
{
	public interface IBookService
	{
		Task AddBookToCollectionAsync(string userId, int id);
		Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
		Task GetBookByIdAsync(int id);
		Task<IEnumerable<MyBookViewModel>> GetMyBooksAsync(string id);
	}
}
