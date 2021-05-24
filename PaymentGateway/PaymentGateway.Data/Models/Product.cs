using System;

namespace PaymentGateway.Data.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Amount { get; set; }

        public Guid MerchantId { get; set; }
        public Merchant Merchant { get; set; }

        public Product()
        {
        }
    }
}
