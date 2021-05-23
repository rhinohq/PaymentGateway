using System;
namespace PaymentGateway.Data.ViewModels
{
    public class BasketItemDetail
    {
        public Guid BasketItemId { get; set; }

        public int Quantity { get; set; }

        public ProductMetaData Product { get; set; }

        public BasketItemDetail()
        {
        }
    }
}
