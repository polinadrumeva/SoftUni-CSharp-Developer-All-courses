using Microsoft.AspNetCore.Mvc;
using MVCIntroExerciseDemo.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MVCIntroExerciseDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello, World!";
            
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is my first ASP.NET Core MVC App";

            return View();
        }

		public IActionResult Numbers()
		{
			return View();
		}
		[HttpGet]
		public IActionResult NumbersToN()
		{
			ViewBag.Count = 0;
			return this.View();
		}

		[HttpPost]
		public IActionResult NumbersToN(int count = 0)
		{
			ViewBag.Count = count;
			return this.View();
		}

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}