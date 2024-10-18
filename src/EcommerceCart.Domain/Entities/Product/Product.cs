using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EcommerceCart.Domain.Entities
{
    public class Product
    {
        public ProductId Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Money Price { get; }
        public int ItemsInStock { get; }

        public Product(ProductId id, string name, string description, Money price, int itemsInStock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            if (price.Amount < 0) throw new ArgumentOutOfRangeException(nameof(price.Amount));

            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ItemsInStock = itemsInStock;
        }
    }
}
