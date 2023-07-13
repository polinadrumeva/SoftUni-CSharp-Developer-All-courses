using HouseRentingSystem.Data.Service.Interfaces;
using HouseRentingSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data.Service
{
	public class HouseService : IHouseService
	{
		private readonly HouseRentingDbContext dbContext;

        public HouseService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> GetLastThreeHousesAsync()
		{
			var lastThreeHouses = await dbContext.Houses
									.OrderByDescending(h => h.CreatedOn)
                                    .Take(3)
                                    .Select(h => new IndexViewModel()
				                    {
                                           Id = h.Id.ToString(),
                                           Title = h.Title,
                                           ImageUrl = h.ImageUrl,
                   
                                    }).ToArrayAsync();

            return lastThreeHouses;
		}
	}
}
