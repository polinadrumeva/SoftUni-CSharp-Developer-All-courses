using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
	[Authorize]
	public class HouseController : Controller
	{
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			return View();
		}
	}
}
