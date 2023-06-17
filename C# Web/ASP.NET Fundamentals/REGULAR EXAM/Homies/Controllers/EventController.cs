using Homies.Service.Intefraces;
using Microsoft.AspNetCore.Mvc;
using Homies.Service;
using Homies.ViewModels.ViewModels;

namespace Homies.Controllers
{
	public class EventController : BaseController
	{
		private readonly IEventService eventService;

		public EventController(IEventService eventService)
		{
			this.eventService = eventService;
		}

		public async Task<IActionResult> All()
		{
			var model = await eventService.GetAllEventsAsync();
			
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
            var model = await eventService.GetEventViewModelsAsync();
			
			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Add(AddEventViewModel model)
		{
            if (!ModelState.IsValid)
			{
                return View(model);
            }
			await eventService.AddEventAsync(model, GetUserId());

            return RedirectToAction("All", "Event");
        }

		public async Task<IActionResult> Joined(int id)
		{
            var userId = GetUserId();

            var model = await eventService.GetMyEventsAsync(userId);

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var userId = GetUserId();

            var model = await eventService.GetEventByIdAsync(id, userId);

            if (model == null)
            {
                return RedirectToAction(nameof(All));
            }


            await eventService.AddMeToEventAsync(userId, model);

			return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var userId = GetUserId();
            var eventToLeave = await eventService.GetEventByIdAsync(id, userId);

            if (eventToLeave == null)
            {
                return RedirectToAction(nameof(Joined));
            }


            await eventService.LeaveEventAsync(userId, eventToLeave);

            return RedirectToAction(nameof(All));
        }

    }
}
