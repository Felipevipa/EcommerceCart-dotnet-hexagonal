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
    public class FindProductsService : IFindProducts
    {
        private readonly IProductRepository _productRepository;

        public FindProductsService(IProductRepository productRepository)
        {
            if (productRepository == null)
                throw new ArgumentNullException(nameof(productRepository));
            _productRepository = productRepository;
        }

        public List<Product> FindByNameOrDescription(string query)
        {
            ArgumentNullException.ThrowIfNull(query, "'query' must no be null");
            if(query.Length < 2)
            {
                throw new ArgumentException("'query' must be at least two characters long");
            }

            return _productRepository.FindByNameOrDescription(query);
        }
    }
}
