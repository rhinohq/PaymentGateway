using System;
using System.Collections.Generic;

namespace PaymentGateway.Data
{
    public class Merchant
    {
        public Guid MerchantId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<Product> Products { get; set; }

        public Merchant()
        {
        }
    }
}
