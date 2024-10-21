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
    public class GetCartService : IGetCart
    {
        private readonly ICartRepository _cartRepository;

        public GetCartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCart(CustomerId customerId)
        {
            ArgumentNullException.ThrowIfNull(customerId, "'customerId' must no be null");
            return _cartRepository
                .FindByCustomerId(customerId)
                 ?? new Cart(customerId);
        }
    }
}
