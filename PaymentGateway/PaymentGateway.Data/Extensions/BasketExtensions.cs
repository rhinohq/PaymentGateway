using System.Linq;

using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Data.Extensions
{
    public static class BasketExtensions
    {
        public static BasketDetail ToBasketDetail(this Basket basket)
        {
            return new BasketDetail
            {
                BasketId = basket.BasketId,
                Items = basket.Items.Select(x => x.ToBasketItemDetail()).ToList()
            };
        }
    }
}
