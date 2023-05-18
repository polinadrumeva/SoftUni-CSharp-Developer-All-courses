using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ExportProductInRangeDto, Product>();

            this.CreateMap<User, ExportUserDTO>();
            this.CreateMap<Product, ExportProductDTO>();
        }
    }
}
