using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using SoftUniBazar.Service.Interfaces;

namespace SoftUniBazar.Controllers
{
	public class AdController : BaseController
	{
		private readonly IAdService adService;

		public AdController(IAdService adService)
		{
			this.adService = adService;
		}

		public async Task<IActionResult> All()
		{
			var model = await adService.GetAllAdModelAsync();

			return View(model);
		}

		public async Task<IActionResult> AddToCart(int id)
		{

			var ad = await adService.GetAdByIdAsync(id);

			if (ad == null)
			{
				return RedirectToAction(nameof(All));
			}


			var userId = GetUserId();

			await adService.AddAdToMyCartAsync(userId, ad);

			return RedirectToAction(nameof(Cart));
		}

		public async Task<IActionResult> Cart()
		{
			var model = await adService.GetMyAdsAsync(GetUserId());

			return View(model);
		}

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var ad = await adService.GetAdByIdAsync(id);

            if (ad == null)
            {
                return RedirectToAction(nameof(Cart));
            }

            var userId = GetUserId();

            await adService.RemoveAdFromMyCartAsync(userId, ad);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = await adService.GetAdModelAsync();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddFormAdViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var userId = GetUserId();

			await adService.AddAdAsync(userId, model);

			return RedirectToAction(nameof(All));
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await adService.GetAdByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddFormAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = GetUserId();

            await adService.EditAdAsync(userId, model);

            return RedirectToAction(nameof(All));
        }
    }
}
