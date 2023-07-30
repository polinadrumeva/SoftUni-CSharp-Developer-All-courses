using AutoMapper;
using Invoices.Data.Models;
using Invoices.DataProcessor.ExportDto;

namespace Invoices
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Invoice, ExportClientInvoicesDto>()
                .ForMember(dest => dest.Number, opt =>
                    opt.MapFrom(s => s.Number))
                .ForMember(dest => dest.DueDate, opt =>
                    opt.MapFrom(s => s.DueDate))
                .ForMember(dest => dest.Amount, opt =>
                    opt.MapFrom(s => s.Amount))
                .ForMember(dest => dest.CurrencyType, opt =>
                    opt.MapFrom(s => s.CurrencyType));

            CreateMap<Client, ExportClientDto>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.NumberVat, opt =>
                    opt.MapFrom(s => s.NumberVat))
                .ForMember(dest => dest.InvoicesCount, opt =>
                    opt.MapFrom(s => s.Invoices.Count))
                .ForMember(dest => dest.Invoices, opt =>
                    opt.MapFrom(s => s.Invoices
                                        .ToArray()));
        }
    }
}
