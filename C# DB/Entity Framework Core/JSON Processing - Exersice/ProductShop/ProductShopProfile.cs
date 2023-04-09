using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            this.CreateMap<UserDTO, User>();
            this.CreateMap<ProductDTO, Product>();
            this.CreateMap<CategoriesDTO, Category>();
            this.CreateMap<CategoryProductDTO, CategoryProduct>();
        }
    }
}
