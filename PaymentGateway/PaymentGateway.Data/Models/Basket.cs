using System;
using System.Collections.Generic;

namespace PaymentGateway.Data
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        public string OwnedByUser { get; set; }

        public List<Product> Products { get; set; }

        public int Size => Products != null ? Products.Count : 0;

        public Basket()
        {
            BasketId = Guid.NewGuid();
        }
    }
}
