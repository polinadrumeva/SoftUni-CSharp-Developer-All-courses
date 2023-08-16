using SoftUniBazar.Models;

namespace SoftUniBazar.Service.Interfaces
{
	public interface IAdService
	{
		Task<IEnumerable<AdViewModel>> GetAllAdModelAsync();

		Task<AddFormAdViewModel> GetAdModelAsync();
		Task<AddFormAdViewModel?> GetAdByIdAsync(int id);

		Task<IEnumerable<AdViewModel>> GetMyAdsAsync(string id);
        Task RemoveAdFromMyCartAsync(string userId, AddFormAdViewModel model);
        Task AddAdToMyCartAsync(string userId, AddFormAdViewModel model);
		Task AddAdAsync(string userId, AddFormAdViewModel model);

        Task EditAdAsync(string userId, AddFormAdViewModel model);
    }
}
