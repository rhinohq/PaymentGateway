using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Data.Models
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        public string OwnedByUser { get; set; }
        public bool Fufilled { get; set; }

        public List<BasketItem> Items { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int Size => Items != null ? Items.Sum(x => x.Quantity) : 0;
        public decimal TotalCost => Items != null ? Items.Sum(x => x.TotalCost) : 0;

        public Basket()
        {
            BasketId = Guid.NewGuid();
        }
    }
}
