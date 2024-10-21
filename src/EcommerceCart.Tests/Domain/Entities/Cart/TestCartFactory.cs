using EcommerceCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class TestCartFactory
    {
        public static Cart EmptyCartForRandomCustomer()
        {
            return new Cart(new CustomerId(Guid.NewGuid()));
        }
    }
}
