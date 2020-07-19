using System;
using System.Collections.Generic;

namespace CodeCheater.Domain.Models.Baskets
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public BasketCart() { }

        public BasketCart(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public List<BasketCartEntry> BasketOrders { get; set; } = new List<BasketCartEntry>();
        public decimal GrandAmount
        {
            get
            {
                decimal totalAmount = 0;
                foreach (var entry in BasketOrders)
                {
                    totalAmount += entry.Price;
                }
                return totalAmount;

            }
        }
    }
}
