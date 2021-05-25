using System;
namespace PaymentGateway.Data.ViewModels
{
    public class BankResponseDetail
    {
        public Guid PaymentId { get; set; }
        public int StatusCode { get; set; }

        public BankResponseDetail()
        {
        }
    }
}
