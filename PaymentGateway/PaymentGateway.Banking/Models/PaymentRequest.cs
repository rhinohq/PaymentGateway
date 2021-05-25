namespace PaymentGateway.Banking.Models
{
    public class PaymentRequest
    {
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public int Cvv { get; set; }

        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }

        // ISO 4217
        public string Currency { get; set; }
        public decimal AmountToCharge { get; set; }

        public PaymentRequest()
        {
        }
    }
}
