using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;

using EcommerceCart.Domain.Entities;
using EcommerceCart.Application.Port.Out.Persistence;
using EcommerceCart.Tests.Domain.Entities;
using EcommerceCart.Application.Service;

namespace EcommerceCart.Tests.Application.Service
{
    public class AddToCartServiceTest
    {
        private static readonly CustomerId TEST_CUSTOMER_ID = new CustomerId(Guid.NewGuid());
        private static readonly Product TEST_PRODUCT_1 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(19, 99));
        private static readonly Product TEST_PRODUCT_2 = TestProductFactory.CreateTestProduct(TestMoneyFactory.Euros(25, 99));

        private readonly Mock<ICartRepository> cartRepositoryMock = new Mock<ICartRepository>();
        private readonly Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
        private readonly AddToCartService addToCartService;

        public AddToCartServiceTest()
        {
            addToCartService = new AddToCartService(cartRepositoryMock.Object, productRepositoryMock.Object);
        }

        [Fact]
        void GivenExistingCart_AddToCart_CartWithAddedProductIsSavedAndReturned()
        {
            // Arrange
            var persistedCart = new Cart(TEST_CUSTOMER_ID);
            persistedCart.AddProduct(TEST_PRODUCT_1, 1);

            cartRepositoryMock
                .Setup(repo => repo.FindByCustomerId(TEST_CUSTOMER_ID))
                .Returns(persistedCart);

            productRepositoryMock
                .Setup(repo => repo.FindById(TEST_PRODUCT_1.Id))
                .Returns(TEST_PRODUCT_1);

            productRepositoryMock
                .Setup(repo => repo.FindById(TEST_PRODUCT_2.Id))
                .Returns(TEST_PRODUCT_2);

            // Act
            var cart = addToCartService.AddToCart(TEST_CUSTOMER_ID, TEST_PRODUCT_2.Id, 3);

            // Assert
            cartRepositoryMock.Verify(repo => repo.Save(cart), Times.Once);

            cart.GetLineItems().Should().HaveCount(2);
            cart.GetLineItems()[0].Product.Should().Be(TEST_PRODUCT_1);
            cart.GetLineItems()[0].Quantity.Should().Be(1);
            cart.GetLineItems()[1].Product.Should().Be(TEST_PRODUCT_2);
            cart.GetLineItems()[1].Quantity.Should().Be(3);
        }
    }
}
