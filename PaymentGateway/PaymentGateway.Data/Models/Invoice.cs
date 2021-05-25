using System;
namespace PaymentGateway.Data.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }

        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public int Cvv { get; set; }

        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Guid BankResponseId { get; set; }
        public BankResponse BankResponse { get; set; }

        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }

        public Invoice()
        {
            InvoiceId = Guid.NewGuid();
        }
    }
}
