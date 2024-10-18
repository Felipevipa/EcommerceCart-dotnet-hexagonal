using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EcommerceCart.Domain.Entities
{
    public class CartLineItem
    {
        private Product Product { get; }
        public int Quantity { get; private set; }

        public CartLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void increaseQuantityBy(int augend, int itemsInStock)
        {
            if(augend < 1)
            {
                throw new ArgumentException("You must add at least one item.");
            }

            int newQuantity = Quantity + augend;
            if (itemsInStock < newQuantity)
            {
                throw new NotEnoughItemsInStockException(String.Format("Product {0} has less items in stock {1} "
                  + "than the requested total quantity {2}", Product.Id, Product.ItemsInStock, newQuantity), 
                  Product.ItemsInStock);
            }

            Quantity = newQuantity;
        }

        public Money SubTotal()
        {
            return Product.Price.Multiply(Quantity);
        }
    }
}
