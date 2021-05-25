using System;
namespace PaymentGateway.Banking.Models
{
    public class PaymentResponse
    {
        public Guid PaymentId { get; set; }
        public int StatusCode { get; set; }

        public PaymentResponse()
        {
        }
    }
}
