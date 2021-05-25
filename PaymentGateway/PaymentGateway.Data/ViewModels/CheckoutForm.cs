using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Data.ViewModels
{
    public class CheckoutForm
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        [Range(minimum: 100, maximum: 999)]
        public int Cvv { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 11)]
        public int ExpiryMonth { get; set; }

        [Required]
        public int ExpiryYear { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Guid BasketId { get; set; }

        public CheckoutForm()
        {
        }

        public CheckoutForm(Guid basketId)
        {
            BasketId = basketId;
        }
    }
}
