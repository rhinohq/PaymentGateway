using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class Product_Mapping : Profile
    {
        public Product_Mapping()
        {
            CreateMap<Product, ProductDetail>();
        }
    }
}
