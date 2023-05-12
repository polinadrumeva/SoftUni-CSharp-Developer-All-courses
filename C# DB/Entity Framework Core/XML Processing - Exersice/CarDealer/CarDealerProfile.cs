using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDTO, Supplier>();

            this.CreateMap<Car, ExportCarDTO>();
            this.CreateMap<Car, ExportBMWCarsDTO>();
            this.CreateMap<Supplier, ExportSupplierDTO>()
                .ForMember(dest => dest.PartsCount, opt => opt.MapFrom(src => src.Parts.Count));

            this.CreateMap<Part, ExportCarPartDTO>();
            this.CreateMap<Car, ExportCarWithPartsDTO>()
                .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars.Select(pc => pc.Part)
                .OrderByDescending(p => p.Price)
                .ToArray()));

           
            this.CreateMap<Customer, ExportCustomerDTO>()
                .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Sales.Count));
        }
    }
}
