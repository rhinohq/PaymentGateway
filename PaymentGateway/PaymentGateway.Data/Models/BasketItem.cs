using System;

namespace PaymentGateway.Data.Models
{
    public class BasketItem
    {
        public Guid BasketItemId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public decimal TotalCost => Product != null ? Product.Amount * Quantity : 0;

        public BasketItem()
        {
            BasketItemId = Guid.NewGuid();
        }

        public BasketItem(Product prod)
        {
            BasketItemId = Guid.NewGuid();
            Quantity = 1;
            Product = prod;
        }
    }
}
