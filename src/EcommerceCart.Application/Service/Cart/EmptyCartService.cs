using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceCart.Application.Port.In;
using EcommerceCart.Application.Port.Out.Persistence;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Application.Service
{
    public class EmptyCartService : IEmptyCart
    {
        private readonly ICartRepository _cartRepository;

        public EmptyCartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void EmptyCart(CustomerId customerId)
        {
            ArgumentNullException.ThrowIfNull(customerId, "'customerId' must no be null");

            _cartRepository.DeleteById(customerId);
        }
    }
}
