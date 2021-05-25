using System;
using PaymentGateway.Banking.Models;

namespace PaymentGateway.Banking.Providers
{
    public class BankProvider : IBankProvider
    {
        public BankProvider()
        {
        }

        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            return new PaymentResponse
            {
                PaymentId = Guid.NewGuid(),
                StatusCode = 50
            };
        }
    }
}
