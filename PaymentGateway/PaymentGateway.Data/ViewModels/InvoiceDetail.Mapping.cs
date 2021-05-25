using AutoMapper;

using PaymentGateway.Data.Extensions;
using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class InvoiceDetail_Mapping : Profile
    {
        public InvoiceDetail_Mapping()
        {
            CreateMap<Invoice, InvoiceDetail>()
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.GetMaskedCardNumber()));
        }
    }
}