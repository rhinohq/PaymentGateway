using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class BasketDetail_Mapping : Profile
    {
        public BasketDetail_Mapping()
        {
            CreateMap<BasketDetail, Basket>();
        }
    }
}
