using HouseRentingSystem.Data.Service.Interfaces;
using HouseRentingSystem.ViewModels;

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
			throw new NotImplementedException();
		}
	}
}
