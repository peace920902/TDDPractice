using Xunit;

namespace DollarsTest;

public class DollarTest
{
    [Fact]
    public void TestMultiplication()
    {
        var dollar = new Dollar(5);
        Assert.Equal(new Dollar(10) , dollar.Times(2));
        Assert.Equal(new Dollar(15), dollar.Times(3));
    }

    [Fact]
    public void TestMultiplication_Franc()
    {
        var dollar = new Franc(5);
        Assert.Equal(new Franc(10) , dollar.Times(2));
        Assert.Equal(new Franc(15), dollar.Times(3));
    }
    
    [Fact]
    public void TestEquality()
    {
        Assert.True(new Dollar(5).Equals(new Dollar(5)));
        Assert.False(new Dollar(5).Equals(new Dollar(6)));
        Assert.True(new Franc(5).Equals(new Franc(5)));
        Assert.False(new Franc(5).Equals(new Franc(6)));
    }
}

public class Money
{ 
    protected internal int Amount { get; set; }
    
    public override bool Equals(object? obj)
    {
        var money = (Money)obj;
        return this.Amount == money.Amount;
    }
}

/// <summary>
/// 法郎
/// </summary>
public class Franc: Money
{
    public Franc(int amount)
    {
        Amount = amount;
    }

    public Franc Times(int multiplier)
    {
        var total = Amount * multiplier;
        return new Franc(total);
    }
    
    public override bool Equals(object? obj)
    {
        Money money = (Franc)obj;
        return this.Amount == money.Amount;
    }
}

/// <summary>
/// 美元
/// </summary>
public class Dollar: Money
{
    public Dollar(int amount)
    {
        Amount = amount;
    }

    public Dollar Times(int multiplier)
    {
        var total = Amount * multiplier;
        return new Dollar(total);
    }
}