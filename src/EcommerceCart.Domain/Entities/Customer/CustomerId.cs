using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EcommerceCart.Domain.Entities
{
    public record CustomerId
    {
        public CustomerId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get;  }
    }
}
