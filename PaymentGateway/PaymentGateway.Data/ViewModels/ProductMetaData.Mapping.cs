using AutoMapper;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.ViewModels
{
    public class ProductMetaData_Mapping : Profile
    {
        public ProductMetaData_Mapping()
        {
            CreateMap<ProductMetaData, Product>();
            CreateMap<Product, ProductMetaData>();
        }
    }
}
