using System;
namespace PaymentGateway.Data.ViewModels
{
    public class InvoiceMeta
    {
        public Guid InvoiceId { get; set; }

        public DateTime InvoiceTime { get; set; }
        public int BankStatusCode { get; set; }
        public decimal OrderCost { get; set; }

        public InvoiceMeta()
        {
        }
    }
}
