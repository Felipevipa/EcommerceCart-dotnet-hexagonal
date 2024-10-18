using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.Domain.Entities
{
    public record Money
    {

        public Currency Currency { get; }
        public decimal Amount { get; }
        public Money(Currency currency, decimal amount)
        {
            ArgumentNullException.ThrowIfNull(currency, "'currency' must not be null");
            ArgumentNullException.ThrowIfNull(amount, "'amount' must not be null");
            if(amount.Scale > currency.getDefaultFractionDigits())
            {
                throw new ArgumentException(String.Format("Scale of amount {0} is greater "
                  + "than the number of fraction digits used with currency {1}", amount, currency));
            }
            Currency = currency;
            Amount = amount;
        }

        public static Money Of(Currency currency, int mayor, int minor)
        {
            int scale = currency.getDefaultFractionDigits();
            decimal amount = mayor + minor / (decimal)Math.Pow(10, scale);
            return new Money(currency, amount);
        }

        public Money Add(Money augend)
        {
            if (this.Currency != augend.Currency)
            {
                throw new ArgumentException(String.Format("Currency {0}  of augend does not match this money's"
                  + "currency {1}", augend.Currency, this,Currency));
            }

            return new Money(Currency, decimal.Add(Amount, augend.Amount));
        }

        public Money Multiply(int multiplicand)
        {
            return new Money(Currency, decimal.Multiply(Amount, multiplicand));
        }
    }

    public class Currency
    {
        private string CurrencyType;
        public Currency(string currencyType)
        {
            CurrencyType = currencyType;
        }

        public int getDefaultFractionDigits()
        {
            return (2);
        }

        public static Currency GetInstance(string currencyType)
        {
            return new Currency(currencyType);
        }
    }
}
