using System.Collections.Generic;
using Xunit;

namespace DollarsTest;

public class DollarTest
{
    [Fact]
    public void TestEquality()
    {
        Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
        Assert.True(Money.Franc(10).Equals(Money.Franc(5).Times(2)));
    }
}

public class Money
{ 
    protected internal int Amount { get; set; }
    protected internal string Currency { get; set; }

    public Money(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    internal static Money Dollar(int amount)
    {
        return new Money(amount,"USD");
    }

    internal static Money Franc(int amount)
    {
        return new Money(amount,"CHT");
    }

    public override bool Equals(object? obj)
    {
        var money = (Money?)obj;
        return this.Amount == money?.Amount
                           && Currency.Equals(money.Currency);
    }

    public Money Times(int multiplier)
    {
        var total = Amount * multiplier;
        return new Money(total, Currency);
    }

    //public string GetCurrency()
    //{
    //    return Currency;
    //}
}