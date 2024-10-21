using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceCart.Application.Port.In;
using EcommerceCart.Application.Port.Out.Persistence;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Application.Service
{
    public class AddToCartService : IAddToCart
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartService(
            ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public Cart AddToCart(CustomerId customerId, ProductId productId, int quantity)
        {
            ArgumentNullException.ThrowIfNull(customerId, "'customerId' must no be null");
            ArgumentNullException.ThrowIfNull(productId, "'productId' must no be null");
            if(quantity < 1)
            {
                throw new ArgumentException("'quantity' must be greater than 0");
            }

            Product product = _productRepository.FindById(productId) ?? throw new ProductNotFoundException();

            Cart cart = _cartRepository.FindByCustomerId(customerId) ?? new Cart(customerId);

            cart.AddProduct(product, quantity);

            _cartRepository.Save(cart);

            return cart;

        }

    }
}
