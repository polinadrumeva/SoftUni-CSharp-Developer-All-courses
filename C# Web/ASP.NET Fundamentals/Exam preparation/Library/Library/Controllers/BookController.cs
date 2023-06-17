using Library.Contracts;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;

		public BookController(IBookService bookService)
		{
			this.bookService = bookService;
		}
		public async Task<IActionResult> All()
		{
			var model = await bookService.GetNewAddBookModelAsync();
			
			return View(model);
		}

		public async Task<IActionResult> Mine()
		{
			var model = await bookService.GetMyBooksAsync(GetUserId());

			return View(model);
		}

		public async Task<IActionResult> AddToCollection(int id)
		{
			var book = await bookService.GetBookByIdAsync(id);

			if (book == null)
			{
				return RedirectToAction(nameof(All));
			}

			var userId = GetUserId();

			await bookService.AddBookToCollectionAsync(userId, book);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> RemoveFromCollection(int id)
		{
			var book = await bookService.GetBookByIdAsync(id);

			if (book == null)
			{
				return RedirectToAction(nameof(Mine));
			}

			var userId = GetUserId();

			await bookService.RemoveBookFromCollectionAsync(userId, book);

			return RedirectToAction(nameof(Mine
				));
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = await bookService.GetBooksModelAsync();
			
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddBookViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await bookService.AddBookAsync(model);

			return RedirectToAction(nameof(All));
		}
	}
}
