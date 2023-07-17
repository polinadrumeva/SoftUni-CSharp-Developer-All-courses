using HouseRentingSystem.Data.Service.Interfaces;
using HouseRentingSystem.ViewModels.Agent;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
	[Authorize]
	public class AgentController : Controller
	{
		private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }


        [HttpGet]
		public async Task<IActionResult> Become()
		{
			var userId = this.User.GetId();
			var agentExist = await agentService.AgentExistById(userId);
			if (agentExist)
			{
                return BadRequest();
            }

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
            var userId = this.User.GetId();
            var agentExist = await agentService.AgentExistById(userId);
            if (agentExist)
			{
                return BadRequest();
            }

            var isPhoneExist = await agentService.AgentExistByPhone(model.PhoneNumber);
            if (isPhoneExist)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "This phone number is already taken.");
            }

            if (!ModelState.IsValid)
			{
                return View(model);
            }

            var hasRents = await agentService.HasRentsByUserId(userId);
            if (hasRents)
            {
                ModelState.AddModelError(string.Empty, "You cannot become agent because you have rents.");
                return RedirectToAction("Mine", "House");
            }

            await agentService.Create(userId, model);

            return RedirectToAction("All", "House");
        }
	}
}
