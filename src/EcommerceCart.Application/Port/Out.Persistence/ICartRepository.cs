using EcommerceCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.Application.Port.Out.Persistence
{
    public interface ICartRepository
    {
        void Save(Cart cart);

        Cart? FindByCustomerId(CustomerId customerId);

        void DeleteById(CustomerId customerId);
    }
}
