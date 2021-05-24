using PaymentGateway.Data.Models;
using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Data.Extensions
{
    public static class ProductExtensions
    {
        public static ProductMetaData ToProdMeta(this Product prod)
        {
            return new ProductMetaData
            {
                ProductId = prod.ProductId,
                Name = prod.Name,
                ImageUrl = prod.ImageUrl,
                Amount = prod.Amount,
                MerchantName = prod.Merchant.Name
            };
        }

        public static ProductDetail ToProdDetail(this Product prod)
        {
            return new ProductDetail
            {
                ProductId = prod.ProductId,
                Name = prod.Name,
                Description = prod.Description,
                ImageUrl = prod.ImageUrl,
                Amount = prod.Amount,

                MerchantId = prod.MerchantId,
                MerchantName = prod.Merchant.Name
            };
        }
    }
}
