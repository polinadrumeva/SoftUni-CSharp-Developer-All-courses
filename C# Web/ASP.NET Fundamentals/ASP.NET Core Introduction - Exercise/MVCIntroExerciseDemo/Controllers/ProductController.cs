using Microsoft.AspNetCore.Mvc;
using MVCIntroExerciseDemo.Models.Products;

namespace MVCIntroExerciseDemo.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{ 
				Id = 1, 
				Name = "Dress", 
				Price = 100.20M
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Shirt",
				Price = 13.30M
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Shoes",
				Price = 220.00M
			}

		};

		public IActionResult All()
		{
			return View(products);
		}
	}
}
