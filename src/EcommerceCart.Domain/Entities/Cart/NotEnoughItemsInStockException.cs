using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.Domain.Entities
{
    public class NotEnoughItemsInStockException : Exception
    {
        private int ItemsInStock { get; init; }

        public NotEnoughItemsInStockException(string message, int itemsInStock) : base(message)
        {
            ItemsInStock = itemsInStock;
        }
    }
}
