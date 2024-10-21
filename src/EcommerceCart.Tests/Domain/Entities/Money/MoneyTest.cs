using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class MoneyTest
    {
        private static readonly Currency EUR = Currency.GetInstance("EUR");

        [Fact]
        void GivenAmountWithAnInvalidScale_NewMoney_ThrowsIlegalArgumentException()
        {
            // Arrange
            decimal amountWithScale3 = 123.463m;

            // Act
            var act = () => new Money(EUR, amountWithScale3);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        void GivenAEuroAmount_AddDollarAmount_ThrowsIllegalArgumentException()
        {
            // Arrange
            Money euros = TestMoneyFactory.Euros(11, 99);
            Money dollars = TestMoneyFactory.UsDollars(11, 99);

            // Act
            var exception = () => euros.Add(dollars);

            // Assert
            Assert.Throws<ArgumentException>(exception);

        }
    }
}
