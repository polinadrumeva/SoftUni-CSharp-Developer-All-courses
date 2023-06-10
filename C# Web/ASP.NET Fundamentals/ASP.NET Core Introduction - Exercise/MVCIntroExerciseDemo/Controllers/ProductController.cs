using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroExerciseDemo.Models.Products;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

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
		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
            if (keyword != null)
            {
				var foundProducts = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
				return View(foundProducts);
            }

			return View(products);
		}

		public IActionResult ById(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);

			if (product == null)
			{
				return BadRequest();
			}

			return View(product);
		}

		public IActionResult AllAsJson()
		{ 
			return Json(products, new JsonSerializerOptions()
			{ 
				WriteIndented = true
			});
		}

		public IActionResult AllAsText()
		{
			var text = string.Empty;
			foreach (var product in products)
			{
				text += $"Product {product.Id}: {product.Name} - {product.Price} lv.";
				text += "\r\n";
			}

			return Content(text);
            
		}

		public IActionResult AllAsTextFile()
		{
			var sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }

			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=product.txt");
			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
	}
}
