using HouseRentingSystem.Data.Service.Interfaces;
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
	}
}
