using HouseRentingSystem.Data.Service.Interfaces;
using HouseRentingSystem.ViewModels.House;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
	[Authorize]
	public class HouseController : Controller
	{
		private readonly ICategoryService categoryService;
		private readonly IAgentService agentService;

		public HouseController(ICategoryService categoryService, IAgentService agentService)
		{
            this.categoryService = categoryService;
			this.agentService = agentService;
        }

		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var isAgent = await this.agentService.AgentExistById(this.User.GetId()!);
			if (!isAgent) 
			{
				return RedirectToAction("Become", "Agent");
			}

			var formModel = new HouseFormModel()
			{
				Categories = await this.categoryService.AllCategoriesAsync()
			};

            return View(formModel);
        }
	}
}
