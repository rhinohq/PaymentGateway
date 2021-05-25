using PaymentGateway.Banking.Models;
using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Server.Extensions
{
    public static class CheckoutFormExtensions
    {
        public static PaymentRequest ToPaymentRequest(this CheckoutForm form, decimal amount)
        {
            return new PaymentRequest
            {
                NameOnCard = form.NameOnCard,
                CardNumber = form.CardNumber,
                Cvv = form.Cvv,

                ExpiryMonth = form.ExpiryMonth,
                ExpiryYear = form.ExpiryYear,

                Currency = "GBP",
                AmountToCharge = amount
            };
        }
    }
}
