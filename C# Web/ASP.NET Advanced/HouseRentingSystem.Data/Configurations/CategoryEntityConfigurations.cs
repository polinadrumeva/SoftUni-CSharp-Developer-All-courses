using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.Configurations
{
	public class CategoryEntityConfigurations : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(GenerateCategory());
		}

		private Category[] GenerateCategory()
		{ 
			var categories = new HashSet<Category>();

			Category category;
			category = new Category()
			{
				Id = 1,
				Name = "Cottage"
			};

			categories.Add(category);

			category = new Category()
			{
				Id = 2,
				Name = "Single-Family"
			};

			categories.Add(category);

			category = new Category()
			{
				Id = 3,
				Name = "Duplex"
			};

			categories.Add(category);
			return categories.ToArray();
		}
	}
}
