using System;
using BasicCalculator.Operators.Helper;
using BasicCalculator.Operators.Service;
using BasicCalculator.Service;

namespace BasicCalculator.Test
{
	public class SampleTestExample
	{
        [Fact]
        public void Test1()
        {
            Calculator c1 = new Calculator();
            var result = c1.Invoke("2+45");
            Assert.Equal(45, result);
             result = c1.Invoke("=");
            Assert.Equal(47, result);
             result = c1.Invoke("X3=");
            Assert.Equal(141, result);
            result = c1.Invoke("-8+12=");
            Assert.Equal(145, result);
            result = c1.Invoke("c");
            Assert.Equal(0, result);


        }
    }
}

