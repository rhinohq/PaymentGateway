using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class BankResponseDetail_Mapping : Profile
    {
        public BankResponseDetail_Mapping()
        {
            CreateMap<BankResponse, BankResponseDetail>();
        }
    }
}
