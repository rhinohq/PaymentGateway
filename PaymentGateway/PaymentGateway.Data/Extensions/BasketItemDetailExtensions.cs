using PaymentGateway.Data.Models;
using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Data.Extensions
{
    public static class BasketItemDetailExtensions
    {
        public static BasketItem ToBasketItem(this BasketItemDetail basketItemDetail, Product prod)
        {
            return new BasketItem
            {
                BasketItemId = basketItemDetail.BasketItemId,
                Quantity = basketItemDetail.Quantity,
                Product = prod
            };
        }
    }
}
