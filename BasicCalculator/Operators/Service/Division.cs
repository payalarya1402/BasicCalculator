using System;
using BasicCalculator.Operators.Interface;

namespace BasicCalculator.Operators.Service
{
    public class Division : IExecutableOperator
    {
        public uint Weight => 3;

        public decimal CalculateOperator(decimal a, decimal b)
        {
            if (b == 0) throw new FormatException("Attempted to divide by zero.");
            return a / b;
        }
    }
}

