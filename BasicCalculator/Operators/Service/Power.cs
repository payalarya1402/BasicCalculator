using System;
using BasicCalculator.Operators.Interface;

namespace BasicCalculator.Operators.Service
{
	public class Power : IExecutableOperator
    {
        public uint Weight => 4;

        public decimal CalculateOperator(decimal a, decimal b)
        {
            return (decimal)Math.Pow((double)a, (double)b);
        }
    }
}

