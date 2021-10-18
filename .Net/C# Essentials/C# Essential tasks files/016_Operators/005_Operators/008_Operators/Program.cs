using System;
using System.Text;

namespace _008_Operators
{
    enum Currency
    {
        USD,
        EUR,
        UAH,
        RUB
    }

    class Money
    {
        public int Dollars { get; }
        public int Cents { get; }
        public Currency Currency { get; }

        public Money(int dollars, int cents, Currency currency)
        {
            Dollars = IsValidDollarsValue(dollars)
                ? dollars
                : throw new ArgumentException("Invalid value", nameof(dollars));
            Cents = IsValidCentsValue(cents)
                ? cents
                : throw new ArgumentException("Invalid value", nameof(cents)); ;
            Currency = currency;
        }

        public override string ToString()
        {
            var currencySign = Currency switch
            {
                Currency.USD => "$",
                Currency.EUR => "€",
                Currency.UAH => "₴",
                Currency.RUB => "₽",
                _ => Currency.ToString()
            };
            return $"{currencySign}{Dollars}.{Cents}";
        }

        public override bool Equals(object obj)
        {
            return obj is Money other
                ? other.Dollars == this.Dollars
                    && other.Cents == this.Cents
                    && other.Currency == this.Currency
                : false;
        }

        public override int GetHashCode()
        {
            return 7 * Currency.GetHashCode() ^ 13 * Dollars ^ 17 * Cents;
        }

        public static bool operator ==(Money left, Money right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !left.Equals(right);
        }

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency == right.Currency)
            {
                var dollars = left.Dollars + right.Dollars;
                var cents = left.Cents + right.Cents;
                if (cents > 100)
                {
                    cents -= 100;
                    dollars++;
                }
                return new Money(dollars, cents, left.Currency);
            }
            else 
            {
                throw new InvalidOperationException("Cannot add money of different currency");
            }
        }

        public static Money UAH(int dollars, int cents)
            => new Money(dollars, cents, Currency.UAH);

        public static Money USD(int dollars, int cents)
            => new Money(dollars, cents, Currency.USD);

        public static Money EUR(int dollars, int cents)
            => new Money(dollars, cents, Currency.EUR);

        public static Money RUB(int dollars, int cents)
        => new Money(dollars, cents, Currency.RUB);

        private bool IsValidCentsValue(int cents)
        {
            return cents > 0 || cents < 100;
        }

        private bool IsValidDollarsValue(int dollars)
        {
            return dollars > 0 && dollars < 1_000_000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var m1 = Money.USD(20, 15);
            var m2 = Money.RUB(100, 20);
            var m3 = Money.UAH(100, 00);

            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);

            m1 += Money.USD(2300, 99);
            Console.WriteLine(m1);

            m2 += m1;
        }
    }
}
