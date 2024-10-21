using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Application.Port.Out.Persistence
{
    public interface IProductRepository
    {
        void Save(Product product);
        Product? FindById(ProductId productId);
        List<Product> FindByNameOrDescription(string query);
    }
}
