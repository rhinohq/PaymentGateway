using System;
namespace PaymentGateway.Data.Models
{
    public class BankResponse
    {
        public Guid BankResponseId { get; set; }

        public Guid PaymentId { get; set; }
        public int StatusCode { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public BankResponse()
        {
            BankResponseId = Guid.NewGuid();
        }
    }
}
