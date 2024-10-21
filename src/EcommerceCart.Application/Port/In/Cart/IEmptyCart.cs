using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Application.Port.In
{
    public interface IEmptyCart
    {
        void EmptyCart(CustomerId customerId);
    }
}
