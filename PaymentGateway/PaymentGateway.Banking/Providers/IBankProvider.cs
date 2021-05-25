using PaymentGateway.Banking.Models;

namespace PaymentGateway.Banking.Providers
{
    public interface IBankProvider
    {
        PaymentResponse ProcessPayment(PaymentRequest request);
    }
}
