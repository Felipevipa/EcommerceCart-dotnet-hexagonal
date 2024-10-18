using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.Domain.Entities
{
    public record ProductId
    {
        private static readonly string ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
        private static readonly int LENGTH_OF_NEW_PRODUCT_IDS = 8;

        public ProductId(Guid value)
        {
            //ArgumentNullException.ThrowIfNullOrEmpty(value, "'value' must not be null or empty");
            Value = value;
        }

        public static ProductId RandomProductId()
        {
            return new ProductId(Guid.NewGuid());
        }

        public Guid Value { get; }
    }
}
