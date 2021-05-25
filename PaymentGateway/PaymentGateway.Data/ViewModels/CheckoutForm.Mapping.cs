using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class CheckoutForm_Mapping : Profile
    {
        public CheckoutForm_Mapping()
        {
            CreateMap<CheckoutForm, Invoice>();
        }
    }
}
