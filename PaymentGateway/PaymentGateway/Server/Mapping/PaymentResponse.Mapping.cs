using AutoMapper;

using PaymentGateway.Banking.Models;
using PaymentGateway.Data.Models;

namespace PaymentGateway.Server.Mapping
{
    public class PaymentResponse_Mapping : Profile
    {
        public PaymentResponse_Mapping()
        {
            CreateMap<PaymentResponse, BankResponse>();
        }
    }
}
