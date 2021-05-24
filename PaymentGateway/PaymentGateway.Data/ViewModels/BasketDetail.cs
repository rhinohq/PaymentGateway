using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Data.ViewModels
{
    public class BasketDetail
    {
        public Guid BasketId { get; set; }

        public List<BasketItemDetail> Items { get; set; }

        public int Size => Items != null ? Items.Sum(x => x.Quantity) : 0;
        public decimal TotalCost => Items != null ? Items.Sum(x => x.TotalCost) : 0;

        public BasketDetail()
        {
        }
    }
}
