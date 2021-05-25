using System;
namespace PaymentGateway.Data.ViewModels
{
    public class InvoiceDetail
    {
        public Guid InvoiceId { get; set; }

        public DateTime InvoiceTime { get; set; }

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

        public BankResponseDetail BankResponse { get; set; }
        public BasketDetail Basket { get; set; }

        public InvoiceDetail()
        {
        }
    }
}
