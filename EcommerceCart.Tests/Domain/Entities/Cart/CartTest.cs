using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCart.Domain.Entities;
using EcommerceCart.Tests.Domain.Entities;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class CartTest
    {
        [Fact]
        void GivenEmptyCart_AddTwoProducts_NumberOfItemsAndSubTotalIsCalculatedCorrectly()
        {
            Cart cart = TestCartFactory.EmptyCartForRandomCustomer();

            Product product1 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(12, 99));
            Product product2 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(5, 97));

            cart.AddProduct(product1, 3);
            cart.AddProduct(product2, 5);

            Assert.Equal(8, cart.NumberOfItems());
            Assert.Equal(TestMoneyFactory.Euros(68,82), cart.SubTotal());
        }
    }
}
