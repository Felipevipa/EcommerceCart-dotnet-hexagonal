using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class CustomerIdTest
    {
        [Fact]
        void GivenAGuidValue_NewCustomerId_Succeds()
        {
            // Arrange
            Guid idForNewCustomer = Guid.NewGuid();

            // Act
            var exception = Record.Exception(() => new CustomerId(idForNewCustomer));

            // Assert
            Assert.Null(exception);
        }
    }
}
