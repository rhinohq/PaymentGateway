using System.Text.RegularExpressions;

using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.Extensions
{
    public static class InvoiceExtensions
    {
        public static string GetMaskedCardNumber(this Invoice invoice)
        {
            string cardNum = invoice.CardNumber;
            var reg = new Regex(@"(?<=\d{4}\d{2})\d{2}\d{4}(?=\d{4})|(?<=\d{4}( |-)\d{2})\d{2}\1\d{4}(?=\1\d{4})");
            var masked = reg.Replace(cardNum, new MatchEvaluator((m) => new string('*', m.Length)));

            return masked;
        }
    }
}
