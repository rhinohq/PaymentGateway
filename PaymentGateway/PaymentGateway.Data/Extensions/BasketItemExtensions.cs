using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Data.Extensions
{
    public static class BasketItemExtensions
    {
        public static BasketItemDetail ToBasketItemDetail(this BasketItem basketItem)
        {
            return new BasketItemDetail
            {
                BasketItemId = basketItem.BasketItemId,
                Quantity = basketItem.Quantity,
                Product = basketItem.Product.ToProdMeta()
            };
        }
    }
}
