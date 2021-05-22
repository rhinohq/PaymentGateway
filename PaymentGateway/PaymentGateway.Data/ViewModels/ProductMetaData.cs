using System;
namespace PaymentGateway.Data.ViewModels
{
    public class ProductMetaData
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Amount { get; set; }
        public string MerchantName { get; set; }

        public ProductMetaData()
        {
        }
    }
}
