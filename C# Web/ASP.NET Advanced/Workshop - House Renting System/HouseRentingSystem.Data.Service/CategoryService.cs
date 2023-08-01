
using HouseRentingSystem.Data.Service.Interfaces;
using HouseRentingSystem.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HouseRentingDbContext dbContext;

        public CategoryService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<HouseSelectCategoryViewModel>> AllCategoriesAsync()
        {
            var allCategories = await this.dbContext
                .Categories
                .Select(c => new HouseSelectCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return allCategories;
        }
    }
}
