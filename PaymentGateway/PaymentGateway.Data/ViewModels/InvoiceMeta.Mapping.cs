using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class InvoiceMeta_Mapping : Profile
    {
        public InvoiceMeta_Mapping()
        {
            CreateMap<Invoice, InvoiceMeta>()
                .ForMember(dest => dest.BankStatusCode, opt => opt.MapFrom(src => src.BankResponse.StatusCode))
                .ForMember(dest => dest.OrderCost, opt => opt.MapFrom(src => src.Basket.TotalCost));
        }
    }
}
