using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class CartTest
    {
        [Fact]
        void GivenEmptyCart_AddTwoProducts_ProductsAreInCart()
        {
            // Arrange
            Cart cart = TestCartFactory.EmptyCartForRandomCustomer();

            Product product1 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(12, 99));
            Product product2  = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(5, 97));

            // Act
            cart.AddProduct(product1, 3);
            cart.AddProduct(product2, 5);

            // Assert
            Assert.Equal(2, cart.GetLineItems().Count());
            Assert.Equal(product1, cart.GetLineItems()[0].Product);
            Assert.Equal(3, cart.GetLineItems()[0].Quantity);
            Assert.Equal(product2, cart.GetLineItems()[1].Product);
            Assert.Equal(5, cart.GetLineItems()[1].Quantity);
        }

        [Fact]
        void GivenEmptyCart_AddTwoProducts_NumberOfItemsAndSubTotalIsCalculatedCorrectly()
        {
            // Arrange
            Cart cart = TestCartFactory.EmptyCartForRandomCustomer();

            Product product1 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(12, 99));
            Product product2 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(5, 97));

            // Act
            cart.AddProduct(product1, 3);
            cart.AddProduct(product2, 5);

            // Assert
            Assert.Equal(8, cart.NumberOfItems());
            Assert.Equal(TestMoneyFactory.Euros(68,82), cart.SubTotal());
        }

        [Fact]
        void GivenAProductWithAFewItemsAvailable_AddMoreItemsThanAvailableToTheCart_ThrowsException()
        {
            // Arrange
            Cart cart = TestCartFactory.EmptyCartForRandomCustomer();
            Product product = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(12, 25), 3);

            // Act
            Action act = () => cart.AddProduct(product, 4);

            // Assert
            var exception = Assert.Throws<NotEnoughItemsInStockException>(act);

            Assert.Equal(product.ItemsInStock, exception.ItemsInStock);
        }

        [Fact]
        void givenAProductWithAFewItemsAvailable_addAllAvailableItemsToTheCart_succeeds()
        {
            // Arrange
            Cart cart = TestCartFactory.EmptyCartForRandomCustomer();
            Product product = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(15, 23), 4);

            // Act
            var exception = Record.Exception(() => cart.AddProduct(product, 4));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        void givenEmptyCart_addLessThanOneItemOfAProduct_throwsException(int value)
        {
            // Arrange
            Cart cart = TestCartFactory.EmptyCartForRandomCustomer();
            Product product = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(12, 3));

            // Act
            var act = ()  => cart.AddProduct(product, value);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

    }
}
