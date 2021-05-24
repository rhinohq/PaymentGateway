using System;
using AutoMapper;
using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class BasketItemDetail_Mapping : Profile
    {
        public BasketItemDetail_Mapping()
        {
            CreateMap<BasketItemDetail, BasketItem>();
        }
    }
}
