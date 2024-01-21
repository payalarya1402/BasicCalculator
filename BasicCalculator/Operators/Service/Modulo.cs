using System;
using BasicCalculator.Operators.Interface;

namespace BasicCalculator.Operators.Service
{
	public class Modulo : IExecutableOperator
    {
        public uint Weight => 3;

        public decimal CalculateOperator(decimal a, decimal b)
        {
            return a % b;
        }
    }
}

