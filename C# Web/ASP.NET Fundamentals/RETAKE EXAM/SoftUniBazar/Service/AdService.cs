using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using SoftUniBazar.Service.Interfaces;

namespace SoftUniBazar.Service
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

        public async Task<IEnumerable<AdViewModel>> GetAllAdModelAsync()
        {
            return await dbContext.Ads
                .Select(x => new AdViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    OwnerName = x.Owner.UserName,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                    CategoryName = x.Category.Name

                })
                .ToListAsync();
        }

		public async Task<AddFormAdViewModel> GetAdModelAsync()
		{
			var categories = await dbContext.Categories
				.Select(x => new CategoryViewModel
				{
					Id = x.Id,
					Name = x.Name
				})
				.ToListAsync();

			var model = new AddFormAdViewModel
			{
				Categories = categories
			};

			return model;
		}

		public async Task AddAdAsync(string userId, AddFormAdViewModel model)
		{
			var ad = new Ad
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				ImageUrl = model.ImageUrl,
				CategoryId = model.CategoryId,
				CreatedOn = DateTime.UtcNow,
				OwnerId = userId
			};

			await dbContext.Ads.AddAsync(ad);
			await dbContext.SaveChangesAsync();
		}

		public async Task<AddFormAdViewModel?> GetAdByIdAsync(int id)
		{
			return await dbContext.Ads.Where(x => x.Id == id)
				.Select(x => new AddFormAdViewModel
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Price = x.Price,
					ImageUrl = x.ImageUrl,
					CategoryId = x.CategoryId,
					Categories = dbContext.Categories.Select(c => new CategoryViewModel
					{
                        Id = c.Id,
                        Name = c.Name
                    }).ToList()

				}).FirstOrDefaultAsync();
		}

		public async Task AddAdToMyCartAsync(string userId, AddFormAdViewModel model)
		{
			var alreadyAdded = await dbContext.AdBuyers.AnyAsync(x => x.BuyerId == userId && x.AdId == model.Id);

			if (!alreadyAdded)
			{
				var newUserAd = new AdBuyer
				{
					BuyerId = userId,
					AdId = model.Id
				};

				await dbContext.AdBuyers.AddAsync(newUserAd);
				await dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<AdViewModel>> GetMyAdsAsync(string id)
		{
			return await dbContext.AdBuyers.Where(x => x.BuyerId == id)
				.Select(x => new AdViewModel
				{
					Id = x.AdId,
					Name = x.Ad.Name,
					Description = x.Ad.Description,
					Price = x.Ad.Price,
					ImageUrl = x.Ad.ImageUrl,
					CategoryName = x.Ad.Category.Name,
					CreatedOn = x.Ad.CreatedOn,
					OwnerName = x.Ad.Owner.UserName

				})
				.ToListAsync();
		}

        public async Task RemoveAdFromMyCartAsync(string userId, AddFormAdViewModel model)
        {
            var userAd = await dbContext.AdBuyers.FirstOrDefaultAsync(x => x.BuyerId == userId && x.AdId == model.Id);

            if (userAd != null)
            {
                dbContext.AdBuyers.Remove(userAd);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EditAdAsync(string userId, AddFormAdViewModel model)
        {
			var existAd = await dbContext.Ads.FirstOrDefaultAsync(x => x.Id == model.Id);

			if (existAd != null)
			{

				existAd.Name = model.Name;
                existAd.Description = model.Description;
                existAd.Price = model.Price;
                existAd.ImageUrl = model.ImageUrl;
                existAd.CategoryId = model.CategoryId;
                existAd.CreatedOn = DateTime.UtcNow;
                existAd.OwnerId = userId;


               await dbContext.SaveChangesAsync();
            }

            
        }
    }
}
