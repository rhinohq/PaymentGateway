using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class BasketItemDetail_Mapping : Profile
    {
        public BasketItemDetail_Mapping()
        {
            CreateMap<BasketItem, BasketItemDetail>();
            CreateMap<BasketItemDetail, BasketItem>();
        }
    }
}
