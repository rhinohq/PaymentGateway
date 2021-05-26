using System;
using PaymentGateway.Banking.Models;

namespace PaymentGateway.Banking.Providers
{
    public class MockBankProvider : IBankProvider
    {
        public MockBankProvider()
        {
        }

        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            Random rnd = new Random();
            int statusCode = rnd.Next(100); // statusCode >= 50 is successful payment

            return new PaymentResponse
            {
                PaymentId = Guid.NewGuid(),
                StatusCode = statusCode
            };
        }
    }
}
