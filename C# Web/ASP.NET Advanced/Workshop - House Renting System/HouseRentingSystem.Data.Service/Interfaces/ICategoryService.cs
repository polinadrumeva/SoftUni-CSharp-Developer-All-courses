
using HouseRentingSystem.ViewModels.Category;

namespace HouseRentingSystem.Data.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<HouseSelectCategoryViewModel>> AllCategoriesAsync();
    }
}
