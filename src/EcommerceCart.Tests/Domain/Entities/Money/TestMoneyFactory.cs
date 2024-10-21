using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCart.Domain.Entities;

namespace EcommerceCart.Tests.Domain.Entities
{
    public class TestMoneyFactory
    {
        private static Currency EUR = Currency.GetInstance("EUR");
        private static Currency USD = Currency.GetInstance("USD");

        public static Money Euros(int euros, int cents)
        {
            return Money.Of(EUR, euros, cents);
        }

        public static Money UsDollars(int dollars, int cents)
        {
            return Money.Of(USD, dollars, cents);
        }
    }
}
