using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDTO, Supplier>();
            this.CreateMap<PartDto, Part>();
            this.CreateMap<CarsDTO, Car>();

        }
    }
}
