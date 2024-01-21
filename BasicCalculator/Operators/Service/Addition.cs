using System;
using BasicCalculator.Operators.Interface;

namespace BasicCalculator.Operators.Service
{
    public class Addition : IExecutableOperator
    {
        public uint Weight => 2;

        public decimal CalculateOperator(decimal a, decimal b)
        {
            return a + b;
        }
    }
}

