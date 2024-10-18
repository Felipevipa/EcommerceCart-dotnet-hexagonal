using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.Domain.Entities
{
    public class Cart(CustomerId id)
    {
        public CustomerId Id { get; init; } = id;

        private readonly Dictionary<ProductId, CartLineItem> LineItems = new Dictionary<ProductId, CartLineItem>();

        public void AddProduct(Product product, int quantity)
        {
            if (!LineItems.TryGetValue(product.Id, out CartLineItem? cartLineItem))
            {
                cartLineItem = new CartLineItem(product, 0);
                LineItems[product.Id] = cartLineItem;
            }
            cartLineItem.increaseQuantityBy(quantity, product.ItemsInStock);
        }

        public List<CartLineItem> GetLineItems()
        {
            return [.. LineItems.Values];
        }

        public int NumberOfItems()
        {
            return LineItems.Values
                .Select(cartLineItem => cartLineItem.Quantity)
                .Sum();
        }

        public Money? SubTotal()
        {
            return LineItems.Values
                    .Select(cartLineItem => cartLineItem.SubTotal())
                    .Aggregate((Money?)null, (total, subTotal) => total == null ? subTotal : total.Add(subTotal)); 
        }
    }
}

