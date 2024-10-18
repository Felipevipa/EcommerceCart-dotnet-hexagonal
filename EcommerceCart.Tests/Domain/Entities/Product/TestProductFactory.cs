using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class TestProductFactory
    {
        private static readonly int ENOUGH_ITEMS_IN_STOCK = int.MaxValue;

        public static Product CreateTestProduct(Money price)
        {
            return CreateTestProduct(price, ENOUGH_ITEMS_IN_STOCK);
        }

        public static Product CreateTestProduct(Money price, int itemsInStock)
        {
            return new Product(
                ProductId.RandomProductId(),
                "Any Name",
                "Any Description",
                price,
                itemsInStock);
        }

    }
}
