using BasicCalculator.Operators.Helper;
using BasicCalculator.Operators.Service;
using BasicCalculator.Service;

namespace BasicCalculator.Test;

public class BasicMathTests
{
  

    [Fact]
    public void Add4And3Return7()
    {
        Calculator c1 = new Calculator(); 
        var result = c1.Invoke("3+4=");
        Assert.Equal(7, result);
    }
    [Fact]
    public void Subtract100And8Return92()
    {
        Calculator c1 = new Calculator();
        var result = c1.Invoke("100-8=");
        Assert.Equal(92, result);
    }
    [Fact]
    public void Multiply8And2Point5Return20()
    {
        Calculator c1 = new Calculator();
        var result = c1.Invoke("8X2.5=");
        Assert.Equal(20, result);
    }
    [Fact]
    public void Divide5By2Return2Point5()
    {
        Calculator c1 = new Calculator();
        var result = c1.Invoke("5/2=");
        Assert.Equal((decimal)2.5, result);
    }
    [Fact]
    public void Power2And10Return1024()
    {
        Calculator c1 = new Calculator();
        var result = c1.Invoke("2^10=");
        Assert.Equal(1024, result);
    }
    [Fact]
    public void Mod3And2Return1()
    {
        Calculator c1 = new Calculator();
        var result = c1.Invoke("3%2=");
        Assert.Equal(1, result);
    }

}
